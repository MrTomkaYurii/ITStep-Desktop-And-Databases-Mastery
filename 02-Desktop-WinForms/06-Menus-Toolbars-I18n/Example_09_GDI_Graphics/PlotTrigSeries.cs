namespace Example_09_GDI_Graphics
{
    public partial class PlotTrigSeries : Form
    {
        public PlotTrigSeries()
        {
            InitializeComponent();
        }

        public void PutPixel(Graphics g, int x, int y, Color c)

        {
            Bitmap bm = new Bitmap(1, 1);
            bm.SetPixel(0, 0, c);
            g.DrawImageUnscaled(bm, x, y);
        }

        bool m_bPlotSinSeries = true;
        bool m_bPlotCosSeries = true;
        bool m_bPlotTanSeries = true;


        private void Form1_Paint(object sender, PaintEventArgs e)
        { 
            //GDI+
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            Rectangle rect = new Rectangle(0, 0, 750, 500);

            int margin = 100;
            int width = rect.Width - margin * 2;
            int height = rect.Height - margin * 2;

            Pen tPen = new Pen(Color.Black);
            g.DrawRectangle(tPen, 0 + margin / 2, 0 + margin / 2, width, height);
            g.DrawLine(tPen, 0 + margin / 2, margin / 2 + height / 2, width + margin / 2, margin / 2 + height / 2);

            double legendypos = margin;
            double legendxpos = margin;
            double PI = Math.PI;

            if (m_bPlotSinSeries == true)
            {
                tPen = new Pen(Color.Red);
                Brush br = new SolidBrush(Color.Red);
                for (double i = 0; i <= 720.01; i += 0.1)
                {
                    double value = Math.Sin(i * PI / 180);
                    value += 1.0;
                    int ypos = (int)(value / 2.0 * height + margin / 2);
                    int xpos = (int)(i / 720.0 * width + margin / 2);
                    PutPixel(g, xpos, ypos, Color.Red);
                    if ((Convert.ToInt32(i) % 90) == 0)
                    {
                        g.DrawLine(tPen, xpos, margin / 2 + height / 2 - 5, xpos, margin / 2 + height / 2 + 5);
                        g.DrawString(Convert.ToInt32(i).ToString(), Font, br, xpos - 10, margin / 2 + height / 2 + 10, StringFormat.GenericDefault);
                    }
                }
                g.DrawString("SIN Series - RED Color", Font, br, (float)legendxpos, (float)legendypos, StringFormat.GenericDefault);
                legendypos += 20;
            }


            if (m_bPlotCosSeries == true)
            {
                tPen = new Pen(Color.Blue);
                Brush br = new SolidBrush(Color.Blue);
                for (double i = 0; i <= 720.01; i += 0.1)
                {
                    double value = Math.Cos(i * PI / 180);
                    value += 1.0;
                    int ypos = (int)(value / 2.0 * height + margin / 2);
                    int xpos = (int)(i / 720.0 * width + margin / 2);
                    PutPixel(g, xpos, ypos, Color.Blue);
                    if ((Convert.ToInt32(i) % 90) == 0)
                    {
                        g.DrawLine(tPen, xpos, margin / 2 + height / 2 - 5, xpos, margin / 2 + height / 2 + 5);
                        g.DrawString(Convert.ToInt32(i).ToString(), Font, br, xpos - 10, margin / 2 + height / 2 + 10, StringFormat.GenericDefault);
                    }
                }

                g.DrawString("COS Series - BLUE Color", Font, br, (float)legendxpos, (float)legendypos, StringFormat.GenericDefault);
                legendypos += 20;

            }


            if (m_bPlotTanSeries == true)
            {
                double factor = 10; // Don't use this factor, it is only for drawing purpose.
                tPen = new Pen(Color.DarkBlue);
                Brush br = new SolidBrush(Color.DarkBlue);
                for (double i = 0; i <= 720.01; i += 0.1)
                {
                    double value = Math.Tan(i * PI / 180);
                    if (value > factor)
                        value = factor;
                    if (value < -factor)
                        value = -factor;
                    value += factor;

                    int ypos = (int)(value / (factor * 2) * height + margin / 2);
                    int xpos = (int)(i / 720.0 * width + margin / 2);
                    PutPixel(g, xpos, ypos, Color.DarkBlue);
                    if ((Convert.ToInt32(i) % 90) == 0)
                    {
                        g.DrawLine(tPen, xpos, margin / 2 + height / 2 - 5, xpos, margin / 2 + height / 2 + 5);
                        g.DrawString(Convert.ToInt32(i).ToString(), Font, br, xpos - 10, margin / 2 + height / 2 + 10, StringFormat.GenericDefault);
                    }
                }
                g.DrawString("TAN Series - DarkBlue Color", Font, br, (float)legendxpos, (float)legendypos, StringFormat.GenericDefault);
                legendypos += 20;
            }


            g.Dispose();
        }


        private void tanSeriesToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            m_bPlotTanSeries = tanSeriesToolStripMenuItem.Checked;
        }
        private void cosSeriesToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            m_bPlotCosSeries = cosSeriesToolStripMenuItem.Checked;
        }
        private void sinSeriesToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            m_bPlotSinSeries = sinSeriesToolStripMenuItem.Checked;
        }


        private void sinSeriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sinSeriesToolStripMenuItem.Checked = !sinSeriesToolStripMenuItem.Checked;
            Invalidate();
        }
        private void cosSeriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cosSeriesToolStripMenuItem.Checked = !cosSeriesToolStripMenuItem.Checked;
            Invalidate();
        }
        private void tanSeriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tanSeriesToolStripMenuItem.Checked = !tanSeriesToolStripMenuItem.Checked;
            Invalidate();
        }
    }
}