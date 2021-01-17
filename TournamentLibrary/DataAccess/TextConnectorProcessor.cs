using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentLibrary.Models;

namespace TournamentLibrary.DataAccess.TextHelpers
{
	public static class TextConnectorProcessor
	{
		/// <summary>
		/// Gives the full file path.
		/// </summary>
		/// <param name="fileName"></param>
		/// <returns>
		/// C:\Documents\TournamentTracker\PrizeModel.csv
		/// </returns>
		public static string FullFilePath(this string fileName) // PrizeModels.csv
		{
			// C:\Documents\TournamentTracker\PrizeModel.csv
			return $"{ ConfigurationManager.AppSettings["filePath"] }\\{ fileName }";
		}

		/// <summary>
		/// Load the text file
		/// </summary>
		/// <param name="file">Contains full file path</param>
		/// <returns>
		/// All lines of the file, or all values of the file in a list.
		/// </returns>
		public static List<string> LoadFile(this string file)
		{
			if (!File.Exists(file))
			{
				return new List<string>();
			}

			return File.ReadAllLines(file).ToList();
		}
		/// <summary>
		/// Converts text to List of PrizeModel
		/// </summary>
		/// <param name="lines"></param>
		/// <returns>Converts</returns>
		public static List<PrizeModel> ConvertToPrizeModels(this List<string> lines)
		{
			List<PrizeModel> output = new List<PrizeModel>();

			foreach (string line in lines)
			{
				string[] cols = line.Split(',');

				PrizeModel p = new PrizeModel();
				p.Id = int.Parse(cols[0]);
				p.PlaceNumber = int.Parse(cols[1]);
				p.PlaceName = cols[2];
				p.PrizeAmount = decimal.Parse(cols[3]);
				p.PrizePercentage = double.Parse(cols[4]);
				output.Add(p);
			}		

			return output;
		}
		/// <summary>
		/// Converts text to List of PersonModel
		/// </summary>
		/// <param name="lines"></param>
		/// <returns>Converts</returns>
		public static List<PersonModel> ConvertToPersonModels(this List<string> lines)
		{
			List<PersonModel> output = new List<PersonModel>();

			foreach (string line in lines)
			{
				string[] cols = line.Split(',');

				PersonModel p = new PersonModel();
				p.Id = int.Parse(cols[0]);
				p.FirstName = cols[1];
				p.LastName = cols[2];
				p.EmailAddress = cols[3];
				p.CellphoneNumber = cols[4];

				output.Add(p);
			}

			return output;
		}
		/// <summary>
		/// Converts text to List of teamModel
		/// </summary>
		/// <param name="lines"></param>
		/// <returns>Converts</returns>
		public static List<TeamModel> ConvertToTeamModels(this List<string> lines)
		{
			// id, TeamName, id|id|id
			List<TeamModel> output = new List<TeamModel>();

			List<PersonModel> person = GlobalConfig.PersonFile.FullFilePath().LoadFile().ConvertToPersonModels();

			foreach (string line in lines)
			{
				string[] cols = line.Split(',');

				TeamModel t = new TeamModel();
				t.Id = int.Parse(cols[0]);
				t.TeamName = cols[1];

				string[] personIds = cols[2].Split('|');

                foreach (string id in personIds)
                {
					t.TeamMembers.Add(person.Where(x => x.Id == int.Parse(id)).First());
                }

				output.Add(t);
			}

			return output;
		}
		public static List<TournamentModel> ConvertToTournamentModels(this List<string> lines)
		{
			// id, TournamentName, EntryFee, (id|id|id - EnteredTeams), (id|id|id - Prizes),(id^id^id|id^id^id|id^id^id - Rounds)
			List<TournamentModel> output = new List<TournamentModel>();
			List<TeamModel> teams = GlobalConfig.TeamsFile.FullFilePath().LoadFile().ConvertToTeamModels();
			List<PrizeModel> prizes = GlobalConfig.PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();
			List<MatchupModel> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModels();

			foreach (string line in lines)
			{
				string[] cols = line.Split(',');

				TournamentModel tm = new TournamentModel();
				tm.Id = int.Parse(cols[0]);
				tm.TournamentName = cols[1];
				tm.EntryFee = decimal.Parse(cols[2]);

				string[] teamIds = cols[3].Split('|');
				foreach (string id in teamIds)
				{
					tm.EnteredTeams.Add(teams.Where(x => x.Id == int.Parse(id)).First());
				}

                if (cols[4].Length > 0)
                {
                    string[] prizeIds = cols[4].Split('|');
                    foreach (string id in prizeIds)
                    {
                        tm.Prizes.Add(prizes.Where(x => x.Id == int.Parse(id)).First());
                    } 
                }

				string[] rounds = cols[5].Split('|');

				foreach (string round in rounds)
				{

					string[] msText = round.Split('^');
					List<MatchupModel> ms = new List<MatchupModel>();

					foreach (string matchupModelTextId in msText)
					{
						if (matchupModelTextId != "")
						{
							ms.Add(matchups.Where(x => x.Id == int.Parse(matchupModelTextId)).First());
						}
					}

					tm.Rounds.Add(ms);
				}

				output.Add(tm);
			}

			return output;
		}
		public static List<MatchupEntryModel> ConvertToMatchupEntryModels(this List<string> lines)
        {			
			List<MatchupEntryModel> output = new List<MatchupEntryModel>();

			foreach (string line in lines)
			{
				string[] cols = line.Split(',');

				MatchupEntryModel me = new MatchupEntryModel();
				me.Id = int.Parse(cols[0]);
				me.TeamCompeting = cols[1] != "" ? LookupTeamById(int.Parse(cols[1])) : null;
				me.Score = double.Parse(cols[2]);

				int parentId = 0;
				if(int.TryParse(cols[3], out parentId)==true)
                {
					me.ParentMatchup = LookupMatchupById(parentId);
				}
				else
                {
					me.ParentMatchup = null; // For first round parent matchup will be null
                }	

				output.Add(me);
			}

			return output;
		}

		/// <summary>
		/// Convert the prizes to List<string> & Save the List<string> to the text file
		/// </summary>
		/// <param name="models"></param>
		/// <param name="fileName"></param>
		public static void SaveToPrizeFile(this List<PrizeModel> models)
		{
			List<string> lines = new List<string>();

			foreach (PrizeModel p in models)
			{
				lines.Add($"{ p.Id },{ p.PlaceNumber },{ p.PlaceName },{ p.PrizeAmount },{ p.PrizePercentage }");
			}

			File.WriteAllLines(GlobalConfig.PrizesFile.FullFilePath(), lines);
		}
		/// <summary>
		/// Convert the person to List<string> & Save the List<string> to the text file
		/// </summary>
		/// <param name="models"></param>
		/// <param name="fileName"></param>
		public static void SaveToPersonFile(this List<PersonModel> models)
		{
			List<string> lines = new List<string>();

			foreach (PersonModel p in models)
			{
				lines.Add($"{ p.Id },{ p.FirstName },{ p.LastName },{ p.EmailAddress },{ p.CellphoneNumber }");
			}

			File.WriteAllLines(GlobalConfig.PersonFile.FullFilePath(), lines);
		}
		/// <summary>
		/// Convert the team to List<string> & Save the List<string> to the text file
		/// </summary>
		/// <param name="models"></param>
		/// <param name="fileName"></param>
		public static void SaveToTeamFile(this List<TeamModel> models)
		{
			List<string> lines = new List<string>();

			foreach (TeamModel t in models)
			{
				lines.Add($"{ t.Id },{ t.TeamName },{ ConvertPersonListToString(t.TeamMembers) }");
			}

			File.WriteAllLines(GlobalConfig.TeamsFile.FullFilePath(), lines);
		}
		/// <summary>
		/// Save all the tournament matchups and rounds to a file
		/// </summary>
		/// <param name="model"></param>
		/// <param name="matchupFile"></param>
		/// <param name="matchupEntryFile"></param>
		public static void SaveTournamentRoundsToFile(this TournamentModel model)
        {
            // Steps:
            // Loop through the Rounds
            // Loop through the Matchups
            // Get the id for the new matchup and save the record
            // Loop through the Matchup Entries, get the id and save it

            foreach (List<MatchupModel> round in model.Rounds)
            {
                foreach (MatchupModel matchup in round)
                {
					// Load all matchups from file
					// Get the max Id + 1
					// Store the id
					// Save the matchup record
					matchup.SaveMatchupToFile();                    
                }
            }
		}
		/// <summary>
		/// Convert string of ids to MatchupEntryModels
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		private static List<MatchupEntryModel> ConvertStringToMatchupEntryModels(string input)
        {
			List <MatchupEntryModel> output = new List<MatchupEntryModel>();
			List<string> entries = GlobalConfig.MatchupEntryFile.FullFilePath().LoadFile();
			List<string> matchingEntries = new List<string>();

			string[] ids = input.Split('|');

            foreach (string id in ids)
            {
                foreach (string entry in entries)
                {
					string[] cols = entry.Split(',');

					if(cols[0] == id)
                    {
						matchingEntries.Add(entry);
                    }
                }				
            }

			output = matchingEntries.ConvertToMatchupEntryModels();

			return output;
        }
		/// <summary>
		/// Find Team Model by ID
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		private static TeamModel LookupTeamById(int id)
        {
			List<string> teams = GlobalConfig.TeamsFile.FullFilePath().LoadFile();

            foreach (string team in teams)
            {
				string[] cols = team.Split(',');
				if(cols[0] == id.ToString())
                {
					List<string> matchingTeams = new List<string>();
					matchingTeams.Add(team);
					return matchingTeams.ConvertToTeamModels().First();
                }
            }

			return null;			
		}
		/// <summary>
		/// Find matchup Model by ID
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		private static MatchupModel LookupMatchupById(int id)
		{
			List<string> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile();

			foreach (string matchup in matchups)
			{
				string[] cols = matchup.Split(',');
				if (cols[0] == id.ToString())
				{
					List<string> matchingMatchups = new List<string>();
					matchingMatchups.Add(matchup);
					return matchingMatchups.ConvertToMatchupModels().First();
				}
			}

			return null;
		}
		public static List<MatchupModel> ConvertToMatchupModels(this List<string> lines)
		{
			// id, id|id - entries, winner id, MatchupRound
			List<MatchupModel> output = new List<MatchupModel>();
			
			foreach (string line in lines)
			{
				string[] cols = line.Split(',');

				MatchupModel m = new MatchupModel();
				m.Id = int.Parse(cols[0]);
				m.Entries = ConvertStringToMatchupEntryModels(cols[1]);
				m.Winner = cols[2] != "" ? LookupTeamById(int.Parse(cols[2])) : null;
				m.MatchupRound = int.Parse(cols[3]);
				output.Add(m);
			}

			return output;
		}
        public static void SaveMatchupToFile(this MatchupModel matchup)
        {
			List<MatchupModel> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModels();
			// Find the max ID & add 1
			int currentId = matchups.Count > 0 ? matchups.OrderByDescending(x => x.Id).First().Id + 1 : 1;

			matchup.Id = currentId;

			matchups.Add(matchup);

			// Save to file
			List<string> lines = new List<string>();

			foreach (MatchupModel m in matchups)
			{
				lines.Add($"{ m.Id },{ "" },{ (m.Winner != null ? m.Winner.Id.ToString() : "") },{ m.MatchupRound }");
			}

			File.WriteAllLines(GlobalConfig.MatchupFile.FullFilePath(), lines);

			foreach (MatchupEntryModel entry in matchup.Entries)
            {
                entry.SaveEntryToFile();
            }

			// ReSave to file with MatchupEntries Ids
			lines = new List<string>();

			foreach (MatchupModel m in matchups)
			{
				lines.Add($"{ m.Id },{ ConvertMatchupEntryListToString(m.Entries) },{ (m.Winner != null ? m.Winner.Id.ToString() : "") },{ m.MatchupRound }");
			}

			File.WriteAllLines(GlobalConfig.MatchupFile.FullFilePath(), lines);
		}
		public static void UpdateMatchupToFile(this MatchupModel matchup)
        {
			List<MatchupModel> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModels();

			MatchupModel oldMatchup = new MatchupModel();

            foreach (MatchupModel m in matchups)
            {
				if(m.Id == matchup.Id)
                {
					oldMatchup = m;
                }
            }

			matchups.Remove(oldMatchup);

			matchups.Add(matchup);

			// Save to file
			List<string> lines = new List<string>();

			foreach (MatchupModel m in matchups)
			{
				lines.Add($"{ m.Id },{ "" },{ (m.Winner != null ? m.Winner.Id.ToString() : "") },{ m.MatchupRound }");
			}

			File.WriteAllLines(GlobalConfig.MatchupFile.FullFilePath(), lines);

			foreach (MatchupEntryModel entry in matchup.Entries)
			{
				entry.UpdateEntryToFile();
			}

			// ReSave to file with MatchupEntries Ids
			lines = new List<string>();

			foreach (MatchupModel m in matchups)
			{
				string winner = "";
				if(m.Winner != null )
                {
					winner = m.Winner.Id.ToString();
                }

				lines.Add($"{ m.Id },{ ConvertMatchupEntryListToString(m.Entries) },{ (m.Winner != null ? m.Winner.Id.ToString() : "") },{ m.MatchupRound }");
			}

			File.WriteAllLines(GlobalConfig.MatchupFile.FullFilePath(), lines);
		}
		public static void UpdateEntryToFile(this MatchupEntryModel entry)
		{
			List<MatchupEntryModel> entries = GlobalConfig.MatchupEntryFile.FullFilePath().LoadFile().ConvertToMatchupEntryModels();

			MatchupEntryModel oldEntry = new MatchupEntryModel();

            foreach (MatchupEntryModel e in entries)
            {
				if(e.Id == entry.Id)
                {
					oldEntry = e;
                }
            }

			entries.Remove(oldEntry);

			entries.Add(entry);

			// Save to file
			List<string> lines = new List<string>();

			foreach (MatchupEntryModel e in entries)
			{
				lines.Add($"{ e.Id },{ (e.TeamCompeting != null ? e.TeamCompeting.Id.ToString() : "") },{ e.Score },{ (e.ParentMatchup != null ? e.ParentMatchup.Id.ToString() : "") }");
			}

			File.WriteAllLines(GlobalConfig.MatchupEntryFile.FullFilePath(), lines);
		}
        public static void SaveEntryToFile(this MatchupEntryModel entry)
        {
			List<MatchupEntryModel> entries = GlobalConfig.MatchupEntryFile.FullFilePath().LoadFile().ConvertToMatchupEntryModels();
			// Find the max ID & add 1
			int currentId = entries.Count > 0 ? entries.OrderByDescending(x => x.Id).First().Id + 1 : 1;

			entry.Id = currentId;

			entries.Add(entry);

			// Save to file
			List<string> lines = new List<string>();

			foreach (MatchupEntryModel e in entries)
			{
				lines.Add($"{ e.Id },{ (e.TeamCompeting != null ? e.TeamCompeting.Id.ToString() : "") },{ e.Score },{ (e.ParentMatchup != null ? e.ParentMatchup.Id.ToString() : "") }");
			}

			File.WriteAllLines(GlobalConfig.MatchupEntryFile.FullFilePath(), lines);
		}
        /// <summary>
        /// Convert the tournament to List<string> & Save the List<string> to the text file
        /// </summary>
        /// <param name="models"></param>
        /// <param name="fileName"></param>
        public static void SaveToTournamentFile(this List<TournamentModel> models)
		{
			List<string> lines = new List<string>();

			foreach (TournamentModel tm in models)
			{
				lines.Add($"{ tm.Id },{ tm.TournamentName },{ tm.EntryFee },{ ConvertTeamListToString(tm.EnteredTeams) },{ ConvertPrizeListToString(tm.Prizes) },{ ConvertRoundListToString(tm.Rounds) }");
			}

			File.WriteAllLines(GlobalConfig.TournamentsFile.FullFilePath(), lines);
		}
		/// <summary>
		/// Convert a list of person model to string joined by pipe
		/// </summary>
		/// <param name="person"></param>
		/// <returns></returns>
		private static string ConvertPersonListToString(List<PersonModel> person)
		{
			string output = "";
			if (person.Count == 0) return "";
			foreach (PersonModel p in person)
			{
				output += $"{ p.Id }|";
			}
			output = output.Substring(0, output.Length - 1);

			return output;
		}
		/// <summary>
		/// Convert a list of teams model to string joined by pipe
		/// </summary>
		/// <param name="teams"></param>
		/// <returns></returns>
		private static string ConvertTeamListToString(List<TeamModel> teams)
		{
			string output = "";
			if (teams.Count == 0) return "";
			foreach (TeamModel t in teams)
			{
				output += $"{ t.Id }|";
			}
			output = output.Substring(0, output.Length - 1);

			return output;
		}
		/// <summary>
		/// Convert a list of matchup entry model to string joined by pipe
		/// </summary>
		/// <param name="prizes"></param>
		/// <returns></returns>
		private static string ConvertMatchupEntryListToString(List<MatchupEntryModel> entries)
		{
			string output = "";
			if (entries.Count == 0) return "";
			foreach (MatchupEntryModel e in entries)
			{
				output += $"{ e.Id }|";
			}
			output = output.Substring(0, output.Length - 1);

			return output;
		}
		/// <summary>
		/// Convert a list of prizes model to string joined by pipe
		/// </summary>
		/// <param name="prizes"></param>
		/// <returns></returns>
		private static string ConvertPrizeListToString(List<PrizeModel> prizes)
		{
			string output = "";
			if (prizes.Count == 0) return "";
			foreach (PrizeModel t in prizes)
			{
				output += $"{ t.Id }|";
			}
			output = output.Substring(0, output.Length - 1);

			return output;
		}
		/// <summary>
		/// Convert a list of rounds model to string joined by ^
		/// </summary>
		/// <param name="rounds"></param>
		/// <returns></returns>
		private static string ConvertRoundListToString(List<List<MatchupModel>> rounds)
		{
			string output = "";
			if (rounds.Count == 0) return "";
			foreach (List<MatchupModel> r in rounds)
			{
				foreach (MatchupModel m in r)
                {
					output += $"{ m.Id }^";
				}
				output += $"|";
			}
			output = output.Substring(0, output.Length - 1);

			return output;
		}
	}
}
