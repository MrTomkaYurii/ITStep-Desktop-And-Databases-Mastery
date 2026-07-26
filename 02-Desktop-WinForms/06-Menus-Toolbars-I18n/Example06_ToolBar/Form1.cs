using System.Drawing.Imaging;

namespace Example06_ToolBar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            toolStripLabel1.Text = "Button1 is clicked";
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            toolStripLabel1.Text = "Button2 is clicked";
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            toolStripLabel1.Text = "Button3 is clicked";
        }
    }
}