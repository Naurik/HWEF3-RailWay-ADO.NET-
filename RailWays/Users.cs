using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWays
{
    public class Users
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public Guid DirectionId { get; set; }
        public Guid TrainsId { get; set; }
        public Guid PlaceId { get; set; }
        public string Status { get; set; }
        public int CountPassangers { get; set; }
        public int Payment { get; set; }
    }
}
