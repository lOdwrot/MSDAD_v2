namespace Client
{
	partial class CreateMeetingForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.topicBox = new System.Windows.Forms.TextBox();
			this.participantNumberBox = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.locationBox = new System.Windows.Forms.TextBox();
			this.addSlotButton = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.removeSlotButton = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.slotsBox = new System.Windows.Forms.ListBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.participantNameBox = new System.Windows.Forms.TextBox();
			this.addParticipantButton = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.removeParticipantButton = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.participantBox = new System.Windows.Forms.ListBox();
			this.createMeetingButton = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.participantNumberBox)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(78, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Meeting Topic:";
			// 
			// topicBox
			// 
			this.topicBox.Location = new System.Drawing.Point(259, 10);
			this.topicBox.Name = "topicBox";
			this.topicBox.Size = new System.Drawing.Size(166, 20);
			this.topicBox.TabIndex = 1;
			// 
			// participantNumberBox
			// 
			this.participantNumberBox.Location = new System.Drawing.Point(374, 37);
			this.participantNumberBox.Name = "participantNumberBox";
			this.participantNumberBox.Size = new System.Drawing.Size(51, 20);
			this.participantNumberBox.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 39);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(108, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Minimum participants:";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(12, 63);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(417, 219);
			this.tabControl1.TabIndex = 4;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.locationBox);
			this.tabPage1.Controls.Add(this.addSlotButton);
			this.tabPage1.Controls.Add(this.label6);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.dateTimePicker1);
			this.tabPage1.Controls.Add(this.removeSlotButton);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.slotsBox);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(409, 193);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Slots";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// locationBox
			// 
			this.locationBox.Location = new System.Drawing.Point(6, 101);
			this.locationBox.Name = "locationBox";
			this.locationBox.Size = new System.Drawing.Size(200, 20);
			this.locationBox.TabIndex = 10;
			this.locationBox.TextChanged += new System.EventHandler(this.locationBox_TextChanged);
			// 
			// addSlotButton
			// 
			this.addSlotButton.Enabled = false;
			this.addSlotButton.Location = new System.Drawing.Point(72, 162);
			this.addSlotButton.Name = "addSlotButton";
			this.addSlotButton.Size = new System.Drawing.Size(75, 23);
			this.addSlotButton.TabIndex = 9;
			this.addSlotButton.Text = "Add Slot";
			this.addSlotButton.UseVisualStyleBackColor = true;
			this.addSlotButton.Click += new System.EventHandler(this.addSlotButton_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(7, 84);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(51, 13);
			this.label6.TabIndex = 7;
			this.label6.Text = "Location:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(7, 41);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(33, 13);
			this.label5.TabIndex = 5;
			this.label5.Text = "Date:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(7, 7);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "Add New Slot";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(6, 57);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
			this.dateTimePicker1.TabIndex = 3;
			// 
			// removeSlotButton
			// 
			this.removeSlotButton.Enabled = false;
			this.removeSlotButton.Location = new System.Drawing.Point(276, 162);
			this.removeSlotButton.Name = "removeSlotButton";
			this.removeSlotButton.Size = new System.Drawing.Size(92, 23);
			this.removeSlotButton.TabIndex = 2;
			this.removeSlotButton.Text = "Remove Slot";
			this.removeSlotButton.UseVisualStyleBackColor = true;
			this.removeSlotButton.Click += new System.EventHandler(this.removeSlotButton_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(243, 4);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(70, 13);
			this.label3.TabIndex = 1;
			this.label3.Text = "Current Slots:";
			// 
			// slotsBox
			// 
			this.slotsBox.FormattingEnabled = true;
			this.slotsBox.Location = new System.Drawing.Point(243, 22);
			this.slotsBox.Name = "slotsBox";
			this.slotsBox.Size = new System.Drawing.Size(160, 134);
			this.slotsBox.TabIndex = 0;
			this.slotsBox.SelectedIndexChanged += new System.EventHandler(this.slotsBox_SelectedIndexChanged);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.participantNameBox);
			this.tabPage2.Controls.Add(this.addParticipantButton);
			this.tabPage2.Controls.Add(this.label7);
			this.tabPage2.Controls.Add(this.label9);
			this.tabPage2.Controls.Add(this.removeParticipantButton);
			this.tabPage2.Controls.Add(this.label10);
			this.tabPage2.Controls.Add(this.participantBox);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(409, 193);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Participants";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// participantNameBox
			// 
			this.participantNameBox.Location = new System.Drawing.Point(10, 53);
			this.participantNameBox.Name = "participantNameBox";
			this.participantNameBox.Size = new System.Drawing.Size(100, 20);
			this.participantNameBox.TabIndex = 19;
			this.participantNameBox.TextChanged += new System.EventHandler(this.participantNameBox_TextChanged);
			// 
			// addParticipantButton
			// 
			this.addParticipantButton.Enabled = false;
			this.addParticipantButton.Location = new System.Drawing.Point(64, 164);
			this.addParticipantButton.Name = "addParticipantButton";
			this.addParticipantButton.Size = new System.Drawing.Size(94, 23);
			this.addParticipantButton.TabIndex = 18;
			this.addParticipantButton.Text = "Add Participant";
			this.addParticipantButton.UseVisualStyleBackColor = true;
			this.addParticipantButton.Click += new System.EventHandler(this.addParticipantButton_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(7, 36);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(91, 13);
			this.label7.TabIndex = 16;
			this.label7.Text = "Participant Name:";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(7, 9);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(103, 13);
			this.label9.TabIndex = 14;
			this.label9.Text = "Whitelist Participant:";
			// 
			// removeParticipantButton
			// 
			this.removeParticipantButton.Enabled = false;
			this.removeParticipantButton.Location = new System.Drawing.Point(261, 164);
			this.removeParticipantButton.Name = "removeParticipantButton";
			this.removeParticipantButton.Size = new System.Drawing.Size(122, 23);
			this.removeParticipantButton.TabIndex = 12;
			this.removeParticipantButton.Text = "Remove Participant";
			this.removeParticipantButton.UseVisualStyleBackColor = true;
			this.removeParticipantButton.Click += new System.EventHandler(this.removeParticipantButton_Click);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(243, 6);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(65, 13);
			this.label10.TabIndex = 11;
			this.label10.Text = "Participants:";
			// 
			// participantBox
			// 
			this.participantBox.FormattingEnabled = true;
			this.participantBox.Location = new System.Drawing.Point(243, 24);
			this.participantBox.Name = "participantBox";
			this.participantBox.Size = new System.Drawing.Size(160, 134);
			this.participantBox.TabIndex = 10;
			this.participantBox.SelectedIndexChanged += new System.EventHandler(this.participantBox_SelectedIndexChanged);
			// 
			// createMeetingButton
			// 
			this.createMeetingButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.createMeetingButton.Enabled = false;
			this.createMeetingButton.Location = new System.Drawing.Point(262, 288);
			this.createMeetingButton.Name = "createMeetingButton";
			this.createMeetingButton.Size = new System.Drawing.Size(98, 23);
			this.createMeetingButton.TabIndex = 5;
			this.createMeetingButton.Text = "Create Meeting";
			this.createMeetingButton.UseVisualStyleBackColor = true;
			// 
			// button6
			// 
			this.button6.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button6.Location = new System.Drawing.Point(80, 288);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(98, 23);
			this.button6.TabIndex = 6;
			this.button6.Text = "Cancel";
			this.button6.UseVisualStyleBackColor = true;
			// 
			// CreateMeetingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(441, 321);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.createMeetingButton);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.participantNumberBox);
			this.Controls.Add(this.topicBox);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "CreateMeetingForm";
			this.Text = "Create new Meeting";
			((System.ComponentModel.ISupportInitialize)(this.participantNumberBox)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox topicBox;
		private System.Windows.Forms.NumericUpDown participantNumberBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Button addSlotButton;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Button removeSlotButton;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListBox slotsBox;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TextBox participantNameBox;
		private System.Windows.Forms.Button addParticipantButton;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button removeParticipantButton;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ListBox participantBox;
		private System.Windows.Forms.Button createMeetingButton;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.TextBox locationBox;
	}
}