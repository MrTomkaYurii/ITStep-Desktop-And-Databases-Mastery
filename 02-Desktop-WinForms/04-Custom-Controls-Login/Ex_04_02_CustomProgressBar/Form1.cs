namespace Ex_04_02_CustomProgressBar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (myProgressBar1.Value < myProgressBar1.Maximum)
            {
                myProgressBar1.Value++;
                myProgressBar2.Value++;
                myProgressBar3.Value++;
            }
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myProgressBar1.Value = 0;
            myProgressBar2.Value = 0;
            myProgressBar3.Value = 0;
            timer1.Start();
        }
    }
}