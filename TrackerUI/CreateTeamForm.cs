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
	public partial class CreateTeamForm : Form
	{
		private List<PersonModel> availableTeamMembers = GlobalConfig.Connection.GetPerson_All();
		private List<PersonModel> selectedTeamMembers = new List<PersonModel>();
		ITeamRequestor callingForm;

		public CreateTeamForm(ITeamRequestor caller)
		{
			InitializeComponent();

			callingForm = caller;
			// CreateSampleData();

			WireUpLists();
		}

		private void CreateSampleData()
        {
			availableTeamMembers.Add(new PersonModel { FirstName = "Khuzema", LastName = "Khomosi"});
			availableTeamMembers.Add(new PersonModel { FirstName = "Lakshita", LastName = "Agarwal" });

			selectedTeamMembers.Add(new PersonModel { FirstName = "Adarsh", LastName = "Malviya" });
			selectedTeamMembers.Add(new PersonModel { FirstName = "Oishik", LastName = "Mandal" });
		}

        private void WireUpLists()
        {
			selectTeamDropdown.DataSource = null;

			selectTeamDropdown.DataSource = availableTeamMembers;
			selectTeamDropdown.DisplayMember = "FullName";

			teamMemberListBox.DataSource = null;

			teamMemberListBox.DataSource = selectedTeamMembers;
			teamMemberListBox.DisplayMember = "FullName";
        }

		private void createMemberButton_Click(object sender, EventArgs e)
		{
			if(ValidateForm())
            {
				PersonModel model = new PersonModel(
					firstNameText.Text, 
					lastNameText.Text, 
					emailText.Text, 
					cellphoneText.Text
				);

				GlobalConfig.Connection.CreatePerson(model);

				selectedTeamMembers.Add(model);
				WireUpLists();

                firstNameText.Text = "";
                lastNameText.Text = "";
                emailText.Text = "";
                cellphoneText.Text = "";
            }
			else
            {
				MessageBox.Show("You need to fill in all the fields.");
            }
		}

		private bool ValidateForm()
		{
			if (firstNameText.Text.Length == 0) return false;
			if (lastNameText.Text.Length == 0) return false;
			if (emailText.Text.Length == 0) return false;
			if (cellphoneText.Text.Length == 0) return false;

			return true;
		}

        private void addMemberButton_Click(object sender, EventArgs e)
        {
			PersonModel p = (PersonModel)selectTeamDropdown.SelectedItem;
			if (p != null)
			{
				availableTeamMembers.Remove(p);
				selectedTeamMembers.Add(p);

				WireUpLists();
			}
		}

        private void removeSelectedTeamMembersButton_Click(object sender, EventArgs e)
        {
			PersonModel p = (PersonModel)teamMemberListBox.SelectedItem;
			if(p != null)
            {
				selectedTeamMembers.Remove(p);
				availableTeamMembers.Add(p);

				WireUpLists();
			}
		}

        private void createTeamButton_Click(object sender, EventArgs e)
        {
			TeamModel t = new TeamModel(
				teamNameText.Text,
				selectedTeamMembers
			);

			GlobalConfig.Connection.CreateTeam(t);

			callingForm.TeamComplete(t);

			this.Close();
		}
    }
}
