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
		List<String> defaultLocations;
        Dictionary<String, ServerInstance> otherServers;
        Dictionary<String, String> connectedClientsURLs;
        String serverId;

        List<Executable> notDelivered;
        Dictionary<String, int> vector_clock;
        int my_clock = 0;
        int last_to_sn;
        String leader;
        
        //Leader Variables
        int to_sn = 0;

        private string status = "OK";
        public ServerInstance(String serverId)
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
            this.otherServers = new Dictionary<String, ServerInstance>();
            this.connectedClientsURLs = new Dictionary<String, String>();
            this.notDelivered = new List<Executable>();
            this.serverId = serverId;
            this.vector_clock = new Dictionary<String, int>();
            this.vector_clock.Add(this.serverId, 0);
            this.last_to_sn = 0;
            this.leader = "s1";
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
            status = "HALT";
        }

        public void unfreeze()
        {
            if (status == "HALT")
            {
                status = "OK";
            }
        }

        public void crash()
        {
            status = "CRASH";
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
			var meeting = this.meetings
				.Where(m => m.topic == meetingTopic)
				.FirstOrDefault();
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

        public void AddRoom(string location, string roomName, int capacity)
        {
            defaultRooms.Add(new Room(location, roomName, 10));
        }

        public void registerNewServer(String serverId, String serverURL)
        {
            ServerInstance s = (ServerInstance)Activator.GetObject(
                typeof(ServerInstance),
                serverURL
            );
            this.otherServers.Add(serverId, s);
            this.vector_clock.Add(serverId, 0);
            Console.WriteLine("Registered new server: " + serverId + " | " + serverURL);
        }

        public void registerNewClient(string clientId, string clientURL)
        {
            connectedClientsURLs.Add(clientId, clientURL);
            Console.WriteLine("New client connected: " + clientId + " | " + clientURL);
        }

        public HashSet<string> getMyClientsSubset()
        {
            int MAX_RETURNS = 10;
            List<String> clientUrlList = connectedClientsURLs.Values.ToList();
            HashSet<string> result = new HashSet<string>();
            int addressessQuantity = MAX_RETURNS < clientUrlList.Count
                ? MAX_RETURNS
                : connectedClientsURLs.Count;

            if (MAX_RETURNS < clientUrlList.Count)
            {
                clientUrlList.ForEach(v => result.Add(v));
            } 
            else
            {
                var random = new Random();
                for (int i = 0; i < addressessQuantity; i++)
                {
                    var nextIndex = random.Next(connectedClientsURLs.Count);
                    result.Add(clientUrlList[nextIndex]);
                }
            }

            return result;
        }

        public HashSet<string> getAgregatedClientsSubset()
        {
            HashSet<string> result = getMyClientsSubset();
            foreach (ServerInstance s in otherServers.Values)
            {
                s.getMyClientsSubset().ToList().ForEach(v => result.Add(v));
            }

            return result;
        }

        private void RB_Broadcast(Executable executable)
        {
            //Broadcast to everyone
            foreach (KeyValuePair<String,ServerInstance> server in otherServers)
            {
                server.Value.RB_Deliver(executable);
            }
        }

        public Object RB_Deliver(Executable executable)
        {
            this.vector_clock.TryGetValue(executable.serverId, out int current_clock);
            //Checks if this sequence number is older than the last executed, and if it is not already in the list of not delivered
            if (executable.clock > current_clock && !this.notDelivered.Contains(executable))
            {
                //Add to list so no other "echo" executes this
                this.notDelivered.Add(executable);

                //Checks if this sequence number is the next to execute
                while (executable.clock != current_clock + 1)
                {
                    System.Threading.Thread.Sleep(200);
                }

                this.vector_clock[executable.serverId] = executable.clock;

                //Broadcast before executing
                Thread thread = new Thread(() => RB_Broadcast(executable));
                thread.Start();

                Object output;
                //if the action is a close:
                if (executable.action == "closeMeeting")
                {
                    //if I am the leader:
                    if(this.leader == this.serverId)
                    {
                        this.to_sn++;
                        Broadcast(executable, this.to_sn);
                        this.last_to_sn = executable.to_sn;
                    }
                    else
                    {
                        while (executable.to_sn != this.last_to_sn + 1)
                        {
                            System.Threading.Thread.Sleep(200);
                        }

                        this.last_to_sn = executable.to_sn;
                        //Execute the action
                        output = Deliver(executable);

                        this.notDelivered.Remove(executable);
                        return output;
                    }
                }
                //Execute the action
                output = Deliver(executable);

                this.notDelivered.Remove(executable);
                return output;
            }

            return null;
        }

        private void Broadcast(Executable executable, int to_sn)
        {
            this.Change_TO_SN(executable, to_sn);
            //Broadcast to everyone
            foreach (KeyValuePair<String, ServerInstance> server in otherServers)
            {
                server.Value.Change_TO_SN(executable,to_sn);
            }
        }

        public void Change_TO_SN(Executable executable, int sn)
        {
            foreach(Executable exec in this.notDelivered)
            {
                if(exec.serverId == executable.serverId && exec.clock == executable.clock)
                {
                    exec.to_sn = sn;
                }
            }
        }

        public Object TO_CloseMeeting(Executable executable)
        {
            return this.CloseMeeting(executable.username, executable.meetingTopic);
        }

        public Object Request(Executable executable)
        {
            this.my_clock = this.my_clock + 1;
            executable.clock = this.my_clock;
            executable.serverId = this.serverId;
            return RB_Deliver(executable);
        }

        private Object Deliver(Executable executable)
        {
            switch (executable.action)
            {
                case "createMeeting":
                    return this.CreateMeeting(executable.newMeeting);
                case "closeMeeting":
                    return TO_CloseMeeting(executable);
                case "joinMeeting":
                    return this.JoinMeeting(executable.username, executable.meetingTopic, executable.slotPicked);
            }
            return null;
        }
    }
}
