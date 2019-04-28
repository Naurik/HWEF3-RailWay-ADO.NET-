using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWays
{
    public class Place
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int NumberPlace { get; set; }
        public int IsEmty { get; set; }
        public string Status { get; set; }
        public int Payment { get; set; }

        public Guid TrainId { get; set; }
    }
}
