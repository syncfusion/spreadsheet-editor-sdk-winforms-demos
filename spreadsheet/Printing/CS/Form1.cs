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
using Syncfusion.Windows.Forms.PdfViewer;
using Syncfusion.XlsIO;
using Syncfusion.ExcelToPdfConverter;
using Syncfusion.Pdf;
using Syncfusion.Calculate;

namespace PrintingDemo
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

        void printpreviewbtn_Click(object sender, EventArgs e)
        {
            PrintPreviewForm previewform = new PrintPreviewForm() { sfspreadsheet = this.spreadsheet };
            previewform.Show();
        }

        void printbtn_Click(object sender, EventArgs e)
        {
            PrintFromPdfViewer(this.spreadsheet);
        }



        #region Direct print through PdfViewer

        private static void PrintFromPdfViewer(Spreadsheet spreadsheetControl)
        {
            //Create the previewdialog for print the document.
            PrintPreviewDialog printdialog = new PrintPreviewDialog();

            //Create the pdfviewer for load the document.
            PdfViewerControl pdfviewer = new PdfViewerControl();

            // PdfDocumentViewer
            MemoryStream pdfstream = new MemoryStream();
            IWorksheet worksheet = spreadsheetControl.Workbook.Worksheets[0];
            worksheet.EnableSheetCalculations();
            worksheet.CalcEngine.AllowShortCircuitIFs = true;
            worksheet.CalcEngine.MaximumRecursiveCalls = 10000;
            worksheet.CalcEngine.UseFormulaValues = true;
            CalcEngine.MaxStackDepth = 10000;
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
            pdfDoc.Save(pdfstream);

            //Load the document to pdfviewer
            pdfviewer.ReferencePath = @"..\..\..\..\..\..\Common\Data\PDF";

            pdfviewer.Load(pdfstream);

            printdialog.Document = pdfviewer.PrintDocument;

            printdialog.ShowDialog();

        }
        #endregion

        #region "GetIconFile"
        private string GetIconFile(string bitmapName)
        {
            for (int n = 0; n < 10; n++)
            {
                if (System.IO.File.Exists(bitmapName))
                    return bitmapName;

                bitmapName = @"..\" + bitmapName;
            }

            return bitmapName;
        }
        #endregion

    }
}
