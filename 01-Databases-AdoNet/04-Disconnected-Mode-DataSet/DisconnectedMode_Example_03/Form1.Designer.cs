namespace DisconnectedMode_Example_03
{
    partial class Form1
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


        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnLoad = new System.Windows.Forms.ToolStripButton();
            this.btnIndex = new System.Windows.Forms.ToolStripButton();
            this.tbIndex = new System.Windows.Forms.ToolStripTextBox();
            this.btnAll = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvPictures = new System.Windows.Forms.DataGridView();
            this.pbShowPictures = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPictures)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShowPictures)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoad,
            this.btnIndex,
            this.tbIndex,
            this.btnAll});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(943, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnLoad
            // 
            this.btnLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(95, 24);
            this.btnLoad.Text = "Load Picture";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnIndex
            // 
            this.btnIndex.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnIndex.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnIndex.Name = "btnIndex";
            this.btnIndex.Size = new System.Drawing.Size(80, 24);
            this.btnIndex.Text = "Show One";
            this.btnIndex.Click += new System.EventHandler(this.btnIndex_Click);
            // 
            // tbIndex
            // 
            this.tbIndex.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tbIndex.Name = "tbIndex";
            this.tbIndex.Size = new System.Drawing.Size(250, 27);
            // 
            // btnAll
            // 
            this.btnAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(71, 24);
            this.btnAll.Text = "Show All";
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvPictures);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pbShowPictures);
            this.splitContainer1.Size = new System.Drawing.Size(943, 651);
            this.splitContainer1.SplitterDistance = 474;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 1;
            // 
            // dgvPictures
            // 
            this.dgvPictures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPictures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPictures.Location = new System.Drawing.Point(0, 0);
            this.dgvPictures.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvPictures.Name = "dgvPictures";
            this.dgvPictures.RowHeadersWidth = 51;
            this.dgvPictures.Size = new System.Drawing.Size(474, 651);
            this.dgvPictures.TabIndex = 0;
            // 
            // pbShowPictures
            // 
            this.pbShowPictures.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbShowPictures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbShowPictures.Location = new System.Drawing.Point(0, 0);
            this.pbShowPictures.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbShowPictures.Name = "pbShowPictures";
            this.pbShowPictures.Size = new System.Drawing.Size(464, 651);
            this.pbShowPictures.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbShowPictures.TabIndex = 0;
            this.pbShowPictures.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 678);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPictures)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShowPictures)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnLoad;
        private System.Windows.Forms.ToolStripButton btnAll;
        private System.Windows.Forms.ToolStripTextBox tbIndex;
        private System.Windows.Forms.ToolStripButton btnIndex;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvPictures;
        private System.Windows.Forms.PictureBox pbShowPictures;
    }
}

