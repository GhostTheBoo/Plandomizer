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

		public Equipment(string eT, string en, string aA, string sA, string eRA, string oRA)
		{
			equipmentType = eT;
			equipmentName = en;
			abilityAddress = aA;
			statAddress = sA;
			elementalResistanceAddress = eRA;
			otherResistanceAddress = oRA;
			replacementAbilityAddress = "";
			ability = "";
			strength = 0;
			magic = 0;
			ap = 0;
			defense = 0;
			physicalResistance = 0;
			fireResistance = 0;
			blizzardResistance = 0;
			thunderResistance = 0;
			darkResistance = 0;
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

				word += replacementAbilityAddress;
				ret += "patch=1,EE," + abilityAddress + ",extended," + word + "// Ability\n";
				word = "";

				word += ap.ToString("X2");
				word += defense.ToString("X2");
				word += magic.ToString("X2");
				word += strength.ToString("X2");
				ret += "patch=1,EE," + statAddress + ",extended," + word + "// Stats\n";
				word = "";

				word += (100 - thunderResistance).ToString("X2");
				word += (100 - blizzardResistance).ToString("X2");
				word += (100 - fireResistance).ToString("X2");
				word += (100 - physicalResistance).ToString("X2");
				ret += "patch=1,EE," + elementalResistanceAddress + ",extended," + word + "// Physical + Elemental Resistances\n";
				word = "00";

				word += (100 - allResistance).ToString("X2");
				word += (100 - lightResistance).ToString("X2");
				word += (100 - darkResistance).ToString("X2");
				ret += "patch=1,EE," + otherResistanceAddress + ",extended," + word + "// Universal, Light, and Dark Resistances\n";
			}
			return ret;
        }
	}
}
