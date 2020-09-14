using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plandomizer
{
    class Keyblade
    {
		public string equipmentName
		{ get; set; }
		public string originalAbility
		{ get; set; }
		public string replacementAbility
		{ get; set; }
		public int strength
		{ get; set; }
		public int magic
		{ get; set; }
		public int ap
		{ get; set; }
		public int defense
		{ get; set; }
		public string abilityAddress
		{ get; set; }
		public string statAddress
		{ get; set; }
		public bool changed
		{ get; set; }

		public Keyblade(string n, string aA, string sA, string oA, int s, int m)
		{
			equipmentName = n;
			abilityAddress = aA;
			statAddress = sA;
			originalAbility = oA;
			replacementAbility = "";
			strength = s;
			magic = m;
			ap = 0;
			defense = 0;
			changed = false;
		}
	}
}
