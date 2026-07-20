using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_03
{
    public partial class Parent : Form
    {
        public Parent()
        {
            InitializeComponent();
        }

        private void Show_Click(object sender, EventArgs e)
        {
            Child child_form = new Child();
            child_form.ShowDialog(textBox1.Text);
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close(); this.Close();
        }
    }
}
