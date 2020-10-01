using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plandomizer
{
	class Level
	{
		[System.ComponentModel.DisplayName("Level")]
		public int level
		{ get; set; }
		[System.ComponentModel.DisplayName("EXP to Next Level")]
		public int expToNext
		{ get; set; }
		public string expToNextAddress
		{ get; set; }
		[System.ComponentModel.DisplayName("AP")]
		public int ap
		{ get; set; }
		[System.ComponentModel.DisplayName("Defense")]
		public int defense
		{ get; set; }
		[System.ComponentModel.DisplayName("Magic")]
		public int magic
		{ get; set; }
		[System.ComponentModel.DisplayName("Strength")]
		public int strength
		{ get; set; }
		public string statAddress
		{ get; set; }
		public string swordAddress
		{ get; set; }
		public string shieldAddress
		{ get; set; }
		public string staffAddress
		{ get; set; }
		public string swordReplacementAddress
		{ get; set; }
		public string shieldReplacementAddress
		{ get; set; }
		public string staffReplacementAddress
		{ get; set; }
		[System.ComponentModel.DisplayName("Sword")]
		public string swordReplacement
		{ get; set; }
		[System.ComponentModel.DisplayName("Shield")]
		public string shieldReplacement
		{ get; set; }
		[System.ComponentModel.DisplayName("Staff")]
		public string staffReplacement
		{ get; set; }
		public bool changed
		{ get; set; }

		public Level(int l, string expA, string statA, string swordA, string shieldA, string staffA)
        {
			level = l;
			expToNextAddress = expA;
			statAddress = statA;
			swordAddress = swordA;
			shieldAddress = shieldA;
			staffAddress = staffA;
			expToNext = 0;
			ap = 0;
			defense = 0;
			magic = 0;
			strength = 0;
			swordReplacementAddress = "";
			shieldReplacementAddress = "";
			staffReplacementAddress = "";
			swordReplacement = "";
			shieldReplacement = "";
			staffReplacement = "";
			changed = false;
		}

		public string toString()
		{
			string ret = "";
			if (changed)
            {
				ret += "// Level " + level + "\n";
				if (level == 99)
					ret += "// Cannot Level to 100\n";
				else
					ret += "patch=1,EE," + expToNextAddress + ",extended," + expToNext.ToString("X8") + " // Level " + (level + 1) + " at " + expToNext + " experience\n";
				ret += "patch=1,EE," + statAddress + ",extended," + ap.ToString("X2") + defense.ToString("X2") + magic.ToString("X2") + strength.ToString("X2") + " // AP:" + ap + " Magic:" + magic + " Defense:" + defense + " Strength:" + strength + "\n";
				if (level == 1)
					ret += "// No Level 1 Dream Weapon Rewards\n";
				else
				{
					ret += "patch=1,EE," + swordAddress + ",extended,0000" + swordReplacementAddress + " // Sword Rreward: " + swordReplacement + "\n";
					ret += "patch=1,EE," + shieldAddress + ",extended,0000" + shieldReplacementAddress + " // Shield Reward: " + shieldReplacement + "\n";
					ret += "patch=1,EE," + staffAddress + ",extended,0000" + staffReplacementAddress + " // Staff Reward: " + staffReplacement + "\n";
				}
			}
			return ret;
		}
	}
}
