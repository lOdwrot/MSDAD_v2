using CommonTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
	public partial class CreateMeetingForm : Form
	{
		private List<Slot> proposals;
		private List<string> participants;

		public CreateMeetingForm()
		{
			InitializeComponent();

			this.proposals = new List<Slot>();
			this.slotsBox.DataSource = this.proposals;

			this.participants = new List<string>();
			this.participantBox.DataSource = this.participants;
		}

		public string getTopic()
		{
			return this.topicBox.Text;
		}

		public int getMinimumParticipants()
		{
			return (int) this.participantNumberBox.Value;
		}

		public List<Slot> getProposals()
		{
			return proposals;
		}

		public List<string> getInvitedParticipants()
		{
			return participants;
		}

		private void locationBox_TextChanged(object sender, EventArgs e)
		{
			this.addSlotButton.Enabled = this.locationBox.Text.Length > 0;
		}

		private void addSlotButton_Click(object sender, EventArgs e)
		{
			var date = this.dateTimePicker1.Value;
			this.proposals.Add(new Slot(date.Year + "-" + date.Month + "-" + date.Day,
				this.locationBox.Text)
			);

			this.removeSlotButton.Enabled = this.slotsBox.SelectedIndex != -1;
			this.slotsBox.DataSource = this.proposals;
		}

		private void slotsBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.removeSlotButton.Enabled = this.slotsBox.SelectedIndex != -1;
		}

		private void removeSlotButton_Click(object sender, EventArgs e)
		{
			this.proposals.RemoveAt(this.slotsBox.SelectedIndex);
			this.removeSlotButton.Enabled = this.proposals.Count != 0;
			this.slotsBox.DataSource = this.proposals;
		}

		private void participantNameBox_TextChanged(object sender, EventArgs e)
		{
			this.addParticipantButton.Enabled = this.participantBox.Text.Length > 0;
		}

		private void addParticipantButton_Click(object sender, EventArgs e)
		{
			this.participants.Add(this.participantNameBox.Text);

			this.removeParticipantButton.Enabled = this.participantBox.SelectedIndex != -1;
			this.participantBox.DataSource = this.participants;
		}

		private void participantBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.removeParticipantButton.Enabled = this.participantBox.SelectedIndex != -1;
		}

		private void removeParticipantButton_Click(object sender, EventArgs e)
		{
			this.participants.RemoveAt(this.participantBox.SelectedIndex);
			this.removeParticipantButton.Enabled = this.participants.Count != 0;
			this.participantBox.DataSource = this.participants;
		}
	}
}
