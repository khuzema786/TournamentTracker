using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TournamentLibrary;
using TournamentLibrary.Models;

namespace TrackerUI
{
	public partial class CreateTournamentForm : Form, IPrizeRequestor, ITeamRequestor
	{
		List<TeamModel> availableTeams = GlobalConfig.Connection.GetTeam_All();
		List<TeamModel> selectedTeams = new List<TeamModel>();
		List<PrizeModel> selectedPrizes = new List<PrizeModel>();
		public CreateTournamentForm()
		{
			InitializeComponent();

			WireUpLists();
		}
		private void WireUpLists()
        {
			selectTeamDropdown.DataSource = null;
			selectTeamDropdown.DataSource = availableTeams;
			selectTeamDropdown.DisplayMember = "TeamName";

			tournamentTeamsListBox.DataSource = null;
			tournamentTeamsListBox.DataSource = selectedTeams;
			tournamentTeamsListBox.DisplayMember = "TeamName";

			prizesListBox.DataSource = null;
			prizesListBox.DataSource = selectedPrizes;
			prizesListBox.DisplayMember = "PlaceName";
		}
        private void addTeamButton_Click(object sender, EventArgs e)
        {
			TeamModel t = (TeamModel)selectTeamDropdown.SelectedItem;
			if (t != null)
			{
				availableTeams.Remove(t);
				selectedTeams.Add(t);

				WireUpLists();
			}
		}

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
			// Call the CreatePrizeForm
			CreatePrizeForm frm = new CreatePrizeForm(this);
			frm.Show();			
        }

        public void PrizeComplete(PrizeModel model)
        {
			// Get back from the form a PrizeModel
			// Take the model and add it to list of selected prizes
			selectedPrizes.Add(model);
			WireUpLists();
		}

		private void createNewLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			// Call the CreateTeamForm
			CreateTeamForm frm = new CreateTeamForm(this);
			frm.Show();
		}
		public void TeamComplete(TeamModel model)
        {
			// Take the model and add it to list of selected teams
			selectedTeams.Add(model);
			WireUpLists();
        }

        private void removeSelectedPrizesButton_Click(object sender, EventArgs e)
        {
			PrizeModel p = (PrizeModel)prizesListBox.SelectedItem;
			if (p != null)
			{
				selectedPrizes.Remove(p);				

				WireUpLists();
			}
		}

        private void removeSelectedPlayersButton_Click(object sender, EventArgs e)
        {
			TeamModel t = (TeamModel)tournamentTeamsListBox.SelectedItem;
			if (t != null)
			{
				selectedTeams.Remove(t);
				availableTeams.Add(t);

				WireUpLists();
			}
		}
		private void createTournamentButton_Click(object sender, EventArgs e)
		{
			// Validate data
			decimal fee = 0;
			bool feeAcceptable = decimal.TryParse(entryFeeText.Text, out fee);


			if (!feeAcceptable)
			{
				MessageBox.Show("You need to enter a Valid Entry Fee.",
					"Invalid Fee",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return;
			}

			// Create our tournament model
			TournamentModel tm = new TournamentModel();

			tm.TournamentName = tournamentNameText.Text;
			tm.EntryFee = fee;

			tm.Prizes = selectedPrizes;
			tm.EnteredTeams = selectedTeams;

			// TODO - Wire our matchups
			TournamentLogic.CreateRounds(tm);

			// Create tournament entry
			// Create all of the prizes entries
			// Create all of the team entries
			GlobalConfig.Connection.CreateTournament(tm);

			tm.AlertUsersToNewRound();

			TournamentViewerForm frm = new TournamentViewerForm(tm);
			frm.Show();
			this.Close();
		}
	}
}
