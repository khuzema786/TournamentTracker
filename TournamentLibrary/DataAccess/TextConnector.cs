using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentLibrary.Models;
using TournamentLibrary.DataAccess.TextHelpers;

namespace TournamentLibrary.DataAccess
{
	public class TextConnector : IDataConnection
	{
		// TODO - Wire up the CreatePrize for text files.
		public void CreatePrize(PrizeModel model)
		{
			// Load the text file & convert the text to List<PrizeModel>
			List<PrizeModel> prizes = GlobalConfig.PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();

			// Find the max ID & add 1
			int currentId = prizes.Count > 0 ? prizes.OrderByDescending(x => x.Id).First().Id + 1 : 1;

			model.Id = currentId;

			// Add new record with the new ID (max + 1)
			prizes.Add(model);

			// Convert the prizes to List<string> & Save the List<string> to the text file
			prizes.SaveToPrizeFile();
		}

        public void CreatePerson(PersonModel model)
        {
			// Load the text file & convert the text to List<PrizeModel>
			List<PersonModel> person = GlobalConfig.PersonFile.FullFilePath().LoadFile().ConvertToPersonModels();

			// Find the max ID & add 1
			int currentId = person.Count > 0 ? person.OrderByDescending(x => x.Id).First().Id + 1 : 1;

			model.Id = currentId;

			// Add new record with the new ID (max + 1)
			person.Add(model);

			// Convert the prizes to List<string> & Save the List<string> to the text file
			person.SaveToPersonFile();
		}
	
		public void CreateTeam(TeamModel model)
		{
			// Load the text file & convert the text to List<PrizeModel>
			List<TeamModel> teams = GlobalConfig.TeamsFile.FullFilePath().LoadFile().ConvertToTeamModels();

			// Find the max ID & add 1
			int currentId = teams.Count > 0 ? teams.OrderByDescending(x => x.Id).First().Id + 1 : 1;

			model.Id = currentId;

			// Add new record with the new ID (max + 1)
			teams.Add(model);

			// Convert the prizes to List<string> & Save the List<string> to the text file
			teams.SaveToTeamFile();		
		}
		public void CreateTournament(TournamentModel model)
		{
			// Load the text file & convert the text to List<TournamentModel>
			List<TournamentModel> tournaments = GlobalConfig.TournamentsFile
				.FullFilePath()
				.LoadFile()
				.ConvertToTournamentModels();

			// Find the max ID & add 1
			int currentId = tournaments.Count > 0 ? tournaments.OrderByDescending(x => x.Id).First().Id + 1 : 1;

			model.Id = currentId;

			// Save all rounds and matchups in a file before saving the tournament
			model.SaveTournamentRoundsToFile();

			// Add new record with the new ID (max + 1)
			tournaments.Add(model);			

			// Convert the tournaments to List<string> & Save the List<string> to the text file
			tournaments.SaveToTournamentFile();

			TournamentLogic.UpdateTournamentResults(model);
		}

		public List<PersonModel> GetPerson_All()
        {
			return GlobalConfig.PersonFile.FullFilePath().LoadFile().ConvertToPersonModels();
        }

        public List<TeamModel> GetTeam_All()
        {
			return GlobalConfig.TeamsFile.FullFilePath().LoadFile().ConvertToTeamModels();
		}

        public List<TournamentModel> GetTournament_All()
        {
			// Load the text file & convert the text to List<TournamentModel>
			return GlobalConfig.TournamentsFile
				.FullFilePath()
				.LoadFile()
				.ConvertToTournamentModels();
		}

        public void UpdateMatchup(MatchupModel model)
        {
			model.UpdateMatchupToFile();
        }

        public void CompleteTournament(TournamentModel model)
        {
			// Load the text file & convert the text to List<TournamentModel>
			List<TournamentModel> tournaments = GlobalConfig.TournamentsFile
				.FullFilePath()
				.LoadFile()
				.ConvertToTournamentModels();

			tournaments.Remove(model);

			// Convert the tournaments to List<string> & Save the List<string> to the text file
			tournaments.SaveToTournamentFile();

			TournamentLogic.UpdateTournamentResults(model);
		}
    }
}
