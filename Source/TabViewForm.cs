using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Data.OleDb;

namespace Plandomizer
{
    public partial class TabViewForm : Form
    {
        internal List<string> worldList;
        internal List<string> rewardTypeList;
        internal List<string> formTypeList;
        internal List<string> formExpList;
        internal List<string> equipmentTypeList;
        internal List<string> patchList;
        internal List<string> characterList;
        internal List<string> levelReplacementTypeList;
        internal List<int> levelNumberList;
        Color replacedBackground;
        Color defaultBackground;

        internal List<List<List<Bonus>>> bonusList;
        internal bool bonusReplaced = false;
        internal List<List<Chest>> chestList;
        internal bool chestReplaced = false;
        internal List<List<DriveForm>> driveFormList;
        internal bool formReplaced = false;
        internal List<List<Popup>> popupList;
        internal bool popupReplaced = false;
        internal List<List<Equipment>> equipmentList;
        internal bool equipmentReplaced = false;
        internal List<Level> levelList;
        internal bool levelReplaced = false;
        internal List<Critical> criticalList;
        internal bool criticalReplaced = false;
        internal Starting startingStuff;
        internal List<Cheat> cheatList;
        internal List<List<Reward>> rewardList;
        internal bool isDarkModeEnabled;

        public TabViewForm()
        {
            InitializeComponent();

            replacedBackground = Color.FromArgb(255, 150, 200);
            defaultBackground = Color.White;

            startingStuff = new Starting();
            isDarkModeEnabled = false;

            populateWorldList();
            populateRewardTypeList();
            populateFormTypeList();
            populateFormExpList();
            populateEquipmentTypeList();
            populatePatchList();
            populateCharacterList();
            populateLevelNumberList();
            populateLevelReplacementTypeList();

            bonusList = new List<List<List<Bonus>>>();

            loadSoraBonuses();
            loadDonaldBonuses();
            loadGoofyBonuses();
            loadChests();
            loadDriveForms();
            loadPopups();
            loadEquipment();
            loadRewards();
            loadLevels();
            loadCritical();
            loadCheats();

            #region Data Sources and Display Members
            bonusWorldSelectorComboBox.DataSource = worldList;
            chestsWorldSelectorComboBox.BindingContext = new BindingContext();
            chestsWorldSelectorComboBox.DataSource = worldList;
            popupWorldSelectorComboBox.BindingContext = new BindingContext();
            popupWorldSelectorComboBox.DataSource = worldList;
            formSelectorComboBox.DataSource = formTypeList;
            equipmentTypeSelectorComboBox.DataSource = equipmentTypeList;
            patchSelectorComboBox.DataSource = patchList;

            bonusRewardTypeComboBox1.BindingContext = new BindingContext();
            bonusRewardComboBox1.BindingContext = new BindingContext();
            bonusRewardTypeComboBox1.DataSource = rewardTypeList;
            bonusRewardTypeComboBox1.SelectedIndex = 17;
            bonusRewardTypeComboBox2.BindingContext = new BindingContext();
            bonusRewardComboBox2.BindingContext = new BindingContext();
            bonusRewardTypeComboBox2.DataSource = rewardTypeList;
            bonusRewardTypeComboBox2.SelectedIndex = 17;

            chestRewardTypeComboBox.BindingContext = new BindingContext();
            chestRewardComboBox.BindingContext = new BindingContext();
            chestRewardTypeComboBox.DataSource = rewardTypeList;
            chestRewardTypeComboBox.SelectedIndex = 17;

            equipmentRewardTypeComboBox.BindingContext = new BindingContext();
            equipmentRewardComboBox.BindingContext = new BindingContext();
            equipmentRewardTypeComboBox.DataSource = rewardTypeList;
            equipmentRewardTypeComboBox.SelectedIndex = 17;

            formRewardTypeComboBox.BindingContext = new BindingContext();
            formRewardComboBox.BindingContext = new BindingContext();
            formRewardTypeComboBox.DataSource = rewardTypeList;
            formRewardTypeComboBox.SelectedIndex = 17;
            formExpComboBox.DataSource = formExpList;
            formExpComboBox.SelectedIndex = 0;

            popupRewardTypeComboBox.BindingContext = new BindingContext();
            popupRewardComboBox.BindingContext = new BindingContext();
            popupRewardTypeComboBox.DataSource = rewardTypeList;
            popupRewardTypeComboBox.SelectedIndex = 17;

            levelDataGridView.DataSource = levelList;
            levelRewardReplacementTypeComboBox.DataSource = levelReplacementTypeList;
            swordRewardTypeComboBox.BindingContext = new BindingContext();
            swordRewardComboBox.BindingContext = new BindingContext();
            swordRewardTypeComboBox.DataSource = rewardTypeList;
            swordRewardTypeComboBox.SelectedIndex = 17;
            shieldRewardTypeComboBox.BindingContext = new BindingContext();
            shieldRewardComboBox.BindingContext = new BindingContext();
            shieldRewardTypeComboBox.DataSource = rewardTypeList;
            shieldRewardTypeComboBox.SelectedIndex = 17;
            staffRewardTypeComboBox.BindingContext = new BindingContext();
            staffRewardComboBox.BindingContext = new BindingContext();
            staffRewardTypeComboBox.DataSource = rewardTypeList;
            staffRewardTypeComboBox.SelectedIndex = 17;

            criticalDataGridView.DataSource = criticalList;
            critExtraRewardTypeComboBox.BindingContext = new BindingContext();
            critExtraRewardTypeComboBox.DataSource = rewardTypeList;
            critExtraRewardTypeComboBox.SelectedIndex = 17;
            critExtraRewardComboBox.BindingContext = new BindingContext();

            startingKeybladeComboBox.BindingContext = new BindingContext();
            startingKeybladeComboBox.DataSource = rewardList[7];
            startingArmorComboBox.BindingContext = new BindingContext();
            startingArmorComboBox.DataSource = rewardList[2];
            startingAccessoryComboBox.BindingContext = new BindingContext();
            startingAccessoryComboBox.DataSource = rewardList[1];

            cheatDataGridView.DataSource = cheatList;

            bonusCharacterSelectorComboBox.DataSource = characterList;

            bonusRewardComboBox1.DisplayMember = "reward";
            bonusRewardComboBox2.DisplayMember = "reward";
            chestRewardComboBox.DisplayMember = "reward";
            equipmentRewardComboBox.DisplayMember = "reward";
            formRewardComboBox.DisplayMember = "reward";
            popupRewardComboBox.DisplayMember = "reward";

            bonusHPCounter.Value = 0;
            bonusMPCounter.Value = 0;
            bonusArmorCounter.Value = 0;
            bonusAccessoryCounter.Value = 0;
            bonusItemCounter.Value = 0;
            bonusDriveCounter.Value = 0;
            #endregion

            #region Column visibility
            chestDataGridView.Columns["locationAddress"].Visible = false;
            chestDataGridView.Columns["replacementAddress"].Visible = false;
            chestDataGridView.Columns["changed"].Visible = false;

            bonusDataGridView.Columns["character"].Visible = false;
            bonusDataGridView.Columns["statAddress"].Visible = false;
            bonusDataGridView.Columns["slotAddress"].Visible = false;
            bonusDataGridView.Columns["rewardAddress"].Visible = false;
            bonusDataGridView.Columns["replacementRewardAddress1"].Visible = false;
            bonusDataGridView.Columns["replacementRewardAddress2"].Visible = false;
            bonusDataGridView.Columns["hpIncrease"].Visible = false;
            bonusDataGridView.Columns["mpIncrease"].Visible = false;
            bonusDataGridView.Columns["armorSlotIncrease"].Visible = false;
            bonusDataGridView.Columns["accessorySlotIncrease"].Visible = false;
            bonusDataGridView.Columns["itemSlotIncrease"].Visible = false;
            bonusDataGridView.Columns["driveGaugeIncrease"].Visible = false;
            bonusDataGridView.Columns["changeCount"].Visible = false;

            formDataGridView.Columns["originalAddress"].Visible = false;
            formDataGridView.Columns["replacementAddress"].Visible = false;
            formDataGridView.Columns["changed"].Visible = false;
            formDataGridView.Columns["expAddress"].Visible = false;
            formDataGridView.Columns["expChanged"].Visible = false;

            equipmentDataGridView.Columns["equipmentName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            equipmentDataGridView.Columns["ability"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            equipmentDataGridView.Columns["equipmentType"].Visible = false;
            equipmentDataGridView.Columns["abilityAddress"].Visible = false;
            equipmentDataGridView.Columns["statAddress"].Visible = false;
            equipmentDataGridView.Columns["elementalResistanceAddress"].Visible = false;
            equipmentDataGridView.Columns["otherResistanceAddress"].Visible = false;
            equipmentDataGridView.Columns["vanillaStrength"].Visible = false;
            equipmentDataGridView.Columns["vanillaMagic"].Visible = false;
            equipmentDataGridView.Columns["vanillaAP"].Visible = false;
            equipmentDataGridView.Columns["vanillaDefense"].Visible = false;
            equipmentDataGridView.Columns["vanillaAbility"].Visible = false;
            equipmentDataGridView.Columns["vanillaFireResistance"].Visible = false;
            equipmentDataGridView.Columns["vanillaBlizzardResistance"].Visible = false;
            equipmentDataGridView.Columns["vanillaThunderResistance"].Visible = false;
            equipmentDataGridView.Columns["vanillaDarkResistance"].Visible = false;
            equipmentDataGridView.Columns["changed"].Visible = false;
            equipmentDataGridView.Columns["replacementAbilityAddress"].Visible = false;

            popupDataGridView.Columns["locationAddress"].Visible = false;
            popupDataGridView.Columns["replacementAddress"].Visible = false;
            popupDataGridView.Columns["changed"].Visible = false;

            levelDataGridView.Columns["swordReplacement"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            levelDataGridView.Columns["shieldReplacement"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            levelDataGridView.Columns["staffReplacement"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            levelDataGridView.Columns["level"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            //levelDataGridView.Columns["ap"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //levelDataGridView.Columns["defense"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //levelDataGridView.Columns["strength"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //levelDataGridView.Columns["magic"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            levelDataGridView.Columns["expToNextAddress"].Visible = false;
            levelDataGridView.Columns["statAddress"].Visible = false;
            levelDataGridView.Columns["swordAddress"].Visible = false;
            levelDataGridView.Columns["shieldAddress"].Visible = false;
            levelDataGridView.Columns["staffAddress"].Visible = false;
            levelDataGridView.Columns["swordReplacementAddress"].Visible = false;
            levelDataGridView.Columns["shieldReplacementAddress"].Visible = false;
            levelDataGridView.Columns["staffReplacementAddress"].Visible = false;
            levelDataGridView.Columns["vanillaSword"].Visible = false;
            levelDataGridView.Columns["vanillaShield"].Visible = false;
            levelDataGridView.Columns["vanillaStaff"].Visible = false;
            levelDataGridView.Columns["rewardReplacementType"].Visible = false;
            levelDataGridView.Columns["changed"].Visible = false;

            criticalDataGridView.Columns["address"].Visible = false;
            criticalDataGridView.Columns["replacementAddress"].Visible = false;
            criticalDataGridView.Columns["changed"].Visible = false;

            cheatDataGridView.Columns["title"].ReadOnly = true;
            #endregion
        }

        public void loadSoraBonuses()
        {
            int entryCount = 5;
            int skip = 1;

            int agrCount = 5;
            int atlCount = 0;
            int bcCount = 4;
            int corCount = 1;
            int dcCount = 3;
            int htCount = 5;
            int hbCount = 4;
            int lodCount = 3;
            int ocCount = 7;
            int cupsCount = 0;
            int poohCount = 0;
            int prCount = 5;
            int plCount = 4;
            int sttCount = 4;
            int spCount = 5;
            int trCount = 2;
            int ttCount = 2;
            int twtnwCount = 6;

            List<List<Bonus>> soraTemp = new List<List<Bonus>>();
            string[] data = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Data\\soraBonus.txt");
            
            List<Bonus> temp = new List<Bonus>();
            populateBonusList(0, temp, data.Skip(skip).Take(entryCount * agrCount).ToArray(), agrCount);
            soraTemp.Add(temp);
            skip += 1 + (entryCount * agrCount);
            temp = new List<Bonus>();

            populateBonusList(0, temp, data.Skip(skip).Take(entryCount * atlCount).ToArray(), atlCount);
            soraTemp.Add(temp);
            skip += 1 + (entryCount * atlCount);
            temp = new List<Bonus>();

            populateBonusList(0, temp, data.Skip(skip).Take(entryCount * bcCount).ToArray(), bcCount);
            soraTemp.Add(temp);
            skip += 1 + (entryCount * bcCount);
            temp = new List<Bonus>();

            populateBonusList(0, temp, data.Skip(skip).Take(entryCount * corCount).ToArray(), corCount);
            soraTemp.Add(temp);
            skip += 1 + (entryCount * corCount);
            temp = new List<Bonus>();

            populateBonusList(0, temp, data.Skip(skip).Take(entryCount * dcCount).ToArray(), dcCount);
            soraTemp.Add(temp);
            skip += 1 + (entryCount * dcCount);
            temp = new List<Bonus>();

            populateBonusList(0, temp, data.Skip(skip).Take(entryCount * htCount).ToArray(), htCount);
            soraTemp.Add(temp);
            skip += 1 + (entryCount * htCount);
            temp = new List<Bonus>();

            populateBonusList(0, temp, data.Skip(skip).Take(entryCount * hbCount).ToArray(), hbCount);
            soraTemp.Add(temp);
            skip += 1 + (entryCount * hbCount);
            temp = new List<Bonus>();

            populateBonusList(0, temp, data.Skip(skip).Take(entryCount * lodCount).ToArray(), lodCount);
            soraTemp.Add(temp);
            skip += 1 + (entryCount * lodCount);
            temp = new List<Bonus>();

            populateBonusList(0, temp, data.Skip(skip).Take(entryCount * ocCount).ToArray(), ocCount);
            soraTemp.Add(temp);
            skip += 1 + (entryCount * ocCount);
            temp = new List<Bonus>();

            populateBonusList(0, temp, data.Skip(skip).Take(entryCount * cupsCount).ToArray(), cupsCount);
            soraTemp.Add(temp);
            skip += 1 + (entryCount * cupsCount);
            temp = new List<Bonus>();

            populateBonusList(0, temp, data.Skip(skip).Take(entryCount * poohCount).ToArray(), poohCount);
            soraTemp.Add(temp);
            skip += 1 + (entryCount * poohCount);
            temp = new List<Bonus>();

            populateBonusList(0, temp, data.Skip(skip).Take(entryCount * prCount).ToArray(), prCount);
            soraTemp.Add(temp);
            skip += 1 + (entryCount * prCount);
            temp = new List<Bonus>();

            populateBonusList(0, temp, data.Skip(skip).Take(entryCount * plCount).ToArray(), plCount);
            soraTemp.Add(temp);
            skip += 1 + (entryCount * plCount);
            temp = new List<Bonus>();

            populateBonusList(0, temp, data.Skip(skip).Take(entryCount * sttCount).ToArray(), sttCount);
            soraTemp.Add(temp);
            skip += 1 + (entryCount * sttCount);
            temp = new List<Bonus>();

            populateBonusList(0, temp, data.Skip(skip).Take(entryCount * spCount).ToArray(), spCount);
            soraTemp.Add(temp);
            skip += 1 + (entryCount * spCount);
            temp = new List<Bonus>();

            populateBonusList(0, temp, data.Skip(skip).Take(entryCount * trCount).ToArray(), trCount);
            soraTemp.Add(temp);
            skip += 1 + (entryCount * trCount);
            temp = new List<Bonus>();

            populateBonusList(0, temp, data.Skip(skip).Take(entryCount * ttCount).ToArray(), ttCount);
            soraTemp.Add(temp);
            skip += 1 + (entryCount * ttCount);
            temp = new List<Bonus>();

            populateBonusList(0, temp, data.Skip(skip).Take(entryCount * twtnwCount).ToArray(), twtnwCount);
            soraTemp.Add(temp);

            bonusList.Add(soraTemp);
        }
        public void loadDonaldBonuses()
        {
            int entryCount = 5;
            int skip = 1;

            int agrCount = 4;
            int atlCount = 0;
            int bcCount = 4;
            int corCount = 1;
            int dcCount = 2;
            int htCount = 5;
            int hbCount = 1;
            int lodCount = 2;
            int ocCount = 5;
            int cupsCount = 0;
            int poohCount = 0;
            int prCount = 5;
            int plCount = 3;
            int sttCount = 0;
            int spCount = 5;
            int trCount = 2;
            int ttCount = 1;
            int twtnwCount = 2;

            List<List<Bonus>> donaldTemp = new List<List<Bonus>>();
            string[] data = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Data\\donaldBonus.txt");

            List<Bonus> temp = new List<Bonus>();
            populateBonusList(1, temp, data.Skip(skip).Take(entryCount * agrCount).ToArray(), agrCount);
            donaldTemp.Add(temp);
            skip += 1 + (entryCount * agrCount);
            temp = new List<Bonus>();

            populateBonusList(1, temp, data.Skip(skip).Take(entryCount * atlCount).ToArray(), atlCount);
            donaldTemp.Add(temp);
            skip += 1 + (entryCount * atlCount);
            temp = new List<Bonus>();

            populateBonusList(1, temp, data.Skip(skip).Take(entryCount * bcCount).ToArray(), bcCount);
            donaldTemp.Add(temp);
            skip += 1 + (entryCount * bcCount);
            temp = new List<Bonus>();

            populateBonusList(1, temp, data.Skip(skip).Take(entryCount * corCount).ToArray(), corCount);
            donaldTemp.Add(temp);
            skip += 1 + (entryCount * corCount);
            temp = new List<Bonus>();

            populateBonusList(1, temp, data.Skip(skip).Take(entryCount * dcCount).ToArray(), dcCount);
            donaldTemp.Add(temp);
            skip += 1 + (entryCount * dcCount);
            temp = new List<Bonus>();

            populateBonusList(1, temp, data.Skip(skip).Take(entryCount * htCount).ToArray(), htCount);
            donaldTemp.Add(temp);
            skip += 1 + (entryCount * htCount);
            temp = new List<Bonus>();

            populateBonusList(1, temp, data.Skip(skip).Take(entryCount * hbCount).ToArray(), hbCount);
            donaldTemp.Add(temp);
            skip += 1 + (entryCount * hbCount);
            temp = new List<Bonus>();

            populateBonusList(1, temp, data.Skip(skip).Take(entryCount * lodCount).ToArray(), lodCount);
            donaldTemp.Add(temp);
            skip += 1 + (entryCount * lodCount);
            temp = new List<Bonus>();

            populateBonusList(1, temp, data.Skip(skip).Take(entryCount * ocCount).ToArray(), ocCount);
            donaldTemp.Add(temp);
            skip += 1 + (entryCount * ocCount);
            temp = new List<Bonus>();

            populateBonusList(1, temp, data.Skip(skip).Take(entryCount * cupsCount).ToArray(), cupsCount);
            donaldTemp.Add(temp);
            skip += 1 + (entryCount * cupsCount);
            temp = new List<Bonus>();

            populateBonusList(1, temp, data.Skip(skip).Take(entryCount * poohCount).ToArray(), poohCount);
            donaldTemp.Add(temp);
            skip += 1 + (entryCount * poohCount);
            temp = new List<Bonus>();

            populateBonusList(1, temp, data.Skip(skip).Take(entryCount * prCount).ToArray(), prCount);
            donaldTemp.Add(temp);
            skip += 1 + (entryCount * prCount);
            temp = new List<Bonus>();

            populateBonusList(1, temp, data.Skip(skip).Take(entryCount * plCount).ToArray(), plCount);
            donaldTemp.Add(temp);
            skip += 1 + (entryCount * plCount);
            temp = new List<Bonus>();

            populateBonusList(1, temp, data.Skip(skip).Take(entryCount * sttCount).ToArray(), sttCount);
            donaldTemp.Add(temp);
            skip += 1 + (entryCount * sttCount);
            temp = new List<Bonus>();

            populateBonusList(1, temp, data.Skip(skip).Take(entryCount * spCount).ToArray(), spCount);
            donaldTemp.Add(temp);
            skip += 1 + (entryCount * spCount);
            temp = new List<Bonus>();

            populateBonusList(1, temp, data.Skip(skip).Take(entryCount * trCount).ToArray(), trCount);
            donaldTemp.Add(temp);
            skip += 1 + (entryCount * trCount);
            temp = new List<Bonus>();

            populateBonusList(1, temp, data.Skip(skip).Take(entryCount * ttCount).ToArray(), ttCount);
            donaldTemp.Add(temp);
            skip += 1 + (entryCount * ttCount);
            temp = new List<Bonus>();

            populateBonusList(1, temp, data.Skip(skip).Take(entryCount * twtnwCount).ToArray(), twtnwCount);
            donaldTemp.Add(temp);

            bonusList.Add(donaldTemp);
        }
        public void loadGoofyBonuses()
        {
            int entryCount = 5;
            int skip = 1;

            int agrCount = 4;
            int atlCount = 0;
            int bcCount = 4;
            int corCount = 1;
            int dcCount = 2;
            int htCount = 5;
            int hbCount = 1;
            int lodCount = 2;
            int ocCount = 5;
            int cupsCount = 0;
            int poohCount = 0;
            int prCount = 5;
            int plCount = 3;
            int sttCount = 0;
            int spCount = 5;
            int trCount = 2;
            int ttCount = 1;
            int twtnwCount = 2;

            List<List<Bonus>> goofyTemp = new List<List<Bonus>>();
            string[] data = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Data\\goofyBonus.txt");

            List<Bonus> temp = new List<Bonus>();
            populateBonusList(2, temp, data.Skip(skip).Take(entryCount * agrCount).ToArray(), agrCount);
            goofyTemp.Add(temp);
            skip += 1 + (entryCount * agrCount);
            temp = new List<Bonus>();

            populateBonusList(2, temp, data.Skip(skip).Take(entryCount * atlCount).ToArray(), atlCount);
            goofyTemp.Add(temp);
            skip += 1 + (entryCount * atlCount);
            temp = new List<Bonus>();

            populateBonusList(2, temp, data.Skip(skip).Take(entryCount * bcCount).ToArray(), bcCount);
            goofyTemp.Add(temp);
            skip += 1 + (entryCount * bcCount);
            temp = new List<Bonus>();

            populateBonusList(2, temp, data.Skip(skip).Take(entryCount * corCount).ToArray(), corCount);
            goofyTemp.Add(temp);
            skip += 1 + (entryCount * corCount);
            temp = new List<Bonus>();

            populateBonusList(2, temp, data.Skip(skip).Take(entryCount * dcCount).ToArray(), dcCount);
            goofyTemp.Add(temp);
            skip += 1 + (entryCount * dcCount);
            temp = new List<Bonus>();

            populateBonusList(2, temp, data.Skip(skip).Take(entryCount * htCount).ToArray(), htCount);
            goofyTemp.Add(temp);
            skip += 1 + (entryCount * htCount);
            temp = new List<Bonus>();

            populateBonusList(2, temp, data.Skip(skip).Take(entryCount * hbCount).ToArray(), hbCount);
            goofyTemp.Add(temp);
            skip += 1 + (entryCount * hbCount);
            temp = new List<Bonus>();

            populateBonusList(2, temp, data.Skip(skip).Take(entryCount * lodCount).ToArray(), lodCount);
            goofyTemp.Add(temp);
            skip += 1 + (entryCount * lodCount);
            temp = new List<Bonus>();

            populateBonusList(2, temp, data.Skip(skip).Take(entryCount * ocCount).ToArray(), ocCount);
            goofyTemp.Add(temp);
            skip += 1 + (entryCount * ocCount);
            temp = new List<Bonus>();

            populateBonusList(2, temp, data.Skip(skip).Take(entryCount * cupsCount).ToArray(), cupsCount);
            goofyTemp.Add(temp);
            skip += 1 + (entryCount * cupsCount);
            temp = new List<Bonus>();

            populateBonusList(2, temp, data.Skip(skip).Take(entryCount * poohCount).ToArray(), poohCount);
            goofyTemp.Add(temp);
            skip += 1 + (entryCount * poohCount);
            temp = new List<Bonus>();

            populateBonusList(2, temp, data.Skip(skip).Take(entryCount * prCount).ToArray(), prCount);
            goofyTemp.Add(temp);
            skip += 1 + (entryCount * prCount);
            temp = new List<Bonus>();

            populateBonusList(2, temp, data.Skip(skip).Take(entryCount * plCount).ToArray(), plCount);
            goofyTemp.Add(temp);
            skip += 1 + (entryCount * plCount);
            temp = new List<Bonus>();

            populateBonusList(2, temp, data.Skip(skip).Take(entryCount * sttCount).ToArray(), sttCount);
            goofyTemp.Add(temp);
            skip += 1 + (entryCount * sttCount);
            temp = new List<Bonus>();

            populateBonusList(2, temp, data.Skip(skip).Take(entryCount * spCount).ToArray(), spCount);
            goofyTemp.Add(temp);
            skip += 1 + (entryCount * spCount);
            temp = new List<Bonus>();

            populateBonusList(2, temp, data.Skip(skip).Take(entryCount * trCount).ToArray(), trCount);
            goofyTemp.Add(temp);
            skip += 1 + (entryCount * trCount);
            temp = new List<Bonus>();

            populateBonusList(2, temp, data.Skip(skip).Take(entryCount * ttCount).ToArray(), ttCount);
            goofyTemp.Add(temp);
            skip += 1 + (entryCount * ttCount);
            temp = new List<Bonus>();

            populateBonusList(2, temp, data.Skip(skip).Take(entryCount * twtnwCount).ToArray(), twtnwCount);
            goofyTemp.Add(temp);

            bonusList.Add(goofyTemp);
        }
        public void loadChests()
        {
            int entryCount = 3;
            int skip = 1;

            int agrCount = 26;
            int atlCount = 0;
            int bcCount = 21;
            int corCount = 24;
            int dcCount = 8;
            int htCount = 14;
            int hbCount = 22;
            int lodCount = 21;
            int ocCount = 20;
            int cupsCount = 0;
            int poohCount = 20;
            int prCount = 21;
            int plCount = 25;
            int sttCount = 16;
            int spCount = 14;
            int trCount = 7;
            int ttCount = 39;
            int twtnwCount = 19;

            chestList = new List<List<Chest>>();
            string[] data = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Data\\chests.txt");

            List<Chest> temp = new List<Chest>();
            populateChestList(temp, data.Skip(skip).Take(entryCount * agrCount).ToArray(), agrCount);
            chestList.Add(temp);
            skip += 1 + (entryCount * agrCount);
            temp = new List<Chest>();

            populateChestList(temp, data.Skip(skip).Take(entryCount * atlCount).ToArray(), atlCount);
            chestList.Add(temp);
            skip += 1 + (entryCount * atlCount);
            temp = new List<Chest>();

            populateChestList(temp, data.Skip(skip).Take(entryCount * bcCount).ToArray(), bcCount);
            chestList.Add(temp);
            skip += 1 + (entryCount * bcCount);
            temp = new List<Chest>();

            populateChestList(temp, data.Skip(skip).Take(entryCount * corCount).ToArray(), corCount);
            chestList.Add(temp);
            skip += 1 + (entryCount * corCount);
            temp = new List<Chest>();

            populateChestList(temp, data.Skip(skip).Take(entryCount * dcCount).ToArray(), dcCount);
            chestList.Add(temp);
            skip += 1 + (entryCount * dcCount);
            temp = new List<Chest>();

            populateChestList(temp, data.Skip(skip).Take(entryCount * htCount).ToArray(), htCount);
            chestList.Add(temp);
            skip += 1 + (entryCount * htCount);
            temp = new List<Chest>();

            populateChestList(temp, data.Skip(skip).Take(entryCount * hbCount).ToArray(), hbCount);
            chestList.Add(temp);
            skip += 1 + (entryCount * hbCount);
            temp = new List<Chest>();

            populateChestList(temp, data.Skip(skip).Take(entryCount * lodCount).ToArray(), lodCount);
            chestList.Add(temp);
            skip += 1 + (entryCount * lodCount);
            temp = new List<Chest>();

            populateChestList(temp, data.Skip(skip).Take(entryCount * ocCount).ToArray(), ocCount);
            chestList.Add(temp);
            skip += 1 + (entryCount * ocCount);
            temp = new List<Chest>();

            populateChestList(temp, data.Skip(skip).Take(entryCount * cupsCount).ToArray(), cupsCount);
            chestList.Add(temp);
            skip += 1 + (entryCount * cupsCount);
            temp = new List<Chest>();

            populateChestList(temp, data.Skip(skip).Take(entryCount * poohCount).ToArray(), poohCount);
            chestList.Add(temp);
            skip += 1 + (entryCount * poohCount);
            temp = new List<Chest>();

            populateChestList(temp, data.Skip(skip).Take(entryCount * prCount).ToArray(), prCount);
            chestList.Add(temp);
            skip += 1 + (entryCount * prCount);
            temp = new List<Chest>();

            populateChestList(temp, data.Skip(skip).Take(entryCount * plCount).ToArray(), plCount);
            chestList.Add(temp);
            skip += 1 + (entryCount * plCount);
            temp = new List<Chest>();

            populateChestList(temp, data.Skip(skip).Take(entryCount * sttCount).ToArray(), sttCount);
            chestList.Add(temp);
            skip += 1 + (entryCount * sttCount);
            temp = new List<Chest>();

            populateChestList(temp, data.Skip(skip).Take(entryCount * spCount).ToArray(), spCount);
            chestList.Add(temp);
            skip += 1 + (entryCount * spCount);
            temp = new List<Chest>();

            populateChestList(temp, data.Skip(skip).Take(entryCount * trCount).ToArray(), trCount);
            chestList.Add(temp);
            skip += 1 + (entryCount * trCount);
            temp = new List<Chest>();

            populateChestList(temp, data.Skip(skip).Take(entryCount * ttCount).ToArray(), ttCount);
            chestList.Add(temp);
            skip += 1 + (entryCount * ttCount);
            temp = new List<Chest>();

            populateChestList(temp, data.Skip(skip).Take(entryCount * twtnwCount).ToArray(), twtnwCount);
            chestList.Add(temp);
        }
        public void loadDriveForms()
        {
            int entryCount = 5;
            int skip = 1;

            int dCount = 6;

            driveFormList = new List<List<DriveForm>>();
            string[] data = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Data\\forms.txt");

            List<DriveForm> temp = new List<DriveForm>();
            for(int i = 0; i < 5; i++)
            {
                populateDriveFormList(temp, data.Skip(skip).Take(entryCount * dCount).ToArray(), dCount);
                driveFormList.Add(temp);
                skip += 1 + (entryCount * dCount);
                temp = new List<DriveForm>();
            }
        }
        public void loadPopups()
        {
            int entryCount = 3;
            int skip = 1;

            int agrCount = 5;
            int atlCount = 4;
            int bcCount = 5;
            int corCount = 0;
            int dcCount = 5;
            int htCount = 6;
            int hbCount = 15;
            int lodCount = 5;
            int ocCount = 8;
            int cupsCount = 9;
            int poohCount = 4;
            int prCount = 6;
            int plCount = 3;
            int sttCount = 8;
            int spCount = 3;
            int trCount = 3;
            int ttCount = 11;
            int twtnwCount = 10;

            popupList = new List<List<Popup>>();
            string[] data = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Data\\popups.txt");

            List<Popup> temp = new List<Popup>();
            populatePopupList(temp, data.Skip(skip).Take(entryCount * agrCount).ToArray(), agrCount);
            popupList.Add(temp);
            skip += 1 + (entryCount * agrCount);
            temp = new List<Popup>();

            populatePopupList(temp, data.Skip(skip).Take(entryCount * bcCount).ToArray(), atlCount);
            popupList.Add(temp);
            skip += 1 + (entryCount * atlCount);
            temp = new List<Popup>();

            populatePopupList(temp, data.Skip(skip).Take(entryCount * bcCount).ToArray(), bcCount);
            popupList.Add(temp);
            skip += 1 + (entryCount * bcCount);
            temp = new List<Popup>();

            populatePopupList(temp, data.Skip(skip).Take(entryCount * corCount).ToArray(), corCount);
            popupList.Add(temp);
            skip += 1 + (entryCount * corCount);
            temp = new List<Popup>();

            populatePopupList(temp, data.Skip(skip).Take(entryCount * dcCount).ToArray(), dcCount);
            popupList.Add(temp);
            skip += 1 + (entryCount * dcCount);
            temp = new List<Popup>();

            populatePopupList(temp, data.Skip(skip).Take(entryCount * htCount).ToArray(), htCount);
            popupList.Add(temp);
            skip += 1 + (entryCount * htCount);
            temp = new List<Popup>();

            populatePopupList(temp, data.Skip(skip).Take(entryCount * hbCount).ToArray(), hbCount);
            popupList.Add(temp);
            skip += 1 + (entryCount * hbCount);
            temp = new List<Popup>();

            populatePopupList(temp, data.Skip(skip).Take(entryCount * lodCount).ToArray(), lodCount);
            popupList.Add(temp);
            skip += 1 + (entryCount * lodCount);
            temp = new List<Popup>();

            populatePopupList(temp, data.Skip(skip).Take(entryCount * ocCount).ToArray(), ocCount);
            popupList.Add(temp);
            skip += 1 + (entryCount * ocCount);
            temp = new List<Popup>();

            populatePopupList(temp, data.Skip(skip).Take(entryCount * cupsCount).ToArray(), cupsCount);
            popupList.Add(temp);
            skip += 1 + (entryCount * cupsCount);

            temp = new List<Popup>();
            populatePopupList(temp, data.Skip(skip).Take(entryCount * poohCount).ToArray(), poohCount);
            popupList.Add(temp);
            skip += 1 + (entryCount * poohCount);

            temp = new List<Popup>();
            populatePopupList(temp, data.Skip(skip).Take(entryCount * prCount).ToArray(), prCount);
            popupList.Add(temp);
            skip += 1 + (entryCount * prCount);

            temp = new List<Popup>();
            populatePopupList(temp, data.Skip(skip).Take(entryCount * plCount).ToArray(), plCount);
            popupList.Add(temp);
            skip += 1 + (entryCount * plCount);
            temp = new List<Popup>();

            populatePopupList(temp, data.Skip(skip).Take(entryCount * sttCount).ToArray(), sttCount);
            popupList.Add(temp);
            skip += 1 + (entryCount * sttCount);
            temp = new List<Popup>();

            populatePopupList(temp, data.Skip(skip).Take(entryCount * spCount).ToArray(), spCount);
            popupList.Add(temp);
            skip += 1 + (entryCount * spCount);
            temp = new List<Popup>();

            populatePopupList(temp, data.Skip(skip).Take(entryCount * trCount).ToArray(), trCount);
            popupList.Add(temp);
            skip += 1 + (entryCount * trCount);
            temp = new List<Popup>();

            populatePopupList(temp, data.Skip(skip).Take(entryCount * ttCount).ToArray(), ttCount);
            popupList.Add(temp);
            skip += 1 + (entryCount * ttCount);
            temp = new List<Popup>();

            populatePopupList(temp, data.Skip(skip).Take(entryCount * twtnwCount).ToArray(), twtnwCount);
            popupList.Add(temp);
        }
        public void loadEquipment()
        {
            int kbEntryCount = 8;
            int dsEntryCount = 8;
            int gsEntryCount = 8;
            int awEntryCount = 7;
            int armEntryCount = 11;
            int accEntryCount = 9;

            //int entryCount = 5;
            int skip = 1;

            int kbCount = 27;
            int dsCount = 20;
            int gsCount = 20;
            int awCount = 8;
            int armCount = 33;
            int accCount = 33;

            equipmentList = new List<List<Equipment>>();
            string[] data = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Data\\equipment.txt");

            List<Equipment> temp = new List<Equipment>();
            populateEquipmentList(0, temp, data.Skip(skip).Take(kbEntryCount * kbCount).ToArray(), kbCount, kbEntryCount);
            equipmentList.Add(temp);
            skip += 1 + (kbEntryCount * kbCount);
            temp = new List<Equipment>();

            populateEquipmentList(1, temp, data.Skip(skip).Take(dsEntryCount * dsCount).ToArray(), dsCount, dsEntryCount);
            equipmentList.Add(temp);
            skip += 1 + (dsEntryCount * dsCount);
            temp = new List<Equipment>();

            populateEquipmentList(2, temp, data.Skip(skip).Take(gsEntryCount * gsCount).ToArray(), gsCount, gsEntryCount);
            equipmentList.Add(temp);
            skip += 1 + (gsEntryCount * gsCount);
            temp = new List<Equipment>();

            populateEquipmentList(3, temp, data.Skip(skip).Take(awEntryCount * awCount).ToArray(), awCount, awEntryCount);
            equipmentList.Add(temp);
            skip += 1 + (awEntryCount * awCount);
            temp = new List<Equipment>();

            populateEquipmentList(4, temp, data.Skip(skip).Take(armEntryCount * armCount).ToArray(), armCount, armEntryCount);
            equipmentList.Add(temp);
            skip += 1 + (armEntryCount * armCount);
            temp = new List<Equipment>();

            populateEquipmentList(5, temp, data.Skip(skip).Take(accEntryCount * accCount).ToArray(), accCount, accEntryCount);
            equipmentList.Add(temp);

        }
        public void loadRewards()
        {
            int entryCount = 2;
            int skip = 1;

            int abilityCount = 80;
            int accessoryCount = 33;
            int armorCount = 34;
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

            rewardList = new List<List<Reward>>();
            string[] data = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Data\\rewards.txt");

            List<Reward> temp = new List<Reward>();
            populateRewardList(temp, data.Skip(skip).Take(entryCount * abilityCount).ToArray(), abilityCount);
            rewardList.Add(temp);
            skip += 1 + (entryCount * abilityCount);
            temp = new List<Reward>();

            populateRewardList(temp, data.Skip(skip).Take(entryCount * accessoryCount).ToArray(), accessoryCount);
            rewardList.Add(temp);
            skip += 1 + (entryCount * accessoryCount);
            temp = new List<Reward>();

            populateRewardList(temp, data.Skip(skip).Take(entryCount * armorCount).ToArray(), armorCount);
            rewardList.Add(temp);
            skip += 1 + (entryCount * armorCount);
            temp = new List<Reward>();

            populateRewardList(temp, data.Skip(skip).Take(entryCount * formCount).ToArray(), formCount);
            rewardList.Add(temp);
            skip += 1 + (entryCount * formCount);
            temp = new List<Reward>();

            populateRewardList(temp, data.Skip(skip).Take(entryCount * growthCount).ToArray(), growthCount);
            rewardList.Add(temp);
            skip += 1 + (entryCount * growthCount);
            temp = new List<Reward>();

            populateRewardList(temp, data.Skip(skip).Take(entryCount * itemCount).ToArray(), itemCount);
            rewardList.Add(temp);
            skip += 1 + (entryCount * itemCount);
            temp = new List<Reward>();

            populateRewardList(temp, data.Skip(skip).Take(entryCount * keyItemCount).ToArray(), keyItemCount);
            rewardList.Add(temp);
            skip += 1 + (entryCount * keyItemCount);
            temp = new List<Reward>();

            populateRewardList(temp, data.Skip(skip).Take(entryCount * keybladeCount).ToArray(), keybladeCount);
            rewardList.Add(temp);
            skip += 1 + (entryCount * keybladeCount);
            temp = new List<Reward>();

            populateRewardList(temp, data.Skip(skip).Take(entryCount * areaMapCount).ToArray(), areaMapCount);
            rewardList.Add(temp);
            skip += 1 + (entryCount * areaMapCount);
            temp = new List<Reward>();

            populateRewardList(temp, data.Skip(skip).Take(entryCount * proofCount).ToArray(), proofCount);
            rewardList.Add(temp);
            skip += 1 + (entryCount * proofCount);
            temp = new List<Reward>();

            populateRewardList(temp, data.Skip(skip).Take(entryCount * recipeCount).ToArray(), recipeCount);
            rewardList.Add(temp);
            skip += 1 + (entryCount * recipeCount);
            temp = new List<Reward>();

            populateRewardList(temp, data.Skip(skip).Take(entryCount * reportCount).ToArray(), reportCount);
            rewardList.Add(temp);
            skip += 1 + (entryCount * reportCount);
            temp = new List<Reward>();

            populateRewardList(temp, data.Skip(skip).Take(entryCount * gShieldCount).ToArray(), gShieldCount);
            rewardList.Add(temp);
            skip += 1 + (entryCount * gShieldCount);
            temp = new List<Reward>();

            populateRewardList(temp, data.Skip(skip).Take(entryCount * dStaffCount).ToArray(), dStaffCount);
            rewardList.Add(temp);
            skip += 1 + (entryCount * dStaffCount);
            temp = new List<Reward>();

            populateRewardList(temp, data.Skip(skip).Take(entryCount * magicCount).ToArray(), magicCount);
            rewardList.Add(temp);
            skip += 1 + (entryCount * magicCount);
            temp = new List<Reward>();

            populateRewardList(temp, data.Skip(skip).Take(entryCount * summonCount).ToArray(), summonCount);
            rewardList.Add(temp);
            skip += 1 + (entryCount * summonCount);
            temp = new List<Reward>();

            populateRewardList(temp, data.Skip(skip).Take(entryCount * synthMatCount).ToArray(), synthMatCount);
            rewardList.Add(temp);
        }
        public void loadLevels()
        {
            string[] entries = new string[8];

            levelList = new List<Level>();
            string[] data = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Data\\levels.txt");

            for(int i = 1; i < 100; i++)
            {
                entries[0] = data[(9 * (i - 1)) + 1];
                entries[1] = data[(9 * (i - 1)) + 2];
                entries[2] = data[(9 * (i - 1)) + 3];
                entries[3] = data[(9 * (i - 1)) + 4];
                entries[4] = data[(9 * (i - 1)) + 5];
                entries[5] = data[(9 * (i - 1)) + 6];
                entries[6] = data[(9 * (i - 1)) + 7];
                entries[7] = data[(9 * (i - 1)) + 8];
                levelList.Add(new Level(i, entries));
            }
        }
        public void loadCritical()
        {
            string[] entries = new string[2];

            criticalList = new List<Critical>();
            string[] data = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Data\\critical.txt");

            for(int i = 0; i < 7; i++)
            {
                entries[0] = data[(2 * i) + 0];
                entries[1] = data[(2 * i) + 1];
                criticalList.Add(new Critical(entries[0], entries[1]));
            }
        }
        public void loadCheats()
        {
            string title = "";
            int lineCount = 0;
            int skip = 0;
            List<string> temp = new List<string>();

            cheatList = new List<Cheat>();
            string[] data = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Data\\cheat.txt");

            for(int i = 0; i < 8; i++)
            {
                title = data[skip];
                lineCount = Convert.ToInt32(data[skip + 1]);
                for (int j = 0; j < lineCount; j++)
                    temp.Add(data[skip + 2 + j]);
                cheatList.Add(new Cheat(title, temp));
                temp.Clear();
                skip += 2 + lineCount;
            }

        }

        internal void populateBonusList(int characterID, List<Bonus> bList, string[] data, int worldCount)
        {
            string[] entries = new string[5];

            for(int i = 0; i < worldCount; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    entries[j] = data[(5 * i) + j];
                }
                bList.Add(new Bonus(characterList[characterID], entries[0], entries[1], entries[2], entries[3], entries[4]));
            }
        }
        internal void populateChestList(List<Chest> cList, string[] data, int worldCount)
        {
            string[] entries = new string[3];

            for (int i = 0; i < worldCount; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    entries[j] = data[(3 * i) + j];
                }
                cList.Add(new Chest(entries[0], entries[1], entries[2]));
            }
        }
        internal void populateDriveFormList(List<DriveForm> dFList, string[] data, int formCount)
        {
            string[] entries = new string[5];

            for (int i = 0; i < formCount; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    entries[j] = data[(5 * i) + j];
                }
                dFList.Add(new DriveForm(entries[0], entries[1], entries[2], entries[3], Convert.ToInt32(entries[4])));
            }
        }
        internal void populatePopupList(List<Popup> pList, string[] data, int worldCount)
        {
            string[] entries = new string[3];

            for (int i = 0; i < worldCount; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    entries[j] = data[(3 * i) + j];
                }
                pList.Add(new Popup(entries[0], entries[1], entries[2]));
            }
        }
        internal void populateEquipmentList(int equipmentTypeID, List<Equipment> eList, string[] data, int typeCount, int entryCount)
        {
            string[] entries = new string[15];

            for (int i = 0; i < typeCount; i++)
            {
                entries[0] = equipmentTypeList[equipmentTypeID];
                entries[1] = data[(entryCount * i) + 0];
                entries[2] = data[(entryCount * i) + 1];
                entries[3] = data[(entryCount * i) + 2];
                entries[4] = data[(entryCount * i) + 3];
                entries[5] = data[(entryCount * i) + 4];
                /* Entries:
                 * 0 equipment type
                 * 1 equipment name
                 * 2 ability address
                 * 3 stat address
                 * 4 elemental resistance address
                 * 5 other resistance address
                 * 6 vanilla strength
                 * 7 vanilla magic
                 * 8 vanilla ap
                 * 9 vanilla defense
                 * 10 vanilla ability
                 * 11 vanilla fire resistance
                 * 12 vanilla blizzard resistance
                 * 13 vanilla thunder resistance
                 * 14 vanilla dark resistance
                */
                switch (equipmentTypeID)
                {
                    case 0:
                        // Keyblade
                    case 1:
                        // Donald Staff
                    case 2:
                        // Goofy Shield
                        entries[6] = data[(entryCount * i) + 5];
                        entries[7] = data[(entryCount * i) + 6];
                        entries[8] = "0";
                        entries[9] = "0";
                        entries[10] = data[(entryCount * i) + 7];
                        for (int j = 11; j < 15; j++)
                            entries[j] = "0";
                        break;
                    case 3:
                        // Ally Weapon
                        entries[6] = data[(entryCount * i) + 5];
                        entries[7] = data[(entryCount * i) + 6];
                        for (int j = 8; j < 15; j++)
                            entries[j] = "0";
                        break;
                    case 4:
                        // Armor
                        entries[6] = "0";
                        entries[7] = "0";
                        entries[8] = "0";
                        entries[9] = data[(entryCount * i) + 5];
                        entries[10] = data[(entryCount * i) + 6];
                        entries[11] = data[(entryCount * i) + 7];
                        entries[12] = data[(entryCount * i) + 8];
                        entries[13] = data[(entryCount * i) + 9];
                        entries[14] = data[(entryCount * i) + 10];
                        break;
                    case 5:
                        // Accessory
                        entries[6] = data[(entryCount * i) + 5];
                        entries[7] = data[(entryCount * i) + 6];
                        entries[8] = data[(entryCount * i) + 7];
                        entries[9] = "0";
                        entries[10] = data[(entryCount * i) + 8];
                        for (int j = 11; j < 15; j++)
                            entries[j] = "0";
                        break;
                    default:
                        break;
                }
                //eList.Add(new Equipment(equipmentType, entries[0], entries[1], entries[2], entries[3], entries[4]));
                eList.Add(new Equipment(entries));
            }
        }
        internal void populateRewardList(List<Reward> rList, string[] data, int rewardTypeCount)
        {
            string[] entries = new string[2];

            for (int i = 0; i < rewardTypeCount; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    entries[j] = data[(2 * i) + j];
                }
                rList.Add(new Reward(entries[0], entries[1]));
            }
        }

        public void populateWorldList()
        {
            worldList = new List<string>();

            worldList.Add("Agrabah");
            worldList.Add("Atlantica");
            worldList.Add("Beast's Castle");
            worldList.Add("Cavern of Remembrance");
            worldList.Add("Disney Castle");
            worldList.Add("Halloween Town");
            worldList.Add("Hollow Bastion");
            worldList.Add("Land of Dragons");
            worldList.Add("Olympus Coliseum");
            worldList.Add("Olympus Cups");
            worldList.Add("100 Acre Wood");
            worldList.Add("Port Royal");
            worldList.Add("Pride Lands");
            worldList.Add("Simulated Twilight Town");
            worldList.Add("Space Paranoids");
            worldList.Add("Timeless River");
            worldList.Add("Twilight Town");
            worldList.Add("The World That Never Was");
        }
        public void populateRewardTypeList()
        {
            rewardTypeList = new List<string>();

            rewardTypeList.Add("Abilities");
            rewardTypeList.Add("Accessories");
            rewardTypeList.Add("Armor");
            rewardTypeList.Add("Forms");
            rewardTypeList.Add("Growth Abilities");
            rewardTypeList.Add("Items");
            rewardTypeList.Add("Key Items");
            rewardTypeList.Add("Keyblades");
            rewardTypeList.Add("Area Maps");
            rewardTypeList.Add("Proofs");
            rewardTypeList.Add("Recipes");
            rewardTypeList.Add("Secret Reports");
            rewardTypeList.Add("Goofy's Shields");
            rewardTypeList.Add("Donald's Staves");
            rewardTypeList.Add("Magic Spells");
            rewardTypeList.Add("Summons");
            rewardTypeList.Add("Synth Materials");
            rewardTypeList.Add("Empty");
        }
        public void populateFormTypeList()
        {
            formTypeList = new List<string>();

            formTypeList.Add("Valor");
            formTypeList.Add("Wisdom");
            formTypeList.Add("Limit");
            formTypeList.Add("Master");
            formTypeList.Add("Final");
        }
        public void populateFormExpList()
        {
            formExpList = new List<string>();

            formExpList.Add("Vanilla");
            formExpList.Add("Custom");
            formExpList.Add("1.5x Multiplied");
            formExpList.Add("2x Multiplied");
            formExpList.Add("2.5x Multiplied");
            formExpList.Add("3x Multiplied");
            formExpList.Add("3.5x Multiplied");
            formExpList.Add("4x Multiplied");
            formExpList.Add("4.5x Multiplied");
            formExpList.Add("5x Multiplied");
        }
        public void populateEquipmentTypeList()
        {
            equipmentTypeList = new List<string>();

            equipmentTypeList.Add("Keyblade");
            equipmentTypeList.Add("Donald Staff");
            equipmentTypeList.Add("Goofy Shield");
            equipmentTypeList.Add("Ally Weapon");
            equipmentTypeList.Add("Armor");
            equipmentTypeList.Add("Accessory");
        }
        public void populatePatchList()
        {
            patchList = new List<string>();

            patchList.Add("Xeeynamo's Rev 5/Japanese (F266B00B.pnach)");
            patchList.Add("Sora6645's Rev 6 (B7398B17.pnach)");
            patchList.Add("CrazyCatz's/Sora6645's Rev Final (FAF99301.pnach)");
        }
        public void populateCharacterList()
        {
            characterList = new List<string>();

            characterList.Add("Sora");
            characterList.Add("Donald");
            characterList.Add("Goofy");
        }
        public void populateLevelNumberList()
        {
            levelNumberList = new List<int>();

            for (int i = 1; i < 100; i++)
                levelNumberList.Add(i);
        }
        internal void populateLevelReplacementTypeList()
        {
            levelReplacementTypeList = new List<string>();

            levelReplacementTypeList.Add("Vanilla");
            levelReplacementTypeList.Add("Custom");
            levelReplacementTypeList.Add("Replace All");
        }

        private void chestsWorldSelectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            chestDataGridView.DataSource = chestList[chestsWorldSelectorComboBox.SelectedIndex];
        }

        private void popupWorldSelectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            popupDataGridView.DataSource = popupList[popupWorldSelectorComboBox.SelectedIndex];
        }

        private void bonusWorldSelectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bonusDataGridView.DataSource = bonusList[bonusCharacterSelectorComboBox.SelectedIndex][bonusWorldSelectorComboBox.SelectedIndex];
        }
        
        private void equipmentTypeSelectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            equipmentDataGridView.DataSource = equipmentList[equipmentTypeSelectorComboBox.SelectedIndex];
        }

        private void formSelectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            formDataGridView.DataSource = driveFormList[formSelectorComboBox.SelectedIndex];
        }

        #region Selection Changed
        private void formRewardTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (formRewardTypeComboBox.SelectedIndex == 17)
                formRewardComboBox.DataSource = null;
            else
                formRewardComboBox.DataSource = rewardList[formRewardTypeComboBox.SelectedIndex];
        }

        private void formExpComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (formExpComboBox.SelectedIndex != 1)
            {
                formExpToNextLevelLabel.Visible = false;
                formExpToNextLevelCounter.Visible = false;
            }
            else
            {
                formExpToNextLevelLabel.Visible = true;
                formExpToNextLevelCounter.Visible = true;
            }
        }
        
        private void chestRewardTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chestRewardTypeComboBox.SelectedIndex == 17)
                chestRewardComboBox.DataSource = null;
            else
                chestRewardComboBox.DataSource = rewardList[chestRewardTypeComboBox.SelectedIndex];
        }

        private void popupRewardTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (popupRewardTypeComboBox.SelectedIndex == 17)
                popupRewardComboBox.DataSource = null;
            else
                popupRewardComboBox.DataSource = rewardList[popupRewardTypeComboBox.SelectedIndex];
        }

        private void bonusRewardTypeComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bonusRewardTypeComboBox1.SelectedIndex == 17)
                bonusRewardComboBox1.DataSource = null;
            else
                bonusRewardComboBox1.DataSource = rewardList[bonusRewardTypeComboBox1.SelectedIndex];
        }

        private void bonusRewardTypeComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bonusRewardTypeComboBox2.SelectedIndex == 17)
                bonusRewardComboBox2.DataSource = null;
            else
                bonusRewardComboBox2.DataSource = rewardList[bonusRewardTypeComboBox2.SelectedIndex];
        }

        private void equipmentRewardTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (equipmentRewardTypeComboBox.SelectedIndex == 17)
                equipmentRewardComboBox.DataSource = null;
            else
                equipmentRewardComboBox.DataSource = rewardList[equipmentRewardTypeComboBox.SelectedIndex];
        }

        private void swordRewardTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (swordRewardTypeComboBox.SelectedIndex == 17)
                swordRewardComboBox.DataSource = null;
            else
                swordRewardComboBox.DataSource = rewardList[swordRewardTypeComboBox.SelectedIndex];
        }

        private void shieldRewardTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (shieldRewardTypeComboBox.SelectedIndex == 17)
                shieldRewardComboBox.DataSource = null;
            else
                shieldRewardComboBox.DataSource = rewardList[shieldRewardTypeComboBox.SelectedIndex];
        }

        private void staffRewardTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (staffRewardTypeComboBox.SelectedIndex == 17)
                staffRewardComboBox.DataSource = null;
            else
                staffRewardComboBox.DataSource = rewardList[staffRewardTypeComboBox.SelectedIndex];
        }

        private void critExtraRewardTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (critExtraRewardTypeComboBox.SelectedIndex == 17)
                critExtraRewardComboBox.DataSource = null;
            else
                critExtraRewardComboBox.DataSource = rewardList[critExtraRewardTypeComboBox.SelectedIndex];
        }

        private void bonusCharacterSelectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cID = bonusCharacterSelectorComboBox.SelectedIndex;
            int world = bonusWorldSelectorComboBox.SelectedIndex;
            bonusDataGridView.DataSource = bonusList[cID][world];
            if (cID != 0)
                bonusDriveCounter.Enabled = false;
            else
                bonusDriveCounter.Enabled = true;
        }

        private void bonusDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (bonusDataGridView.Focused)
            {
                Bonus temp = (Bonus)bonusDataGridView.SelectedRows[0].DataBoundItem;

                bonusCurrentHPTextBox.Text = Convert.ToString(temp.hpIncrease);
                bonusCurrentMPTextBox.Text = Convert.ToString(temp.mpIncrease);
                bonusCurrentArmorSlotTextBox.Text = Convert.ToString(temp.armorSlotIncrease);
                bonusCurrentAccessorySlotTextBox.Text = Convert.ToString(temp.accessorySlotIncrease);
                bonusCurrentItemSlotTextBox.Text = Convert.ToString(temp.itemSlotIncrease);
                bonusCurrentDriveTextBox.Text = Convert.ToString(temp.driveGaugeIncrease);
            }
        }
        #endregion

        #region Buttons
        private void chestReplaceButton_Click(object sender, EventArgs e)
        {
            if(chestRewardTypeComboBox.SelectedIndex != 17)
            {
                int world = chestsWorldSelectorComboBox.SelectedIndex;
                int chest = chestDataGridView.SelectedRows[0].Index;
                Reward temp = rewardList[chestRewardTypeComboBox.SelectedIndex][chestRewardComboBox.SelectedIndex];
                chestList[world][chest].replacement = temp.reward;
                chestList[world][chest].replacementAddress = temp.rewardAddress;
                chestList[world][chest].changed = true;
                chestReplaced = true;
                chestDataGridView.Update();
                chestDataGridView.Refresh();
            }
        }

        private void chestDefaultButton_Click(object sender, EventArgs e)
        {
            chestList[chestsWorldSelectorComboBox.SelectedIndex][chestDataGridView.SelectedRows[0].Index].Default();
            chestDataGridView.Update();
            chestDataGridView.Refresh();
        }

        private void popupReplaceButton_Click(object sender, EventArgs e)
        {
            if(popupRewardTypeComboBox.SelectedIndex != 17)
            {
                int world = popupWorldSelectorComboBox.SelectedIndex;
                int popup = popupDataGridView.SelectedRows[0].Index;
                Reward temp = rewardList[popupRewardTypeComboBox.SelectedIndex][popupRewardComboBox.SelectedIndex];
                popupList[world][popup].replacement = temp.reward;
                popupList[world][popup].replacementAddress = temp.rewardAddress;
                popupList[world][popup].changed = true;
                popupReplaced = true;
                popupDataGridView.Update();
                popupDataGridView.Refresh();
            }
        }

        private void popupDefaultButton_Click(object sender, EventArgs e)
        {
            popupList[popupWorldSelectorComboBox.SelectedIndex][popupDataGridView.SelectedRows[0].Index].Default();
            popupDataGridView.Update();
            popupDataGridView.Refresh();
        }

        private void bonusReplaceButton_Click(object sender, EventArgs e)
        {
            int world = bonusWorldSelectorComboBox.SelectedIndex;
            int bonus = bonusDataGridView.SelectedRows[0].Index;
            int cID = bonusCharacterSelectorComboBox.SelectedIndex;
            int hp = Convert.ToInt32(bonusHPCounter.Value);
            int mp = Convert.ToInt32(bonusMPCounter.Value);
            int armor = Convert.ToInt32(bonusArmorCounter.Value);
            int accessory = Convert.ToInt32(bonusAccessoryCounter.Value);
            int item = Convert.ToInt32(bonusItemCounter.Value);
            int drive = Convert.ToInt32(bonusDriveCounter.Value);
            int cCount = 0;

            if (hp != 0)
                cCount++;
            bonusList[cID][world][bonus].hpIncrease = hp;

            if (mp != 0)
                cCount++;
            bonusList[cID][world][bonus].mpIncrease = mp;

            if (armor != 0)
                cCount++;
            bonusList[cID][world][bonus].armorSlotIncrease = armor;

            if (accessory != 0)
                cCount++;
            bonusList[cID][world][bonus].accessorySlotIncrease = accessory;

            if (item != 0)
                cCount++;
            bonusList[cID][world][bonus].itemSlotIncrease = item;

            if (drive != 0)
                cCount++;
            bonusList[cID][world][bonus].driveGaugeIncrease = drive;

            Reward temp;
            if (bonusRewardTypeComboBox1.SelectedIndex != 17)
            {
                temp = rewardList[bonusRewardTypeComboBox1.SelectedIndex][bonusRewardComboBox1.SelectedIndex];
                bonusList[cID][world][bonus].replacementReward1 = temp.reward;
                bonusList[cID][world][bonus].replacementRewardAddress1 = temp.rewardAddress;
                cCount++;
            }
            if(bonusRewardTypeComboBox2.SelectedIndex != 17)
            {
                temp = rewardList[bonusRewardTypeComboBox2.SelectedIndex][bonusRewardComboBox2.SelectedIndex];
                bonusList[cID][world][bonus].replacementReward2 = temp.reward;
                bonusList[cID][world][bonus].replacementRewardAddress2 = temp.rewardAddress;
                cCount++;
            }
            bonusList[cID][world][bonus].changeCount = cCount;

            bonusCurrentHPTextBox.Text = Convert.ToString(hp);
            bonusCurrentMPTextBox.Text = Convert.ToString(mp);
            bonusCurrentArmorSlotTextBox.Text = Convert.ToString(armor);
            bonusCurrentAccessorySlotTextBox.Text = Convert.ToString(accessory);
            bonusCurrentItemSlotTextBox.Text = Convert.ToString(item);
            bonusCurrentDriveTextBox.Text = Convert.ToString(drive);

            if (cCount > 0)
                bonusReplaced = true;

            bonusDataGridView.Update();
            bonusDataGridView.Refresh();
        }

        private void bonusDefaultButton_Click(object sender, EventArgs e)
        {
            bonusList[bonusCharacterSelectorComboBox.SelectedIndex][bonusWorldSelectorComboBox.SelectedIndex][bonusDataGridView.SelectedRows[0].Index].Default();

            bonusCurrentHPTextBox.Text = Convert.ToString(0);
            bonusCurrentMPTextBox.Text = Convert.ToString(0);
            bonusCurrentArmorSlotTextBox.Text = Convert.ToString(0);
            bonusCurrentAccessorySlotTextBox.Text = Convert.ToString(0);
            bonusCurrentItemSlotTextBox.Text = Convert.ToString(0);
            bonusCurrentDriveTextBox.Text = Convert.ToString(0);

            bonusDataGridView.Update();
            bonusDataGridView.Refresh();
        }

        private void formReplaceButton_Click(object sender, EventArgs e)
        {
            int form = formSelectorComboBox.SelectedIndex;
            int level = formDataGridView.SelectedRows[0].Index;
            int id = formExpComboBox.SelectedIndex;

            if (formRewardTypeComboBox.SelectedIndex != 17)
            {
                Reward temp = rewardList[formRewardTypeComboBox.SelectedIndex][formRewardComboBox.SelectedIndex];
                driveFormList[form][level].replacement = temp.reward;
                driveFormList[form][level].replacementAddress = temp.rewardAddress;
                driveFormList[form][level].changed = true;

                formReplaced = true;
            }

            switch (id)
            {
                //index 2 = 1.5
                case 0:
                    driveFormList[form][level].newExp = driveFormList[form][level].originalExp;
                    driveFormList[form][level].expChanged = false;
                    break;
                case 1:
                    driveFormList[form][level].newExp = Convert.ToInt32(formExpToNextLevelCounter.Value);
                    driveFormList[form][level].expChanged = true;
                    break;
                default:
                    driveFormList[form][level].newExp = (2 * driveFormList[form][level].originalExp) / (id + 1);
                    driveFormList[form][level].expChanged = true;
                    break;
            }
            formDataGridView.Update();
            formDataGridView.Refresh();
        }

        private void formDefaultButton_Click(object sender, EventArgs e)
        {
            driveFormList[formSelectorComboBox.SelectedIndex][formDataGridView.SelectedRows[0].Index].Default();
            formDataGridView.Update();
            formDataGridView.Refresh();
        }

        private void equipmentReplaceButton_Click(object sender, EventArgs e)
        {
            int equipmentType = equipmentTypeSelectorComboBox.SelectedIndex;
            int equipment = equipmentDataGridView.SelectedRows[0].Index;
            if (equipmentRewardTypeComboBox.SelectedIndex != 17)
            {
                Reward temp = rewardList[equipmentRewardTypeComboBox.SelectedIndex][equipmentRewardComboBox.SelectedIndex];
                equipmentList[equipmentType][equipment].ability = temp.reward;
                equipmentList[equipmentType][equipment].replacementAbilityAddress = temp.rewardAddress;
            }
            else
            {
                equipmentList[equipmentType][equipment].ability = "";
                equipmentList[equipmentType][equipment].replacementAbilityAddress = "0000";
            }
            equipmentList[equipmentType][equipment].ap = Convert.ToInt32(equipmentAPCounter.Value);
            equipmentList[equipmentType][equipment].strength = Convert.ToInt32(equipmentStrengthCounter.Value);
            equipmentList[equipmentType][equipment].magic = Convert.ToInt32(equipmentMagicCounter.Value);
            equipmentList[equipmentType][equipment].defense = Convert.ToInt32(equipmentDefenseCounter.Value);
            equipmentList[equipmentType][equipment].physicalResistance = Convert.ToInt32(physicalResistanceCounter.Value);
            equipmentList[equipmentType][equipment].fireResistance = Convert.ToInt32(fireResistanceCounter.Value);
            equipmentList[equipmentType][equipment].blizzardResistance = Convert.ToInt32(blizzardResistanceCounter.Value);
            equipmentList[equipmentType][equipment].thunderResistance = Convert.ToInt32(thunderResistanceCounter.Value);
            equipmentList[equipmentType][equipment].darkResistance = Convert.ToInt32(darkResistanceCounter.Value);
            equipmentList[equipmentType][equipment].lightResistance = Convert.ToInt32(lightResistanceCounter.Value);
            equipmentList[equipmentType][equipment].allResistance = Convert.ToInt32(universalResistanceCounter.Value);
            equipmentList[equipmentType][equipment].changed = true;
            equipmentReplaced = true;
            equipmentDataGridView.Update();
            equipmentDataGridView.Refresh();
        }

        private void equipmentDefaultButton_Click(object sender, EventArgs e)
        {
            equipmentList[equipmentTypeSelectorComboBox.SelectedIndex][equipmentDataGridView.SelectedRows[0].Index].Default();
            equipmentDataGridView.Update();
            equipmentDataGridView.Refresh();
        }
        
        private void levelReplaceButton_Click(object sender, EventArgs e)
        {
            int level = levelDataGridView.SelectedRows[0].Index;

            levelList[level].ap = Convert.ToInt32(levelAPCounter.Value);
            levelList[level].magic = Convert.ToInt32(levelMagicCounter.Value);
            levelList[level].defense = Convert.ToInt32(levelDefenseCounter.Value);
            levelList[level].strength = Convert.ToInt32(levelStrengthCounter.Value);
            levelList[level].expToNext = Convert.ToInt32(nextEXPCounter.Value);
            levelList[level].rewardReplacementType = levelRewardReplacementTypeComboBox.SelectedIndex;
            levelList[level].changed = true;

            Reward temp;

            if (levelRewardReplacementTypeComboBox.SelectedIndex != 0)
            {
                if (swordRewardTypeComboBox.SelectedIndex != 17)
                {
                    temp = rewardList[swordRewardTypeComboBox.SelectedIndex][swordRewardComboBox.SelectedIndex];
                    levelList[level].swordReplacement = temp.reward;
                    levelList[level].swordReplacementAddress = temp.rewardAddress;
                }
                else
                {
                    levelList[level].swordReplacement = "";
                    levelList[level].swordReplacementAddress = "0000";
                }

                if(levelRewardReplacementTypeComboBox.SelectedIndex == 2)
                {
                    levelList[level].shieldReplacement = levelList[level].swordReplacement;
                    levelList[level].shieldReplacementAddress = levelList[level].swordReplacementAddress;
                    levelList[level].staffReplacement = levelList[level].swordReplacement;
                    levelList[level].staffReplacementAddress = levelList[level].swordReplacementAddress;
                }
                else
                {
                    if (shieldRewardTypeComboBox.SelectedIndex != 17)
                    {
                        temp = rewardList[shieldRewardTypeComboBox.SelectedIndex][shieldRewardComboBox.SelectedIndex];
                        levelList[level].shieldReplacement = temp.reward;
                        levelList[level].shieldReplacementAddress = temp.rewardAddress;
                    }
                    else
                    {
                        levelList[level].shieldReplacement = "";
                        levelList[level].shieldReplacementAddress = "0000";
                    }

                    if (staffRewardTypeComboBox.SelectedIndex != 17)
                    {
                        temp = rewardList[staffRewardTypeComboBox.SelectedIndex][staffRewardComboBox.SelectedIndex];
                        levelList[level].staffReplacement = temp.reward;
                        levelList[level].staffReplacementAddress = temp.rewardAddress;
                    }
                    else
                    {
                        levelList[level].staffReplacement = "";
                        levelList[level].staffReplacementAddress = "0000";
                    }
                }
            }
            levelDataGridView.Update();
            levelDataGridView.Refresh();
        }

        private void levelDefaultButton_Click(object sender, EventArgs e)
        {
            levelList[levelDataGridView.SelectedRows[0].Index].Default();
            levelDataGridView.Update();
            levelDataGridView.Refresh();
        }

        private void critExtraReplaceButton_Click(object sender, EventArgs e)
        {
            if(critExtraRewardTypeComboBox.SelectedIndex != 17)
            {
                int ability = criticalDataGridView.SelectedRows[0].Index;
                Reward temp = rewardList[critExtraRewardTypeComboBox.SelectedIndex][critExtraRewardComboBox.SelectedIndex];
                criticalList[ability].replacement = temp.reward;
                criticalList[ability].replacementAddress = temp.rewardAddress;
                criticalList[ability].changed = true;

                criticalDataGridView.Update();
                criticalDataGridView.Refresh();
            }
        }

        private void CritExtraDefaultButton_Click(object sender, EventArgs e)
        {
            criticalList[criticalDataGridView.SelectedRows[0].Index].Default();
            criticalDataGridView.Update();
            criticalDataGridView.Refresh();
        }

        private void startingGearReplaceButton_Click(object sender, EventArgs e)
        {
            if (startingKeybladeCheckBox.Checked)
            {
                startingStuff.keyblade = rewardList[7][startingKeybladeComboBox.SelectedIndex].reward;
                startingStuff.keybladeAddress = rewardList[7][startingKeybladeComboBox.SelectedIndex].rewardAddress;
                startingStuff.keybladeChanged = true;
            }

            if (startingArmorCheckBox.Checked)
            {
                startingStuff.armor = rewardList[2][startingArmorComboBox.SelectedIndex].reward;
                startingStuff.armorAddress = rewardList[2][startingArmorComboBox.SelectedIndex].rewardAddress;
                startingStuff.armorChanged = true;
            }

            if (startingAccessoryCheckBox.Checked)
            {
                startingStuff.accessory = rewardList[1][startingAccessoryComboBox.SelectedIndex].reward;
                startingStuff.accessoryAddress = rewardList[1][startingAccessoryComboBox.SelectedIndex].rewardAddress;
                startingStuff.accessoryChanged = true;
            }

            startingStuff.munny = Convert.ToInt32(startingMunnyCounter.Value);
        }

        private void startingGearDefaultButton_Click(object sender, EventArgs e)
        {
            startingStuff.keyblade = "";
            startingStuff.keybladeAddress = "";
            startingStuff.keybladeChanged = false;
            startingKeybladeCheckBox.Checked = false;
            startingKeybladeComboBox.SelectedIndex = 0;

            startingStuff.armor = "";
            startingStuff.armorAddress = "";
            startingStuff.armorChanged = false;
            startingArmorCheckBox.Checked = false;
            startingArmorComboBox.SelectedIndex = 0;

            startingStuff.accessory = "";
            startingStuff.accessoryAddress = "";
            startingStuff.accessoryChanged = false;
            startingAccessoryCheckBox.Checked = false;
            startingAccessoryComboBox.SelectedIndex = 0;

            startingMunnyCounter.Value = 0;
        }

        private void startingStatsReplaceButton_Click(object sender, EventArgs e)
        {
            startingStuff.hp = Convert.ToInt32(startingHPCounter.Value);
            startingStuff.mp = Convert.ToInt32(startingMPCounter.Value);
            startingStuff.drive = Convert.ToInt32(startingDriveCounter.Value);
            startingStuff.statChanged = true;
        }

        private void startingStatsDefaultButton_Click(object sender, EventArgs e)
        {
            startingStuff.statChanged = false;
        }
        
        private void cheatApplyButton_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (DataGridViewRow r in cheatDataGridView.Rows)
            {
                if (Convert.ToBoolean(r.Cells[0].Value))
                    cheatList[i].enabled = true;
                i++;
            }
        }

        private void darkModeButton_Click(object sender, EventArgs e)
        {
            if (!isDarkModeEnabled)
            {
                BackColor = SystemColors.ControlDarkDark;
                foreach (TabPage tp in tabControlContainer.TabPages)
                {
                    tp.BackColor = SystemColors.ControlDark;
                    //tp.UseVisualStyleBackColor = true;
                }
                defaultBackground = SystemColors.ControlDark;
            }
            else
            {
                BackColor = SystemColors.Control;
                foreach (TabPage tp in tabControlContainer.TabPages)
                {
                    tp.BackColor = Color.Transparent;
                    tp.UseVisualStyleBackColor = true;
                }
                defaultBackground = Color.White;
            }
            isDarkModeEnabled = !isDarkModeEnabled;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            /*
            patchList.Add("Xeeynamo's Rev 5/Japanese (F266B00B.pnach)");
            patchList.Add("Sora6645's Rev 6 (B7398B17.pnach)");
            patchList.Add("CrazyCatz's/Sora6645's Rev Final (FAF99301.pnach)");
            */

            string patchFileName = "";
            switch(patchSelectorComboBox.SelectedIndex)
            {
                case 0:
                    patchFileName = "F266B00B.pnach";
                    break;
                case 1:
                    patchFileName = "B7398B17.pnach";
                    break;
                case 2:
                    patchFileName = "FAF99301.pnach";
                    break;
                default:
                    break;
            }
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(patchFileName))
            {
                int i = 0;
                // Printing!
                file.WriteLine("//Cheat Codes");
                foreach (Cheat c in cheatList)
                {
                    if (c.enabled)
                        file.Write(c.toString() + "\n");
                }
                i = 0;
                file.WriteLine("\n//Critical Mode Extras");
                foreach (Critical c in criticalList)
                {
                    if (c.changed)
                        file.Write(c.toString());
                }
                i = 0;
                file.WriteLine("\n//Sora's Starting Status");
                file.Write(startingStuff.toString());
                i = 0;
                file.WriteLine("\n//Sora's Bonus Rewards");
                foreach (List<Bonus> bList in bonusList[0])
                {
                    file.Write("// " + worldList[i] + "\n");
                    foreach(Bonus b in bList)
                    {
                        if(b.changeCount > 0)
                            file.Write(b.toString());
                    }
                    i++;
                }
                i = 0;
                file.WriteLine("\n//Donald's Bonus Rewards");
                foreach (List<Bonus> bList in bonusList[1])
                {
                    file.Write("// " + worldList[i] + "\n");
                    foreach (Bonus b in bList)
                    {
                        if (b.changeCount > 0)
                            file.Write(b.toString());
                    }
                    i++;
                }
                i = 0;
                file.WriteLine("\n//Goofy's Bonus Rewards");
                foreach (List<Bonus> bList in bonusList[2])
                {
                    file.Write("// " + worldList[i] + "\n");
                    foreach (Bonus b in bList)
                    {
                        if (b.changeCount > 0)
                            file.Write(b.toString());
                    }
                    i++;
                }
                i = 0;
                file.WriteLine("\n//Chest Rewards");
                foreach (List<Chest> cList in chestList)
                {
                    file.Write("// " + worldList[i] + "\n");
                    foreach (Chest c in cList)
                    {
                        if (c.changed)
                            file.Write(c.toString());
                    }
                    i++;
                }
                i = 0;
                file.WriteLine("\n//Popup Rewards");
                foreach (List<Popup> pList in popupList)
                {
                    file.Write("// " + worldList[i] + "\n");
                    foreach (Popup p in pList)
                    {
                        if (p.changed)
                            file.Write(p.toString());
                    }
                    i++;
                }
                i = 0;
                file.WriteLine("\n//Drive Level Experience");
                foreach (List<DriveForm> dfList in driveFormList)
                {
                    file.Write("// " + formTypeList[i] + "\n");
                    foreach (DriveForm df in dfList)
                        file.Write(df.toStringExp());
                    i++;
                }
                i = 0;
                file.WriteLine("\n//Drive Level Rewards");
                foreach (List<DriveForm> dfList in driveFormList)
                {
                    file.Write("// " + formTypeList[i] + "\n");
                    foreach (DriveForm df in dfList)
                    {
                        if (df.changed)
                            file.Write(df.toStringAbility());
                    }
                    i++;
                }
                i = 0;
                file.WriteLine("\n//Equipment Stats");
                foreach (List<Equipment> eList in equipmentList)
                {
                    file.Write("// " + equipmentTypeList[i] + "\n");
                    foreach (Equipment eq in eList)
                    {
                        if (eq.changed)
                            file.Write(eq.toString());
                    }
                    i++;
                }
                i = 0;
                file.WriteLine("\n//Level Ups");
                foreach (Level l in levelList)
                {
                    if (l.changed)
                        file.Write(l.toString());
                }
            }
            MessageBox.Show("File saved as " + patchFileName);
        }
        
        private void helpButton_Click(object sender, EventArgs e)
        {
            helpForm hForm = new helpForm(tabControlContainer.SelectedIndex);
            hForm.Show();
        }
        #endregion

        #region Formatting Data Grid Views
        private void chestDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (isDarkModeEnabled)
                chestDataGridView.GridColor = SystemColors.Control;
            else
                chestDataGridView.GridColor = SystemColors.ControlDark;

            foreach (DataGridViewRow r in chestDataGridView.Rows)
            {
                if (Convert.ToBoolean(r.Cells["changed"].Value))
                    r.DefaultCellStyle.BackColor = replacedBackground;
                else
                    r.DefaultCellStyle.BackColor = defaultBackground;
            }
        }

        private void popupDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (isDarkModeEnabled)
                popupDataGridView.GridColor = SystemColors.Control;
            else
                popupDataGridView.GridColor = SystemColors.ControlDark;

            foreach (DataGridViewRow r in popupDataGridView.Rows)
            {
                if (Convert.ToBoolean(r.Cells["changed"].Value))
                    r.DefaultCellStyle.BackColor = replacedBackground;
                else
                    r.DefaultCellStyle.BackColor = defaultBackground;
            }
        }

        private void formDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (isDarkModeEnabled)
                formDataGridView.GridColor = SystemColors.Control;
            else
                formDataGridView.GridColor = SystemColors.ControlDark;

            foreach (DataGridViewRow r in formDataGridView.Rows)
            {
                if (Convert.ToBoolean(r.Cells["changed"].Value))
                    r.DefaultCellStyle.BackColor = replacedBackground;
                else
                    r.DefaultCellStyle.BackColor = defaultBackground;
            }
        }

        private void equipmentDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (isDarkModeEnabled)
                equipmentDataGridView.GridColor = SystemColors.Control;
            else
                equipmentDataGridView.GridColor = SystemColors.ControlDark;

            foreach (DataGridViewRow r in equipmentDataGridView.Rows)
            {
                if (Convert.ToBoolean(r.Cells["changed"].Value))
                    r.DefaultCellStyle.BackColor = replacedBackground;
                else
                    r.DefaultCellStyle.BackColor = defaultBackground;
            }
        }

        private void bonusDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (isDarkModeEnabled)
                bonusDataGridView.GridColor = SystemColors.Control;
            else
                bonusDataGridView.GridColor = SystemColors.ControlDark;

            foreach (DataGridViewRow r in bonusDataGridView.Rows)
            {
                int temp = Convert.ToInt32(r.Cells["changeCount"].Value);
                if(temp == 0)
                    r.DefaultCellStyle.BackColor = defaultBackground;
                else
                {
                    if (temp <= 2)
                        r.DefaultCellStyle.BackColor = replacedBackground;
                    else
                        r.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        private void levelDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (isDarkModeEnabled)
                levelDataGridView.GridColor = SystemColors.Control;
            else
                levelDataGridView.GridColor = SystemColors.ControlDark;

            foreach (DataGridViewRow r in levelDataGridView.Rows)
            {
                if (Convert.ToBoolean(r.Cells["changed"].Value))
                    r.DefaultCellStyle.BackColor = replacedBackground;
                else
                    r.DefaultCellStyle.BackColor = defaultBackground;
            }
        }

        private void criticalDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (isDarkModeEnabled)
                criticalDataGridView.GridColor = SystemColors.Control;
            else
                criticalDataGridView.GridColor = SystemColors.ControlDark;

            foreach (DataGridViewRow r in criticalDataGridView.Rows)
            {
                if (Convert.ToBoolean(r.Cells["changed"].Value))
                    r.DefaultCellStyle.BackColor = replacedBackground;
                else
                    r.DefaultCellStyle.BackColor = defaultBackground;
            }
        }
        #endregion

        #region Check Boxes
        private void startingKeybladeCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            if (startingKeybladeCheckBox.Checked)
                startingKeybladeComboBox.Enabled = true;
            else
                startingKeybladeComboBox.Enabled = false;
        }

        private void startingArmorCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            if (startingArmorCheckBox.Checked)
                startingArmorComboBox.Enabled = true;
            else
                startingArmorComboBox.Enabled = false;
        }

        private void startingAccessoryCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            if (startingAccessoryCheckBox.Checked)
                startingAccessoryComboBox.Enabled = true;
            else
                startingAccessoryComboBox.Enabled = false;
        }
        #endregion
    }
}
