using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plandomizer
{
    public class Reward
    {
        public string Title
        { get; set; }
        public string Index
        { get; set; }

        public Reward(string title, string index)
        {
            Title = title;
            Index = index;
        }
    }
}
