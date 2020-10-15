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
		[System.ComponentModel.DisplayName("Total EXP to Next Level")]
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
		public string vanillaSword
		{ get; set; }
		public string vanillaShield
		{ get; set; }
		public string vanillaStaff
		{ get; set; }
		public int rewardReplacementType
		{ get; set; }
		public bool changed
		{ get; set; }

		public Level(int l, string[] entries)
        {
			level = l;
			expToNextAddress = entries[0];
			statAddress = entries[1];
			swordAddress = entries[2];
			shieldAddress = entries[3];
			staffAddress = entries[4];
			vanillaSword = entries[5];
			vanillaShield = entries[6];
			vanillaStaff = entries[7];
			expToNext = 0;
			ap = 0;
			defense = 0;
			magic = 0;
			strength = 0;
			swordReplacementAddress = "";
			shieldReplacementAddress = "";
			staffReplacementAddress = "";
			swordReplacement = vanillaSword;
			shieldReplacement = vanillaShield;
			staffReplacement = vanillaStaff;
			rewardReplacementType = 0;
			changed = false;
		}

		public void Default()
		{
			expToNext = 0;
			ap = 0;
			defense = 0;
			magic = 0;
			strength = 0;
			swordReplacementAddress = "";
			shieldReplacementAddress = "";
			staffReplacementAddress = "";
			swordReplacement = vanillaSword;
			shieldReplacement = vanillaShield;
			staffReplacement = vanillaStaff;
			rewardReplacementType = 0;
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
					if(rewardReplacementType != 0)
                    {
						ret += "patch=1,EE," + swordAddress + ",extended,0000" + swordReplacementAddress + " // Sword Reward: " + swordReplacement + "\n";
						ret += "patch=1,EE," + shieldAddress + ",extended,0000" + shieldReplacementAddress + " // Shield Reward: " + shieldReplacement + "\n";
						ret += "patch=1,EE," + staffAddress + ",extended,0000" + staffReplacementAddress + " // Staff Reward: " + staffReplacement + "\n";
                    }
				}
			}
			return ret;
		}
	}
}
