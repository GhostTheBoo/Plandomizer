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
				string word = "";
				// Stats
				if (mpIncrease != -1)
					word += mpIncrease.ToString("X2");
				else
					word += "00";
				if (hpIncrease != -1)
					word += hpIncrease.ToString("X2");
				else
					word += "00";
				ret += "patch=1,EE," + statAddress + ",extended,0000" + word + "// MP+ and HP+\n";

				// Slots
				word = "";
				if (armorSlotIncrease != -1)
					word += armorSlotIncrease.ToString("X2");
				else
					word += "00";
				if (accessorySlotIncrease != -1)
					word += accessorySlotIncrease.ToString("X2");
				else
					word += "00";
				if (itemSlotIncrease != -1)
					word += itemSlotIncrease.ToString("X2");
				else
					word += "00";
				if (driveGaugeIncrease != -1)
					word += driveGaugeIncrease.ToString("X2");
				else
					word += "00";
				ret += "patch=1,EE," + statAddress + ",extended," + word + "// Armor Slot+ Accessory Slot+ Item Slot+ Drive Gauge+\n";

				// Rewards
				word = "";
				if (replacementReward2 != "")
					word += replacementRewardAddress2;
				else
					word += "0000";
				if (replacementReward1 != "")
					word += replacementRewardAddress1;
				else
					word += "0000";
				ret += "patch=1,EE," + rewardAddress + ",extended," + word + "// Reward 2 and Reward 1\n";
			}

			return ret;
		}
	}
}
