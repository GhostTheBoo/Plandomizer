using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.CodeDom;

namespace Plandomizer
{
    public partial class Form1 : Form
    {
        /*private List<List<Reward>> rewards;
        private List<List<rewardLocation>> rewardLocations;
        private List<Keyblade> keybladeList;
        private List<Bonus> bonusList;
        // private string finalOutput;
                
        enum RewardType
        {
            Ability,
            Accesory,
            Armor,
            Bonus,
            Form,
            Growth,
            Item,
            KeyItem,
            Keyblade,
            AreaMap,
            Proof,
            Recipe,
            Report,
            GoofyShield,
            DonaldStaff,
            Magic,
            Summon,
            SynthMat
        }

        enum RewardLocation
        {
            // Total: 22
            // Level
            // Donald
            // Goofy
            // Keyblade //27
            AbsentSilhouttes, //5
            Agrabah, //32
            Atlantica, //4
            BeastsCastle, //28
            CavernOfRemembrance, //24
            Critical, //7
            DataOrganization, //13
            DisneyCastle, //12
            Form, //30
            HalloweenTown, //19
            HollowBastion, //39
            LandOfDragons, //28
            OlympusColiseum, //31
            OlympusCups, //9
            HundredAcreWood, //24
            PortRoyal, //30
            PrideLands, //28
            SimulatedTwilightTown, //26
            SpaceParanoids, //18
            TimelessRiver, //12
            TwilightTown, //50
            TheWorldThatNeverWas //30
        }
        */
        public Form1()
        {
            InitializeComponent();
            /*
            rewards = Load_Rewards();
            rewardLocations = Load_Locations();
            keybladeList = Load_Keyblades();
            bonusList = Load_Bonuses();

            worldSelectorDropDown.DataSource = Enum.GetValues(typeof(RewardLocation));
            rewardTypeDropDown.DataSource = Enum.GetValues(typeof(RewardType));
            specificRewardDropDown.DisplayMember = "Title";*/
        }
        /*
        private List<List<Reward>> Load_Rewards()
        {
            // Loads all rewards and returns list of lists

            int skip = 1;
            int abilityCount = 80;
            int accessoryCount = 33;
            int armorCount = 34;
            int bonusCount = 6;
            int formCount = 5;
            int growthCount = 20;
            int itemCount = 14;
            int keyItemCount = 20;
            int keybladeCount = 26;
            int areaMapCount = 55;
            int proofCount = 3;
            int recipeCount = 16;
            int reportCount = 13;
            int gShieldCount = 22;
            int dStaffCount = 21;
            int magicCount = 6;
            int summonCount = 4;
            int synthMatCount = 60;

            string[] data = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Data\\rewards.txt");
            List<List<Reward>> ret = new List<List<Reward>>();

            List<Reward> ability = new List<Reward>();
            Populate_Rewards(data.Skip(skip).Take(2 * abilityCount), ability);
            ret.Add(ability);
            skip += 1 + (2 * abilityCount);

            List<Reward> accessory = new List<Reward>();
            Populate_Rewards(data.Skip(skip).Take(2 * accessoryCount), accessory);
            ret.Add(accessory);
            skip += 1 + (2 * accessoryCount);

            List<Reward> armor = new List<Reward>();
            Populate_Rewards(data.Skip(skip).Take(2 * armorCount), armor);
            ret.Add(armor);
            skip += 1 + (2 * armorCount);

            List<Reward> bonus = new List<Reward>();
            Populate_Rewards(data.Skip(skip).Take(2 * bonusCount), bonus);
            ret.Add(bonus);
            skip += 1 + (2 * bonusCount);

            List<Reward> form = new List<Reward>();
            Populate_Rewards(data.Skip(skip).Take(2 * formCount), form);
            ret.Add(form);
            skip += 1 + (2 * formCount);

            List<Reward> growth = new List<Reward>();
            Populate_Rewards(data.Skip(skip).Take(2 * growthCount), growth);
            ret.Add(growth);
            skip += 1 + (2 * growthCount);

            List<Reward> item = new List<Reward>();
            Populate_Rewards(data.Skip(skip).Take(2 * itemCount), item);
            ret.Add(item);
            skip += 1 + (2 * itemCount);

            List<Reward> keyItem = new List<Reward>();
            Populate_Rewards(data.Skip(skip).Take(2 * keyItemCount), keyItem);
            ret.Add(keyItem);
            skip += 1 + (2 * keyItemCount);

            List<Reward> keyblade = new List<Reward>();
            Populate_Rewards(data.Skip(skip).Take(2 * keybladeCount), keyblade);
            ret.Add(keyblade);
            skip += 1 + (2 * keybladeCount);

            List<Reward> areaMap = new List<Reward>();
            Populate_Rewards(data.Skip(skip).Take(2 * areaMapCount), areaMap);
            ret.Add(areaMap);
            skip += 1 + (2 * areaMapCount);

            List<Reward> proof = new List<Reward>();
            Populate_Rewards(data.Skip(skip).Take(2 * proofCount), proof);
            ret.Add(proof);
            skip += 1 + (2 * proofCount);

            List<Reward> recipe = new List<Reward>();
            Populate_Rewards(data.Skip(skip).Take(2 * recipeCount), recipe);
            ret.Add(recipe);
            skip += 1 + (2 * recipeCount);

            List<Reward> report = new List<Reward>();
            Populate_Rewards(data.Skip(skip).Take(2 * reportCount), report);
            ret.Add(report);
            skip += 1 + (2 * reportCount);

            List<Reward> gShield = new List<Reward>();
            Populate_Rewards(data.Skip(skip).Take(2 * gShieldCount), gShield);
            ret.Add(gShield);
            skip += 1 + (2 * gShieldCount);

            List<Reward> dStaff = new List<Reward>();
            Populate_Rewards(data.Skip(skip).Take(2 * dStaffCount), dStaff);
            ret.Add(dStaff);
            skip += 1 + (2 * dStaffCount);

            List<Reward> magic = new List<Reward>();
            Populate_Rewards(data.Skip(skip).Take(2 * magicCount), magic);
            ret.Add(magic);
            skip += 1 + (2 * magicCount);

            List<Reward> summon = new List<Reward>();
            Populate_Rewards(data.Skip(skip).Take(2 * summonCount), summon);
            ret.Add(summon);
            skip += 1 + (2 * summonCount);

            List<Reward> synthMat = new List<Reward>();
            Populate_Rewards(data.Skip(skip).Take(2 * synthMatCount), synthMat);
            ret.Add(synthMat);

            return ret;
        }

        private List<List<rewardLocation>> Load_Locations()
        {
            // Loads all reward locations and returns list of lists
            int skip = 1;
            int AScount = 5;
            int AGRcount = 32;
            int ATLcount = 4;
            int BCcount = 28;
            int CORcount = 24;
            int CRITcount = 7;
            int DOcount = 13;
            int DCcount = 12;
            int FORMcount = 30;
            int HTcount = 19;
            int HBcount = 39;
            int LODcount = 28;
            int OCcount = 31;
            int CUPScount = 9;
            int POOHcount = 24;
            int PRcount = 30;
            int PLcount = 28;
            int STTcount = 26;
            int SPcount = 18;
            int TRcount = 12;
            int TTcount = 50;
            int TWTNWcount = 30;

            string[] data = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Data\\rewardLocations.txt");

            List<List<rewardLocation>> ret = new List<List<rewardLocation>>();

            List<rewardLocation> AS = new List<rewardLocation>();
            Populate_RewardLocations(data.Skip(skip).Take(3 * AScount), AS);
            ret.Add(AS);
            skip += 1 + (3 * AScount);

            List<rewardLocation> AGR = new List<rewardLocation>();
            Populate_RewardLocations(data.Skip(skip).Take(3 * AGRcount), AGR);
            ret.Add(AGR);
            skip += 1 + (3 * AGRcount);

            List<rewardLocation> ATL = new List<rewardLocation>();
            Populate_RewardLocations(data.Skip(skip).Take(3 * ATLcount), ATL);
            ret.Add(ATL);
            skip += 1 + (3 * ATLcount);

            List<rewardLocation> BC = new List<rewardLocation>();
            Populate_RewardLocations(data.Skip(skip).Take(3 * BCcount), BC);
            ret.Add(BC);
            skip += 1 + (3 * BCcount);

            List<rewardLocation> COR = new List<rewardLocation>();
            Populate_RewardLocations(data.Skip(skip).Take(3 * CORcount), COR);
            ret.Add(COR);
            skip += 1 + (3 * CORcount);

            List<rewardLocation> CRIT = new List<rewardLocation>();
            Populate_RewardLocations(data.Skip(skip).Take(3 * CRITcount), CRIT);
            ret.Add(CRIT);
            skip += 1 + (3 * CRITcount);

            List<rewardLocation> DO = new List<rewardLocation>();
            Populate_RewardLocations(data.Skip(skip).Take(3 * DOcount), DO);
            ret.Add(DO);
            skip += 1 + (3 * DOcount);

            List<rewardLocation> DC = new List<rewardLocation>();
            Populate_RewardLocations(data.Skip(skip).Take(3 * DCcount), DC);
            ret.Add(DC);
            skip += 1 + (3 * DCcount);

            List<rewardLocation> FORM = new List<rewardLocation>();
            Populate_RewardLocations(data.Skip(skip).Take(3 * FORMcount), FORM);
            ret.Add(FORM);
            skip += 1 + (3 * FORMcount);

            List<rewardLocation> HT = new List<rewardLocation>();
            Populate_RewardLocations(data.Skip(skip).Take(3 * HTcount), HT);
            ret.Add(HT);
            skip += 1 + (3 * HTcount);

            List<rewardLocation> HB = new List<rewardLocation>();
            Populate_RewardLocations(data.Skip(skip).Take(3 * HBcount), HB);
            ret.Add(HB);
            skip += 1 + (3 * HBcount);

            List<rewardLocation> LOD = new List<rewardLocation>();
            Populate_RewardLocations(data.Skip(skip).Take(3 * LODcount), LOD);
            ret.Add(LOD);
            skip += 1 + (3 * LODcount);

            List<rewardLocation> OC = new List<rewardLocation>();
            Populate_RewardLocations(data.Skip(skip).Take(3 * OCcount), OC);
            ret.Add(OC);
            skip += 1 + (3 * OCcount);

            List<rewardLocation> CUPS = new List<rewardLocation>();
            Populate_RewardLocations(data.Skip(skip).Take(3 * CUPScount), CUPS);
            ret.Add(CUPS);
            skip += 1 + (3 * CUPScount);

            List<rewardLocation> POOH = new List<rewardLocation>();
            Populate_RewardLocations(data.Skip(skip).Take(3 * POOHcount), POOH);
            ret.Add(POOH);
            skip += 1 + (3 * POOHcount);

            List<rewardLocation> PR = new List<rewardLocation>();
            Populate_RewardLocations(data.Skip(skip).Take(3 * PRcount), PR);
            ret.Add(PR);
            skip += 1 + (3 * PRcount);

            List<rewardLocation> PL = new List<rewardLocation>();
            Populate_RewardLocations(data.Skip(skip).Take(3 * PLcount), PL);
            ret.Add(PL);
            skip += 1 + (3 * PLcount);

            List<rewardLocation> STT = new List<rewardLocation>();
            Populate_RewardLocations(data.Skip(skip).Take(3 * STTcount), STT);
            ret.Add(STT);
            skip += 1 + (3 * STTcount);

            List<rewardLocation> SP = new List<rewardLocation>();
            Populate_RewardLocations(data.Skip(skip).Take(3 * SPcount), SP);
            ret.Add(SP);
            skip += 1 + (3 * SPcount);

            List<rewardLocation> TR = new List<rewardLocation>();
            Populate_RewardLocations(data.Skip(skip).Take(3 * TRcount), TR);
            ret.Add(TR);
            skip += 1 + (3 * TRcount);

            List<rewardLocation> TT = new List<rewardLocation>();
            Populate_RewardLocations(data.Skip(skip).Take(3 * TTcount), TT);
            ret.Add(TT);
            skip += 1 + (3 * TTcount);

            List<rewardLocation> TWTNW = new List<rewardLocation>();
            Populate_RewardLocations(data.Skip(skip).Take(3 * TWTNWcount), TWTNW);
            ret.Add(TWTNW);

            return ret;
        }

        private List<Keyblade> Load_Keyblades()
        {
            string[] data = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Data\\keyblades.txt");
            List<Keyblade> ret = new List<Keyblade>();

            for(int i = 0; i < 27; i++)
                ret.Add(new Keyblade(data[(6 * i) + 0], data[(6 * i) + 1], data[(6 * i) + 2], data[(6 * i) + 3], Int32.Parse(data[(6 * i) + 4]), Int32.Parse(data[(6 * i) + 5])));

            return ret;
        }

        private List<Bonus> Load_Bonuses()
        {
            List<Bonus> ret = new List<Bonus>();
            string[] data = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Data\\bonus.txt");

            for(int i = 0; i < 60; i++)
                ret.Add(new Bonus(data[(5 * i) + 0], data[(5 * i) + 1], data[(5 * i) + 2], data[(5 * i) + 3], data[(5 * i) + 4]));

            return ret;
        }
        public void Populate_Rewards(IEnumerable<string> data, List<Reward> toPopulate)
        {
            string title = "";
            string index = "";
            bool memberStatus = true;

            foreach (string s in data)
            {
                if (memberStatus)
                {
                    title = s;
                    memberStatus = false;
                }
                else
                {
                    index = s;
                    memberStatus = true;
                    toPopulate.Add(new Reward(title, index));
                    title = "";
                    index = "";
                }
            }
        }

        public void Populate_RewardLocations(IEnumerable<string> data, List<rewardLocation> toPopulate)
        {
            string location = "";
            string original = "";
            string index = "";
            int memberStatus = 0;

            foreach (string s in data)
            {
                if (memberStatus == 0)
                {
                    location = s;
                    memberStatus++;
                }
                else
                {
                    if (memberStatus == 1)
                    {
                        original = s;
                        memberStatus++;
                    }
                    else
                    {
                        if (memberStatus == 2)
                        {
                            index = s;
                            memberStatus = 0;
                            toPopulate.Add(new rewardLocation(location, original, index));
                            location = "";
                            original = "";
                            index = "";
                        }
                    }
                }
            }
        }
        
        private void rewardTypeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            specificRewardDropDown.DataSource = rewards[rewardTypeDropDown.SelectedIndex];
        }

        private void worldSelectorDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            locationCheckList.DataSource = rewardLocations[worldSelectorDropDown.SelectedIndex];
            locationCheckList.AutoGenerateColumns = false;
            locationCheckList.Columns["Index"].Visible = false;
            locationCheckList.Columns["ReplacementIndex"].Visible = false;
        }

        private void replaceButton_Click(object sender, EventArgs e)
        {
            rewardLocation location = rewardLocations[worldSelectorDropDown.SelectedIndex][locationCheckList.SelectedRows[0].Index];
            Reward replace = rewards[rewardTypeDropDown.SelectedIndex][specificRewardDropDown.SelectedIndex];
            rewardLocations[worldSelectorDropDown.SelectedIndex][locationCheckList.SelectedRows[0].Index].isReplaced = true;
            rewardLocations[worldSelectorDropDown.SelectedIndex][locationCheckList.SelectedRows[0].Index].Replacement = replace.Title;
            rewardLocations[worldSelectorDropDown.SelectedIndex][locationCheckList.SelectedRows[0].Index].ReplacementIndex = replace.Index;
            locationCheckList.Update();
            locationCheckList.Refresh();
            /*DialogResult = MessageBox.Show("Are you sure you want to replace " + location.Original + " with " + replace.Title + "?", "Replace Confirmation", MessageBoxButtons.YesNo);
            if(DialogResult == DialogResult.Yes)
            {
            }*/
        //}
    /*
        private void fileSaveButton_Click(object sender, EventArgs e)
        {
           using (System.IO.StreamWriter file = new System.IO.StreamWriter("F266B00B.pnach"))
            {
                foreach(List<rewardLocation> rList in rewardLocations)
                {
                    foreach(rewardLocation r in rList)
                    {
                        //patch=1,EE,21D0BCB8,extended,0008C68C
                        if(r.isReplaced)
                            file.WriteLine("patch=1,EE," + r.Index + ",extended,0000" + r.ReplacementIndex + "// " + r.Location + ", " + r.Original + " has been replaced with " + r.Replacement);
                    }
                }
            }
            MessageBox.Show("File saved as F266B00B.pnach");
        }

        private void defaultButton_Click(object sender, EventArgs e)
        {
            rewardLocations[worldSelectorDropDown.SelectedIndex][locationCheckList.SelectedRows[0].Index].isReplaced = false;
            rewardLocations[worldSelectorDropDown.SelectedIndex][locationCheckList.SelectedRows[0].Index].Replacement = "DEFAULT";
            rewardLocations[worldSelectorDropDown.SelectedIndex][locationCheckList.SelectedRows[0].Index].ReplacementIndex = "";
            locationCheckList.Update();
            locationCheckList.Refresh();
        }
    */
    }
}