using DemoCommon.Grid;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Syncfusion.Telemetry;
using Syncfusion.Windows.Forms.Spreadsheet;
using Syncfusion.XlsIO;
using Syncfusion.XlsIO.Implementation;
using Syncfusion.ExcelToPdfConverter;
using Syncfusion.Pdf;
using System.Drawing.Imaging;

namespace ExportingDemo
{
    public partial class Form1 : GridDemoForm
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
            if (DpiAware.GetCurrentDpi() > 96)
            {
                this.CaptionBarHeight = (int)DpiAware.LogicalToDeviceUnits(this.CaptionBarHeight);
            }
        }

        /// <summary>
        /// Export the spreadsheet based on the selected options.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void exportbtn_Click(object sender, EventArgs e)
        {
            if (pdfradiobtn.Checked)
                ExportToPDF(this.spreadsheet);
            else if (htmlradiobtn.Checked)
                ExportWorkBookToHTML(this.spreadsheet);
            else if (imageradiobtn.Checked)
                ExportWorksheetToBitmap(this.spreadsheet);
        }

        #region PDF
        private static void ExportToPDF(Spreadsheet spreadsheetControl)
        {

            ExcelToPdfConverter converter = new ExcelToPdfConverter(spreadsheetControl.Workbook);
            //Intialize the PdfDocument
            PdfDocument pdfDoc = new PdfDocument();

            //Intialize the ExcelToPdfConverter Settings
            ExcelToPdfConverterSettings settings = new ExcelToPdfConverterSettings();
            settings.LayoutOptions = LayoutOptions.NoScaling;

            //Assign the PdfDocument to the templateDocument property of ExcelToPdfConverterSettings
            settings.TemplateDocument = pdfDoc;
            settings.DisplayGridLines = GridLinesDisplayStyle.Invisible;

            //Convert Excel Document into PDF document
            pdfDoc = converter.Convert(settings);

            //Save the PDF file
            pdfDoc.Save("Sample.pdf");

            System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo("Sample.pdf");
            info.UseShellExecute = true;
            System.Diagnostics.Process.Start(info);

        }
        #endregion

        #region Image

        private static void ExportWorksheetToBitmap(Spreadsheet spreadsheetControl)
        {

            IWorksheet sheet = spreadsheetControl.Workbook.ActiveSheet;
            sheet.UsedRangeIncludesFormatting = false;
            int lastRow = sheet.UsedRange.LastRow + 1;
            int lastColumn = sheet.UsedRange.LastColumn + 1;
            System.Drawing.Image img = sheet.ConvertToImage(1, 1, lastRow, lastColumn, ImageType.Bitmap, null);
            img.Save("Sample.png", ImageFormat.Png);
            System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo("Sample.png");
            info.UseShellExecute = true;
            System.Diagnostics.Process.Start(info);

        }

        #endregion

        #region HTML

        private static void ExportWorkBookToHTML(Spreadsheet spreadsheetControl)
        {
            spreadsheetControl.Workbook.SaveAsHtml("Sample.html", HtmlSaveOptions.Default);
            System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo("Sample.html");
            info.UseShellExecute = true;
            System.Diagnostics.Process.Start(info);
        }
        #endregion

    }
}
