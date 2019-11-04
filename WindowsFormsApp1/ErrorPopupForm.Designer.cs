namespace Client
{
	partial class ErrorPopupForm
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
			this.popupText = new System.Windows.Forms.Label();
			this.popupCloseButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// popupText
			// 
			this.popupText.AutoSize = true;
			this.popupText.Location = new System.Drawing.Point(12, 9);
			this.popupText.Name = "popupText";
			this.popupText.Size = new System.Drawing.Size(66, 13);
			this.popupText.TabIndex = 0;
			this.popupText.Text = "Lorem ipsum";
			// 
			// popupCloseButton
			// 
			this.popupCloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.popupCloseButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.popupCloseButton.Location = new System.Drawing.Point(170, 51);
			this.popupCloseButton.Name = "popupCloseButton";
			this.popupCloseButton.Size = new System.Drawing.Size(61, 23);
			this.popupCloseButton.TabIndex = 1;
			this.popupCloseButton.Text = "OK";
			this.popupCloseButton.UseVisualStyleBackColor = true;
			// 
			// ErrorPopupForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(397, 86);
			this.Controls.Add(this.popupCloseButton);
			this.Controls.Add(this.popupText);
			this.Name = "ErrorPopupForm";
			this.Text = "ErrorPopupForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label popupText;
		private System.Windows.Forms.Button popupCloseButton;
	}
}