
namespace TrackerUI
{
	partial class TournamentViewerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TournamentViewerForm));
            this.tournamentHeader = new System.Windows.Forms.Label();
            this.tournamentName = new System.Windows.Forms.Label();
            this.roundLabel = new System.Windows.Forms.Label();
            this.roundDropdown = new System.Windows.Forms.ComboBox();
            this.unplayedOnlyCheckbox = new System.Windows.Forms.CheckBox();
            this.matchupListBox = new System.Windows.Forms.ListBox();
            this.teamOneName = new System.Windows.Forms.Label();
            this.teamOneScoreLabel = new System.Windows.Forms.Label();
            this.teamOneScoreText = new System.Windows.Forms.TextBox();
            this.teamTwoScoreText = new System.Windows.Forms.TextBox();
            this.teamTwoScoreLabel = new System.Windows.Forms.Label();
            this.teamTwoName = new System.Windows.Forms.Label();
            this.vsLabel = new System.Windows.Forms.Label();
            this.scoreButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tournamentHeader
            // 
            this.tournamentHeader.AutoSize = true;
            this.tournamentHeader.BackColor = System.Drawing.Color.Transparent;
            this.tournamentHeader.Font = new System.Drawing.Font("SF Pro Display", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tournamentHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.tournamentHeader.Location = new System.Drawing.Point(12, 20);
            this.tournamentHeader.Name = "tournamentHeader";
            this.tournamentHeader.Size = new System.Drawing.Size(183, 35);
            this.tournamentHeader.TabIndex = 0;
            this.tournamentHeader.Text = "Tournament:";
            // 
            // tournamentName
            // 
            this.tournamentName.AutoSize = true;
            this.tournamentName.BackColor = System.Drawing.Color.Transparent;
            this.tournamentName.Font = new System.Drawing.Font("SF Pro Display", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tournamentName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.tournamentName.Location = new System.Drawing.Point(211, 20);
            this.tournamentName.Name = "tournamentName";
            this.tournamentName.Size = new System.Drawing.Size(111, 35);
            this.tournamentName.TabIndex = 1;
            this.tournamentName.Text = "<none>";
            // 
            // roundLabel
            // 
            this.roundLabel.AutoSize = true;
            this.roundLabel.BackColor = System.Drawing.Color.Transparent;
            this.roundLabel.Font = new System.Drawing.Font("SF Pro Display", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.roundLabel.Location = new System.Drawing.Point(13, 72);
            this.roundLabel.Name = "roundLabel";
            this.roundLabel.Size = new System.Drawing.Size(70, 25);
            this.roundLabel.TabIndex = 2;
            this.roundLabel.Text = "Round";
            // 
            // roundDropdown
            // 
            this.roundDropdown.FormattingEnabled = true;
            this.roundDropdown.Location = new System.Drawing.Point(102, 74);
            this.roundDropdown.Name = "roundDropdown";
            this.roundDropdown.Size = new System.Drawing.Size(207, 21);
            this.roundDropdown.TabIndex = 3;
            this.roundDropdown.SelectedIndexChanged += new System.EventHandler(this.roundDropdown_SelectedIndexChanged);
            // 
            // unplayedOnlyCheckbox
            // 
            this.unplayedOnlyCheckbox.AutoSize = true;
            this.unplayedOnlyCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.unplayedOnlyCheckbox.Font = new System.Drawing.Font("SF Pro Display", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unplayedOnlyCheckbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.unplayedOnlyCheckbox.Location = new System.Drawing.Point(102, 120);
            this.unplayedOnlyCheckbox.Name = "unplayedOnlyCheckbox";
            this.unplayedOnlyCheckbox.Size = new System.Drawing.Size(161, 29);
            this.unplayedOnlyCheckbox.TabIndex = 4;
            this.unplayedOnlyCheckbox.Text = "Unplayed Only";
            this.unplayedOnlyCheckbox.UseVisualStyleBackColor = false;
            this.unplayedOnlyCheckbox.CheckedChanged += new System.EventHandler(this.unplayedOnlyCheckbox_CheckedChanged);
            // 
            // matchupListBox
            // 
            this.matchupListBox.BackColor = System.Drawing.Color.White;
            this.matchupListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.matchupListBox.Font = new System.Drawing.Font("SF Pro Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matchupListBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.matchupListBox.FormattingEnabled = true;
            this.matchupListBox.ItemHeight = 19;
            this.matchupListBox.Location = new System.Drawing.Point(18, 170);
            this.matchupListBox.Name = "matchupListBox";
            this.matchupListBox.Size = new System.Drawing.Size(291, 209);
            this.matchupListBox.TabIndex = 5;
            this.matchupListBox.SelectedIndexChanged += new System.EventHandler(this.matchupListBox_SelectedIndexChanged);
            // 
            // teamOneName
            // 
            this.teamOneName.AutoSize = true;
            this.teamOneName.BackColor = System.Drawing.Color.Transparent;
            this.teamOneName.Font = new System.Drawing.Font("SF Pro Display", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamOneName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.teamOneName.Location = new System.Drawing.Point(325, 170);
            this.teamOneName.Name = "teamOneName";
            this.teamOneName.Size = new System.Drawing.Size(120, 25);
            this.teamOneName.TabIndex = 6;
            this.teamOneName.Text = "<team one>";
            // 
            // teamOneScoreLabel
            // 
            this.teamOneScoreLabel.AutoSize = true;
            this.teamOneScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.teamOneScoreLabel.Font = new System.Drawing.Font("SF Pro Display", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamOneScoreLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.teamOneScoreLabel.Location = new System.Drawing.Point(325, 215);
            this.teamOneScoreLabel.Name = "teamOneScoreLabel";
            this.teamOneScoreLabel.Size = new System.Drawing.Size(62, 25);
            this.teamOneScoreLabel.TabIndex = 7;
            this.teamOneScoreLabel.Text = "Score";
            // 
            // teamOneScoreText
            // 
            this.teamOneScoreText.Location = new System.Drawing.Point(403, 217);
            this.teamOneScoreText.Name = "teamOneScoreText";
            this.teamOneScoreText.Size = new System.Drawing.Size(100, 21);
            this.teamOneScoreText.TabIndex = 8;
            // 
            // teamTwoScoreText
            // 
            this.teamTwoScoreText.Location = new System.Drawing.Point(403, 340);
            this.teamTwoScoreText.Name = "teamTwoScoreText";
            this.teamTwoScoreText.Size = new System.Drawing.Size(100, 21);
            this.teamTwoScoreText.TabIndex = 11;
            // 
            // teamTwoScoreLabel
            // 
            this.teamTwoScoreLabel.AutoSize = true;
            this.teamTwoScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.teamTwoScoreLabel.Font = new System.Drawing.Font("SF Pro Display", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamTwoScoreLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.teamTwoScoreLabel.Location = new System.Drawing.Point(325, 338);
            this.teamTwoScoreLabel.Name = "teamTwoScoreLabel";
            this.teamTwoScoreLabel.Size = new System.Drawing.Size(62, 25);
            this.teamTwoScoreLabel.TabIndex = 10;
            this.teamTwoScoreLabel.Text = "Score";
            // 
            // teamTwoName
            // 
            this.teamTwoName.AutoSize = true;
            this.teamTwoName.BackColor = System.Drawing.Color.Transparent;
            this.teamTwoName.Font = new System.Drawing.Font("SF Pro Display", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamTwoName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.teamTwoName.Location = new System.Drawing.Point(325, 294);
            this.teamTwoName.Name = "teamTwoName";
            this.teamTwoName.Size = new System.Drawing.Size(118, 25);
            this.teamTwoName.TabIndex = 9;
            this.teamTwoName.Text = "<team two>";
            // 
            // vsLabel
            // 
            this.vsLabel.AutoSize = true;
            this.vsLabel.BackColor = System.Drawing.Color.Transparent;
            this.vsLabel.Font = new System.Drawing.Font("SF Pro Display", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.vsLabel.Location = new System.Drawing.Point(381, 257);
            this.vsLabel.Name = "vsLabel";
            this.vsLabel.Size = new System.Drawing.Size(65, 25);
            this.vsLabel.TabIndex = 12;
            this.vsLabel.Text = "- VS -";
            // 
            // scoreButton
            // 
            this.scoreButton.BackColor = System.Drawing.Color.White;
            this.scoreButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.scoreButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.scoreButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.scoreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scoreButton.Font = new System.Drawing.Font("SF Pro Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.scoreButton.Location = new System.Drawing.Point(490, 267);
            this.scoreButton.Name = "scoreButton";
            this.scoreButton.Size = new System.Drawing.Size(90, 39);
            this.scoreButton.TabIndex = 13;
            this.scoreButton.Text = "Score";
            this.scoreButton.UseVisualStyleBackColor = false;
            this.scoreButton.Click += new System.EventHandler(this.scoreButton_Click);
            // 
            // TournamentViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 402);
            this.Controls.Add(this.scoreButton);
            this.Controls.Add(this.vsLabel);
            this.Controls.Add(this.teamTwoScoreText);
            this.Controls.Add(this.teamTwoScoreLabel);
            this.Controls.Add(this.teamTwoName);
            this.Controls.Add(this.teamOneScoreText);
            this.Controls.Add(this.teamOneScoreLabel);
            this.Controls.Add(this.teamOneName);
            this.Controls.Add(this.matchupListBox);
            this.Controls.Add(this.unplayedOnlyCheckbox);
            this.Controls.Add(this.roundDropdown);
            this.Controls.Add(this.roundLabel);
            this.Controls.Add(this.tournamentName);
            this.Controls.Add(this.tournamentHeader);
            this.Font = new System.Drawing.Font("SF Pro Display", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TournamentViewerForm";
            this.Text = "Tournament Viewer";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label tournamentHeader;
		private System.Windows.Forms.Label tournamentName;
		private System.Windows.Forms.Label roundLabel;
		private System.Windows.Forms.ComboBox roundDropdown;
		private System.Windows.Forms.CheckBox unplayedOnlyCheckbox;
		private System.Windows.Forms.ListBox matchupListBox;
		private System.Windows.Forms.Label teamOneName;
		private System.Windows.Forms.Label teamOneScoreLabel;
		private System.Windows.Forms.TextBox teamOneScoreText;
		private System.Windows.Forms.TextBox teamTwoScoreText;
		private System.Windows.Forms.Label teamTwoScoreLabel;
		private System.Windows.Forms.Label teamTwoName;
		private System.Windows.Forms.Label vsLabel;
		private System.Windows.Forms.Button scoreButton;
	}
}

