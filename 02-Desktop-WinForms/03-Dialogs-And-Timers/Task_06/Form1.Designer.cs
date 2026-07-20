namespace Task_06
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.AddGood = new System.Windows.Forms.Button();
            this.EditGood = new System.Windows.Forms.Button();
            this.DeleteGood = new System.Windows.Forms.Button();
            this.ClearAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(431, 479);
            this.listBox1.TabIndex = 0;
            // 
            // AddGood
            // 
            this.AddGood.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AddGood.Location = new System.Drawing.Point(0, 409);
            this.AddGood.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AddGood.Name = "AddGood";
            this.AddGood.Size = new System.Drawing.Size(431, 35);
            this.AddGood.TabIndex = 1;
            this.AddGood.Text = "Добавить товар";
            this.AddGood.UseVisualStyleBackColor = true;
            this.AddGood.Click += new System.EventHandler(this.AddGood_Click);
            // 
            // EditGood
            // 
            this.EditGood.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.EditGood.Location = new System.Drawing.Point(0, 444);
            this.EditGood.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EditGood.Name = "EditGood";
            this.EditGood.Size = new System.Drawing.Size(431, 35);
            this.EditGood.TabIndex = 2;
            this.EditGood.Text = "Редактировать товар";
            this.EditGood.UseVisualStyleBackColor = true;
            this.EditGood.Click += new System.EventHandler(this.EditGood_Click);
            // 
            // DeleteGood
            // 
            this.DeleteGood.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DeleteGood.Location = new System.Drawing.Point(0, 479);
            this.DeleteGood.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DeleteGood.Name = "DeleteGood";
            this.DeleteGood.Size = new System.Drawing.Size(431, 35);
            this.DeleteGood.TabIndex = 3;
            this.DeleteGood.Text = "Удалить товар";
            this.DeleteGood.UseVisualStyleBackColor = true;
            this.DeleteGood.Click += new System.EventHandler(this.DeleteGood_Click);
            // 
            // ClearAll
            // 
            this.ClearAll.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ClearAll.Location = new System.Drawing.Point(0, 514);
            this.ClearAll.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ClearAll.Name = "ClearAll";
            this.ClearAll.Size = new System.Drawing.Size(431, 35);
            this.ClearAll.TabIndex = 4;
            this.ClearAll.Text = "Очистить список";
            this.ClearAll.UseVisualStyleBackColor = true;
            this.ClearAll.Click += new System.EventHandler(this.ClearAll_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 549);
            this.Controls.Add(this.AddGood);
            this.Controls.Add(this.EditGood);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.DeleteGood);
            this.Controls.Add(this.ClearAll);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Каталог товаров";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button AddGood;
        private System.Windows.Forms.Button EditGood;
        private System.Windows.Forms.Button DeleteGood;
        private System.Windows.Forms.Button ClearAll;
    }
}
