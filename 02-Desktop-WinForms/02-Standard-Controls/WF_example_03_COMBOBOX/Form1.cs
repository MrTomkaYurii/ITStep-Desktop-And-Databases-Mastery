using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_example_03_COMBOBOX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add(textBox1.Text);
        }

        private void addGrandButton_Click(object sender, EventArgs e)
        {
            comboBox1.BeginUpdate();
            for (int i = 0; i < 1000; i++)
            {
                comboBox1.Items.Add("Item 1" + i.ToString());
            }
            comboBox1.EndUpdate();
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            int index = comboBox1.FindString(textBox2.Text);
            comboBox1.SelectedIndex = index;
        }

        private void showSelectedButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = comboBox1.SelectedIndex;
            Object selectedItem = comboBox1.SelectedItem;

            MessageBox.Show("Selected Item Text: " + selectedItem.ToString() + "\n" +
                            "Index: " + selectedIndex.ToString());
        }
    }
}
