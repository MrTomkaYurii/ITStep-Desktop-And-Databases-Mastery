using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_example_05_PROGRESSBAR_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            materialProgressBar1.Value = materialProgressBar1.Value + 1;
            materialLabel2.Text = materialProgressBar1.Value.ToString() + "%";
            if (materialProgressBar1.Value >= 99)
            {
                timer1.Enabled = false;
                Form frm = new Form2();
                frm.Show();
                this.Hide();
            }
        }
    }
}
