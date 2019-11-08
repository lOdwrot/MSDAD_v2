﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonTypes
{
    public enum MeetingStatus {New, Confirmed, Canceled};
    public class Meeting : MarshalByRefObject
    {
        public string coordinator { get; }
		public string topic { get; }
		public int minimumParticipants { get; }
		public MeetingStatus status { get; }
		public List<String> invited { get; }
		public List<Slot> proposals { get; }
		public List<Vote> votes { get; set; }
		public Slot selectedSlot { get; set; }
		public Room selectedRoom { get; set; }

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
		
        public void submitVotes(string voterName, Slot slot)
        {
			var userVote = votes.Where(v => v.voterName == voterName).FirstOrDefault();
			if (userVote is null)
			{
				votes.Add(new Vote(voterName, new List<Slot> { slot }));
			}
			else
			{
				userVote.slots.Add(slot);
			}
        }

        public bool isClosed()
        {
			return this.status != MeetingStatus.New;
        }
    }

    public class Slot : MarshalByRefObject
	{
        public string date { get; }
        public string location { get; }

        public Slot(string date, string location)
        {
            this.date = date;
            this.location = location;
        }
    }

    public class Room : MarshalByRefObject
	{
        public string name { get; }
		public string location { get; }
		public int capacity { get; }
		public List<string> bookings { get; }

		public Room(string name, string location, int capacity)
        {
            this.name = name;
            this.location = location;
            this.capacity = capacity;
			this.bookings = new List<string>();
        }

		public void bookDate(string date)
		{
			// TODO: check if it already exists
			this.bookings.Add(date);
		}
    }

    public class Vote : MarshalByRefObject
	{
        public string voterName { get; }
        public List<Slot> slots { get; }

        public Vote(string voterName, List<Slot> slots)
        {
            this.voterName = voterName;
            this.slots = slots;
        }
    }
}
