namespace WF_example_01
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.btnAddToListBox = new System.Windows.Forms.Button();
            this.btnCopyFromListBox = new System.Windows.Forms.Button();
            this.btnRemoveSelected = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(195, 124);
            this.listBox1.TabIndex = 0;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 20;
            this.listBox2.Location = new System.Drawing.Point(268, 12);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(195, 124);
            this.listBox2.TabIndex = 1;
            // 
            // btnAddToListBox
            // 
            this.btnAddToListBox.Location = new System.Drawing.Point(14, 235);
            this.btnAddToListBox.Name = "btnAddToListBox";
            this.btnAddToListBox.Size = new System.Drawing.Size(195, 29);
            this.btnAddToListBox.TabIndex = 2;
            this.btnAddToListBox.Text = "Add To ListBox";
            this.btnAddToListBox.UseVisualStyleBackColor = true;
            this.btnAddToListBox.Click += new System.EventHandler(this.btnAddToListBox_Click);
            // 
            // btnCopyFromListBox
            // 
            this.btnCopyFromListBox.Location = new System.Drawing.Point(268, 235);
            this.btnCopyFromListBox.Name = "btnCopyFromListBox";
            this.btnCopyFromListBox.Size = new System.Drawing.Size(195, 29);
            this.btnCopyFromListBox.TabIndex = 3;
            this.btnCopyFromListBox.Text = "Copy From ListBox";
            this.btnCopyFromListBox.UseVisualStyleBackColor = true;
            this.btnCopyFromListBox.Click += new System.EventHandler(this.btnCopyFromListBox_Click);
            // 
            // btnRemoveSelected
            // 
            this.btnRemoveSelected.Location = new System.Drawing.Point(144, 270);
            this.btnRemoveSelected.Name = "btnRemoveSelected";
            this.btnRemoveSelected.Size = new System.Drawing.Size(195, 29);
            this.btnRemoveSelected.TabIndex = 4;
            this.btnRemoveSelected.Text = "Remove Selected";
            this.btnRemoveSelected.UseVisualStyleBackColor = true;
            this.btnRemoveSelected.Click += new System.EventHandler(this.btnRemoveSelected_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 180);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(195, 27);
            this.textBox1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 316);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnRemoveSelected);
            this.Controls.Add(this.btnCopyFromListBox);
            this.Controls.Add(this.btnAddToListBox);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button btnAddToListBox;
        private System.Windows.Forms.Button btnCopyFromListBox;
        private System.Windows.Forms.Button btnRemoveSelected;
        private System.Windows.Forms.TextBox textBox1;
    }
}
