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
		PrizeModel CreatePrize(PrizeModel model);
		PersonModel CreatePerson(PersonModel model);
		TeamModel CreateTeam(TeamModel model);
		void CreateTournament(TournamentModel model);
		// Select Statements
		List<PersonModel> GetPerson_All();
		List<TeamModel> GetTeam_All();
	}
}
