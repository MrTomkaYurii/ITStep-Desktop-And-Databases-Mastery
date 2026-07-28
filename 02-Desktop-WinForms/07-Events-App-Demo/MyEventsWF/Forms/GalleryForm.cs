using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyEventsEntityFrameworkDb.EFRepositories.Contracts;
using MyEventsEntityFrameworkDb.Entities;
using MyEventsWF.Helpers;
using System.Drawing.Imaging;

namespace MyEventsWF.Forms
{
    public partial class GalleryForm : Form
    {
        private readonly IServiceProvider serviceProvider;
        private readonly ILogger<GalleryForm> logger;
        private readonly ServiceArgs args;

        private Event? my_event;
        private string fileNameforUpload = "";

        public GalleryForm(
            IServiceProvider serviceProvider,
            ILogger<GalleryForm> logger,
            ServiceArgs serviceArgs)
        {
            InitializeComponent();
            this.serviceProvider = serviceProvider;
            this.logger = logger;
            this.args = serviceArgs;
        }

        #region Theme Styling
        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                           .Concat(controls)
                           .Where(c => c.GetType() == type);
        }

        private void LoadTheme()
        {
            foreach (Button btn in GetAll(this, typeof(Button)))
            {
                btn.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
                btn.BackColor = ThemeColor.PrimaryColor;
                btn.ForeColor = Color.White;
                btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            }
            foreach (Label lbl in GetAll(this, typeof(Label)))
            {
                lbl.Font = new Font("Verdana", 12.2F, FontStyle.Regular, GraphicsUnit.Point);
                lbl.ForeColor = ThemeColor.PrimaryColor;
            }
            foreach (TextBox txtb in GetAll(this, typeof(TextBox)))
            {
                txtb.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
                txtb.ForeColor = ThemeColor.PrimaryColor;
            }
        }
        #endregion

        #region Dynamic Controls Creation
        private async Task GetEventInformationAsync(int event_Id)
        {
            this.logger.LogInformation("Запит інформації про подію #{Id}", event_Id);
            using IServiceScope serviceScope = this.serviceProvider.CreateScope();
            var _unitOfWork = serviceScope.ServiceProvider.GetRequiredService<IEFUnitOfWork>();
            try
            {
                this.my_event = await _unitOfWork.EFEventRepository.GetCompleteEntityAsync(event_Id);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Запит до БД: помилка отримання події");
            }
        }

        private TableLayoutPanel tableLayoutPanelBuild()
        {
            var tlp = new TableLayoutPanel();
            int columns = 5;
            int imageCount = this.my_event?.Gallery?.Images?.Count ?? 0;
            int rows = (imageCount / columns) + 1;

            for (int x = 0; x < rows; x++)
            {
                tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 200));
                for (int y = 0; y < columns; y++)
                {
                    tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
                }
            }

            int count = 0;
            if (this.my_event?.Gallery?.Images != null)
            {
                foreach (var item in this.my_event.Gallery.Images)
                {
                    int x = count / columns;
                    int y = count % columns;
                    count++;

                    var img = new PictureBox();
                    img.Dock = DockStyle.Fill;
                    img.Name = item.Id.ToString();
                    img.SizeMode = PictureBoxSizeMode.Zoom;
                    if (item.ImageBytes != null && item.ImageBytes.Length > 0)
                    {
                        img.Image = ByteToImage(item.ImageBytes);
                    }
                    img.MouseHover += OnDeleteImg;
                    img.MouseLeave += NotDeleteImg;
                    img.Click += DeleteImageFromGallery;
                    tlp.Controls.Add(img, y, x);
                }
            }

            tlp.Dock = DockStyle.Fill;
            tlp.Name = "tlp_GalleryImages";
            tlp.AutoScroll = true;
            tlp.Margin = new Padding(1);
            return tlp;
        }

        private void OnDeleteImg(object? sender, EventArgs e)
        {
            if (sender is PictureBox box)
            {
                box.SizeMode = PictureBoxSizeMode.StretchImage;
                var delButton = new Button
                {
                    Text = "Видалити",
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.Red,
                    ForeColor = Color.White,
                    Dock = DockStyle.Bottom
                };
                delButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
                delButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
                box.Controls.Add(delButton);
            }
        }

        private void NotDeleteImg(object? sender, EventArgs e)
        {
            if (sender is PictureBox box)
            {
                foreach (Control control in box.Controls.OfType<Button>().ToList())
                {
                    box.Controls.Remove(control);
                }
                box.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private async void DeleteImageFromGallery(object? sender, EventArgs e)
        {
            if (sender is not PictureBox box) return;

            this.logger.LogInformation("Видалення фото із БД");
            using (IServiceScope serviceScope = this.serviceProvider.CreateScope())
            {
                var _unitOfWork = serviceScope.ServiceProvider.GetRequiredService<IEFUnitOfWork>();
                try
                {
                    await _unitOfWork.EFImageRepository.DeleteByIdAsync(Convert.ToInt32(box.Name));
                    await _unitOfWork.SaveChangesAsync();
                    MessageBox.Show("Зображення успішно видалено!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    this.logger.LogError(ex, "Помилка видалення фото із БД");
                    MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (box.Parent is TableLayoutPanel tblp)
            {
                tblp.Controls.Remove(box);
            }
        }

        public Bitmap ByteToImage(byte[] blob)
        {
            using var mStream = new MemoryStream(blob);
            return new Bitmap(mStream);
        }
        #endregion

        #region Work with Image (Save to DB)
        public async Task LoadPictureToDbAsync()
        {
            this.logger.LogInformation("Запис зображення до БД");
            using IServiceScope serviceScope = this.serviceProvider.CreateScope();
            var _unitOfWork = serviceScope.ServiceProvider.GetRequiredService<IEFUnitOfWork>();
            try
            {
                var imageEntity = new MyEventsEntityFrameworkDb.Entities.Image
                {
                    Name = Path.GetFileName(fileNameforUpload) + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss"),
                    GalleryId = this.my_event?.GalleryId,
                    UserId = this.my_event?.UserId,
                    ImageBytes = CreateCopy()
                };

                await _unitOfWork.EFImageRepository.AddAsync(imageEntity);
                await _unitOfWork.SaveChangesAsync();
                MessageBox.Show("Зображення успішно збережено в базі даних!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Помилка запису зображення до БД");
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private byte[] CreateCopy()
        {
            using var img = System.Drawing.Image.FromFile(fileNameforUpload);
            int maxWidth = 220, maxHeight = 220;
            double ratioX = (double)maxWidth / img.Width;
            double ratioY = (double)maxHeight / img.Height;
            double ratio = Math.Min(ratioX, ratioY);

            int newWidth = (int)(img.Width * ratio);
            int newHeight = (int)(img.Height * ratio);

            using var mi = new Bitmap(newWidth, newHeight);
            using (var g = Graphics.FromImage(mi))
            {
                g.DrawImage(img, 0, 0, newWidth, newHeight);
            }

            using var ms = new MemoryStream();
            mi.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }
        #endregion

        #region Events
        private async void GalleryForm_Load(object sender, EventArgs e)
        {
            await GetEventInformationAsync(args.Id);
            if (this.my_event != null && this.my_event.Gallery != null)
            {
                this.Controls.Add(tableLayoutPanelBuild());
                this.lblNameOfEvent.Text = this.my_event.Name;
                this.lblNameOfGallery.Text = this.my_event.Gallery.Name;
            }
            else
            {
                this.lblNameOfEvent.Text = $"Подія #{args.Id} (виконайте SQL-скрипт MyEventsDb_Create_And_Seed.sql)";
                this.lblNameOfGallery.Text = "Галерея порожня або БД не підключено";
            }
            LoadTheme();
        }

        private async void btnImageLoad_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "Графічні файли|*.bmp;*.gif;*.jpg;*.jpeg;*.png",
                FileName = ""
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileNameforUpload = ofd.FileName;
                await LoadPictureToDbAsync();
            }
        }
        #endregion
    }
}
