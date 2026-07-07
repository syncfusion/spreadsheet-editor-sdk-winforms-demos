using System.Drawing;
using System.Windows.Forms;

namespace ImportDataTable.View
{
    public partial class GridView
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

        //DataGridView to Export the Data from the spreadsheet.
        internal DataGridView dataGridView;
        private Panel panel;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView = new DataGridView();
            this.panel = new Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.dataGridView.BackColor = Color.White;
            this.dataGridView.ReadOnly = true;
            this.dataGridView.ForeColor = Color.Black;
            this.dataGridView.Location = new Point(0, 0);
            this.dataGridView.MinimumSize = new Size(584, 376);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.Size = new Size(779, 431);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Text = "DataGridView";
            // 
            // panel
            // 
            this.panel.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.panel.BackColor = Color.White;
            this.panel.BorderStyle = BorderStyle.FixedSingle;
            this.panel.Controls.Add(this.dataGridView);
            this.panel.ForeColor = Color.DarkGray;
            this.panel.Location = new Point(12, 0);
            this.panel.MinimumSize = new Size(584, 376);
            this.panel.Name = "panel";
            this.panel.Size = new Size(781, 431);
            this.panel.TabIndex = 0;
            // 
            // GridView Layout
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(805, 443);
            this.Controls.Add(this.panel);
            this.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new Size(600, 500);
            this.Name = "GridView";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = string.Empty;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

    }
}