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
        internal List<string> equipmentTypeList;
        internal List<string> patchList;
        internal List<int> levelNumberList;
        Color replacedBackground;

        internal List<List<Bonus>> bonusList;
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
        internal List<List<Reward>> rewardList;

        public TabViewForm()
        {
            InitializeComponent();

            replacedBackground = Color.FromArgb(255, 150, 200);

            populateWorldList();
            populateRewardTypeList();
            populateFormTypeList();
            populateEquipmentTypeList();
            populatePatchList();
            populateLevelNumberList();

            loadBonuses();
            loadChests();
            loadDriveForms();
            loadPopups();
            loadEquipment();
            loadRewards();
            loadLevels();

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

            popupRewardTypeComboBox.BindingContext = new BindingContext();
            popupRewardComboBox.BindingContext = new BindingContext();
            popupRewardTypeComboBox.DataSource = rewardTypeList;
            popupRewardTypeComboBox.SelectedIndex = 17;

            levelDataGridView.DataSource = levelList;
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

            equipmentDataGridView.Columns["equipmentName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            equipmentDataGridView.Columns["ability"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            equipmentDataGridView.Columns["equipmentType"].Visible = false;
            equipmentDataGridView.Columns["abilityAddress"].Visible = false;
            equipmentDataGridView.Columns["statAddress"].Visible = false;
            equipmentDataGridView.Columns["elementalResistanceAddress"].Visible = false;
            equipmentDataGridView.Columns["otherResistanceAddress"].Visible = false;
            equipmentDataGridView.Columns["changed"].Visible = false;
            equipmentDataGridView.Columns["replacementAbilityAddress"].Visible = false;

            popupDataGridView.Columns["locationAddress"].Visible = false;
            popupDataGridView.Columns["replacementAddress"].Visible = false;
            popupDataGridView.Columns["changed"].Visible = false;

            levelDataGridView.Columns["expToNextAddress"].Visible = false;
            levelDataGridView.Columns["statAddress"].Visible = false;
            levelDataGridView.Columns["swordAddress"].Visible = false;
            levelDataGridView.Columns["shieldAddress"].Visible = false;
            levelDataGridView.Columns["staffAddress"].Visible = false;
            levelDataGridView.Columns["swordReplacementAddress"].Visible = false;
            levelDataGridView.Columns["shieldReplacementAddress"].Visible = false;
            levelDataGridView.Columns["staffReplacementAddress"].Visible = false;
            levelDataGridView.Columns["changed"].Visible = false;
            #endregion
        }

        public void loadBonuses()
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

            bonusList = new List<List<Bonus>>();
            string[] data = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Data\\bonus.txt");
            
            List<Bonus> temp = new List<Bonus>();
            populateBonusList(temp, data.Skip(skip).Take(entryCount * agrCount).ToArray(), agrCount);
            bonusList.Add(temp);
            skip += 1 + (entryCount * agrCount);
            temp = new List<Bonus>();

            populateBonusList(temp, data.Skip(skip).Take(entryCount * atlCount).ToArray(), atlCount);
            bonusList.Add(temp);
            skip += 1 + (entryCount * atlCount);
            temp = new List<Bonus>();

            populateBonusList(temp, data.Skip(skip).Take(entryCount * bcCount).ToArray(), bcCount);
            bonusList.Add(temp);
            skip += 1 + (entryCount * bcCount);
            temp = new List<Bonus>();

            populateBonusList(temp, data.Skip(skip).Take(entryCount * corCount).ToArray(), corCount);
            bonusList.Add(temp);
            skip += 1 + (entryCount * corCount);
            temp = new List<Bonus>();

            populateBonusList(temp, data.Skip(skip).Take(entryCount * dcCount).ToArray(), dcCount);
            bonusList.Add(temp);
            skip += 1 + (entryCount * dcCount);
            temp = new List<Bonus>();

            populateBonusList(temp, data.Skip(skip).Take(entryCount * htCount).ToArray(), htCount);
            bonusList.Add(temp);
            skip += 1 + (entryCount * htCount);
            temp = new List<Bonus>();

            populateBonusList(temp, data.Skip(skip).Take(entryCount * hbCount).ToArray(), hbCount);
            bonusList.Add(temp);
            skip += 1 + (entryCount * hbCount);
            temp = new List<Bonus>();

            populateBonusList(temp, data.Skip(skip).Take(entryCount * lodCount).ToArray(), lodCount);
            bonusList.Add(temp);
            skip += 1 + (entryCount * lodCount);
            temp = new List<Bonus>();

            populateBonusList(temp, data.Skip(skip).Take(entryCount * ocCount).ToArray(), ocCount);
            bonusList.Add(temp);
            skip += 1 + (entryCount * ocCount);
            temp = new List<Bonus>();

            populateBonusList(temp, data.Skip(skip).Take(entryCount * cupsCount).ToArray(), cupsCount);
            bonusList.Add(temp);
            skip += 1 + (entryCount * cupsCount);
            temp = new List<Bonus>();

            populateBonusList(temp, data.Skip(skip).Take(entryCount * poohCount).ToArray(), poohCount);
            bonusList.Add(temp);
            skip += 1 + (entryCount * poohCount);
            temp = new List<Bonus>();

            populateBonusList(temp, data.Skip(skip).Take(entryCount * prCount).ToArray(), prCount);
            bonusList.Add(temp);
            skip += 1 + (entryCount * prCount);
            temp = new List<Bonus>();

            populateBonusList(temp, data.Skip(skip).Take(entryCount * plCount).ToArray(), plCount);
            bonusList.Add(temp);
            skip += 1 + (entryCount * plCount);
            temp = new List<Bonus>();

            populateBonusList(temp, data.Skip(skip).Take(entryCount * sttCount).ToArray(), sttCount);
            bonusList.Add(temp);
            skip += 1 + (entryCount * sttCount);
            temp = new List<Bonus>();

            populateBonusList(temp, data.Skip(skip).Take(entryCount * spCount).ToArray(), spCount);
            bonusList.Add(temp);
            skip += 1 + (entryCount * spCount);
            temp = new List<Bonus>();

            populateBonusList(temp, data.Skip(skip).Take(entryCount * trCount).ToArray(), trCount);
            bonusList.Add(temp);
            skip += 1 + (entryCount * trCount);
            temp = new List<Bonus>();

            populateBonusList(temp, data.Skip(skip).Take(entryCount * ttCount).ToArray(), ttCount);
            bonusList.Add(temp);
            skip += 1 + (entryCount * ttCount);
            temp = new List<Bonus>();

            populateBonusList(temp, data.Skip(skip).Take(entryCount * twtnwCount).ToArray(), twtnwCount);
            bonusList.Add(temp);
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
            int entryCount = 3;
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
            int entryCount = 5;
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
            populateEquipmentList(temp, data.Skip(skip).Take(entryCount * kbCount).ToArray(), kbCount, equipmentTypeList[0]);
            equipmentList.Add(temp);
            skip += 1 + (entryCount * kbCount);
            temp = new List<Equipment>();

            populateEquipmentList(temp, data.Skip(skip).Take(entryCount * dsCount).ToArray(), dsCount, equipmentTypeList[1]);
            equipmentList.Add(temp);
            skip += 1 + (entryCount * dsCount);
            temp = new List<Equipment>();

            populateEquipmentList(temp, data.Skip(skip).Take(entryCount * gsCount).ToArray(), gsCount, equipmentTypeList[2]);
            equipmentList.Add(temp);
            skip += 1 + (entryCount * gsCount);
            temp = new List<Equipment>();

            populateEquipmentList(temp, data.Skip(skip).Take(entryCount * awCount).ToArray(), awCount, equipmentTypeList[3]);
            equipmentList.Add(temp);
            skip += 1 + (entryCount * awCount);
            temp = new List<Equipment>();

            populateEquipmentList(temp, data.Skip(skip).Take(entryCount * armCount).ToArray(), armCount, equipmentTypeList[4]);
            equipmentList.Add(temp);
            skip += 1 + (entryCount * armCount);
            temp = new List<Equipment>();

            populateEquipmentList(temp, data.Skip(skip).Take(entryCount * accCount).ToArray(), accCount, equipmentTypeList[5]);
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
            string[] entries = new string[5];

            levelList = new List<Level>();
            string[] data = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Data\\levels.txt");

            for(int i = 1; i < 100; i++)
            {
                entries[0] = data[(6 * (i - 1)) + 1];
                entries[1] = data[(6 * (i - 1)) + 2];
                entries[2] = data[(6 * (i - 1)) + 3];
                entries[3] = data[(6 * (i - 1)) + 4];
                entries[4] = data[(6 * (i - 1)) + 5];
                levelList.Add(new Level(i, entries[0], entries[1], entries[2], entries[3], entries[4]));
            }
        }

        internal void populateBonusList(List<Bonus> bList, string[] data, int worldCount)
        {
            string[] entries = new string[5];

            for(int i = 0; i < worldCount; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    entries[j] = data[(5 * i) + j];
                }
                bList.Add(new Bonus(entries[0], entries[1], entries[2], entries[3], entries[4]));
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
            string[] entries = new string[3];

            for (int i = 0; i < formCount; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    entries[j] = data[(3 * i) + j];
                }
                dFList.Add(new DriveForm(entries[0], entries[1], entries[2]));
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
        internal void populateEquipmentList(List<Equipment> eList, string[] data, int typeCount, string equipmentType)
        {
            string[] entries = new string[5];

            for (int i = 0; i < typeCount; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    entries[j] = data[(5 * i) + j];
                }
                eList.Add(new Equipment(equipmentType, entries[0], entries[1], entries[2], entries[3], entries[4]));
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
        public void populateLevelNumberList()
        {
            levelNumberList = new List<int>();

            for (int i = 1; i < 100; i++)
                levelNumberList.Add(i);
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
            bonusDataGridView.DataSource = bonusList[bonusWorldSelectorComboBox.SelectedIndex];
        }
        
        private void equipmentTypeSelectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            equipmentDataGridView.DataSource = equipmentList[equipmentTypeSelectorComboBox.SelectedIndex];
        }

        private void formSelectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            formDataGridView.DataSource = driveFormList[formSelectorComboBox.SelectedIndex];
        }

        #region Reward Combo Box
        private void formRewardTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (formRewardTypeComboBox.SelectedIndex == 17)
                formRewardComboBox.DataSource = null;
            else
                formRewardComboBox.DataSource = rewardList[formRewardTypeComboBox.SelectedIndex];
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
                chestDataGridView.SelectedRows[0].DefaultCellStyle.BackColor = replacedBackground;
                chestDataGridView.Update();
                chestDataGridView.Refresh();
            }
        }

        private void chestDefaultButton_Click(object sender, EventArgs e)
        {
            int world = chestsWorldSelectorComboBox.SelectedIndex;
            int chest = chestDataGridView.SelectedRows[0].Index;
            chestList[world][chest].replacement = "";
            chestList[world][chest].replacementAddress = "";
            chestList[world][chest].changed = false;
            chestDataGridView.SelectedRows[0].DefaultCellStyle.BackColor = Color.White;
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
                popupDataGridView.SelectedRows[0].DefaultCellStyle.BackColor = replacedBackground;
                popupDataGridView.Update();
                popupDataGridView.Refresh();
            }
        }

        private void popupDefaultButton_Click(object sender, EventArgs e)
        {
            int world = popupWorldSelectorComboBox.SelectedIndex;
            int popup = popupDataGridView.SelectedRows[0].Index;
            popupList[world][popup].replacement = "";
            popupList[world][popup].replacementAddress = "";
            popupList[world][popup].changed = false;
            popupDataGridView.SelectedRows[0].DefaultCellStyle.BackColor = Color.White;
            popupDataGridView.Update();
            popupDataGridView.Refresh();
        }

        private void bonusReplaceButton_Click(object sender, EventArgs e)
        {
            int world = bonusWorldSelectorComboBox.SelectedIndex;
            int bonus = bonusDataGridView.SelectedRows[0].Index;
            int hp = Convert.ToInt32(bonusHPCounter.Value);
            int mp = Convert.ToInt32(bonusMPCounter.Value);
            int armor = Convert.ToInt32(bonusArmorCounter.Value);
            int accessory = Convert.ToInt32(bonusAccessoryCounter.Value);
            int item = Convert.ToInt32(bonusItemCounter.Value);
            int drive = Convert.ToInt32(bonusDriveCounter.Value);

            bonusList[world][bonus].hpIncrease = hp;
            bonusList[world][bonus].mpIncrease = mp;
            bonusList[world][bonus].armorSlotIncrease = armor;
            bonusList[world][bonus].accessorySlotIncrease = accessory;
            bonusList[world][bonus].itemSlotIncrease = item;
            bonusList[world][bonus].driveGaugeIncrease = drive;

            Reward temp;
            if (bonusRewardTypeComboBox1.SelectedIndex != 17)
            {
                temp = rewardList[bonusRewardTypeComboBox1.SelectedIndex][bonusRewardComboBox1.SelectedIndex];
                bonusList[world][bonus].replacementReward1 = temp.reward;
                bonusList[world][bonus].replacementRewardAddress1 = temp.rewardAddress;
                bonusList[world][bonus].changeCount++;
            }
            if(bonusRewardTypeComboBox2.SelectedIndex != 17)
            {
                temp = rewardList[bonusRewardTypeComboBox2.SelectedIndex][bonusRewardComboBox2.SelectedIndex];
                bonusList[world][bonus].replacementReward2 = temp.reward;
                bonusList[world][bonus].replacementRewardAddress2 = temp.rewardAddress;
                bonusList[world][bonus].changeCount++;
            }

            if(bonusList[world][bonus].changeCount + (hp + mp + armor + accessory + item + drive) > 0)
            {
                bonusDataGridView.SelectedRows[0].DefaultCellStyle.BackColor = replacedBackground;
                bonusReplaced = true;
            }

            bonusDataGridView.Update();
            bonusDataGridView.Refresh();
        }

        private void bonusDefaultButton_Click(object sender, EventArgs e)
        {
            int world = bonusWorldSelectorComboBox.SelectedIndex;
            int bonus = bonusDataGridView.SelectedRows[0].Index;
            bonusList[world][bonus].hpIncrease = 0;
            bonusList[world][bonus].mpIncrease = 0;
            bonusList[world][bonus].armorSlotIncrease = 0;
            bonusList[world][bonus].accessorySlotIncrease = 0;
            bonusList[world][bonus].itemSlotIncrease = 0;
            bonusList[world][bonus].driveGaugeIncrease = 0;
            bonusList[world][bonus].replacementReward1 = "";
            bonusList[world][bonus].replacementRewardAddress1 = "";
            bonusList[world][bonus].replacementReward2 = "";
            bonusList[world][bonus].replacementRewardAddress2 = "";
            bonusList[world][bonus].changeCount = 0;
            bonusDataGridView.SelectedRows[0].DefaultCellStyle.BackColor = Color.White;
            bonusDataGridView.Update();
            bonusDataGridView.Refresh();

        }

        private void formReplaceButton_Click(object sender, EventArgs e)
        {
            if(formRewardTypeComboBox.SelectedIndex != 17)
            {
                int form = formSelectorComboBox.SelectedIndex;
                int level = formDataGridView.SelectedRows[0].Index;
                Reward temp = rewardList[formRewardTypeComboBox.SelectedIndex][formRewardComboBox.SelectedIndex];
                driveFormList[form][level].replacement = temp.reward;
                driveFormList[form][level].replacementAddress = temp.rewardAddress;
                driveFormList[form][level].changed = true;
                formReplaced = true;
                formDataGridView.SelectedRows[0].DefaultCellStyle.BackColor = replacedBackground;
                formDataGridView.Update();
                formDataGridView.Refresh();
            }
        }

        private void formDefaultButton_Click(object sender, EventArgs e)
        {
            int form = formSelectorComboBox.SelectedIndex;
            int level = formDataGridView.SelectedRows[0].Index;
            driveFormList[form][level].replacement = "";
            driveFormList[form][level].replacementAddress = "";
            driveFormList[form][level].changed = false;
            formDataGridView.SelectedRows[0].DefaultCellStyle.BackColor = Color.White;
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
            equipmentDataGridView.SelectedRows[0].DefaultCellStyle.BackColor = replacedBackground;
            equipmentDataGridView.Update();
            equipmentDataGridView.Refresh();
        }

        private void equipmentDefaultButton_Click(object sender, EventArgs e)
        {
            int equipmentType = equipmentTypeSelectorComboBox.SelectedIndex;
            int equipment = equipmentDataGridView.SelectedRows[0].Index;

            equipmentList[equipmentType][equipment].ap = 0;
            equipmentList[equipmentType][equipment].strength = 0;
            equipmentList[equipmentType][equipment].magic = 0;
            equipmentList[equipmentType][equipment].defense = 0;
            equipmentList[equipmentType][equipment].physicalResistance = 0;
            equipmentList[equipmentType][equipment].fireResistance = 0;
            equipmentList[equipmentType][equipment].blizzardResistance = 0;
            equipmentList[equipmentType][equipment].thunderResistance = 0;
            equipmentList[equipmentType][equipment].darkResistance = 0;
            equipmentList[equipmentType][equipment].lightResistance = 0;
            equipmentList[equipmentType][equipment].allResistance = 0;
            equipmentList[equipmentType][equipment].replacementAbilityAddress = "";
            equipmentList[equipmentType][equipment].ability = "";
            equipmentList[equipmentTypeSelectorComboBox.SelectedIndex][equipmentDataGridView.SelectedRows[0].Index].changed = false;
            equipmentDataGridView.SelectedRows[0].DefaultCellStyle.BackColor = Color.White;
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
            levelList[level].changed = true;

            Reward temp;

            if (swordRewardTypeComboBox.SelectedIndex != 17)
            {
                temp = rewardList[swordRewardTypeComboBox.SelectedIndex][swordRewardComboBox.SelectedIndex];
                levelList[level].swordReplacement = temp.reward;
                levelList[level].swordReplacementAddress = temp.rewardAddress;
            }

            if (shieldRewardTypeComboBox.SelectedIndex != 17)
            {
                temp = rewardList[shieldRewardTypeComboBox.SelectedIndex][shieldRewardComboBox.SelectedIndex];
                levelList[level].shieldReplacement = temp.reward;
                levelList[level].shieldReplacementAddress = temp.rewardAddress;
            }

            if (staffRewardTypeComboBox.SelectedIndex != 17)
            {
                temp = rewardList[staffRewardTypeComboBox.SelectedIndex][staffRewardComboBox.SelectedIndex];
                levelList[level].staffReplacement = temp.reward;
                levelList[level].staffReplacementAddress = temp.rewardAddress;
            }

            levelDataGridView.SelectedRows[0].DefaultCellStyle.BackColor = replacedBackground;
            levelDataGridView.Update();
            levelDataGridView.Refresh();
        }

        private void levelDefaultButton_Click(object sender, EventArgs e)
        {
            int level = levelDataGridView.SelectedRows[0].Index;

            levelList[level].ap = 0;
            levelList[level].magic = 0;
            levelList[level].defense = 0;
            levelList[level].strength = 0;
            levelList[level].expToNext = 0;
            levelList[level].swordReplacement = "";
            levelList[level].swordReplacementAddress = "";
            levelList[level].shieldReplacement = "";
            levelList[level].shieldReplacementAddress = "";
            levelList[level].staffReplacement = "";
            levelList[level].staffReplacementAddress = "";
            levelList[level].changed = true;

            levelDataGridView.SelectedRows[0].DefaultCellStyle.BackColor = Color.White;
            levelDataGridView.Update();
            levelDataGridView.Refresh();
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
                file.WriteLine("//Sora's Bonus Rewards");
                foreach (List<Bonus> bList in bonusList)
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
                file.WriteLine("\n//Drive Level Rewards");
                foreach (List<DriveForm> dfList in driveFormList)
                {
                    file.Write("// " + formTypeList[i] + "\n");
                    foreach (DriveForm df in dfList)
                    {
                        if (df.changed)
                            file.Write(df.toString());
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
            helpForm hForm = new helpForm();
            hForm.Show();
        }
        #endregion

        #region Reset Input Fields
        private void chestDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            chestRewardTypeComboBox.SelectedIndex = 17;
        }

        private void popupDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            popupRewardTypeComboBox.SelectedIndex = 17;
        }

        private void equipmentDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            equipmentRewardTypeComboBox.SelectedIndex = 17;

            equipmentAPCounter.Value = 0;
            equipmentMagicCounter.Value = 0;
            equipmentDefenseCounter.Value = 0;
            equipmentStrengthCounter.Value = 0;

            fireResistanceCounter.Value = 0;
            blizzardResistanceCounter.Value = 0;
            thunderResistanceCounter.Value = 0;
            darkResistanceCounter.Value = 0;

            physicalResistanceCounter.Value = 0;
            lightResistanceCounter.Value = 0;
            universalResistanceCounter.Value = 0;
        }

        private void bonusDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            bonusHPCounter.Value = 0;
            bonusMPCounter.Value = 0;
            bonusArmorCounter.Value = 0;
            bonusAccessoryCounter.Value = 0;
            bonusItemCounter.Value = 0;
            bonusDriveCounter.Value = 0;
            bonusRewardTypeComboBox1.SelectedIndex = 17;
            bonusRewardTypeComboBox2.SelectedIndex = 17;
        }

        private void formDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            formRewardTypeComboBox.SelectedIndex = 17;
        }
        
        private void levelDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            swordRewardTypeComboBox.SelectedIndex = 17;
            shieldRewardTypeComboBox.SelectedIndex = 17;
            staffRewardTypeComboBox.SelectedIndex = 17;
            nextEXPCounter.Value = 0;
            levelAPCounter.Value = 0;
            levelMagicCounter.Value = 0;
            levelDefenseCounter.Value = 0;
            levelStrengthCounter.Value = 0;
        }
        #endregion
    }
}
