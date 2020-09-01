using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plandomizer
{
    class Replacement
    {
        public string LocationIndex
        { get; set; }
        public string ReplacementIndex
        { get; set; }
        public string OriginalLocation
        { get; set; }
        public string ReplacedReward
        { get; set; }
        public Replacement(string lIndex, string rIndex, string oLocation, string rReward)
        {
            LocationIndex = lIndex;
            ReplacementIndex = rIndex;
            OriginalLocation = oLocation;
            ReplacedReward = rReward;
        }
    }
}
