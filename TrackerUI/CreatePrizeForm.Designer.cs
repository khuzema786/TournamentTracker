
using System;

namespace TrackerUI
{
	partial class CreatePrizeForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreatePrizeForm));
			this.prizeHeader = new System.Windows.Forms.Label();
			this.placeNumberText = new System.Windows.Forms.TextBox();
			this.placeNumberLabel = new System.Windows.Forms.Label();
			this.placeNameText = new System.Windows.Forms.TextBox();
			this.placeNameLabel = new System.Windows.Forms.Label();
			this.prizeAmountText = new System.Windows.Forms.TextBox();
			this.prizeAmountLabel = new System.Windows.Forms.Label();
			this.prizePercentageText = new System.Windows.Forms.TextBox();
			this.prizePercentLabel = new System.Windows.Forms.Label();
			this.orLabel = new System.Windows.Forms.Label();
			this.createPrizeButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// prizeHeader
			// 
			this.prizeHeader.AutoSize = true;
			this.prizeHeader.BackColor = System.Drawing.Color.Transparent;
			this.prizeHeader.Font = new System.Drawing.Font("SF Pro Display", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.prizeHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
			this.prizeHeader.Location = new System.Drawing.Point(12, 21);
			this.prizeHeader.Name = "prizeHeader";
			this.prizeHeader.Size = new System.Drawing.Size(178, 35);
			this.prizeHeader.TabIndex = 19;
			this.prizeHeader.Text = "Create Prize";
			// 
			// placeNumberText
			// 
			this.placeNumberText.Location = new System.Drawing.Point(182, 82);
			this.placeNumberText.Name = "placeNumberText";
			this.placeNumberText.Size = new System.Drawing.Size(123, 21);
			this.placeNumberText.TabIndex = 21;
			// 
			// placeNumberLabel
			// 
			this.placeNumberLabel.AutoSize = true;
			this.placeNumberLabel.BackColor = System.Drawing.Color.Transparent;
			this.placeNumberLabel.Font = new System.Drawing.Font("SF Pro Display", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.placeNumberLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
			this.placeNumberLabel.Location = new System.Drawing.Point(17, 78);
			this.placeNumberLabel.Name = "placeNumberLabel";
			this.placeNumberLabel.Size = new System.Drawing.Size(137, 25);
			this.placeNumberLabel.TabIndex = 20;
			this.placeNumberLabel.Text = "Place Number";
			// 
			// placeNameText
			// 
			this.placeNameText.Location = new System.Drawing.Point(182, 127);
			this.placeNameText.Name = "placeNameText";
			this.placeNameText.Size = new System.Drawing.Size(123, 21);
			this.placeNameText.TabIndex = 23;
			// 
			// placeNameLabel
			// 
			this.placeNameLabel.AutoSize = true;
			this.placeNameLabel.BackColor = System.Drawing.Color.Transparent;
			this.placeNameLabel.Font = new System.Drawing.Font("SF Pro Display", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.placeNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
			this.placeNameLabel.Location = new System.Drawing.Point(17, 123);
			this.placeNameLabel.Name = "placeNameLabel";
			this.placeNameLabel.Size = new System.Drawing.Size(119, 25);
			this.placeNameLabel.TabIndex = 22;
			this.placeNameLabel.Text = "Place Name";
			// 
			// prizeAmountText
			// 
			this.prizeAmountText.Location = new System.Drawing.Point(182, 171);
			this.prizeAmountText.Name = "prizeAmountText";
			this.prizeAmountText.Size = new System.Drawing.Size(123, 21);
			this.prizeAmountText.TabIndex = 25;
			this.prizeAmountText.Text = "0";
			// 
			// prizeAmountLabel
			// 
			this.prizeAmountLabel.AutoSize = true;
			this.prizeAmountLabel.BackColor = System.Drawing.Color.Transparent;
			this.prizeAmountLabel.Font = new System.Drawing.Font("SF Pro Display", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.prizeAmountLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
			this.prizeAmountLabel.Location = new System.Drawing.Point(17, 167);
			this.prizeAmountLabel.Name = "prizeAmountLabel";
			this.prizeAmountLabel.Size = new System.Drawing.Size(128, 25);
			this.prizeAmountLabel.TabIndex = 24;
			this.prizeAmountLabel.Text = "Prize Amount";
			// 
			// prizePercentageText
			// 
			this.prizePercentageText.Location = new System.Drawing.Point(182, 257);
			this.prizePercentageText.Name = "prizePercentageText";
			this.prizePercentageText.Size = new System.Drawing.Size(123, 21);
			this.prizePercentageText.TabIndex = 27;
			this.prizePercentageText.Text = "0";
			// 
			// prizePercentLabel
			// 
			this.prizePercentLabel.AutoSize = true;
			this.prizePercentLabel.BackColor = System.Drawing.Color.Transparent;
			this.prizePercentLabel.Font = new System.Drawing.Font("SF Pro Display", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.prizePercentLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
			this.prizePercentLabel.Location = new System.Drawing.Point(17, 253);
			this.prizePercentLabel.Name = "prizePercentLabel";
			this.prizePercentLabel.Size = new System.Drawing.Size(159, 25);
			this.prizePercentLabel.TabIndex = 26;
			this.prizePercentLabel.Text = "Prize Percentage";
			// 
			// orLabel
			// 
			this.orLabel.AutoSize = true;
			this.orLabel.BackColor = System.Drawing.Color.Transparent;
			this.orLabel.Font = new System.Drawing.Font("SF Pro Display", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.orLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
			this.orLabel.Location = new System.Drawing.Point(135, 211);
			this.orLabel.Name = "orLabel";
			this.orLabel.Size = new System.Drawing.Size(55, 25);
			this.orLabel.TabIndex = 28;
			this.orLabel.Text = "- or -";
			// 
			// createPrizeButton
			// 
			this.createPrizeButton.BackColor = System.Drawing.Color.White;
			this.createPrizeButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.createPrizeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
			this.createPrizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
			this.createPrizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.createPrizeButton.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.createPrizeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
			this.createPrizeButton.Location = new System.Drawing.Point(81, 314);
			this.createPrizeButton.Name = "createPrizeButton";
			this.createPrizeButton.Size = new System.Drawing.Size(158, 32);
			this.createPrizeButton.TabIndex = 32;
			this.createPrizeButton.Text = "Create Prize";
			this.createPrizeButton.UseVisualStyleBackColor = false;
			this.createPrizeButton.Click += new System.EventHandler(this.createPrizeButton_Click);
			// 
			// CreatePrizeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(329, 368);
			this.Controls.Add(this.createPrizeButton);
			this.Controls.Add(this.orLabel);
			this.Controls.Add(this.prizePercentageText);
			this.Controls.Add(this.prizePercentLabel);
			this.Controls.Add(this.prizeAmountText);
			this.Controls.Add(this.prizeAmountLabel);
			this.Controls.Add(this.placeNameText);
			this.Controls.Add(this.placeNameLabel);
			this.Controls.Add(this.placeNumberText);
			this.Controls.Add(this.placeNumberLabel);
			this.Controls.Add(this.prizeHeader);
			this.Font = new System.Drawing.Font("SF Pro Display", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "CreatePrizeForm";
			this.Text = "Create Prize Form";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

        #endregion

        private System.Windows.Forms.Label prizeHeader;
		private System.Windows.Forms.TextBox placeNumberText;
		private System.Windows.Forms.Label placeNumberLabel;
		private System.Windows.Forms.TextBox placeNameText;
		private System.Windows.Forms.Label placeNameLabel;
		private System.Windows.Forms.TextBox prizeAmountText;
		private System.Windows.Forms.Label prizeAmountLabel;
		private System.Windows.Forms.TextBox prizePercentageText;
		private System.Windows.Forms.Label prizePercentLabel;
		private System.Windows.Forms.Label orLabel;
		private System.Windows.Forms.Button createPrizeButton;
	}
}