using Syncfusion.Windows.Forms.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Spreadsheet;
using Syncfusion.Telemetry;

namespace ExportingDemo
{
    public partial class Form1 : RibbonForm
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()        
		{
            Telemetry.Disable();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Syncfusion.Licensing.DemoCommon.FindLicenseKey());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new Form1());
        }

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Provide support for Excel like closing operation when press the close button.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                this.spreadsheet.Commands.FileClose.Execute(null);
                e.Cancel = true;
            }
            base.OnFormClosing(e);
        }

        ToolStripComboBoxEx visualStyleComboBox;

        private void AddVisualStyleMenu(SpreadsheetRibbon ribbon)
        {
            ToolStripEx panel = new ToolStripEx();
            panel.GripStyle = ToolStripGripStyle.Hidden;
            panel.Office12Mode = false;
            panel.Size = new Size(143, 0);
            panel.ShowLauncher = false;
            panel.Text = "Visual Style";
            visualStyleComboBox = new ToolStripComboBoxEx();
            visualStyleComboBox.Size = new Size(140, 0);
            visualStyleComboBox.Style = ToolStripExStyle.Metro;
            visualStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            visualStyleComboBox.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            visualStyleComboBox.Items.Add("Default");
            visualStyleComboBox.Items.Add("Office 2016 Colorful");
            visualStyleComboBox.Items.Add("Office 2016 DarkGray");
            visualStyleComboBox.Items.Add("Office 2016 Black");
            visualStyleComboBox.Items.Add("Office 2016 White");
            visualStyleComboBox.SelectedIndex = 3;
            visualStyleComboBox.SelectedIndexChanged += visualStyleComboBox_SelectedIndexChanged;
            visualStyleComboBox.DropDownClosed += visualStyleComboBox_DropDownClosed;
            panel.Items.Add(visualStyleComboBox);
            var tab = ribbon.Header.MainItems[2] as ToolStripTabItem;

            tab.Panel.Controls.Add(panel);
        }

        void visualStyleComboBox_DropDownClosed(object sender, EventArgs e)
        {
            this.spreadsheet.ActiveGrid.Focus();
        }

        void visualStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combobox = sender as ToolStripComboBoxEx;
            if (combobox.SelectedIndex == 0)
            {
                spreadsheet.ThemeName = "Default";
                ribbon.ThemeName = "Default";
                visualStyleComboBox.Style = ToolStripExStyle.Metro;
                visualStyleComboBox.DropDownStyle = ComboBoxStyle.DropDown;

            }
            else if (combobox.SelectedIndex == 1)
            {
                spreadsheet.ThemeName = "Office2016Colorful";
                ribbon.ThemeName = "Office2016Colorful";
            }
            else if (combobox.SelectedIndex == 2)
            {
                spreadsheet.ThemeName = "Office2016DarkGray";
                ribbon.ThemeName = "Office2016DarkGray";
            }
            else if (combobox.SelectedIndex == 3)
            {
                spreadsheet.ThemeName = "Office2016Black";
                ribbon.ThemeName = "Office2016Black";
            }
            else if (combobox.SelectedIndex == 4)
            {
                spreadsheet.ThemeName = "Office2016White";
                ribbon.ThemeName = "Office2016White";
            }
        }

    }
}
