using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plandomizer
{
    class Equipment
	{
		public string equipmentType
		{ get; set; }
		[System.ComponentModel.DisplayName("Name")]
		public string equipmentName
		{ get; set; }
		[System.ComponentModel.DisplayName("Ability")]
		public string ability
		{ get; set; }
		[System.ComponentModel.DisplayName("Strength")]
		public int strength
		{ get; set; }
		[System.ComponentModel.DisplayName("Magic")]
		public int magic
		{ get; set; }
		[System.ComponentModel.DisplayName("AP")]
		public int ap
		{ get; set; }
		[System.ComponentModel.DisplayName("Defense")]
		public int defense
		{ get; set; }
		[System.ComponentModel.DisplayName("Physical")]
		public int physicalResistance
		{ get; set; }
		[System.ComponentModel.DisplayName("Fire")]
		public int fireResistance
		{ get; set; }
		[System.ComponentModel.DisplayName("Blizzard")]
		public int blizzardResistance
		{ get; set; }
		[System.ComponentModel.DisplayName("Thunder")]
		public int thunderResistance
		{ get; set; }
		[System.ComponentModel.DisplayName("Dark")]
		public int darkResistance
		{ get; set; }
		[System.ComponentModel.DisplayName("Light")]
		public int lightResistance
		{ get; set; }
		[System.ComponentModel.DisplayName("Universal")]
		public int allResistance
		{ get; set; }
		public string vanillaAbility
		{ get; set; }
		public int vanillaStrength
		{ get; set; }
		public int vanillaMagic
		{ get; set; }
		public int vanillaAP
		{ get; set; }
		public int vanillaDefense
		{ get; set; }
		public int vanillaFireResistance
		{ get; set; }
		public int vanillaBlizzardResistance
		{ get; set; }
		public int vanillaThunderResistance
		{ get; set; }
		public int vanillaDarkResistance
		{ get; set; }
		public string abilityAddress
		{ get; set; }
		public string statAddress
		{ get; set; }
		public string elementalResistanceAddress
		{ get; set; }
		public string otherResistanceAddress
		{ get; set; }
		public string replacementAbilityAddress
		{ get; set; }
		public bool changed
		{ get; set; }

		public Equipment(string[] entryList)
		{
			equipmentType = entryList[0];
			equipmentName = entryList[1];
			abilityAddress = entryList[2];
			statAddress = entryList[3];
			elementalResistanceAddress = entryList[4];
			otherResistanceAddress = entryList[5];
			vanillaStrength = Convert.ToInt32(entryList[6]);
			vanillaMagic = Convert.ToInt32(entryList[7]);
			vanillaAP = Convert.ToInt32(entryList[8]);
			vanillaDefense = Convert.ToInt32(entryList[9]);
			vanillaAbility = entryList[10];
			vanillaFireResistance = Convert.ToInt32(entryList[11]);
			vanillaBlizzardResistance = Convert.ToInt32(entryList[12]);
			vanillaThunderResistance = Convert.ToInt32(entryList[13]);
			vanillaDarkResistance = Convert.ToInt32(entryList[14]);
			replacementAbilityAddress = "";
			ability = vanillaAbility;
			strength = vanillaStrength;
			magic = vanillaMagic;
			ap = vanillaAP;
			defense = vanillaDefense;
			physicalResistance = 0;
			fireResistance = vanillaFireResistance;
			blizzardResistance = vanillaBlizzardResistance;
			thunderResistance = vanillaThunderResistance;
			darkResistance = vanillaDarkResistance;
			lightResistance = 0;
			allResistance = 0;
			changed = false;
		}

		public void Default()
		{
			replacementAbilityAddress = "";
			ability = vanillaAbility;
			strength = vanillaStrength;
			magic = vanillaMagic;
			ap = vanillaAP;
			defense = vanillaDefense;
			physicalResistance = 0;
			fireResistance = vanillaFireResistance;
			blizzardResistance = vanillaBlizzardResistance;
			thunderResistance = vanillaThunderResistance;
			darkResistance = vanillaDarkResistance;
			lightResistance = 0;
			allResistance = 0;
			changed = false;
		}

		public string toString()
        {
			string ret = "";
			if(changed)
            {
				string word = "0000";
				ret += "// " + equipmentName + "\n";

				word += replacementAbilityAddress + " // Ability: " + ability + "\n";
				ret += "patch=1,EE," + abilityAddress + ",extended," + word;
				word = "";

				word += ap.ToString("X2");
				word += defense.ToString("X2");
				word += magic.ToString("X2");
				word += strength.ToString("X2");
				word += " // AP:" + ap + " Defense:" + defense + " Magic:" + magic + " Strength:" + strength + "\n";
				ret += "patch=1,EE," + statAddress + ",extended," + word;
				word = "";

				word += (100 - thunderResistance).ToString("X2");
				word += (100 - blizzardResistance).ToString("X2");
				word += (100 - fireResistance).ToString("X2");
				word += (100 - physicalResistance).ToString("X2");
				word += " // Thunder:" + thunderResistance + "% Blizzard:" + blizzardResistance + "% Fire:" + fireResistance + "% Physical:" + physicalResistance + "%\n";
				ret += "patch=1,EE," + elementalResistanceAddress + ",extended," + word;
				word = "00";

				word += (100 - allResistance).ToString("X2");
				word += (100 - lightResistance).ToString("X2");
				word += (100 - darkResistance).ToString("X2");
				word += " // Universal:" + allResistance + "% Light:" + lightResistance + "% Dark:" + darkResistance + "%\n";
				ret += "patch=1,EE," + otherResistanceAddress + ",extended," + word;
			}
			return ret;
        }
	}
}
