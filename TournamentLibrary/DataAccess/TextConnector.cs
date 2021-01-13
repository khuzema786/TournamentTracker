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
		private const string PrizesFile = "PrizeModels.csv";
		private const string PersonFile = "PersonModels.csv";
		private const string TeamsFile = "TeamModels.csv";
		private const string TournamentsFile = "TournamentModels.csv";
		private const string MatchupFile = "MatchupModels.csv";
		private const string MatchupEntryFile = "MatchupEntryModels.csv";
		// TODO - Wire up the CreatePrize for text files.
		public PrizeModel CreatePrize(PrizeModel model)
		{
			// Load the text file & convert the text to List<PrizeModel>
			List<PrizeModel> prizes = PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();

			// Find the max ID & add 1
			int currentId = prizes.Count > 0 ? prizes.OrderByDescending(x => x.Id).First().Id + 1 : 1;

			model.Id = currentId;

			// Add new record with the new ID (max + 1)
			prizes.Add(model);

			// Convert the prizes to List<string> & Save the List<string> to the text file
			prizes.SaveToPrizeFile(PrizesFile);

			return model;
		}

        public PersonModel CreatePerson(PersonModel model)
        {
			// Load the text file & convert the text to List<PrizeModel>
			List<PersonModel> person = PersonFile.FullFilePath().LoadFile().ConvertToPersonModels();

			// Find the max ID & add 1
			int currentId = person.Count > 0 ? person.OrderByDescending(x => x.Id).First().Id + 1 : 1;

			model.Id = currentId;

			// Add new record with the new ID (max + 1)
			person.Add(model);

			// Convert the prizes to List<string> & Save the List<string> to the text file
			person.SaveToPersonFile(PersonFile);

			return model;
		}
	
		public TeamModel CreateTeam(TeamModel model)
		{
			// Load the text file & convert the text to List<PrizeModel>
			List<TeamModel> teams = TeamsFile.FullFilePath().LoadFile().ConvertToTeamModels(PersonFile);

			// Find the max ID & add 1
			int currentId = teams.Count > 0 ? teams.OrderByDescending(x => x.Id).First().Id + 1 : 1;

			model.Id = currentId;

			// Add new record with the new ID (max + 1)
			teams.Add(model);

			// Convert the prizes to List<string> & Save the List<string> to the text file
			teams.SaveToTeamFile(TeamsFile);
			
			return model;			
		}
		public void CreateTournament(TournamentModel model)
		{
			// Load the text file & convert the text to List<TournamentModel>
			List<TournamentModel> tournaments = TournamentsFile
				.FullFilePath()
				.LoadFile()
				.ConvertToTournamentModels(TeamsFile, PersonFile, PrizesFile);

			// Find the max ID & add 1
			int currentId = tournaments.Count > 0 ? tournaments.OrderByDescending(x => x.Id).First().Id + 1 : 1;

			model.Id = currentId;

			// Save all rounds and matchups in a file before saving the tournament
			model.SaveTournamentRoundsToFile(MatchupFile, MatchupEntryFile);

			// Add new record with the new ID (max + 1)
			tournaments.Add(model);			

			// Convert the tournaments to List<string> & Save the List<string> to the text file
			tournaments.SaveToTournamentFile(TournamentsFile);
		}

		public List<PersonModel> GetPerson_All()
        {
			return PersonFile.FullFilePath().LoadFile().ConvertToPersonModels();
        }

        public List<TeamModel> GetTeam_All()
        {
			return TeamsFile.FullFilePath().LoadFile().ConvertToTeamModels(PersonFile);
		}
    }
}
