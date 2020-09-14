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
		public string form
		{ get; set; }
		[System.ComponentModel.DisplayName("Original Ability")]
		public string originalAbility
		{ get; set; }
		[System.ComponentModel.DisplayName("Replacement")]
		public string replacement
		{ get; set; }
		public string originalAddress
		{ get; set; }
		public string replacementAddress
		{ get; set; }
		public bool changed
		{ get; set; }

		public DriveForm(string f, string oAb, string oAd)
		{
			form = f;
			originalAbility = oAb;
			replacement = "";
			originalAddress = oAd;
			replacementAddress = "";
			changed = false;
		}

		public string toString()
		{
			string ret = "";
			if (changed)
				// ret += "patch=1,EE," + originalAddress + ",extended,0000" + replacementAddress + "// " + form + ", " + originalAbility + "\n";
				ret += "patch=1,EE," + originalAddress + ",extended,0000" + replacementAddress + "// " + form + ", " + originalAbility + " is now " + replacement + "\n";
			return ret;
		}
	}
}
