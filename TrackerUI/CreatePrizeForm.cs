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
using TournamentLibrary.DataAccess;
using TournamentLibrary.Models;

namespace TrackerUI
{
	public partial class CreatePrizeForm : Form
	{
		IPrizeRequestor callingForm;
		public CreatePrizeForm(IPrizeRequestor caller)
		{
			InitializeComponent();

			callingForm = caller;
		}

		private void createPrizeButton_Click(object sender, EventArgs e)
		{
			if (ValidateForm())
			{
				PrizeModel model = new PrizeModel(
					placeNameText.Text,
					placeNumberText.Text,
					prizeAmountText.Text,
					prizePercentageText.Text
				);

				GlobalConfig.Connection.CreatePrize(model);

				callingForm.PrizeComplete(model);

				this.Close();
			
				//placeNameText.Text = "";
				//placeNumberText.Text = "";
				//prizeAmountText.Text = "0";
				//prizePercentageText.Text = "0";
			}
			else
			{
				MessageBox.Show("This form has invalid information. Please check it and try again");
			}

		}

		private bool ValidateForm()
		{
			bool output = true;

			int PlaceNumber = 0;
			bool placeNumberValidNumber = int.TryParse(placeNumberText.Text, out PlaceNumber);

			if (placeNumberValidNumber == false) output = false;
			if (PlaceNumber < 1) output = false;
			if (placeNameText.Text.Length == 0) output = false;

			decimal prizeAmount = 0;
			double prizePercentage = 0;
			bool prizeAmountValidNumber = decimal.TryParse(prizeAmountText.Text, out prizeAmount);
			bool prizePercentageValidNumber = double.TryParse(prizePercentageText.Text, out prizePercentage);

			if (prizeAmountValidNumber == false || prizePercentageValidNumber == false) output = false;
			if (prizeAmount <= 0 && prizePercentage <= 0) output = false;
			if (prizePercentage < 0 || prizePercentage > 100) output = false; 

			return output;
		}
	}
}
