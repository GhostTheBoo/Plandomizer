using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plandomizer
{
    class Cheat
    {
        [System.ComponentModel.DisplayName("Enabled")]
        public bool enabled
        { get; set; }
        [System.ComponentModel.DisplayName("Title")]
        public string title
        { get; set; }
        public List<string> codes
        { get; set; }

        public Cheat(string t, List<string> l)
        {
            codes = new List<string>();
            title = t;
            foreach (string s in l)
                codes.Add(s);
        }

        public string toString()
        {
            string ret = "";
            foreach (string c in codes)
                ret += c + "\n";
            return ret;
        }
    }
}
