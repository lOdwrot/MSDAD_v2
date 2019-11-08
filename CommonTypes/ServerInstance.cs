using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CommonTypes
{
    public class ServerInstance : MarshalByRefObject, IRemoteMachine
	{
		List<Meeting> meetings;
		List<Room> defaultRooms;
		List<string> defaultLocations;

		public ServerInstance()
		{
			this.defaultRooms = new List<Room> {
				new Room("R1", "Lisboa", 10),
				new Room("R2", "Lisboa", 50),
				new Room("R1", "Porto", 5)
			};
			this.defaultLocations = new List<string>
			{
				"Lisboa", "Porto"
			};

			this.meetings = new List<Meeting>();
		}

        public string getStatus()
        {
			return "Alive!";
        }

		public List<Meeting> GetMeetings()
		{
			return this.meetings;
		}

		public bool CreateMeeting(Meeting newMeeting)
		{
			var exists = this.meetings.Where(m => m.topic == newMeeting.topic).Count() != 0;
			if (!exists)
				this.meetings.Add(newMeeting);
			return !exists;
		}

		public bool JoinMeeting(string username, string meetingTopic, Slot slotPicked)
		{
			var meeting = this.meetings.Where(m => m.topic == meetingTopic).FirstOrDefault();
			var userVote = meeting.votes.Where(v => v.voterName == username).FirstOrDefault();
			var alreadyVoted = userVote != null && userVote.slots.Contains(slotPicked);
			if (!alreadyVoted)
				meeting.submitVotes(username, slotPicked);
			return !alreadyVoted;
		}

		public Meeting CloseMeeting(string username, string meetingTopic)
		{
			var meeting = this.meetings.Where(m => m.topic == meetingTopic).FirstOrDefault();
			// meeting can't be already closed
			if (meeting.isClosed())
				return null;

			// there has to be enough participants
			var numParticipants = meeting.votes.Count();
			if (numParticipants < meeting.minimumParticipants)
				return null;

			var usersPerVote = new List<Tuple<Slot, List<string>>>();
			foreach (Vote vote in meeting.votes)
			{
				foreach (Slot slot in vote.slots)
				{
					var item = usersPerVote.Where(t => t.Item1 == slot).FirstOrDefault();
					if (item is null)
						usersPerVote.Add(new Tuple<Slot, List<string>>(slot, new List<string> { vote.voterName }));
					else
						item.Item2.Add(vote.voterName);
				}
			}

			//var allVotedSlots = meeting.votes.SelectMany(v => v.slots);
			//var sortedVotes = allVotedSlots.Distinct().OrderByDescending(cs => allVotedSlots.Where(s => s == cs).Count());
			
			foreach (var slotUsers in usersPerVote)
			{
				var slot = slotUsers.Item1;
				foreach (Room room in defaultRooms.Where(r => r.location == slot.location))
				{
					// if room has enough space
					if (!room.bookings.Contains(slot.date))
					{
						// remove extra users
						if (numParticipants > room.capacity)
						{
							meeting.votes = meeting.votes.Take(room.capacity).ToList();
						}

						// select meeting and return
						meeting.selectedRoom = room;
						meeting.selectedSlot = slot;
						return meeting;
					}
				}
			}
			return null;
		}
	}
}
