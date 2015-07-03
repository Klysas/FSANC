namespace FSANC
{
	partial class ConfirmBox
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

			this.MinimizeBox = false;
			this.MaximizeBox = false;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			
			this.YesButton = new System.Windows.Forms.Button();
			this.NoButton = new System.Windows.Forms.Button();
			this.ConfirmationLabel = new System.Windows.Forms.Label();
			this.FilesList = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// YesButton
			// 
			this.YesButton.Location = new System.Drawing.Point(154, 294);
			this.YesButton.Name = "YesButton";
			this.YesButton.Size = new System.Drawing.Size(75, 23);
			this.YesButton.TabIndex = 0;
			this.YesButton.Text = "Yes";
			this.YesButton.UseVisualStyleBackColor = true;
			this.YesButton.Click += new System.EventHandler(this.Button_Yes_Click);
			// 
			// NoButton
			// 
			this.NoButton.Location = new System.Drawing.Point(235, 294);
			this.NoButton.Name = "NoButton";
			this.NoButton.Size = new System.Drawing.Size(75, 23);
			this.NoButton.TabIndex = 1;
			this.NoButton.Text = "No";
			this.NoButton.UseVisualStyleBackColor = true;
			this.NoButton.Click += new System.EventHandler(this.Button_No_Click);
			// 
			// ConfirmationLabel
			// 
			this.ConfirmationLabel.AutoSize = true;
			this.ConfirmationLabel.Location = new System.Drawing.Point(167, 278);
			this.ConfirmationLabel.Name = "ConfirmationLabel";
			this.ConfirmationLabel.Size = new System.Drawing.Size(127, 13);
			this.ConfirmationLabel.TabIndex = 2;
			this.ConfirmationLabel.Text = "Do you want to proceed?";
			// 
			// FilesList
			// 
			this.FilesList.FormattingEnabled = true;
			this.FilesList.Location = new System.Drawing.Point(13, 13);
			this.FilesList.Name = "FilesList";
			this.FilesList.Size = new System.Drawing.Size(444, 264);
			this.FilesList.TabIndex = 3;
			// 
			// ConfirmBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(469, 325);
			this.Controls.Add(this.FilesList);
			this.Controls.Add(this.ConfirmationLabel);
			this.Controls.Add(this.NoButton);
			this.Controls.Add(this.YesButton);
			this.Name = "ConfirmBox";
			this.ShowIcon = false;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button YesButton;
		private System.Windows.Forms.Button NoButton;
		private System.Windows.Forms.Label ConfirmationLabel;
		private System.Windows.Forms.ListBox FilesList;
	}
}