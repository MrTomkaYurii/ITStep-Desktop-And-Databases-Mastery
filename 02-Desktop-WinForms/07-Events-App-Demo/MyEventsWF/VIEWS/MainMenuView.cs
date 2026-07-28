using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MVP.Views;
using MyEventsWF.Forms;
using System.Runtime.InteropServices;

namespace MyEventsWF
{
    public partial class MainMenuView : Form, IMainMenuView
    {
        #region Fields
        private readonly IServiceProvider? serviceProvider;
        private readonly ILogger<MainMenuView>? logger;

        private Button? currentButton;
        private Random random;
        private Form? activeForm;
        private int borderSize = 1;
        private int tempIndex;
        #endregion

        #region Constructors
        public MainMenuView()
        {
            InitializeComponent();
            InitFormProperties();
            random = new Random();
        }

        public MainMenuView(IServiceProvider serviceProvider, ILogger<MainMenuView> logger) : this()
        {
            this.serviceProvider = serviceProvider;
            this.logger = logger;

            btnGallery.Click += btnGallery_Click;
        }

        private void InitFormProperties()
        {
            this.Padding = new Padding(borderSize);
            this.BackColor = Color.FromArgb(0, 0, 0);

            btnCloseChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        #endregion

        #region Borderless Window Drag / Resize
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083;
            const int WM_NCHITTEST = 0x0084;
            const int resizeAreaSize = 10;

            const int htBottomLeft = 16;
            const int htBottomRight = 17;
            const int htLeft = 10;
            const int htRight = 11;
            const int htBottom = 15;

            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }

            if (m.Msg == WM_NCHITTEST)
            {
                base.WndProc(ref m);
                if (this.WindowState == FormWindowState.Normal)
                {
                    if ((int)m.Result == 1)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);

                        if (clientPoint.Y >= this.Size.Height - resizeAreaSize)
                        {
                            if (clientPoint.X <= resizeAreaSize)
                                m.Result = (IntPtr)htBottomLeft;
                            else if (clientPoint.X >= this.Size.Width - resizeAreaSize)
                                m.Result = (IntPtr)htBottomRight;
                            else
                                m.Result = (IntPtr)htBottom;
                            return;
                        }

                        if (clientPoint.X <= resizeAreaSize)
                        {
                            m.Result = (IntPtr)htLeft;
                            return;
                        }

                        if (clientPoint.X >= this.Size.Width - resizeAreaSize)
                        {
                            m.Result = (IntPtr)htRight;
                            return;
                        }
                    }
                }
                return;
            }

            base.WndProc(ref m);
        }
        #endregion

        #region Styling & Theme
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object? btnSender)
        {
            if (btnSender is Button btn)
            {
                if (currentButton != btn)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = btn;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new Font("Verdana", 9.3F, FontStyle.Regular, GraphicsUnit.Point);
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnCloseChildForm.Visible = true;
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn is Button)
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 99);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new Font("Verdana", 8.2F, FontStyle.Regular, GraphicsUnit.Point);
                }
            }
        }

        private void OpenChildForm(Form childForm, object? btnSender)
        {
            if (activeForm != null && !activeForm.IsDisposed)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.MdiParent = this;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
            lblTitleBar.Text = childForm.Text;
        }

        private void Reset()
        {
            DisableButton();
            lblTitleBar.Text = "HOME";
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }
        #endregion

        #region Title Bar Buttons
        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null && !activeForm.IsDisposed)
            {
                activeForm.Close();
            }
            Reset();
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnTitleBarMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnTitleBarMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnTitleBarClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region MVP Events & Menu Navigation
        public event EventHandler? ShowProfileView;
        public event EventHandler? ShowAllEventsView;
        public event EventHandler? ShowDetailsOfEventView;
        public event EventHandler? ShowCategoryView;
        public event EventHandler? ShowGalleryView;
        public event EventHandler? ShowForumView;

        private void btnProfile_Click(object sender, EventArgs e)
        {
            logger?.LogInformation("Відкриття профілю: {Time}", DateTime.UtcNow);
            ShowProfileView?.Invoke(this, EventArgs.Empty);
            if (serviceProvider != null)
            {
                var form = serviceProvider.GetRequiredService<ProfileForm>();
                OpenChildForm(form, sender);
            }
        }

        private void btnAllEvents_Click(object sender, EventArgs e)
        {
            logger?.LogInformation("Відкриття списку подій: {Time}", DateTime.UtcNow);
            ShowAllEventsView?.Invoke(this, EventArgs.Empty);
            if (serviceProvider != null)
            {
                var form = serviceProvider.GetRequiredService<AllEventsForm>();
                OpenChildForm(form, sender);
            }
        }

        private void btnDetailsOfEvent_Click(object sender, EventArgs e)
        {
            logger?.LogInformation("Відкриття деталей події: {Time}", DateTime.UtcNow);
            ShowDetailsOfEventView?.Invoke(this, EventArgs.Empty);
            if (serviceProvider != null)
            {
                var form = serviceProvider.GetRequiredService<DetaisOfEventForm>();
                OpenChildForm(form, sender);
            }
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            logger?.LogInformation("Відкриття категорій: {Time}", DateTime.UtcNow);
            ShowCategoryView?.Invoke(this, EventArgs.Empty);
            if (serviceProvider != null)
            {
                var form = serviceProvider.GetRequiredService<CategoryForm>();
                OpenChildForm(form, sender);
            }
        }

        private void btnGallery_Click(object? sender, EventArgs e)
        {
            logger?.LogInformation("Відкриття фотогалереї: {Time}", DateTime.UtcNow);
            ShowGalleryView?.Invoke(this, EventArgs.Empty);
            if (serviceProvider != null)
            {
                var form = serviceProvider.GetRequiredService<GalleryForm>();
                OpenChildForm(form, sender);
            }
        }

        private void btnForum_Click(object sender, EventArgs e)
        {
            logger?.LogInformation("Відкриття форуму події: {Time}", DateTime.UtcNow);
            ShowForumView?.Invoke(this, EventArgs.Empty);
            if (serviceProvider != null)
            {
                var form = serviceProvider.GetRequiredService<ForumForm>();
                OpenChildForm(form, sender);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            logger?.LogInformation("Завершення роботи застосунку");
            ActivateButton(sender);
            Application.Exit();
        }
        #endregion
    }
}
