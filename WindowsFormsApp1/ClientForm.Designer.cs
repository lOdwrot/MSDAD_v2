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
			this.registerButton = new System.Windows.Forms.Button();
			this.portLabel = new System.Windows.Forms.Label();
			this.usernameLabel = new System.Windows.Forms.Label();
			this.usernameBox = new System.Windows.Forms.TextBox();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.schedulerGroupBox = new System.Windows.Forms.GroupBox();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.button3 = new System.Windows.Forms.Button();
			this.meetingsListLabel = new System.Windows.Forms.Label();
			this.meetingsListBox = new System.Windows.Forms.ListBox();
			this.participantsValueLabel = new System.Windows.Forms.Label();
			this.participantsLabel = new System.Windows.Forms.Label();
			this.coordinatorValueLabel = new System.Windows.Forms.Label();
			this.coordinatorLabel = new System.Windows.Forms.Label();
			this.topicValueLabel = new System.Windows.Forms.Label();
			this.topicLabel = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.slotListLabel = new System.Windows.Forms.Label();
			this.slotListBox = new System.Windows.Forms.ListBox();
			this.portBox = new System.Windows.Forms.NumericUpDown();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.schedulerGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.portBox)).BeginInit();
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
			this.groupBox1.Size = new System.Drawing.Size(475, 59);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Registration";
			// 
			// registerButton
			// 
			this.registerButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.registerButton.Enabled = false;
			this.registerButton.Location = new System.Drawing.Point(394, 25);
			this.registerButton.Name = "registerButton";
			this.registerButton.Size = new System.Drawing.Size(75, 20);
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
			this.portLabel.Location = new System.Drawing.Point(199, 28);
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
			this.splitContainer1.Panel2.Controls.Add(this.schedulerGroupBox);
			this.splitContainer1.Size = new System.Drawing.Size(481, 426);
			this.splitContainer1.SplitterDistance = 65;
			this.splitContainer1.TabIndex = 2;
			// 
			// schedulerGroupBox
			// 
			this.schedulerGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.schedulerGroupBox.Controls.Add(this.splitContainer2);
			this.schedulerGroupBox.Enabled = false;
			this.schedulerGroupBox.Location = new System.Drawing.Point(3, 3);
			this.schedulerGroupBox.Name = "schedulerGroupBox";
			this.schedulerGroupBox.Size = new System.Drawing.Size(475, 351);
			this.schedulerGroupBox.TabIndex = 3;
			this.schedulerGroupBox.TabStop = false;
			this.schedulerGroupBox.Text = "Scheduler";
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
			this.splitContainer2.Panel2.Controls.Add(this.participantsValueLabel);
			this.splitContainer2.Panel2.Controls.Add(this.participantsLabel);
			this.splitContainer2.Panel2.Controls.Add(this.coordinatorValueLabel);
			this.splitContainer2.Panel2.Controls.Add(this.coordinatorLabel);
			this.splitContainer2.Panel2.Controls.Add(this.topicValueLabel);
			this.splitContainer2.Panel2.Controls.Add(this.topicLabel);
			this.splitContainer2.Panel2.Controls.Add(this.button1);
			this.splitContainer2.Panel2.Controls.Add(this.button4);
			this.splitContainer2.Panel2.Controls.Add(this.slotListLabel);
			this.splitContainer2.Panel2.Controls.Add(this.slotListBox);
			this.splitContainer2.Panel2.Enabled = false;
			this.splitContainer2.Size = new System.Drawing.Size(469, 332);
			this.splitContainer2.SplitterDistance = 219;
			this.splitContainer2.TabIndex = 0;
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
			this.meetingsListBox.Location = new System.Drawing.Point(3, 27);
			this.meetingsListBox.Name = "meetingsListBox";
			this.meetingsListBox.Size = new System.Drawing.Size(213, 251);
			this.meetingsListBox.TabIndex = 0;
			// 
			// participantsValueLabel
			// 
			this.participantsValueLabel.AutoSize = true;
			this.participantsValueLabel.Location = new System.Drawing.Point(188, 65);
			this.participantsValueLabel.Name = "participantsValueLabel";
			this.participantsValueLabel.Size = new System.Drawing.Size(55, 13);
			this.participantsValueLabel.TabIndex = 15;
			this.participantsValueLabel.Text = "----------------";
			this.participantsValueLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// participantsLabel
			// 
			this.participantsLabel.AutoSize = true;
			this.participantsLabel.Location = new System.Drawing.Point(7, 65);
			this.participantsLabel.Name = "participantsLabel";
			this.participantsLabel.Size = new System.Drawing.Size(87, 13);
			this.participantsLabel.TabIndex = 14;
			this.participantsLabel.Text = "Min. participants:";
			// 
			// coordinatorValueLabel
			// 
			this.coordinatorValueLabel.AutoSize = true;
			this.coordinatorValueLabel.Location = new System.Drawing.Point(188, 37);
			this.coordinatorValueLabel.Name = "coordinatorValueLabel";
			this.coordinatorValueLabel.Size = new System.Drawing.Size(55, 13);
			this.coordinatorValueLabel.TabIndex = 13;
			this.coordinatorValueLabel.Text = "----------------";
			this.coordinatorValueLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// coordinatorLabel
			// 
			this.coordinatorLabel.AutoSize = true;
			this.coordinatorLabel.Location = new System.Drawing.Point(7, 37);
			this.coordinatorLabel.Name = "coordinatorLabel";
			this.coordinatorLabel.Size = new System.Drawing.Size(64, 13);
			this.coordinatorLabel.TabIndex = 12;
			this.coordinatorLabel.Text = "Coordinator:";
			// 
			// topicValueLabel
			// 
			this.topicValueLabel.AutoSize = true;
			this.topicValueLabel.Location = new System.Drawing.Point(188, 11);
			this.topicValueLabel.Name = "topicValueLabel";
			this.topicValueLabel.Size = new System.Drawing.Size(55, 13);
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
			// button1
			// 
			this.button1.Enabled = false;
			this.button1.Location = new System.Drawing.Point(129, 295);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(114, 23);
			this.button1.TabIndex = 9;
			this.button1.Text = "Close Meeting";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button4
			// 
			this.button4.Enabled = false;
			this.button4.Location = new System.Drawing.Point(7, 295);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(106, 23);
			this.button4.TabIndex = 8;
			this.button4.Text = "Join Meeting";
			this.button4.UseVisualStyleBackColor = true;
			// 
			// slotListLabel
			// 
			this.slotListLabel.AutoSize = true;
			this.slotListLabel.Location = new System.Drawing.Point(7, 114);
			this.slotListLabel.Name = "slotListLabel";
			this.slotListLabel.Size = new System.Drawing.Size(76, 13);
			this.slotListLabel.TabIndex = 3;
			this.slotListLabel.Text = "Available Slots";
			// 
			// slotListBox
			// 
			this.slotListBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.slotListBox.FormattingEnabled = true;
			this.slotListBox.Location = new System.Drawing.Point(5, 130);
			this.slotListBox.Name = "slotListBox";
			this.slotListBox.Size = new System.Drawing.Size(237, 147);
			this.slotListBox.TabIndex = 1;
			// 
			// portBox
			// 
			this.portBox.Location = new System.Drawing.Point(231, 25);
			this.portBox.Name = "portBox";
			this.portBox.Size = new System.Drawing.Size(66, 20);
			this.portBox.TabIndex = 5;
			this.portBox.ValueChanged += new System.EventHandler(this.portBox_ValueChanged);
			// 
			// ClientForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(505, 450);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.listBox1);
			this.Name = "ClientForm";
			this.Text = "Form1";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.schedulerGroupBox.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel1.PerformLayout();
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.portBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button registerButton;
		private System.Windows.Forms.Label portLabel;
		private System.Windows.Forms.Label usernameLabel;
		private System.Windows.Forms.TextBox usernameBox;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.GroupBox schedulerGroupBox;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label meetingsListLabel;
		private System.Windows.Forms.ListBox meetingsListBox;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Label slotListLabel;
		private System.Windows.Forms.ListBox slotListBox;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label participantsValueLabel;
		private System.Windows.Forms.Label participantsLabel;
		private System.Windows.Forms.Label coordinatorValueLabel;
		private System.Windows.Forms.Label coordinatorLabel;
		private System.Windows.Forms.Label topicValueLabel;
		private System.Windows.Forms.Label topicLabel;
		private System.Windows.Forms.NumericUpDown portBox;
	}
}

