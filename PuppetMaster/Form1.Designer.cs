﻿namespace PuppetMaster
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
            this.serverId = new System.Windows.Forms.TextBox();
            this.serverURL = new System.Windows.Forms.TextBox();
            this.serverMaxFaults = new System.Windows.Forms.TextBox();
            this.serverMinDelay = new System.Windows.Forms.TextBox();
            this.serverMaxDelay = new System.Windows.Forms.TextBox();
            this.clientUsername = new System.Windows.Forms.TextBox();
            this.clientServerURL = new System.Windows.Forms.TextBox();
            this.clientScriptFile = new System.Windows.Forms.TextBox();
            this.locationLocation = new System.Windows.Forms.TextBox();
            this.locationRoom = new System.Windows.Forms.TextBox();
            this.locationCapacity = new System.Windows.Forms.TextBox();
            this.buttonInstantiateServer = new System.Windows.Forms.Button();
            this.buttonInstantiateClient = new System.Windows.Forms.Button();
            this.buttonAddRoom = new System.Windows.Forms.Button();
            this.buttonStatus = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonListLocations = new System.Windows.Forms.Button();
            this.buttonCrashServer = new System.Windows.Forms.Button();
            this.buttonFreezeServer = new System.Windows.Forms.Button();
            this.buttonUnfreezeServer = new System.Windows.Forms.Button();
            this.affectedServerId = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // serverId
            // 
            this.serverId.Location = new System.Drawing.Point(62, 33);
            this.serverId.Name = "serverId";
            this.serverId.Size = new System.Drawing.Size(100, 20);
            this.serverId.TabIndex = 0;
            // 
            // serverURL
            // 
            this.serverURL.Location = new System.Drawing.Point(188, 33);
            this.serverURL.Name = "serverURL";
            this.serverURL.Size = new System.Drawing.Size(100, 20);
            this.serverURL.TabIndex = 1;
            // 
            // serverMaxFaults
            // 
            this.serverMaxFaults.Location = new System.Drawing.Point(306, 34);
            this.serverMaxFaults.Name = "serverMaxFaults";
            this.serverMaxFaults.Size = new System.Drawing.Size(100, 20);
            this.serverMaxFaults.TabIndex = 2;
            // 
            // serverMinDelay
            // 
            this.serverMinDelay.Location = new System.Drawing.Point(420, 33);
            this.serverMinDelay.Name = "serverMinDelay";
            this.serverMinDelay.Size = new System.Drawing.Size(100, 20);
            this.serverMinDelay.TabIndex = 3;
            // 
            // serverMaxDelay
            // 
            this.serverMaxDelay.Location = new System.Drawing.Point(540, 33);
            this.serverMaxDelay.Name = "serverMaxDelay";
            this.serverMaxDelay.Size = new System.Drawing.Size(100, 20);
            this.serverMaxDelay.TabIndex = 4;
            // 
            // clientUsername
            // 
            this.clientUsername.Location = new System.Drawing.Point(62, 113);
            this.clientUsername.Name = "clientUsername";
            this.clientUsername.Size = new System.Drawing.Size(100, 20);
            this.clientUsername.TabIndex = 5;
            // 
            // clientServerURL
            // 
            this.clientServerURL.Location = new System.Drawing.Point(188, 112);
            this.clientServerURL.Name = "clientServerURL";
            this.clientServerURL.Size = new System.Drawing.Size(100, 20);
            this.clientServerURL.TabIndex = 6;
            // 
            // clientScriptFile
            // 
            this.clientScriptFile.Location = new System.Drawing.Point(306, 114);
            this.clientScriptFile.Name = "clientScriptFile";
            this.clientScriptFile.Size = new System.Drawing.Size(100, 20);
            this.clientScriptFile.TabIndex = 7;
            // 
            // locationLocation
            // 
            this.locationLocation.Location = new System.Drawing.Point(62, 191);
            this.locationLocation.Name = "locationLocation";
            this.locationLocation.Size = new System.Drawing.Size(100, 20);
            this.locationLocation.TabIndex = 8;
            // 
            // locationRoom
            // 
            this.locationRoom.Location = new System.Drawing.Point(188, 190);
            this.locationRoom.Name = "locationRoom";
            this.locationRoom.Size = new System.Drawing.Size(100, 20);
            this.locationRoom.TabIndex = 9;
            // 
            // locationCapacity
            // 
            this.locationCapacity.Location = new System.Drawing.Point(306, 192);
            this.locationCapacity.Name = "locationCapacity";
            this.locationCapacity.Size = new System.Drawing.Size(100, 20);
            this.locationCapacity.TabIndex = 10;
            // 
            // buttonInstantiateServer
            // 
            this.buttonInstantiateServer.Location = new System.Drawing.Point(62, 59);
            this.buttonInstantiateServer.Name = "buttonInstantiateServer";
            this.buttonInstantiateServer.Size = new System.Drawing.Size(226, 23);
            this.buttonInstantiateServer.TabIndex = 11;
            this.buttonInstantiateServer.Text = "Instantiate Server";
            this.buttonInstantiateServer.UseVisualStyleBackColor = true;
            this.buttonInstantiateServer.Click += new System.EventHandler(this.buttonInstantiateServer_Click);
            // 
            // buttonInstantiateClient
            // 
            this.buttonInstantiateClient.Location = new System.Drawing.Point(62, 139);
            this.buttonInstantiateClient.Name = "buttonInstantiateClient";
            this.buttonInstantiateClient.Size = new System.Drawing.Size(226, 23);
            this.buttonInstantiateClient.TabIndex = 12;
            this.buttonInstantiateClient.Text = "Instantiate Client";
            this.buttonInstantiateClient.UseVisualStyleBackColor = true;
            // 
            // buttonAddRoom
            // 
            this.buttonAddRoom.Location = new System.Drawing.Point(62, 217);
            this.buttonAddRoom.Name = "buttonAddRoom";
            this.buttonAddRoom.Size = new System.Drawing.Size(226, 23);
            this.buttonAddRoom.TabIndex = 13;
            this.buttonAddRoom.Text = "Add Room";
            this.buttonAddRoom.UseVisualStyleBackColor = true;
            // 
            // buttonStatus
            // 
            this.buttonStatus.Location = new System.Drawing.Point(62, 316);
            this.buttonStatus.Name = "buttonStatus";
            this.buttonStatus.Size = new System.Drawing.Size(161, 23);
            this.buttonStatus.TabIndex = 14;
            this.buttonStatus.Text = "Status";
            this.buttonStatus.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(62, 345);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(560, 213);
            this.richTextBox1.TabIndex = 15;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Server ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "URL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(306, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Max Faults";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(420, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Min Delay";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(540, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Max Delay";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(62, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Username";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(188, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Server URL";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(306, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Script File";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(62, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Location";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(188, 174);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Room";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(306, 174);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Capacity";
            // 
            // buttonListLocations
            // 
            this.buttonListLocations.Location = new System.Drawing.Point(306, 216);
            this.buttonListLocations.Name = "buttonListLocations";
            this.buttonListLocations.Size = new System.Drawing.Size(100, 23);
            this.buttonListLocations.TabIndex = 27;
            this.buttonListLocations.Text = "List Locations";
            this.buttonListLocations.UseVisualStyleBackColor = true;
            // 
            // buttonCrashServer
            // 
            this.buttonCrashServer.Location = new System.Drawing.Point(242, 314);
            this.buttonCrashServer.Name = "buttonCrashServer";
            this.buttonCrashServer.Size = new System.Drawing.Size(100, 23);
            this.buttonCrashServer.TabIndex = 28;
            this.buttonCrashServer.Text = "Crash Server";
            this.buttonCrashServer.UseVisualStyleBackColor = true;
            // 
            // buttonFreezeServer
            // 
            this.buttonFreezeServer.Location = new System.Drawing.Point(351, 314);
            this.buttonFreezeServer.Name = "buttonFreezeServer";
            this.buttonFreezeServer.Size = new System.Drawing.Size(95, 23);
            this.buttonFreezeServer.TabIndex = 29;
            this.buttonFreezeServer.Text = "Freeze Server";
            this.buttonFreezeServer.UseVisualStyleBackColor = true;
            // 
            // buttonUnfreezeServer
            // 
            this.buttonUnfreezeServer.Location = new System.Drawing.Point(453, 314);
            this.buttonUnfreezeServer.Name = "buttonUnfreezeServer";
            this.buttonUnfreezeServer.Size = new System.Drawing.Size(95, 23);
            this.buttonUnfreezeServer.TabIndex = 30;
            this.buttonUnfreezeServer.Text = "Unfreeze Server";
            this.buttonUnfreezeServer.UseVisualStyleBackColor = true;
            // 
            // affectedServerId
            // 
            this.affectedServerId.Location = new System.Drawing.Point(245, 288);
            this.affectedServerId.Name = "affectedServerId";
            this.affectedServerId.Size = new System.Drawing.Size(303, 20);
            this.affectedServerId.TabIndex = 31;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(242, 269);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "Server Id";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 590);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.affectedServerId);
            this.Controls.Add(this.buttonUnfreezeServer);
            this.Controls.Add(this.buttonFreezeServer);
            this.Controls.Add(this.buttonCrashServer);
            this.Controls.Add(this.buttonListLocations);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.buttonStatus);
            this.Controls.Add(this.buttonAddRoom);
            this.Controls.Add(this.buttonInstantiateClient);
            this.Controls.Add(this.buttonInstantiateServer);
            this.Controls.Add(this.locationCapacity);
            this.Controls.Add(this.locationRoom);
            this.Controls.Add(this.locationLocation);
            this.Controls.Add(this.clientScriptFile);
            this.Controls.Add(this.clientServerURL);
            this.Controls.Add(this.clientUsername);
            this.Controls.Add(this.serverMaxDelay);
            this.Controls.Add(this.serverMinDelay);
            this.Controls.Add(this.serverMaxFaults);
            this.Controls.Add(this.serverURL);
            this.Controls.Add(this.serverId);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox serverId;
        private System.Windows.Forms.TextBox serverURL;
        private System.Windows.Forms.TextBox serverMaxFaults;
        private System.Windows.Forms.TextBox serverMinDelay;
        private System.Windows.Forms.TextBox serverMaxDelay;
        private System.Windows.Forms.TextBox clientUsername;
        private System.Windows.Forms.TextBox clientServerURL;
        private System.Windows.Forms.TextBox clientScriptFile;
        private System.Windows.Forms.TextBox locationLocation;
        private System.Windows.Forms.TextBox locationRoom;
        private System.Windows.Forms.TextBox locationCapacity;
        private System.Windows.Forms.Button buttonInstantiateServer;
        private System.Windows.Forms.Button buttonInstantiateClient;
        private System.Windows.Forms.Button buttonAddRoom;
        private System.Windows.Forms.Button buttonStatus;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonListLocations;
        private System.Windows.Forms.Button buttonCrashServer;
        private System.Windows.Forms.Button buttonFreezeServer;
        private System.Windows.Forms.Button buttonUnfreezeServer;
        private System.Windows.Forms.TextBox affectedServerId;
        private System.Windows.Forms.Label label12;
    }
}

