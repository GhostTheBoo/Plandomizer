using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plandomizer
{
    class Bonus
	{
		public string character
		{ get; set; }
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
		[System.ComponentModel.DisplayName("HP Increase")]
		public int hpIncrease
		{ get; set; }
		[System.ComponentModel.DisplayName("MP Increase")]
		public int mpIncrease
		{ get; set; }
		[System.ComponentModel.DisplayName("Armor Slot Increase")]
		public int armorSlotIncrease
		{ get; set; }
		[System.ComponentModel.DisplayName("Accessory Slot Increase")]
		public int accessorySlotIncrease
		{ get; set; }
		[System.ComponentModel.DisplayName("Item Slot Increase")]
		public int itemSlotIncrease
		{ get; set; }
		[System.ComponentModel.DisplayName("Drive Gauge Increase")]
		public int driveGaugeIncrease
		{ get; set; }
		public int changeCount
		{ get; set; }

		public Bonus(string c, string f, string stA, string slA, string rA, string oR)
		{
			character = c;
			fight = f;
			statAddress = stA;
			slotAddress = slA;
			rewardAddress = rA;
			originalReward = oR;

			replacementReward1 = "";
			replacementRewardAddress1 = "";
			replacementReward2 = "";
			replacementRewardAddress2 = "";
			hpIncrease = 0;
			mpIncrease = 0;
			armorSlotIncrease = 0;
			accessorySlotIncrease = 0;
			itemSlotIncrease = 0;
			driveGaugeIncrease = 0;
			changeCount = 0;
		}

		public Bonus(Bonus other)
        {
			character = other.character;
			fight = other.fight;
			statAddress = other.statAddress;
			slotAddress = other.slotAddress;
			rewardAddress = other.rewardAddress;
			originalReward = other.originalReward;

			replacementReward1 = other.replacementReward1;
			replacementRewardAddress1 = other.replacementRewardAddress1;
			replacementReward2 = other.replacementReward2;
			replacementRewardAddress2 = other.replacementRewardAddress2;
			hpIncrease = other.hpIncrease;
			mpIncrease = other.mpIncrease;
			armorSlotIncrease = other.armorSlotIncrease;
			accessorySlotIncrease = other.accessorySlotIncrease;
			itemSlotIncrease = other.itemSlotIncrease;
			driveGaugeIncrease = other.driveGaugeIncrease;
			changeCount = other.changeCount;
		}

		public void Default()
		{
			replacementReward1 = "";
			replacementRewardAddress1 = "";
			replacementReward2 = "";
			replacementRewardAddress2 = "";
			hpIncrease = 0;
			mpIncrease = 0;
			armorSlotIncrease = 0;
			accessorySlotIncrease = 0;
			itemSlotIncrease = 0;
			driveGaugeIncrease = 0;
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
				ret += " // Replacement Reward #2:" + replacementReward2 + " Replacement Reward #1:" + replacementReward1 + "\n";
			}

			return ret;
		}
	}
}
