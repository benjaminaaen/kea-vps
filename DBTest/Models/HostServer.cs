using System;
using System.Collections.Generic;

namespace DBTest.Models
{
    public enum ServerStatus
    {
        Running, Maintenance, Pending, Inactive
    }
    public class HostServer
    {
        public int HostServerId { get; set; }
        public String Name { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public ICollection<ServerSlot> ServerSlots { get; set; }
        public String Specs { get; set; }
    }
}