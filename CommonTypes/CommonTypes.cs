using System;
using System.Collections.Generic;

namespace CommonTypes
{
    public enum MeetingStatus {New, Confirmed, Canceled};
    public class Meeting
    {
        private string coordinator;
        private string topic;
        private int minimumParticipants;
        private MeetingStatus status;
        private List<String> invited;
        private List<Slot> proposals;
        private List<Vote> votes;
        private Slot selectedSlot;

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
