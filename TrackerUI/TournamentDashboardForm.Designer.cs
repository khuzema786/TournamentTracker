
namespace TrackerUI
{
	partial class TournamentDashboardForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TournamentDashboardForm));
			this.tournamentDashboardHeader = new System.Windows.Forms.Label();
			this.loadTournamentButton = new System.Windows.Forms.Button();
			this.loadExistingTournamentLabel = new System.Windows.Forms.Label();
			this.loadExistingTournamentDropdown = new System.Windows.Forms.ComboBox();
			this.createTournamentButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tournamentDashboardHeader
			// 
			this.tournamentDashboardHeader.AutoSize = true;
			this.tournamentDashboardHeader.BackColor = System.Drawing.Color.Transparent;
			this.tournamentDashboardHeader.Font = new System.Drawing.Font("SF Pro Display", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tournamentDashboardHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
			this.tournamentDashboardHeader.Location = new System.Drawing.Point(75, 35);
			this.tournamentDashboardHeader.Name = "tournamentDashboardHeader";
			this.tournamentDashboardHeader.Size = new System.Drawing.Size(327, 35);
			this.tournamentDashboardHeader.TabIndex = 20;
			this.tournamentDashboardHeader.Text = "Tournament Dashboard";
			// 
			// loadTournamentButton
			// 
			this.loadTournamentButton.BackColor = System.Drawing.Color.White;
			this.loadTournamentButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.loadTournamentButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
			this.loadTournamentButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
			this.loadTournamentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.loadTournamentButton.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.loadTournamentButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
			this.loadTournamentButton.Location = new System.Drawing.Point(179, 173);
			this.loadTournamentButton.Name = "loadTournamentButton";
			this.loadTournamentButton.Size = new System.Drawing.Size(118, 32);
			this.loadTournamentButton.TabIndex = 27;
			this.loadTournamentButton.Text = "Load Tournament";
			this.loadTournamentButton.UseVisualStyleBackColor = false;
			this.loadTournamentButton.Click += new System.EventHandler(this.createMemberButton_Click);
			// 
			// loadExistingTournamentLabel
			// 
			this.loadExistingTournamentLabel.AutoSize = true;
			this.loadExistingTournamentLabel.BackColor = System.Drawing.Color.Transparent;
			this.loadExistingTournamentLabel.Font = new System.Drawing.Font("SF Pro Display", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.loadExistingTournamentLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
			this.loadExistingTournamentLabel.Location = new System.Drawing.Point(119, 102);
			this.loadExistingTournamentLabel.Name = "loadExistingTournamentLabel";
			this.loadExistingTournamentLabel.Size = new System.Drawing.Size(238, 25);
			this.loadExistingTournamentLabel.TabIndex = 26;
			this.loadExistingTournamentLabel.Text = "Load Existing Tournament";
			// 
			// loadExistingTournamentDropdown
			// 
			this.loadExistingTournamentDropdown.FormattingEnabled = true;
			this.loadExistingTournamentDropdown.Location = new System.Drawing.Point(99, 141);
			this.loadExistingTournamentDropdown.Name = "loadExistingTournamentDropdown";
			this.loadExistingTournamentDropdown.Size = new System.Drawing.Size(279, 21);
			this.loadExistingTournamentDropdown.TabIndex = 25;
			// 
			// createTournamentButton
			// 
			this.createTournamentButton.BackColor = System.Drawing.Color.White;
			this.createTournamentButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.createTournamentButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
			this.createTournamentButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
			this.createTournamentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.createTournamentButton.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.createTournamentButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
			this.createTournamentButton.Location = new System.Drawing.Point(167, 225);
			this.createTournamentButton.Name = "createTournamentButton";
			this.createTournamentButton.Size = new System.Drawing.Size(143, 32);
			this.createTournamentButton.TabIndex = 28;
			this.createTournamentButton.Text = "Create Tournament";
			this.createTournamentButton.UseVisualStyleBackColor = false;
			// 
			// TournamentDashboardForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(499, 290);
			this.Controls.Add(this.createTournamentButton);
			this.Controls.Add(this.loadTournamentButton);
			this.Controls.Add(this.loadExistingTournamentLabel);
			this.Controls.Add(this.loadExistingTournamentDropdown);
			this.Controls.Add(this.tournamentDashboardHeader);
			this.Font = new System.Drawing.Font("SF Pro Display", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "TournamentDashboardForm";
			this.Text = "Tournament Dashboard Form";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label tournamentDashboardHeader;
		private System.Windows.Forms.Button loadTournamentButton;
		private System.Windows.Forms.Label loadExistingTournamentLabel;
		private System.Windows.Forms.ComboBox loadExistingTournamentDropdown;
		private System.Windows.Forms.Button createTournamentButton;
	}
}