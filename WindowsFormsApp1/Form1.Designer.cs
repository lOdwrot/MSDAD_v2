namespace WindowsFormsApp1
{
	partial class Form1
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.usernameBox = new System.Windows.Forms.TextBox();
			this.usernameLabel = new System.Windows.Forms.Label();
			this.portLabel = new System.Windows.Forms.Label();
			this.portBox = new System.Windows.Forms.TextBox();
			this.registerButton = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.meetingsListBox = new System.Windows.Forms.ListBox();
			this.dateListBox = new System.Windows.Forms.ListBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.meetingsListLabel = new System.Windows.Forms.Label();
			this.dateListLabel = new System.Windows.Forms.Label();
			this.locationListLabel = new System.Windows.Forms.Label();
			this.locationListBox = new System.Windows.Forms.ListBox();
			this.dateNewButton = new System.Windows.Forms.Button();
			this.locationNewButton = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.registerButton);
			this.groupBox1.Controls.Add(this.portLabel);
			this.groupBox1.Controls.Add(this.portBox);
			this.groupBox1.Controls.Add(this.usernameLabel);
			this.groupBox1.Controls.Add(this.usernameBox);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(475, 59);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Registration";
			this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
			// 
			// usernameBox
			// 
			this.usernameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.usernameBox.Location = new System.Drawing.Point(67, 25);
			this.usernameBox.Name = "usernameBox";
			this.usernameBox.Size = new System.Drawing.Size(100, 20);
			this.usernameBox.TabIndex = 0;
			// 
			// usernameLabel
			// 
			this.usernameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.usernameLabel.AutoSize = true;
			this.usernameLabel.Location = new System.Drawing.Point(6, 28);
			this.usernameLabel.Name = "usernameLabel";
			this.usernameLabel.Size = new System.Drawing.Size(55, 13);
			this.usernameLabel.TabIndex = 1;
			this.usernameLabel.Text = "Username";
			// 
			// portLabel
			// 
			this.portLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.portLabel.AutoSize = true;
			this.portLabel.Location = new System.Drawing.Point(199, 28);
			this.portLabel.Name = "portLabel";
			this.portLabel.Size = new System.Drawing.Size(26, 13);
			this.portLabel.TabIndex = 3;
			this.portLabel.Text = "Port";
			// 
			// portBox
			// 
			this.portBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.portBox.Location = new System.Drawing.Point(231, 25);
			this.portBox.Name = "portBox";
			this.portBox.Size = new System.Drawing.Size(100, 20);
			this.portBox.TabIndex = 2;
			// 
			// registerButton
			// 
			this.registerButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.registerButton.Location = new System.Drawing.Point(394, 22);
			this.registerButton.Name = "registerButton";
			this.registerButton.Size = new System.Drawing.Size(75, 20);
			this.registerButton.TabIndex = 4;
			this.registerButton.Text = "Connect";
			this.registerButton.UseVisualStyleBackColor = true;
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(532, 256);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(120, 95);
			this.listBox1.TabIndex = 1;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(12, 12);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
			this.splitContainer1.Size = new System.Drawing.Size(481, 426);
			this.splitContainer1.SplitterDistance = 65;
			this.splitContainer1.TabIndex = 2;
			// 
			// meetingsListBox
			// 
			this.meetingsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.meetingsListBox.FormattingEnabled = true;
			this.meetingsListBox.Location = new System.Drawing.Point(3, 27);
			this.meetingsListBox.Name = "meetingsListBox";
			this.meetingsListBox.Size = new System.Drawing.Size(213, 251);
			this.meetingsListBox.TabIndex = 0;
			// 
			// dateListBox
			// 
			this.dateListBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.dateListBox.FormattingEnabled = true;
			this.dateListBox.Location = new System.Drawing.Point(6, 27);
			this.dateListBox.Name = "dateListBox";
			this.dateListBox.Size = new System.Drawing.Size(107, 173);
			this.dateListBox.TabIndex = 1;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.splitContainer2);
			this.groupBox2.Location = new System.Drawing.Point(3, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(475, 351);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Scheduler";
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(3, 16);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.button3);
			this.splitContainer2.Panel1.Controls.Add(this.meetingsListLabel);
			this.splitContainer2.Panel1.Controls.Add(this.meetingsListBox);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.button1);
			this.splitContainer2.Panel2.Controls.Add(this.button4);
			this.splitContainer2.Panel2.Controls.Add(this.locationNewButton);
			this.splitContainer2.Panel2.Controls.Add(this.dateNewButton);
			this.splitContainer2.Panel2.Controls.Add(this.locationListLabel);
			this.splitContainer2.Panel2.Controls.Add(this.locationListBox);
			this.splitContainer2.Panel2.Controls.Add(this.dateListLabel);
			this.splitContainer2.Panel2.Controls.Add(this.dateListBox);
			this.splitContainer2.Size = new System.Drawing.Size(469, 332);
			this.splitContainer2.SplitterDistance = 219;
			this.splitContainer2.TabIndex = 0;
			// 
			// meetingsListLabel
			// 
			this.meetingsListLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.meetingsListLabel.AutoSize = true;
			this.meetingsListLabel.Location = new System.Drawing.Point(3, 11);
			this.meetingsListLabel.Name = "meetingsListLabel";
			this.meetingsListLabel.Size = new System.Drawing.Size(69, 13);
			this.meetingsListLabel.TabIndex = 2;
			this.meetingsListLabel.Text = "Meetings List";
			// 
			// dateListLabel
			// 
			this.dateListLabel.AutoSize = true;
			this.dateListLabel.Location = new System.Drawing.Point(3, 11);
			this.dateListLabel.Name = "dateListLabel";
			this.dateListLabel.Size = new System.Drawing.Size(49, 13);
			this.dateListLabel.TabIndex = 3;
			this.dateListLabel.Text = "Date List";
			// 
			// locationListLabel
			// 
			this.locationListLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.locationListLabel.AutoSize = true;
			this.locationListLabel.Location = new System.Drawing.Point(126, 11);
			this.locationListLabel.Name = "locationListLabel";
			this.locationListLabel.Size = new System.Drawing.Size(67, 13);
			this.locationListLabel.TabIndex = 5;
			this.locationListLabel.Text = "Location List";
			// 
			// locationListBox
			// 
			this.locationListBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.locationListBox.FormattingEnabled = true;
			this.locationListBox.Location = new System.Drawing.Point(129, 27);
			this.locationListBox.Name = "locationListBox";
			this.locationListBox.Size = new System.Drawing.Size(114, 173);
			this.locationListBox.TabIndex = 4;
			// 
			// dateNewButton
			// 
			this.dateNewButton.Location = new System.Drawing.Point(7, 206);
			this.dateNewButton.Name = "dateNewButton";
			this.dateNewButton.Size = new System.Drawing.Size(106, 23);
			this.dateNewButton.TabIndex = 6;
			this.dateNewButton.Text = "New Date...";
			this.dateNewButton.UseVisualStyleBackColor = true;
			// 
			// locationNewButton
			// 
			this.locationNewButton.Location = new System.Drawing.Point(129, 206);
			this.locationNewButton.Name = "locationNewButton";
			this.locationNewButton.Size = new System.Drawing.Size(114, 23);
			this.locationNewButton.TabIndex = 7;
			this.locationNewButton.Text = "New Location...";
			this.locationNewButton.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(55, 295);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(97, 23);
			this.button3.TabIndex = 3;
			this.button3.Text = "New Meeting...";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(7, 295);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(106, 23);
			this.button4.TabIndex = 8;
			this.button4.Text = "Join Meeting";
			this.button4.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(129, 295);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(114, 23);
			this.button1.TabIndex = 9;
			this.button1.Text = "Close Meeting";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(505, 450);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.listBox1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel1.PerformLayout();
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button registerButton;
		private System.Windows.Forms.Label portLabel;
		private System.Windows.Forms.TextBox portBox;
		private System.Windows.Forms.Label usernameLabel;
		private System.Windows.Forms.TextBox usernameBox;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label meetingsListLabel;
		private System.Windows.Forms.ListBox meetingsListBox;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button locationNewButton;
		private System.Windows.Forms.Button dateNewButton;
		private System.Windows.Forms.Label locationListLabel;
		private System.Windows.Forms.ListBox locationListBox;
		private System.Windows.Forms.Label dateListLabel;
		private System.Windows.Forms.ListBox dateListBox;
		private System.Windows.Forms.Button button1;
	}
}

