using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plandomizer
{
    class Chest
    {
		[System.ComponentModel.DisplayName("Room")]
		public string room
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

		public Chest(string r, string oR, string lA)
		{
			room = r;
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
				// ret += "patch=1,EE," + locationAddress + ",extended,0000" + replacementAddress + "// " + room + ", " + originalReward + "\n";
				ret += "patch=1,EE," + locationAddress + ",extended,0000" + replacementAddress + " // " + room + ", " + originalReward + " is now " + replacement + "\n";
			return ret;
		}
	}
}
