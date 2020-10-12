using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plandomizer
{
    class DriveForm
	{
		[System.ComponentModel.DisplayName("Drive Form Level")]
		public string level
		{ get; set; }
		[System.ComponentModel.DisplayName("Original Ability")]
		public string originalAbility
		{ get; set; }
		[System.ComponentModel.DisplayName("Replacement")]
		public string replacement
		{ get; set; }
		[System.ComponentModel.DisplayName("Original Experience to This Level")]
		public int originalExp
		{ get; set; }
		[System.ComponentModel.DisplayName("Replaced Experience to This Level")]
		public int newExp
		{ get; set; }
		public string expAddress
		{ get; set; }
		public string originalAddress
		{ get; set; }
		public string replacementAddress
		{ get; set; }
		public bool changed
		{ get; set; }
		public bool expChanged
		{ get; set; }

		public DriveForm(string l, string oAb, string oAd, string eA, int oE)
		{
			level = l;
			originalAbility = oAb;
			expAddress = eA;
			originalExp = oE;
			newExp = oE;
			replacement = "";
			originalAddress = oAd;
			replacementAddress = "";
			changed = false;
			expChanged = false;
		}

		public void Default()
		{
			newExp = originalExp;
			replacement = "";
			replacementAddress = "";
			changed = false;
			expChanged = false;
		}

		public string toStringAbility()
		{
			string ret = "";
			if (changed)
				ret += "patch=1,EE," + originalAddress + ",extended,0000" + replacementAddress + " // " + level + ", " + originalAbility + " is now " + replacement + "\n";
			return ret;
		}

		public string toStringExp()
		{
			string ret = "";
			if (expChanged)
				ret += "patch=1,EE," + expAddress + ",extended," + newExp.ToString("X8") + " // " + newExp + " experience is required to reach " + level + "\n";
			return ret;
		}
	}
}
