using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBTest.Models
{
    public class ServerType
    {
        public int ServerTypeId { get; set; }
        public String OperatingSystem { get; set; }
        public int MemoryInMb { get; set; }
        public int DiskSpaceInMb { get; set; }
        public int CpuSpeedInMhz { get; set; }
        public String AdditionalServices { get; set; }


    }
}