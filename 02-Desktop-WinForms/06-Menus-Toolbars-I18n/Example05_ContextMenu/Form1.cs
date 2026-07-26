namespace Example05_ContextMenu
{
    public partial class Form1 : Form
    {
        ContextMenuStrip m;
        public Form1()
        {
            InitializeComponent();
            m = new ContextMenuStrip();
            m.Items.Add("Open");
            m.Items.Add("Close");
            textBox1.ContextMenuStrip = m;
        }
    }
}