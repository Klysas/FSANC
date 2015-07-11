namespace FSANC.Windows
{
	partial class SelectionBox
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
			this.Button_Ok = new System.Windows.Forms.Button();
			this.ListBox_Files = new System.Windows.Forms.ListBox();
			this.Button_Cancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// Button_Ok
			// 
			this.Button_Ok.Enabled = false;
			this.Button_Ok.Location = new System.Drawing.Point(12, 230);
			this.Button_Ok.Name = "Button_Ok";
			this.Button_Ok.Size = new System.Drawing.Size(123, 27);
			this.Button_Ok.TabIndex = 1;
			this.Button_Ok.Text = "Ok";
			this.Button_Ok.UseVisualStyleBackColor = true;
			this.Button_Ok.Click += new System.EventHandler(this.Button_Ok_Click);
			// 
			// ListBox_Files
			// 
			this.ListBox_Files.FormattingEnabled = true;
			this.ListBox_Files.Location = new System.Drawing.Point(12, 12);
			this.ListBox_Files.Name = "ListBox_Files";
			this.ListBox_Files.Size = new System.Drawing.Size(260, 212);
			this.ListBox_Files.TabIndex = 2;
			this.ListBox_Files.SelectedIndexChanged += new System.EventHandler(this.ListBox_Files_SelectedIndexChanged);
			// 
			// Button_Cancel
			// 
			this.Button_Cancel.Location = new System.Drawing.Point(149, 230);
			this.Button_Cancel.Name = "Button_Cancel";
			this.Button_Cancel.Size = new System.Drawing.Size(123, 27);
			this.Button_Cancel.TabIndex = 3;
			this.Button_Cancel.Text = "Cancel";
			this.Button_Cancel.UseVisualStyleBackColor = true;
			this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
			// 
			// SelectionBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 274);
			this.ControlBox = false;
			this.Controls.Add(this.Button_Cancel);
			this.Controls.Add(this.ListBox_Files);
			this.Controls.Add(this.Button_Ok);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "SelectionBox";
			this.ShowIcon = false;
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button Button_Ok;
		private System.Windows.Forms.ListBox ListBox_Files;
		private System.Windows.Forms.Button Button_Cancel;
	}
}