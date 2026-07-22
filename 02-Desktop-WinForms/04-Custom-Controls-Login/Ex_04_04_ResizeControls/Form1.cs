namespace Ex_04_04_ResizeControls
{
    public partial class Form1 : Form
    {
        private Rectangle _formOriginalRectangle;
        private Rectangle _buttonOriginalRectangle;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _formOriginalRectangle = new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height);
            _buttonOriginalRectangle = new Rectangle(button1.Location.X, button1.Location.Y, button1.Width, button1.Height);

        }

        private void resizeControl(Rectangle r, Control c)
        {
            float xRatio = (float)(this.Width)/(float) (_formOriginalRectangle.Width);
            float yRatio = (float)(this.Height)/(float) (_formOriginalRectangle.Height);

            int newX = (int)(r.X * xRatio);
            int newY = (int)(r.Y * yRatio);
            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);

            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            resizeControl(_buttonOriginalRectangle, button1);
        }
    }
}