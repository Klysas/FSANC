using System;
namespace MyApp
{
    partial class MainForm
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
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

			this.MaximizeBox = false;

			this.FilesCountLabel = new System.Windows.Forms.Label();
			this.DropBox = new System.Windows.Forms.ComboBox();
			this.ClearButton = new System.Windows.Forms.Button();
			this.NameLabel = new System.Windows.Forms.Label();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.RenameFilesButton = new System.Windows.Forms.Button();
			this.LanguageBox = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// FilesCountLabel
			// 
			this.FilesCountLabel.AutoSize = true;
			this.FilesCountLabel.BackColor = System.Drawing.SystemColors.Control;
			this.FilesCountLabel.Cursor = System.Windows.Forms.Cursors.Default;
			this.FilesCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FilesCountLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.FilesCountLabel.Location = new System.Drawing.Point(12, 13);
			this.FilesCountLabel.Name = "FilesCountLabel";
			this.FilesCountLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.FilesCountLabel.Size = new System.Drawing.Size(96, 16);
			this.FilesCountLabel.TabIndex = 0;
			this.FilesCountLabel.Text = "Files loaded: 0";
			// 
			// DropBox
			// 
			this.DropBox.FormattingEnabled = true;
			this.DropBox.Items.AddRange(new object[] {
            MyApp.MainForm.videoType.SERIAL,
            MyApp.MainForm.videoType.FILM});
			this.DropBox.Location = new System.Drawing.Point(151, 12);
			this.DropBox.Name = "DropBox";
			this.DropBox.Size = new System.Drawing.Size(121, 21);
			this.DropBox.TabIndex = 1;
			this.DropBox.SelectedIndex = 0;
			this.LanguageBox.Hide();
			this.DropBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// ClearButton
			// 
			this.ClearButton.Location = new System.Drawing.Point(114, 12);
			this.ClearButton.Name = "ClearButton";
			this.ClearButton.Size = new System.Drawing.Size(31, 21);
			this.ClearButton.TabIndex = 2;
			this.ClearButton.Text = "C";
			this.ClearButton.UseVisualStyleBackColor = true;
			this.ClearButton.Click += new System.EventHandler(this.button1_Click);
			// 
			// NameLabel
			// 
			this.NameLabel.AutoSize = true;
			this.NameLabel.Location = new System.Drawing.Point(13, 53);
			this.NameLabel.Name = "NameLabel";
			this.NameLabel.Size = new System.Drawing.Size(38, 13);
			this.NameLabel.TabIndex = 3;
			this.NameLabel.Text = "Name:";
			// 
			// NameBox
			// 
			this.NameBox.Location = new System.Drawing.Point(58, 50);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(214, 20);
			this.NameBox.TabIndex = 4;
			// 
			// RenameFilesButton
			// 
			this.RenameFilesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RenameFilesButton.Location = new System.Drawing.Point(16, 127);
			this.RenameFilesButton.Name = "RenameFilesButton";
			this.RenameFilesButton.Size = new System.Drawing.Size(257, 23);
			this.RenameFilesButton.TabIndex = 5;
			this.RenameFilesButton.Text = "Rename Files";
			this.RenameFilesButton.UseVisualStyleBackColor = true;
			this.RenameFilesButton.Click += new System.EventHandler(this.RenameFilesButton_Click);
			// 
			// LanguageBox
			// 
			this.LanguageBox.FormattingEnabled = true;
			this.LanguageBox.Items.AddRange(new object[] {
            "EN",
            "LT",
            "EN-Original",
            "LT-Original",
            "EN-Sub",
            "LT-Sub"});
			this.LanguageBox.Location = new System.Drawing.Point(58, 77);
			this.LanguageBox.Name = "LanguageBox";
			this.LanguageBox.Size = new System.Drawing.Size(214, 21);
			this.LanguageBox.TabIndex = 6;
			this.LanguageBox.Text = "Language";
			this.LanguageBox.SelectedIndexChanged += new System.EventHandler(this.LanguageBox_SelectedIndexChanged);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 162);
			this.Controls.Add(this.LanguageBox);
			this.Controls.Add(this.RenameFilesButton);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.NameLabel);
			this.Controls.Add(this.ClearButton);
			this.Controls.Add(this.DropBox);
			this.Controls.Add(this.FilesCountLabel);
			this.Name = "MainForm";
			this.ShowIcon = false;
			this.Text = "Rename F&S";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FilesCountLabel;
        private System.Windows.Forms.ComboBox DropBox;
        private System.Windows.Forms.Button ClearButton;
		private System.Windows.Forms.Label NameLabel;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.Button RenameFilesButton;
		private System.Windows.Forms.ComboBox LanguageBox;
    }
}

