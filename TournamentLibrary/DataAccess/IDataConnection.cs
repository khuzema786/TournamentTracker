using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentLibrary.Models;

namespace TournamentLibrary.DataAccess
{
	public interface IDataConnection
	{
		// Insert Statements
		void CreatePrize(PrizeModel model);
		void CreatePerson(PersonModel model);
		void CreateTeam(TeamModel model);
		void CreateTournament(TournamentModel model);
		// Update Statements
		void UpdateMatchup(MatchupModel model);
		void CompleteTournament(TournamentModel model);
		// Select Statements
		List<PersonModel> GetPerson_All();
		List<TeamModel> GetTeam_All();
		List<TournamentModel> GetTournament_All();
	}
}
