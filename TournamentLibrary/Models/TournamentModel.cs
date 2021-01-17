using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentLibrary.Models
{
	/// <summary>
	/// Represents one tournament with all rounds, matchups, prizes & outcomes.
	/// </summary>
	public class TournamentModel
	{
		public event EventHandler<DateTime> OnTournamentComplete;
		/// <summary>
		/// The unique identifier for the tournament.
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// The name of tournament.
		/// </summary>
		public string TournamentName { get; set; }
		/// <summary>
		/// Entry fee for the tournament.
		/// </summary>
		public decimal EntryFee { get; set; }
		/// <summary>
		/// The set of teams that have been entered.
		/// </summary>
		public List<TeamModel> EnteredTeams { get; set; } = new List<TeamModel>();
		/// <summary>
		/// List of prizes for the various places.
		/// </summary>
		public List<PrizeModel> Prizes { get; set; } = new List<PrizeModel>();
		/// <summary>
		/// The matchups per round.
		/// </summary>
		public List<List<MatchupModel>> Rounds { get; set; } = new List<List<MatchupModel>>();

		public void CompleteTournament()
        {
			OnTournamentComplete?.Invoke(this, DateTime.Now);
        }
    }
}
