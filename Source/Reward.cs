using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plandomizer
{
    public class Reward
    {
        public string reward
        { get; set; }
        public string rewardAddress
        { get; set; }

        public Reward(string r, string rA)
        {
            reward = r;
            rewardAddress = rA;
        }

        public override string ToString()
        {
            return reward;
        }
    }
}
