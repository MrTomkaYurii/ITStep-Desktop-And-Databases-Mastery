namespace Ex_04_02_CustomProgressBar
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.myProgressBar1 = new Ex_04_02_CustomProgressBar.Controls.MyProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.myProgressBar2 = new Ex_04_02_CustomProgressBar.Controls.MyProgressBar();
            this.myProgressBar3 = new Ex_04_02_CustomProgressBar.Controls.MyProgressBar();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.myProgressBar4 = new Ex_04_02_CustomProgressBar.Controls.MyProgressBar();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 50);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("agave Nerd Font Mono", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(265, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "CUSTOM PROGRESS BAR";
            // 
            // myProgressBar1
            // 
            this.myProgressBar1.ChannelColor = System.Drawing.Color.LightSteelBlue;
            this.myProgressBar1.ChannelHeight = 6;
            this.myProgressBar1.ForeBackColor = System.Drawing.Color.RoyalBlue;
            this.myProgressBar1.ForeColor = System.Drawing.Color.White;
            this.myProgressBar1.Location = new System.Drawing.Point(34, 95);
            this.myProgressBar1.Name = "myProgressBar1";
            this.myProgressBar1.ShowMaximun = false;
            this.myProgressBar1.ShowValue = Ex_04_02_CustomProgressBar.Controls.TextPosition.Right;
            this.myProgressBar1.Size = new System.Drawing.Size(741, 39);
            this.myProgressBar1.SliderColor = System.Drawing.Color.RoyalBlue;
            this.myProgressBar1.SliderHeight = 15;
            this.myProgressBar1.SymbolAfter = "";
            this.myProgressBar1.SymbolBefore = "";
            this.myProgressBar1.TabIndex = 1;
            this.myProgressBar1.Value = 20;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button1.CausesValidation = false;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Symbol", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(278, 578);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(196, 54);
            this.button1.TabIndex = 2;
            this.button1.Text = "RUN";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // myProgressBar2
            // 
            this.myProgressBar2.ChannelColor = System.Drawing.Color.LightSteelBlue;
            this.myProgressBar2.ChannelHeight = 30;
            this.myProgressBar2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.myProgressBar2.ForeBackColor = System.Drawing.Color.RoyalBlue;
            this.myProgressBar2.ForeColor = System.Drawing.Color.White;
            this.myProgressBar2.Location = new System.Drawing.Point(34, 220);
            this.myProgressBar2.Name = "myProgressBar2";
            this.myProgressBar2.ShowMaximun = false;
            this.myProgressBar2.ShowValue = Ex_04_02_CustomProgressBar.Controls.TextPosition.Sliding;
            this.myProgressBar2.Size = new System.Drawing.Size(741, 45);
            this.myProgressBar2.SliderColor = System.Drawing.SystemColors.MenuText;
            this.myProgressBar2.SliderHeight = 30;
            this.myProgressBar2.SymbolAfter = "";
            this.myProgressBar2.SymbolBefore = "";
            this.myProgressBar2.TabIndex = 3;
            this.myProgressBar2.Value = 20;
            // 
            // myProgressBar3
            // 
            this.myProgressBar3.ChannelColor = System.Drawing.Color.DarkTurquoise;
            this.myProgressBar3.ChannelHeight = 6;
            this.myProgressBar3.ForeBackColor = System.Drawing.Color.RoyalBlue;
            this.myProgressBar3.ForeColor = System.Drawing.Color.White;
            this.myProgressBar3.Location = new System.Drawing.Point(30, 334);
            this.myProgressBar3.Name = "myProgressBar3";
            this.myProgressBar3.ShowMaximun = true;
            this.myProgressBar3.ShowValue = Ex_04_02_CustomProgressBar.Controls.TextPosition.Left;
            this.myProgressBar3.Size = new System.Drawing.Size(741, 39);
            this.myProgressBar3.SliderColor = System.Drawing.Color.Red;
            this.myProgressBar3.SliderHeight = 15;
            this.myProgressBar3.SymbolAfter = "sec";
            this.myProgressBar3.SymbolBefore = "";
            this.myProgressBar3.TabIndex = 4;
            this.myProgressBar3.Value = 20;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(197, 394);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(405, 29);
            this.progressBar1.TabIndex = 5;
            // 
            // myProgressBar4
            // 
            this.myProgressBar4.ChannelColor = System.Drawing.Color.DeepSkyBlue;
            this.myProgressBar4.ChannelHeight = 6;
            this.myProgressBar4.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.myProgressBar4.ForeBackColor = System.Drawing.Color.Black;
            this.myProgressBar4.ForeColor = System.Drawing.Color.IndianRed;
            this.myProgressBar4.Location = new System.Drawing.Point(91, 478);
            this.myProgressBar4.Name = "myProgressBar4";
            this.myProgressBar4.ShowMaximun = false;
            this.myProgressBar4.ShowValue = Ex_04_02_CustomProgressBar.Controls.TextPosition.Center;
            this.myProgressBar4.Size = new System.Drawing.Size(623, 50);
            this.myProgressBar4.SliderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.myProgressBar4.SliderHeight = 36;
            this.myProgressBar4.SymbolAfter = "";
            this.myProgressBar4.SymbolBefore = "";
            this.myProgressBar4.TabIndex = 6;
            this.myProgressBar4.Value = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 689);
            this.Controls.Add(this.myProgressBar4);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.myProgressBar3);
            this.Controls.Add(this.myProgressBar2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.myProgressBar1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Controls.MyProgressBar myProgressBar1;
        private Button button1;
        private System.Windows.Forms.Timer timer1;
        private Controls.MyProgressBar myProgressBar2;
        private Controls.MyProgressBar myProgressBar3;
        private ProgressBar progressBar1;
        private Controls.MyProgressBar myProgressBar4;
    }
}