using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Task_03
{
    public partial class Child : Form
    {
        public Child()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public DialogResult ShowDialog(string s)
        {
            textBox1.Text = s;
            return ShowDialog();
        }
    }
}
