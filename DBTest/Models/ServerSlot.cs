using System;


namespace DBTest.Models
{
    public class ServerSlot
    {
        public int ServerSlotId { get; set; }
        public virtual HostServer HostServer { get; set; }
        public String IpAddress { get; set; }
        public virtual KeySet KeySet { get; set; }
        public virtual ServerType ServerType { get; set; }
    }
}