using System;
using System.Collections.Generic;

namespace CommonTypes
{
    public enum MeetingStatus {New, Confirmed, Canceled};
    public class Meeting
    {
        public string coordinator { get; }
		public string topic { get; }
		public int minimumParticipants { get; }
		public MeetingStatus status { get; }
		public List<String> invited { get; }
		public List<Slot> proposals { get; }
		public List<Vote> votes { get; }
		public Slot selectedSlot { get; }

		public Meeting(string coordinator, string topic, int minimumParticipants, List<Slot> proposals, List<String> invited)
        {
            this.coordinator = coordinator;
            this.topic = topic;
            this.minimumParticipants = minimumParticipants;
            this.invited = invited;
            this.proposals = proposals;
            this.invited = invited;

            this.votes = new List<Vote>();
            this.status = MeetingStatus.New;
        }

		// TODO: should users only be able to vote on one slot? PDF is unclear about this
        public void submitVotes(string voterName, List<Slot> slots)
        {
            foreach(Slot s in slots)
            {
                votes.Add(new Vote(voterName, s));
            }
        }

        public void closeVoting()
        {
            throw new NotImplementedException();
        }
    }

    public class Slot
    {
        string date;
        Location location;

        public Slot(string date, Location location)
        {
            this.date = date;
            this.location = location;
        }
    }

    public class Location
    {
        string name;
        string room;
        string capacity;

        public Location(string name, string room, string capacity)
        {
            this.name = name;
            this.room = room;
            this.capacity = capacity;
        }

    }

    public class Vote
    {
        string voterName;
        Slot slot;

        public Vote(string voterName, Slot slot)
        {
            this.voterName = voterName;
            this.slot = slot;
        }
    }
}
