using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Syncfusion.Windows.Forms.CellGrid;
using Syncfusion.Windows.Forms.Spreadsheet;
using Syncfusion.Windows.Forms.Spreadsheet.Helpers;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools.Win32API;
using Syncfusion.Windows.Forms.Tools;

namespace ExportingDemo
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

        private Spreadsheet spreadsheet;
        private SpreadsheetRibbon ribbon;
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.WindowState = FormWindowState.Maximized;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            #region Spreadsheet

            spreadsheet = new Spreadsheet();
            ribbon = new SpreadsheetRibbon() { Spreadsheet = spreadsheet };
            spreadsheet.ShowBusyIndicator = false;
            ribbon.SelectedTab = ribbon.Header.MainItems[2] as ToolStripTabItem;
            AddVisualStyleMenu(ribbon);

            this.DataBindings.Add("Text", this.spreadsheet, "FileName");
            spreadsheet.Dock = DockStyle.Fill;
            spreadsheet.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            spreadsheet.ThemeName = "Office2016Black";
            ribbon.ThemeName = "Office2016Black";
#if !NETCORE
            spreadsheet.Open(@"..\..\..\..\..\Common\Data\Spreadsheet\GettingStarted.xlsx");
#else
            spreadsheet.Open(@"..\..\..\..\..\..\Common\Data\Spreadsheet\GettingStarted.xlsx");
#endif
            this.Controls.Add(spreadsheet);
            this.Controls.Add(ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            #endregion
        }
        #endregion
    }
}

