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

namespace Plandomizer
{
    public partial class helpForm : Form
    {
        public helpForm(int page)
        {
            InitializeComponent();

            chestHelpTextBox.LoadFile(Directory.GetCurrentDirectory() + "\\Data\\Chest Help.rtf");
            bonusHelpTextBox.LoadFile(Directory.GetCurrentDirectory() + "\\Data\\Bonus Help.rtf");
            equipmentHelpTextBox.LoadFile(Directory.GetCurrentDirectory() + "\\Data\\Equipment Help.rtf");
            formHelpTextBox.LoadFile(Directory.GetCurrentDirectory() + "\\Data\\Form Help.rtf");
            levelHelpTextBox.LoadFile(Directory.GetCurrentDirectory() + "\\Data\\Level Up Help.rtf");
            popupHelpTextBox.LoadFile(Directory.GetCurrentDirectory() + "\\Data\\Popup Help.rtf");
            otherHelpTextBox.LoadFile(Directory.GetCurrentDirectory() + "\\Data\\Other Help.rtf");

            helpTabControl.SelectedIndex = page;
        }
    }
}
