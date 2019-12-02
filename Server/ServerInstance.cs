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
        Dictionary<String, String> otherServers;
        Dictionary<String, String> connectedClients;
        String serverId;
        int minDelay;
        int maxDelay;
        int maxFaults;

        List<Executable> notDelivered;
        Dictionary<String, int> vector_clock;
        int my_clock = 0;
        int last_to_sn;
        String leader;
        Boolean leader_election = false;

        //Leader Variables
        int to_sn = 0;

        private string status = "OK";
        public ServerInstance(String serverId, int minDelay, int maxDelay, int maxFaults)
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
            this.otherServers = new Dictionary<String, String>();
            this.connectedClients = new Dictionary<String, String>();
            this.notDelivered = new List<Executable>();
            this.serverId = serverId;
            this.minDelay = minDelay;
            this.maxDelay = maxDelay;
            this.vector_clock = new Dictionary<String, int>();
            this.vector_clock.Add(this.serverId, 0);
            this.last_to_sn = 0;
            this.leader = "s2";
            this.maxFaults = maxFaults;
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
            waitForProcessRequest();
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
            waitForProcessRequest();
            return this.meetings;
		}

		public int CreateMeeting(Meeting newMeeting)
		{
			var locations = newMeeting.proposals.Select(s => s.location).Distinct().ToList();
			var existingRoomLocations = defaultRooms.Select(r => r.location).Distinct().ToList();

			// make sure meeting is only created if all locations exist
			foreach (string location in locations)
				if (!existingRoomLocations.Contains(location))
					return -1;

			// make sure meeting doesn't already exist
			if (this.meetings.Where(m => m.topic == newMeeting.topic).Count() != 0)
				return -2;

			this.meetings.Add(newMeeting);
			return 0;
		}

		public int JoinMeeting(string username, string meetingTopic, List<Slot> slotsPicked)
		{
            var meeting = this.meetings
				.Where(m => m.topic == meetingTopic)
				.FirstOrDefault();

			// can't join if slots are not proposed
			foreach (var slot in slotsPicked)
			{
				if (meeting.proposals.Where(p => p.date.Equals(slot.date) && p.location.Equals(slot.location)).Count() == 0)
					return -1;
			}

			// can't join if user already joined
			if (meeting.votes.Where(v => v.voterName == username).Count() > 0)
				return -2;

			// can't join if not invited
			if (meeting.invited.Count > 0 && !meeting.invited.Contains(username))
				return -3;

			meeting.submitVotes(username, slotsPicked);
			return 0;
		}

		public Meeting CloseMeeting(string username, string meetingTopic)
		{
			var meeting = this.meetings.Where(m => m.topic == meetingTopic).FirstOrDefault();
			// meeting can't be already closed
			if (meeting.isClosed())
				return null;

			// if there isn't enough participants, close the meeting
			var numParticipants = meeting.votes.Count();
			if (numParticipants < meeting.minimumParticipants)
			{
				meeting.status = MeetingStatus.Canceled;
				return meeting;
			}

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
            waitForProcessRequest();
            defaultRooms.Add(new Room(location, roomName, 10));
        }

        public void registerNewServer(String serverId, String serverURL)
        {
            otherServers.Add(serverId, serverURL);
            this.vector_clock.Add(serverId, 0);
            Console.WriteLine("Registered new server: " + serverId + " | " + serverURL);
        }

        public void registerNewClient(string clientId, string clientURL)
        {
            connectedClients.Add(clientId, clientURL);
            Console.WriteLine("New client connected: " + clientId + " | " + clientURL);
		}

        public Dictionary<string, string> getMyClientsSubset()
        {
            int MAX_RETURNS = 5;
			Dictionary<string, string> result = new Dictionary<string, string>();
            int addressessQuantity = MAX_RETURNS < this.connectedClients.Count
                ? MAX_RETURNS
                : connectedClients.Count;

            if (MAX_RETURNS >= this.connectedClients.Count)
            {
				foreach (var clientKV in this.connectedClients)
				{
					result.Add(clientKV.Key, clientKV.Value);
				}
            } 
            else
            {
                var random = new Random();
				var clientKeys = this.connectedClients.Keys.ToList();
				for (int i = 0; i < addressessQuantity; i++)
                {
                    var clientKey = clientKeys[random.Next(connectedClients.Count)];
                    result.Add(clientKey, this.connectedClients[clientKey]);
                }
            }

            return result;
        }

        public Dictionary<string, string> getAgregatedClientsSubset()
        {
			Dictionary<string, string> result = getMyClientsSubset();
            foreach (string serverURL in otherServers.Values)
            {
				ServerInstance s = (ServerInstance)Activator.GetObject(
					typeof(ServerInstance),
					serverURL
				);
				var clientDict = s.getMyClientsSubset();
				foreach (var clientKV in clientDict)
					result.Add(clientKV.Key, clientKV.Value);
            }

            return result;
        }

        private bool RB_Broadcast(Executable executable, bool starter)
        {
            int replies = 0;
            //Broadcast to everyone
            foreach (string serverURL in otherServers.Values)
            {
                Thread thread = new Thread(() => {
                    try{
                        ServerInstance s = (ServerInstance)Activator.GetObject(
                            typeof(ServerInstance),
                            serverURL
				        );
                        Object output = s.RB_Deliver(executable);
                        if (output != null)
                        {
                            replies++;
                        }

                    }
                    catch (Exception e)
                    {   
                        //do nothing
                    }
                });
                thread.Start();
            }
            if (starter)
            {
                long unixTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                double timer = 0;
                while (replies < maxFaults+1)
                {
                    if (timer > 2) return false;
                    System.Threading.Thread.Sleep(50);
                    timer += 0.05;
                }
                System.Console.WriteLine("Waited for: " + (DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()-unixTime) + " milliseconds.");
            }
            return true;
        }

        public Object RB_Deliver(Executable executable, bool starter=false)
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
                if(!RB_Broadcast(executable,starter)) return null;

                Object output;
                //if the action is a close:
                if (executable.action == "closeMeeting")
                {
                    //if I am the leader:
                    if(this.leader == this.serverId)
                    {
                        this.to_sn++;
                        TO_Broadcast(executable, this.to_sn);
                    }
                    else
                    {
                        double timer = 0;
                        //check if this is the next totalorder closeMeeting() to execute
                        while (executable.to_sn != this.last_to_sn + 1)
                        {
                            //If no to_sn comes within 2 seconds, start leader election
                            if (timer >= 2)
                            {
                                startLeaderElection(executable.to_sn);
                                //wait until leader election finishes
                                while (leader_election == true)
                                {
                                    System.Threading.Thread.Sleep(200);
                                }
                                //when a new leader is elected remove the request from the list so it can be re-sent 
                                this.notDelivered.Remove(executable);
                                this.vector_clock[executable.serverId] = this.vector_clock[executable.serverId] - 1;
                                timer = 0;
                                //return result from a new RB_Deliver
                                return RB_Deliver(executable);
                            }
                            //if it is not time to execute, sleep for 0,2 seconds, and try again
                            System.Threading.Thread.Sleep(200);
                            if (executable.to_sn == 0) timer += 0.2;
                        }  
                    }
                    this.last_to_sn = executable.to_sn;
                }
                //Execute the action
                output = Deliver(executable);

                this.notDelivered.Remove(executable);
                return output;
            }

            return null;
        }

        private void startLeaderElection(int to_sn)
        {
            Executable executable = new Executable();
            executable.action = "LeaderElection";
            executable.serverId = leader;
            LE_Broadcast(executable, to_sn);

        }

        private void LE_Broadcast(Executable executable, int to_sn)
        {
            remoteSLE(executable);
            //Broadcast to everyone
            foreach (string serverURL in otherServers.Values)
            {
                Thread thread = new Thread(() =>
                {
                    try
                    {
                        ServerInstance s = (ServerInstance)Activator.GetObject(
                            typeof(ServerInstance),
                            serverURL
				        );
                        s.remoteSLE(executable);
                    } catch (Exception e)
                    {

                    }      
                });
                thread.Start();
            }
        }

        public void remoteSLE(Executable executable)
        {
            System.Console.WriteLine("Leader Election started");
            this.leader_election = true;
        }

        private void TO_Broadcast(Executable executable, int to_sn)
        {
            this.Change_TO_SN(executable, to_sn);

            //Broadcast to everyone
            foreach (string serverURL in otherServers.Values)
            {
                Thread thread = new Thread(() =>
                {
                    try
                    {
                        ServerInstance s = (ServerInstance)Activator.GetObject(
                            typeof(ServerInstance),
                            serverURL
				        );
                        s.Change_TO_SN(executable, to_sn);
                    }
                    catch (Exception e)
                    {

                    }

                });
                thread.Start();
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

        public Object Request(Executable executable)
        {
            waitForProcessRequest();
            this.my_clock = this.my_clock + 1;
            executable.clock = this.my_clock;
            executable.serverId = this.serverId;
            return RB_Deliver(executable,true);
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
        
        private void waitForProcessRequest()
        {
            if(maxDelay > 0)
            {
                Random r = new Random();
                int rInt = r.Next(minDelay, maxDelay);
                System.Threading.Thread.Sleep(rInt);
            }

            while (status != "OK")
            {
                System.Threading.Thread.Sleep(200);
            }
        }
    }
}
