using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plandomizer
{
    class Critical
    {
        [System.ComponentModel.DisplayName("Oriignal Ability")]
        public string ability
        { get; set; }
        public string address
        { get; set; }
        [System.ComponentModel.DisplayName("Replacement")]
        public string replacement
        { get; set; }
        public string replacementAddress
        { get; set; }
        public bool changed
        { get; set; }

        public Critical(string ab, string ad)
        {
            ability = ab;
            replacement = ab;
            address = ad;
            replacementAddress = "";
            changed = false;
        }

        public void Default()
        {
            replacement = ability;
            replacementAddress = "";
            changed = false;
        }

        public string toString()
        {
            string ret = "";
            if (changed)
                // ret += "patch=1,EE," + locationAddress + ",extended,0000" + replacementAddress + "// " + room + ", " + originalReward + "\n";
                ret += "patch=1,EE," + address + ",extended,0000" + replacementAddress + " // " + ability + " has been replaced with " + replacement + "\n";
            return ret;
        }
    }
}
