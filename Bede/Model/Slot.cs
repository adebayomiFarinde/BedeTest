using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bede.Model
{
    internal class Slot
    {
        public char Data { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Coefficient { get; set; }
        public int ProbabilityRangeFrom { get; set; }
        public int ProbabilityRangeTo { get; set; }
        public double PercentProbability { get; set; }
    }
}
