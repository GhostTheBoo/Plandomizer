using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plandomizer
{
    class Bonus
	{
		[System.ComponentModel.DisplayName("Fight")]
		public string fight
		{ get; set; }
		public string statAddress
		{ get; set; }
		public string slotAddress
		{ get; set; }
		public string rewardAddress
		{ get; set; }
		[System.ComponentModel.DisplayName("Original Reward")]
		public string originalReward
		{ get; set; }
		[System.ComponentModel.DisplayName("Replacement 1")]
		public string replacementReward1
		{ get; set; }
		public string replacementRewardAddress1
		{ get; set; }
		[System.ComponentModel.DisplayName("Replacement 2")]
		public string replacementReward2
		{ get; set; }
		public string replacementRewardAddress2
		{ get; set; }
		public int hpIncrease
		{ get; set; }
		public int mpIncrease
		{ get; set; }
		public int armorSlotIncrease
		{ get; set; }
		public int accessorySlotIncrease
		{ get; set; }
		public int itemSlotIncrease
		{ get; set; }
		public int driveGaugeIncrease
		{ get; set; }
		public int changeCount
		{ get; set; }

		public Bonus(string f, string stA, string slA, string rA, string oR)
		{
			fight = f;
			statAddress = stA;
			slotAddress = slA;
			rewardAddress = rA;
			originalReward = oR;

			replacementReward1 = "";
			replacementRewardAddress1 = "";
			replacementReward2 = "";
			replacementRewardAddress2 = "";
			hpIncrease = -1;
			mpIncrease = -1;
			armorSlotIncrease = -1;
			accessorySlotIncrease = -1;
			itemSlotIncrease = -1;
			driveGaugeIncrease = -1;
			changeCount = 0;
		}

		public string toString()
		{
			string ret = "";
			if(changeCount != 0)
			{
				ret += "// " + fight + "\n";
				ret += "patch=1,EE," + statAddress + ",extended,0000";
				// Stats
				if (mpIncrease != -1)
					ret += mpIncrease.ToString("X2");
				else
					ret += "00";
				if (hpIncrease != -1)
					ret += hpIncrease.ToString("X2");
				else
					ret += "00";
				ret += " // MP:" + mpIncrease + " HP:" + hpIncrease + "\n";

				// Slots
				ret += "patch=1,EE," + slotAddress + ",extended,";
				if (armorSlotIncrease != -1)
					ret += armorSlotIncrease.ToString("X2");
				else
					ret += "00";
				if (accessorySlotIncrease != -1)
					ret += accessorySlotIncrease.ToString("X2");
				else
					ret += "00";
				if (itemSlotIncrease != -1)
					ret += itemSlotIncrease.ToString("X2");
				else
					ret += "00";
				if (driveGaugeIncrease != -1)
					ret += driveGaugeIncrease.ToString("X2");
				else
					ret += "00";
				ret += " // Armor Slot:+" + armorSlotIncrease + " Accessory Slot:+" + accessorySlotIncrease + " Item Slot:+" + itemSlotIncrease + " Drive Gauge:+" + driveGaugeIncrease + "\n";

				// Rewards
				ret += "patch=1,EE," + rewardAddress + ",extended,";
				if (replacementReward2 != "")
					ret += replacementRewardAddress2;
				else
					ret += "0000";
				if (replacementReward1 != "")
					ret += replacementRewardAddress1;
				else
					ret += "0000";
				ret += " // " + replacementReward2 + " " + replacementReward1 + "\n";
			}

			return ret;
		}
	}
}
