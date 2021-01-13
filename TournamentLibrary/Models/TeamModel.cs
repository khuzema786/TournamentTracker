using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentLibrary.Models
{
	public class TeamModel
	{
		public int Id { get; set; }
		public string TeamName { get; set; }
		public List<PersonModel> TeamMembers { get; set; } = new List<PersonModel>();
        public TeamModel() { }
        public TeamModel(string teamName, List<PersonModel> teamMembers)
        {
			TeamName = teamName;
			TeamMembers = teamMembers;
        }
	}
}
