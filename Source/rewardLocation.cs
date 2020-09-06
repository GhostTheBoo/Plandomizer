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
        public string Replacement
        { get; set; }
        public bool isReplaced
        { get; set; }
        public string locationType
        { get; set; }
        public string ReplacementIndex
        { get; set; }
        public rewardLocation(string location, string original, string index)
        {
            isReplaced = false;
            Replacement = "DEFAULT";
            Location = location;
            Original = original;
            Index = index;
            locationType = "chest";
            ReplacementIndex = "";
        }
    }
}
