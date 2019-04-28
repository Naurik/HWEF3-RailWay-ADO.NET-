using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWays
{
    public class Train
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string NameTrain { get; set; }
        public int CountWagon { get; set; }

        public Guid DirectionId { get; set; }
    }
}
