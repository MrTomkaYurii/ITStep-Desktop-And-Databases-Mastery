namespace Example_09_GDI_Graphics
{
    partial class PlotTrigSeries
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sinSeriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cosSeriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tanSeriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();

            //
            // menuStrip1
            //
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plotToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(492, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            //
            // plotToolStripMenuItem
            //
            this.plotToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sinSeriesToolStripMenuItem,
            this.cosSeriesToolStripMenuItem,
            this.tanSeriesToolStripMenuItem});
            this.plotToolStripMenuItem.Name = "plotToolStripMenuItem";
            this.plotToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.plotToolStripMenuItem.Text = "Plot";
            //
            // sinSeriesToolStripMenuItem
            //
            this.sinSeriesToolStripMenuItem.Checked = true;
            this.sinSeriesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sinSeriesToolStripMenuItem.Name = "sinSeriesToolStripMenuItem";
            this.sinSeriesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sinSeriesToolStripMenuItem.Text = "Sin Series";
            this.sinSeriesToolStripMenuItem.CheckedChanged += new System.EventHandler(this.sinSeriesToolStripMenuItem_CheckedChanged);
            this.sinSeriesToolStripMenuItem.Click += new System.EventHandler(this.sinSeriesToolStripMenuItem_Click);
            //
            // cosSeriesToolStripMenuItem
            //
            this.cosSeriesToolStripMenuItem.Checked = true;
            this.cosSeriesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cosSeriesToolStripMenuItem.Name = "cosSeriesToolStripMenuItem";
            this.cosSeriesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cosSeriesToolStripMenuItem.Text = "Cos Series";
            this.cosSeriesToolStripMenuItem.CheckedChanged += new System.EventHandler(this.cosSeriesToolStripMenuItem_CheckedChanged);
            this.cosSeriesToolStripMenuItem.Click += new System.EventHandler(this.cosSeriesToolStripMenuItem_Click);
            //
            // tanSeriesToolStripMenuItem
            //
            this.tanSeriesToolStripMenuItem.Checked = true;
            this.tanSeriesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tanSeriesToolStripMenuItem.Name = "tanSeriesToolStripMenuItem";
            this.tanSeriesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.tanSeriesToolStripMenuItem.Text = "Tan Series";
            this.tanSeriesToolStripMenuItem.CheckedChanged += new System.EventHandler(this.tanSeriesToolStripMenuItem_CheckedChanged);
            this.tanSeriesToolStripMenuItem.Click += new System.EventHandler(this.tanSeriesToolStripMenuItem_Click);
            //
            // PlotTrigSeries
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 373);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PlotTrigSeries";
            this.Text = "CSharp - Plot  Trig Series";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sinSeriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cosSeriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tanSeriesToolStripMenuItem;
    }
}