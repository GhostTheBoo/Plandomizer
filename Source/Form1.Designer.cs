namespace Plandomizer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            /*
            this.worldSelectorDropDown = new System.Windows.Forms.ComboBox();
            this.fileSaveButton = new System.Windows.Forms.Button();
            this.checkLabel = new System.Windows.Forms.Label();
            this.rewardTypeDropDown = new System.Windows.Forms.ComboBox();
            this.specificRewardDropDown = new System.Windows.Forms.ComboBox();
            this.replaceButton = new System.Windows.Forms.Button();
            this.locationCheckList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.defaultButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.locationCheckList)).BeginInit();
            this.SuspendLayout();
            // 
            // worldSelectorDropDown
            // 
            this.worldSelectorDropDown.FormattingEnabled = true;
            this.worldSelectorDropDown.Location = new System.Drawing.Point(12, 12);
            this.worldSelectorDropDown.Name = "worldSelectorDropDown";
            this.worldSelectorDropDown.Size = new System.Drawing.Size(155, 21);
            this.worldSelectorDropDown.TabIndex = 5;
            this.worldSelectorDropDown.SelectedIndexChanged += new System.EventHandler(this.worldSelectorDropDown_SelectedIndexChanged);
            // 
            // fileSaveButton
            // 
            this.fileSaveButton.Location = new System.Drawing.Point(977, 666);
            this.fileSaveButton.Name = "fileSaveButton";
            this.fileSaveButton.Size = new System.Drawing.Size(110, 23);
            this.fileSaveButton.TabIndex = 7;
            this.fileSaveButton.Text = "Save";
            this.fileSaveButton.UseVisualStyleBackColor = true;
            this.fileSaveButton.Click += new System.EventHandler(this.fileSaveButton_Click);
            // 
            // checkLabel
            // 
            this.checkLabel.AutoSize = true;
            this.checkLabel.Location = new System.Drawing.Point(13, 40);
            this.checkLabel.Name = "checkLabel";
            this.checkLabel.Size = new System.Drawing.Size(77, 13);
            this.checkLabel.TabIndex = 8;
            this.checkLabel.Text = "Vanilla Checks";
            // 
            // rewardTypeDropDown
            // 
            this.rewardTypeDropDown.FormattingEnabled = true;
            this.rewardTypeDropDown.Location = new System.Drawing.Point(937, 73);
            this.rewardTypeDropDown.Name = "rewardTypeDropDown";
            this.rewardTypeDropDown.Size = new System.Drawing.Size(150, 21);
            this.rewardTypeDropDown.TabIndex = 10;
            this.rewardTypeDropDown.SelectedIndexChanged += new System.EventHandler(this.rewardTypeDropDown_SelectedIndexChanged);
            // 
            // specificRewardDropDown
            // 
            this.specificRewardDropDown.FormattingEnabled = true;
            this.specificRewardDropDown.Location = new System.Drawing.Point(937, 122);
            this.specificRewardDropDown.Name = "specificRewardDropDown";
            this.specificRewardDropDown.Size = new System.Drawing.Size(150, 21);
            this.specificRewardDropDown.TabIndex = 11;
            // 
            // replaceButton
            // 
            this.replaceButton.Location = new System.Drawing.Point(977, 637);
            this.replaceButton.Name = "replaceButton";
            this.replaceButton.Size = new System.Drawing.Size(110, 23);
            this.replaceButton.TabIndex = 12;
            this.replaceButton.Text = "Replace";
            this.replaceButton.UseVisualStyleBackColor = true;
            this.replaceButton.Click += new System.EventHandler(this.replaceButton_Click);
            // 
            // locationCheckList
            // 
            this.locationCheckList.AllowUserToAddRows = false;
            this.locationCheckList.AllowUserToDeleteRows = false;
            this.locationCheckList.AllowUserToResizeColumns = false;
            this.locationCheckList.AllowUserToResizeRows = false;
            this.locationCheckList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.locationCheckList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.locationCheckList.Location = new System.Drawing.Point(12, 57);
            this.locationCheckList.MultiSelect = false;
            this.locationCheckList.Name = "locationCheckList";
            this.locationCheckList.ReadOnly = true;
            this.locationCheckList.RowHeadersVisible = false;
            this.locationCheckList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.locationCheckList.Size = new System.Drawing.Size(708, 574);
            this.locationCheckList.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(934, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Reward Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(934, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Specific Reward";
            // 
            // defaultButton
            // 
            this.defaultButton.Location = new System.Drawing.Point(977, 608);
            this.defaultButton.Name = "defaultButton";
            this.defaultButton.Size = new System.Drawing.Size(110, 23);
            this.defaultButton.TabIndex = 16;
            this.defaultButton.Text = "Default";
            this.defaultButton.UseVisualStyleBackColor = true;
            this.defaultButton.Click += new System.EventHandler(this.defaultButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 701);
            this.Controls.Add(this.defaultButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.replaceButton);
            this.Controls.Add(this.specificRewardDropDown);
            this.Controls.Add(this.rewardTypeDropDown);
            this.Controls.Add(this.checkLabel);
            this.Controls.Add(this.fileSaveButton);
            this.Controls.Add(this.worldSelectorDropDown);
            this.Controls.Add(this.locationCheckList);
            this.Name = "Form1";
            this.Text = "Plandomizer";
            ((System.ComponentModel.ISupportInitialize)(this.locationCheckList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ComboBox worldSelectorDropDown;
        private System.Windows.Forms.Button fileSaveButton;
        private System.Windows.Forms.Label checkLabel;
        private System.Windows.Forms.ComboBox rewardTypeDropDown;
        private System.Windows.Forms.ComboBox specificRewardDropDown;
        private System.Windows.Forms.Button replaceButton;
        private System.Windows.Forms.DataGridView locationCheckList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button defaultButton;*/
            #endregion
        }
    }
}

