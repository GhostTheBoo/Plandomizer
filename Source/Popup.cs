using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plandomizer
{
    class Popup
	{
		[System.ComponentModel.DisplayName("Location")]
		public string location
		{ get; set; }
		[System.ComponentModel.DisplayName("Original Reward")]
		public string originalReward
		{ get; set; }
		[System.ComponentModel.DisplayName("Replacement")]
		public string replacement
		{ get; set; }
		public string locationAddress
		{ get; set; }
		public string replacementAddress
		{ get; set; }
		public bool changed
		{ get; set; }

		public Popup(string l, string oR, string lA)
		{
			location = l;
			originalReward = oR;
			replacement = "";
			locationAddress = lA;
			replacementAddress = "";
			changed = false;
		}

		public string toString()
		{
			string ret = "";
			if (changed)
				// ret += "patch=1,EE," + locationAddress + ",extended,0000" + replacementAddress + "// " + location + ", " + originalReward + "\n";
				ret += "patch=1,EE," + locationAddress + ",extended,0000" + replacementAddress + "// " + location + ", " + originalReward + " is now " + replacement + "\n";
			return ret;
        }
	}
}
