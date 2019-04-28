using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWays
{
    public class Direction
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string BeginCity { get; set; }
        public string EndCity { get; set; }
    }
}
