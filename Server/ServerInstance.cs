using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CommonTypes;
using System.Threading;

namespace Server
{
    public class ServerInstance : MarshalByRefObject, IServer
	{
		List<Meeting> meetings;
		List<Room> defaultRooms;
		List<string> defaultLocations;
        Dictionary<string, string> otherServers;
        Dictionary<string, string> connectedClients;

        Dictionary<int, Executable> notDelivered;
        int lastSequenceNumber;
        int leaderNumber = 0;

        private string status = "OK";
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
            this.otherServers = new Dictionary<string, string>();
            this.connectedClients = new Dictionary<string, string>();
            this.notDelivered = new Dictionary<int, Executable>();
            this.lastSequenceNumber = 0;
        }

        public void test()
        {
            Console.WriteLine("Server Runing | executed remotely");
        }

        public string testAsync(string param)
        {
            Console.WriteLine("Test Async Function");
            return "Hello async " + param;
        }

        public string getStatus()
        {
            return status;
        }

        public void freeze()
        {
            Console.WriteLine("Server freezed!");
            status = "HALT";
        }

        public void unfreeze()
        {
            Console.WriteLine("Server unfreezed!");
            if (status == "HALT")
            {
                status = "OK";
            }
        }

        public void crash()
        {
            Console.WriteLine("Server Stoped!");
            status = "CRASH";
        }

		

		public List<Meeting> GetMeetings()
		{
			return this.meetings;
		}

		public bool CreateMeeting(Meeting newMeeting)
		{
			var locations = newMeeting.proposals.Select(s => s.location).Distinct().ToList();
			var existingRoomLocations = defaultRooms.Select(r => r.location).Distinct().ToList();
			// make sure meeting is only created if all locations exist
			foreach (string location in locations)
				if (!existingRoomLocations.Contains(location))
					return false;

			var exists = this.meetings.Where(m => m.topic == newMeeting.topic).Count() != 0;
			if (!exists)
				this.meetings.Add(newMeeting);
			return !exists;
		}

		public bool JoinMeeting(string username, string meetingTopic, List<Slot> slotsPicked)
		{
			var meeting = this.meetings
				.Where(m => m.topic == meetingTopic)
				.FirstOrDefault();
			var alreadyVoted = meeting.votes.Where(v => v.voterName == username).Count() > 0;
			if (!alreadyVoted)
				meeting.submitVotes(username, slotsPicked);
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

        public void AddRoom(string location, string roomName, int capacity)
        {
            defaultRooms.Add(new Room(location, roomName, 10));
        }

        public void registerNewServer(String serverId, String serverURL)
        {
            otherServers.Add(serverId, serverURL);
            Console.WriteLine("Registered new server: " + serverId + " | " + serverURL);
        }

        public void registerNewClient(string clientId, string clientURL)
        {
            connectedClients.Add(clientId, clientURL);
            Console.WriteLine("New client connected: " + clientId + " | " + clientURL);
		}

        public HashSet<string> getMyClientsSubset()
        {
            int MAX_RETURNS = 5;
            List<String> clientUrlList = connectedClients.Values.ToList();
            HashSet<string> result = new HashSet<string>();
            int addressessQuantity = MAX_RETURNS < clientUrlList.Count
                ? MAX_RETURNS
                : connectedClients.Count;

            if (MAX_RETURNS >= clientUrlList.Count)
            {
                clientUrlList.ForEach(v => result.Add(v));
                
            } 
            else
            {
                var random = new Random();
                for (int i = 0; i < addressessQuantity; i++)
                {
                    var nextIndex = random.Next(connectedClients.Count);
                    result.Add(clientUrlList[nextIndex]);
                }
            }

            return result;
        }

        public HashSet<string> getAgregatedClientsSubset()
        {
            HashSet<string> result = getMyClientsSubset();
            foreach (string serverURL in otherServers.Values)
            {
				ServerInstance s = (ServerInstance)Activator.GetObject(
					typeof(ServerInstance),
					serverURL
				);
                s.getMyClientsSubset().ToList().ForEach(v => result.Add(v));
            }

            return result;
        }

        
        private void RB_Broadcast(Executable executable, int sequenceNumber)
        {
            //Broadcast to everyone
            foreach (string serverURL in otherServers.Values)
			{
				ServerInstance s = (ServerInstance)Activator.GetObject(
					typeof(ServerInstance),
					serverURL
				);
				s.RB_Deliver(executable,sequenceNumber);
            }
        }

        public Object RB_Deliver(Executable executable, int sequenceNumber)
        {
            //Checks if this sequence number is older than the last executed, and if it is not already in the list of not delivered
            if (sequenceNumber > this.lastSequenceNumber & !this.notDelivered.ContainsKey(sequenceNumber))
            {
                //Add to list so no other "echo" executes this
                this.notDelivered.Add(sequenceNumber, executable);

                //Checks if this sequence number is the next to execute
                while (sequenceNumber != this.lastSequenceNumber + 1)
                {
                    System.Threading.Thread.Sleep(200);
                }
                //Broadcast before executing
                RB_Broadcast(executable, sequenceNumber);

                //Execute the action
                Object output = Deliver(executable);
                this.lastSequenceNumber = sequenceNumber;
                this.notDelivered.Remove(sequenceNumber);
                return output;
                //Execute next action if in memory
                //this.notDelivered.TryGetValue(this.lastSequenceNumber + 1, out Executable nextAction);
                //if (nextAction != null) RB_Deliver(executable, this.lastSequenceNumber + 1);
            }
            return null;
        }

        public Object Request(Executable executable)
        {
            //int sequenceNumber = this.leader.getSequenceNumber();
            otherServers.TryGetValue("s1", out string serverURL);
			ServerInstance leader = null;
			if (!(serverURL is null))
			{
				leader = (ServerInstance)Activator.GetObject(
						typeof(ServerInstance),
						serverURL
					); 
			}
            if (leader == null) leader = this;
            int sequenceNumber = leader.getSequenceNumber();
            return RB_Deliver(executable, sequenceNumber);
        }

        public int getSequenceNumber()
        {
            leaderNumber = leaderNumber + 1;
            return leaderNumber;
        }

        private Object Deliver(Executable executable)
        {
            switch (executable.action)
            {
                case "createMeeting":
                    return this.CreateMeeting(executable.newMeeting);
                case "closeMeeting":
                    return this.CloseMeeting(executable.username, executable.meetingTopic);
                case "joinMeeting":
                    return this.JoinMeeting(executable.username, executable.meetingTopic, executable.slotsPicked);
            }
            return null;
        }

        public List<string> getOtherServerAddresses()
        {
            return this.otherServers.Values.ToList();
        }
    }
}
