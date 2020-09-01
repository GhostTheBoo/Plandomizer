using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plandomizer
{
    public class rewardLocation
    {
        public string Location
        { get; set; }
        public string Original
        { get; set; }
        public string Index
        { get; set; }
        public rewardLocation(string location, string original, string index)
        {
            Location = location;
            Original = original;
            Index = index;
        }
    }
}
