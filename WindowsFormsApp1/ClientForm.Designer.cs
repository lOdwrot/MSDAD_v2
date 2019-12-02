namespace Client
{
	partial class ClientForm
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
			this.portBox = new System.Windows.Forms.NumericUpDown();
			this.registerButton = new System.Windows.Forms.Button();
			this.portLabel = new System.Windows.Forms.Label();
			this.usernameLabel = new System.Windows.Forms.Label();
			this.usernameBox = new System.Windows.Forms.TextBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.debugBox = new System.Windows.Forms.GroupBox();
			this.debugButton = new System.Windows.Forms.Button();
			this.debugLabel = new System.Windows.Forms.Label();
			this.schedulerGroupBox = new System.Windows.Forms.GroupBox();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.refreshList = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.meetingsListLabel = new System.Windows.Forms.Label();
			this.meetingsListBox = new System.Windows.Forms.ListBox();
			this.statusValueLabel = new System.Windows.Forms.Label();
			this.statusLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.participantsListBox = new System.Windows.Forms.ListBox();
			this.participantsValueLabel = new System.Windows.Forms.Label();
			this.participantsLabel = new System.Windows.Forms.Label();
			this.coordinatorValueLabel = new System.Windows.Forms.Label();
			this.coordinatorLabel = new System.Windows.Forms.Label();
			this.topicValueLabel = new System.Windows.Forms.Label();
			this.topicLabel = new System.Windows.Forms.Label();
			this.closeMeetingButton = new System.Windows.Forms.Button();
			this.joinMeetingButton = new System.Windows.Forms.Button();
			this.slotListLabel = new System.Windows.Forms.Label();
			this.slotListBox = new System.Windows.Forms.ListBox();
			this.listKnownClientsButton = new System.Windows.Forms.Button();
			this.clearLogsButton = new System.Windows.Forms.Button();
			this.logsTextBox = new System.Windows.Forms.RichTextBox();
			this.listServers = new System.Windows.Forms.Button();
			this.debugAllButton = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.portBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.debugBox.SuspendLayout();
			this.schedulerGroupBox.SuspendLayout();
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
			this.groupBox1.Controls.Add(this.portBox);
			this.groupBox1.Controls.Add(this.registerButton);
			this.groupBox1.Controls.Add(this.portLabel);
			this.groupBox1.Controls.Add(this.usernameLabel);
			this.groupBox1.Controls.Add(this.usernameBox);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(381, 60);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Registration";
			// 
			// portBox
			// 
			this.portBox.Location = new System.Drawing.Point(219, 25);
			this.portBox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
			this.portBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.portBox.Name = "portBox";
			this.portBox.Size = new System.Drawing.Size(66, 20);
			this.portBox.TabIndex = 5;
			this.portBox.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this.portBox.ValueChanged += new System.EventHandler(this.portBox_ValueChanged);
			// 
			// registerButton
			// 
			this.registerButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.registerButton.Enabled = false;
			this.registerButton.Location = new System.Drawing.Point(300, 25);
			this.registerButton.Name = "registerButton";
			this.registerButton.Size = new System.Drawing.Size(75, 21);
			this.registerButton.TabIndex = 4;
			this.registerButton.Text = "Connect";
			this.registerButton.UseVisualStyleBackColor = true;
			this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
			// 
			// portLabel
			// 
			this.portLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.portLabel.AutoSize = true;
			this.portLabel.Location = new System.Drawing.Point(187, 29);
			this.portLabel.Name = "portLabel";
			this.portLabel.Size = new System.Drawing.Size(26, 13);
			this.portLabel.TabIndex = 3;
			this.portLabel.Text = "Port";
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
			// usernameBox
			// 
			this.usernameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.usernameBox.Location = new System.Drawing.Point(67, 25);
			this.usernameBox.Name = "usernameBox";
			this.usernameBox.Size = new System.Drawing.Size(100, 20);
			this.usernameBox.TabIndex = 0;
			this.usernameBox.TextChanged += new System.EventHandler(this.usernameBox_TextChanged);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(12, 12);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.debugBox);
			this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.schedulerGroupBox);
			this.splitContainer1.Size = new System.Drawing.Size(526, 434);
			this.splitContainer1.SplitterDistance = 66;
			this.splitContainer1.TabIndex = 2;
			// 
			// debugBox
			// 
			this.debugBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.debugBox.Controls.Add(this.debugAllButton);
			this.debugBox.Controls.Add(this.debugButton);
			this.debugBox.Controls.Add(this.debugLabel);
			this.debugBox.Enabled = false;
			this.debugBox.Location = new System.Drawing.Point(390, 3);
			this.debugBox.Name = "debugBox";
			this.debugBox.Size = new System.Drawing.Size(133, 60);
			this.debugBox.TabIndex = 6;
			this.debugBox.TabStop = false;
			this.debugBox.Text = "Debug";
			// 
			// debugButton
			// 
			this.debugButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.debugButton.Enabled = false;
			this.debugButton.Location = new System.Drawing.Point(6, 33);
			this.debugButton.Name = "debugButton";
			this.debugButton.Size = new System.Drawing.Size(55, 21);
			this.debugButton.TabIndex = 4;
			this.debugButton.Text = "Next";
			this.debugButton.UseVisualStyleBackColor = true;
			this.debugButton.Click += new System.EventHandler(this.debugButton_Click);
			// 
			// debugLabel
			// 
			this.debugLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.debugLabel.AutoEllipsis = true;
			this.debugLabel.Location = new System.Drawing.Point(6, 16);
			this.debugLabel.Name = "debugLabel";
			this.debugLabel.Size = new System.Drawing.Size(124, 14);
			this.debugLabel.TabIndex = 1;
			this.debugLabel.Text = "--";
			// 
			// schedulerGroupBox
			// 
			this.schedulerGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.schedulerGroupBox.Controls.Add(this.splitContainer2);
			this.schedulerGroupBox.Enabled = false;
			this.schedulerGroupBox.Location = new System.Drawing.Point(3, 3);
			this.schedulerGroupBox.Name = "schedulerGroupBox";
			this.schedulerGroupBox.Size = new System.Drawing.Size(520, 341);
			this.schedulerGroupBox.TabIndex = 3;
			this.schedulerGroupBox.TabStop = false;
			this.schedulerGroupBox.Text = "Scheduler";
			// 
			// splitContainer2
			// 
			this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer2.Location = new System.Drawing.Point(3, 16);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.refreshList);
			this.splitContainer2.Panel1.Controls.Add(this.button3);
			this.splitContainer2.Panel1.Controls.Add(this.meetingsListLabel);
			this.splitContainer2.Panel1.Controls.Add(this.meetingsListBox);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.statusValueLabel);
			this.splitContainer2.Panel2.Controls.Add(this.statusLabel);
			this.splitContainer2.Panel2.Controls.Add(this.label1);
			this.splitContainer2.Panel2.Controls.Add(this.participantsListBox);
			this.splitContainer2.Panel2.Controls.Add(this.participantsValueLabel);
			this.splitContainer2.Panel2.Controls.Add(this.participantsLabel);
			this.splitContainer2.Panel2.Controls.Add(this.coordinatorValueLabel);
			this.splitContainer2.Panel2.Controls.Add(this.coordinatorLabel);
			this.splitContainer2.Panel2.Controls.Add(this.topicValueLabel);
			this.splitContainer2.Panel2.Controls.Add(this.topicLabel);
			this.splitContainer2.Panel2.Controls.Add(this.closeMeetingButton);
			this.splitContainer2.Panel2.Controls.Add(this.joinMeetingButton);
			this.splitContainer2.Panel2.Controls.Add(this.slotListLabel);
			this.splitContainer2.Panel2.Controls.Add(this.slotListBox);
			this.splitContainer2.Panel2.Enabled = false;
			this.splitContainer2.Size = new System.Drawing.Size(514, 332);
			this.splitContainer2.SplitterDistance = 247;
			this.splitContainer2.TabIndex = 0;
			// 
			// refreshList
			// 
			this.refreshList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.refreshList.Location = new System.Drawing.Point(169, 6);
			this.refreshList.Name = "refreshList";
			this.refreshList.Size = new System.Drawing.Size(75, 23);
			this.refreshList.TabIndex = 4;
			this.refreshList.Text = "Refresh List";
			this.refreshList.UseVisualStyleBackColor = true;
			this.refreshList.Click += new System.EventHandler(this.refreshList_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(67, 295);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(97, 23);
			this.button3.TabIndex = 3;
			this.button3.Text = "New Meeting...";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
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
			// meetingsListBox
			// 
			this.meetingsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.meetingsListBox.FormattingEnabled = true;
			this.meetingsListBox.Location = new System.Drawing.Point(3, 35);
			this.meetingsListBox.Name = "meetingsListBox";
			this.meetingsListBox.Size = new System.Drawing.Size(241, 251);
			this.meetingsListBox.TabIndex = 0;
			this.meetingsListBox.SelectedIndexChanged += new System.EventHandler(this.meetingsListBox_SelectedIndexChanged);
			// 
			// statusValueLabel
			// 
			this.statusValueLabel.AutoEllipsis = true;
			this.statusValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.statusValueLabel.Location = new System.Drawing.Point(182, 66);
			this.statusValueLabel.Name = "statusValueLabel";
			this.statusValueLabel.Size = new System.Drawing.Size(75, 13);
			this.statusValueLabel.TabIndex = 19;
			this.statusValueLabel.Text = "----------------";
			this.statusValueLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// statusLabel
			// 
			this.statusLabel.AutoSize = true;
			this.statusLabel.Location = new System.Drawing.Point(7, 66);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(40, 13);
			this.statusLabel.TabIndex = 18;
			this.statusLabel.Text = "Status:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 101);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 13);
			this.label1.TabIndex = 17;
			this.label1.Text = "Participants:";
			// 
			// participantsListBox
			// 
			this.participantsListBox.FormattingEnabled = true;
			this.participantsListBox.Location = new System.Drawing.Point(7, 117);
			this.participantsListBox.Name = "participantsListBox";
			this.participantsListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
			this.participantsListBox.Size = new System.Drawing.Size(235, 56);
			this.participantsListBox.TabIndex = 16;
			// 
			// participantsValueLabel
			// 
			this.participantsValueLabel.AutoEllipsis = true;
			this.participantsValueLabel.Location = new System.Drawing.Point(156, 37);
			this.participantsValueLabel.Name = "participantsValueLabel";
			this.participantsValueLabel.Size = new System.Drawing.Size(101, 13);
			this.participantsValueLabel.TabIndex = 15;
			this.participantsValueLabel.Text = "----------------";
			this.participantsValueLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// participantsLabel
			// 
			this.participantsLabel.AutoSize = true;
			this.participantsLabel.Location = new System.Drawing.Point(7, 37);
			this.participantsLabel.Name = "participantsLabel";
			this.participantsLabel.Size = new System.Drawing.Size(87, 13);
			this.participantsLabel.TabIndex = 14;
			this.participantsLabel.Text = "Min. participants:";
			// 
			// coordinatorValueLabel
			// 
			this.coordinatorValueLabel.AutoEllipsis = true;
			this.coordinatorValueLabel.Location = new System.Drawing.Point(156, 24);
			this.coordinatorValueLabel.Name = "coordinatorValueLabel";
			this.coordinatorValueLabel.Size = new System.Drawing.Size(101, 15);
			this.coordinatorValueLabel.TabIndex = 13;
			this.coordinatorValueLabel.Text = "----------------";
			this.coordinatorValueLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// coordinatorLabel
			// 
			this.coordinatorLabel.AutoSize = true;
			this.coordinatorLabel.Location = new System.Drawing.Point(7, 24);
			this.coordinatorLabel.Name = "coordinatorLabel";
			this.coordinatorLabel.Size = new System.Drawing.Size(64, 13);
			this.coordinatorLabel.TabIndex = 12;
			this.coordinatorLabel.Text = "Coordinator:";
			// 
			// topicValueLabel
			// 
			this.topicValueLabel.AutoEllipsis = true;
			this.topicValueLabel.Location = new System.Drawing.Point(153, 11);
			this.topicValueLabel.Name = "topicValueLabel";
			this.topicValueLabel.Size = new System.Drawing.Size(104, 13);
			this.topicValueLabel.TabIndex = 11;
			this.topicValueLabel.Text = "----------------";
			this.topicValueLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// topicLabel
			// 
			this.topicLabel.AutoSize = true;
			this.topicLabel.Location = new System.Drawing.Point(7, 11);
			this.topicLabel.Name = "topicLabel";
			this.topicLabel.Size = new System.Drawing.Size(37, 13);
			this.topicLabel.TabIndex = 10;
			this.topicLabel.Text = "Topic:";
			// 
			// closeMeetingButton
			// 
			this.closeMeetingButton.Enabled = false;
			this.closeMeetingButton.Location = new System.Drawing.Point(129, 295);
			this.closeMeetingButton.Name = "closeMeetingButton";
			this.closeMeetingButton.Size = new System.Drawing.Size(114, 23);
			this.closeMeetingButton.TabIndex = 9;
			this.closeMeetingButton.Text = "Close Meeting";
			this.closeMeetingButton.UseVisualStyleBackColor = true;
			this.closeMeetingButton.Click += new System.EventHandler(this.closeMeetingButton_Click);
			// 
			// joinMeetingButton
			// 
			this.joinMeetingButton.Enabled = false;
			this.joinMeetingButton.Location = new System.Drawing.Point(7, 295);
			this.joinMeetingButton.Name = "joinMeetingButton";
			this.joinMeetingButton.Size = new System.Drawing.Size(106, 23);
			this.joinMeetingButton.TabIndex = 8;
			this.joinMeetingButton.Text = "Join Meeting";
			this.joinMeetingButton.UseVisualStyleBackColor = true;
			this.joinMeetingButton.Click += new System.EventHandler(this.joinMeetingButton_Click);
			// 
			// slotListLabel
			// 
			this.slotListLabel.AutoSize = true;
			this.slotListLabel.Location = new System.Drawing.Point(7, 187);
			this.slotListLabel.Name = "slotListLabel";
			this.slotListLabel.Size = new System.Drawing.Size(79, 13);
			this.slotListLabel.TabIndex = 3;
			this.slotListLabel.Text = "Available Slots:";
			// 
			// slotListBox
			// 
			this.slotListBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.slotListBox.FormattingEnabled = true;
			this.slotListBox.Location = new System.Drawing.Point(7, 203);
			this.slotListBox.Name = "slotListBox";
			this.slotListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.slotListBox.Size = new System.Drawing.Size(237, 82);
			this.slotListBox.TabIndex = 1;
			this.slotListBox.SelectedIndexChanged += new System.EventHandler(this.slotListBox_SelectedIndexChanged);
			// 
			// listKnownClientsButton
			// 
			this.listKnownClientsButton.Location = new System.Drawing.Point(428, 494);
			this.listKnownClientsButton.Name = "listKnownClientsButton";
			this.listKnownClientsButton.Size = new System.Drawing.Size(110, 23);
			this.listKnownClientsButton.TabIndex = 0;
			this.listKnownClientsButton.Text = "List Known Clients";
			this.listKnownClientsButton.Click += new System.EventHandler(this.listKnownClientsButton_Click_1);
			// 
			// clearLogsButton
			// 
			this.clearLogsButton.Location = new System.Drawing.Point(428, 523);
			this.clearLogsButton.Name = "clearLogsButton";
			this.clearLogsButton.Size = new System.Drawing.Size(110, 23);
			this.clearLogsButton.TabIndex = 1;
			this.clearLogsButton.Text = "Clear Log";
			this.clearLogsButton.Click += new System.EventHandler(this.clearLogsButton_Click_1);
			// 
			// logsTextBox
			// 
			this.logsTextBox.Location = new System.Drawing.Point(15, 452);
			this.logsTextBox.Name = "logsTextBox";
			this.logsTextBox.Size = new System.Drawing.Size(407, 96);
			this.logsTextBox.TabIndex = 2;
			this.logsTextBox.Text = "";
			// 
			// listServers
			// 
			this.listServers.Location = new System.Drawing.Point(431, 465);
			this.listServers.Name = "listServers";
			this.listServers.Size = new System.Drawing.Size(107, 23);
			this.listServers.TabIndex = 3;
			this.listServers.Text = "List Servers";
			this.listServers.UseVisualStyleBackColor = true;
			this.listServers.Click += new System.EventHandler(this.listServers_Click);
			// 
			// debugAllButton
			// 
			this.debugAllButton.Enabled = false;
			this.debugAllButton.Location = new System.Drawing.Point(67, 33);
			this.debugAllButton.Name = "debugAllButton";
			this.debugAllButton.Size = new System.Drawing.Size(60, 21);
			this.debugAllButton.TabIndex = 5;
			this.debugAllButton.Text = "Run All";
			this.debugAllButton.UseVisualStyleBackColor = true;
			this.debugAllButton.Click += new System.EventHandler(this.debugAllButton_Click);
			// 
			// ClientForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(550, 558);
			this.Controls.Add(this.listServers);
			this.Controls.Add(this.clearLogsButton);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.listKnownClientsButton);
			this.Controls.Add(this.logsTextBox);
			this.Name = "ClientForm";
			this.Text = "Client";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.portBox)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.debugBox.ResumeLayout(false);
			this.schedulerGroupBox.ResumeLayout(false);
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
		private System.Windows.Forms.Label usernameLabel;
		private System.Windows.Forms.TextBox usernameBox;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.GroupBox schedulerGroupBox;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label meetingsListLabel;
		private System.Windows.Forms.ListBox meetingsListBox;
		private System.Windows.Forms.Button joinMeetingButton;
		private System.Windows.Forms.Label slotListLabel;
		private System.Windows.Forms.ListBox slotListBox;
		private System.Windows.Forms.Button closeMeetingButton;
		private System.Windows.Forms.Label participantsValueLabel;
		private System.Windows.Forms.Label participantsLabel;
		private System.Windows.Forms.Label coordinatorValueLabel;
		private System.Windows.Forms.Label coordinatorLabel;
		private System.Windows.Forms.Label topicValueLabel;
		private System.Windows.Forms.Label topicLabel;
		private System.Windows.Forms.NumericUpDown portBox;
		private System.Windows.Forms.GroupBox debugBox;
		private System.Windows.Forms.Button debugButton;
		private System.Windows.Forms.Label debugLabel;
		private System.Windows.Forms.Button refreshList;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox participantsListBox;
        private System.Windows.Forms.Button listKnownClientsButton;
        private System.Windows.Forms.Button clearLogsButton;
        private System.Windows.Forms.RichTextBox logsTextBox;
        private System.Windows.Forms.Button listServers;
		private System.Windows.Forms.Label statusValueLabel;
		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.Button debugAllButton;
	}
}

