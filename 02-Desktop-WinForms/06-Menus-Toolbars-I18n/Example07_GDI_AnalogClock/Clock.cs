using Timer = System.Windows.Forms.Timer;

namespace Example07_GDI_AnalogClock
{
    public partial class Clock : Form
    {
        /// <summary>Timer event handler. Will be called every second to redraw
        /// the clock.</summary>
        void Tick(Object o, EventArgs e)
        {
            this.Invalidate();
            // Invalidate() by itself does not trigger a repaint.
            this.Update();
        }

        public Clock()
        {
            InitializeComponent();

            // Set window title and name.
            this.Text = "Clock Demo";
            this.Name = "Clock";

            // Activate double-buffering.
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            // Invalidate on resize.
            SetStyle(ControlStyles.ResizeRedraw, true);

            // Start the timer. Tell it to call Tick().
            Timer timer = new Timer();
            timer.Tick += new EventHandler(Tick);
            timer.Interval = 1000;
            timer.Start();
        }

        static Color background = Color.DarkBlue;
        static Color foreground = Color.Yellow;

        int xmid;
        int ymid;
        int clockradius;

        /// <summary>Polar to Rectangular coordinate conversion.</summary>
        /// <remarks>xmid needs to be set before calling.</remarks>
        /// <param name="dist">Distance from center</param>
        /// <param name="angle">Angle in radians</param>
        /// <returns>the X coordinate</returns>
        int polarx(double dist, double angle)
        {
            return xmid + (int)Math.Round(dist * Math.Sin(angle));
        }

        /// <summary>Polar to Rectangular coordinate conversion.</summary>
        /// <remarks>ymid needs to be set before calling.</remarks>
        /// <param name="dist">Distance from center</param>
        /// <param name="angle">Angle in radians</param>
        /// <returns>the Y coordinate</returns>
        int polary(double dist, double angle)
        {
            return ymid - (int)Math.Round(dist * Math.Cos(angle));
        }

        /// <summary>Displays text centered on a specific coordinate. 
        /// Takes into account text width and height.</summary>
        /// <param name="g">Graphics context</param> 
        /// <param name="font">Font to use to draw the text</param> 
        /// <param name="text">Text to be drawn</param> 
        /// <param name="x">Where to draw the text</param> 
        /// <param name="y">Where to draw the text</param> 
        void CenterText(Graphics g, Font font, string text, int x, int y)
        {
            SizeF size = g.MeasureString(text, font);
            g.DrawString(text, font, new SolidBrush(foreground),
                     new PointF(x - size.Width / 2, y - size.Height / 2));
        }

        /// <summary>Draw a clock hand.</summary>
        /// <param name="g">Graphics context</param>
        /// <param name="length">Length of hand from center</param>
        /// <param name="width">Width of hand at center</param>
        /// <param name="bkwidth">Length of hand on the other side of
        /// center</param>
        /// <param name="angle">Angle in radians</param>
        void DrawHand(Graphics g,
              int length, int width, int bkwidth,
              double angle)
        {
            g.DrawPolygon(new Pen(foreground),
                      new Point[] {
            new Point(polarx(-bkwidth, angle),
                  polary(-bkwidth, angle)),
            new Point(polarx(width, angle + Math.PI / 2),
                  polary(width, angle + Math.PI / 2)),
            new Point(polarx(length, angle),
                  polary(length, angle)),
            new Point(polarx(width, angle - Math.PI / 2),
                  polary(width, angle - Math.PI / 2)) });
        } // DrawHand

        /// <summary>Draw the three clock hands.</summary>
        /// <remarks>clockradius must be set before calling</remarks>
        /// <param name="g">Graphics context</param>
        /// <param name="hour">Hours</param>
        /// <param name="min">Minutes</param>
        /// <param name="sec">Seconds</param>
        void DrawHands(Graphics g, int hour, int min, int sec)
        {
            DrawHand(g,
                 (int)(0.6 * clockradius),
                 (int)(0.075 * clockradius),
                 (int)(0.1 * clockradius),
                 (hour + min / 60.0) * 2 * Math.PI / 12);
            DrawHand(g,
                 (int)(0.9 * clockradius),
                 (int)(0.075 * clockradius),
                 (int)(0.15 * clockradius),
                 (min + sec / 60.0) * 2 * Math.PI / 60);
            DrawHand(g,
                 (int)(0.9 * clockradius),
                 (int)(0.025 * clockradius),
                 (int)(0.15 * clockradius),
                 sec * 2 * Math.PI / 60);
        } // DrawHands

        /// <summary>Draw the clock face and hands</summary>
        /// <param name="g">Graphics context</param>
        /// <param name="width">Width of drawing area</param>
        /// <param name="height">Height of drawing area</param>
        void DrawClock(Graphics g, int width, int height)
        {
            g.Clear(background);

            // Clock has to fit the drawing area and be round.
            xmid = width / 2;
            ymid = height / 2;
            clockradius = (int)(Math.Min(xmid, ymid) * 0.95);

            int fontsize = clockradius / 7;
            if (fontsize < 1)
                fontsize = 1;

            Font font = new Font("SansSerif", fontsize);

            // Draw tick marks and numbers.
            for (int i = 0; i < 360; i += 6)
            {
                double rad = i * Math.PI / 180;

                if (i % 30 == 0)
                {
                    g.DrawLine(new Pen(foreground),
                           new Point(polarx(clockradius, rad),
                                 polary(clockradius, rad)),
                           new Point(polarx(0.925 * clockradius, rad),
                                 polary(0.925 * clockradius, rad)));

                    int hour = i == 0 ? 12 : i / 30;
                    CenterText(g, font, hour.ToString(),
                           polarx(0.8 * clockradius, rad),
                           polary(0.8 * clockradius, rad));
                }
                else
                {
                    g.DrawLine(new Pen(foreground),
                           new Point(polarx(clockradius, rad),
                                 polary(clockradius, rad)),
                           new Point(polarx(0.975 * clockradius, rad),
                                 polary(0.975 * clockradius, rad)));
                }
            }

            // Draw hands showing the current time.
            DateTime time = DateTime.Now;
            DrawHands(g, time.Hour % 12, time.Minute, time.Second);
        } // DrawClock

        /// <summary>Override the paint event handler to draw the clock 
        /// face.</summary>
        /// <param name="e">Paint event</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            DrawClock(e.Graphics, ClientRectangle.Width, ClientRectangle.Height);
        }
    }
}