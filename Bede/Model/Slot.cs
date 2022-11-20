using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bede.Model
{
    public class Slot
    {
        public char Data { get; set; }
        public string? Description { get; set; }
        public double Coefficient { get; set; }
        public int ProbabilityRangeFrom { get; set; }
        public int ProbabilityRangeTo { get; set; }
        public int PercentProbability { get; set; }
    }
}
