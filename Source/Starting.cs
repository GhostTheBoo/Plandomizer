using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plandomizer
{
    class Starting
    {
        public int hp
        { get; set; }
        public int mp
        { get; set; }
        public int drive
        { get; set; }
        public bool statChanged
        { get; set; }
        public int munny
        { get; set; }
        public string keyblade
        { get; set; }
        public string keybladeAddress
        { get; set; }
        public bool keybladeChanged
        { get; set; }
        public string armor
        { get; set; }
        public string armorAddress
        { get; set; }
        public bool armorChanged
        { get; set; }
        public string accessory
        { get; set; }
        public string accessoryAddress
        { get; set; }
        public bool accessoryChanged
        { get; set; }

        public Starting()
        {
            hp = 0;
            mp = 0;
            drive = 0;
            statChanged = false;
            munny = 0;
            keyblade = "";
            keybladeAddress = "";
            keybladeChanged = false;
            armor = "";
            armorAddress = "";
            armorChanged = false;
            accessory = "";
            accessoryAddress = "";
            accessoryChanged = false;
        }

        public string toString()
        {
            string ret = "";

            if (keybladeChanged)
            {
                ret += "// Starting Keyblade\n";
                ret += "patch=1,EE,E0050003,extended,0032DFC8\n";
                ret += "patch=1,EE,E0042002,extended,0032BAE0\n";
                ret += "patch=1,EE,E0030001,extended,0032BAE4\n";
                ret += "patch=1,EE,E0020001,extended,0032BAE6\n";
                ret += "patch=1,EE,E0010001,extended,0032BAE8\n";
                ret += "patch=1,EE,1032E020,extended,0000" + keybladeAddress + " // " + keyblade + "\n";
            }

            if (armorChanged)
            {
                ret += "// Starting Armor\n";
                ret += "patch=1,EE,E0050003,extended,0032DFC8\n";
                ret += "patch=1,EE,E0042002,extended,0032BAE0\n";
                ret += "patch=1,EE,E0030001,extended,0032BAE4\n";
                ret += "patch=1,EE,E0020001,extended,0032BAE6\n";
                ret += "patch=1,EE,E0010001,extended,0032BAE8\n";
                ret += "patch=1,EE,1032E034,extended,0000" + armorAddress + " // " + armor + "\n";
            }

            if (accessoryChanged)
            {
                ret += "// Starting Accessory\n";
                ret += "patch=1,EE,E0050003,extended,0032DFC8\n";
                ret += "patch=1,EE,E0042002,extended,0032BAE0\n";
                ret += "patch=1,EE,E0030001,extended,0032BAE4\n";
                ret += "patch=1,EE,E0020001,extended,0032BAE6\n";
                ret += "patch=1,EE,E0010001,extended,0032BAE8\n";
                ret += "patch=1,EE,1032E044,extended,0000" + accessoryAddress + " // " + accessory + "\n";
            }

            if (munny != 0)
            {
                ret += "//Starting Munny\n";
                ret += "patch=1,EE,E0050003,extended,0032DFC8\n";
                ret += "patch=1,EE,E0042002,extended,0032BAE0\n";
                ret += "patch=1,EE,E0030001,extended,0032BAE4\n";
                ret += "patch=1,EE,E0020001,extended,0032BAE6\n";
                ret += "patch=1,EE,E0010001,extended,0032BAE8\n";
                ret += "patch=1,EE,2032DF70,extended," + munny.ToString("X8") + " // " + munny + " munny\n";
            }

            if (statChanged)
            {
                ret += "//Starting Max HP\n";
                ret += "patch=1,EE,E0041A04,extended,0032BAE0\n";
                ret += "patch=1,EE,E0030001,extended,0032BAE4\n";
                ret += "patch=1,EE,E0020001,extended,0032BAE8\n";
                ret += "patch=1,EE,01C6C754,extended,000000" + hp.ToString("X2") + " // Max HP: " + hp + "\n";
                ret += "patch=1,EE,01C6C750,extended,000000" + hp.ToString("X2") + " // Current HP: " + hp + "\n";

                ret += "//Starting Max MP\n";
                ret += "patch=1,EE,E0041A04,extended,0032BAE0\n";
                ret += "patch=1,EE,E0030001,extended,0032BAE4\n";
                ret += "patch=1,EE,E0020001,extended,0032BAE8\n";
                ret += "patch=1,EE,01C6C8D4,extended,000000" + mp.ToString("X2") + " //Max MP: " + mp + "\n";
                ret += "patch=1,EE,01C6C8D0,extended,000000" + mp.ToString("X2") + " //Current MP: " + mp + "\n";

                ret += "//Starting Drive Gauges (Critical) Place This in the GOA Pnach if you aren't merging.\n";
                ret += "patch=1,EE,E0050003,extended,0032DFC8\n";
                ret += "patch=1,EE,E0042002,extended,0032BAE0\n";
                ret += "patch=1,EE,E0030001,extended,0032BAE4\n";
                ret += "patch=1,EE,E0020001,extended,0032BAE6\n";
                ret += "patch=1,EE,E0010001,extended,0032BAE8\n";
                ret += "patch=1,EE,11C6C901,extended,0000" + drive.ToString("X2") + drive.ToString("X2") + " // Drive Gauge: " + drive + "\n";
            }

            return ret;
        }
    }
}
