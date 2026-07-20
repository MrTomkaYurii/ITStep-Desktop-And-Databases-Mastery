using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_02
{
    public partial class Parent : Form
    {
        public Parent()
        {
            InitializeComponent();
        }

        private void Show_Click(object sender, EventArgs e)
        {
            Child child_form = new Child(textBox1.Text);
            child_form.ShowDialog();
        }
    }
}
