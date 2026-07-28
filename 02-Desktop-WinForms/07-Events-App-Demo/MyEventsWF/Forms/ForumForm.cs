using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyEventsAdoNetDB.Repositories.Interfaces;

namespace MyEventsWF.Forms
{
    public partial class ForumForm : Form
    {
        private readonly IServiceProvider serviceProvider;
        private readonly ILogger<ForumForm> logger;

        public ForumForm(IServiceProvider serviceProvider, ILogger<ForumForm> logger)
        {
            InitializeComponent();
            this.serviceProvider = serviceProvider;
            this.logger = logger;
        }

        private void LoadTheme()
        {
            foreach (Button btn in this.Controls.OfType<Button>())
            {
                btn.Font = new Font("Verdana", 8.2F, FontStyle.Regular, GraphicsUnit.Point);
                btn.BackColor = ThemeColor.PrimaryColor;
                btn.ForeColor = Color.White;
                btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            }
            foreach (Label lbl in this.Controls.OfType<Label>())
            {
                lbl.Font = new Font("Verdana", 8.2F, FontStyle.Regular, GraphicsUnit.Point);
                lbl.ForeColor = ThemeColor.PrimaryColor;
            }
            foreach (TextBox txtb in this.Controls.OfType<TextBox>())
            {
                txtb.Font = new Font("Verdana", 8.2F, FontStyle.Regular, GraphicsUnit.Point);
                txtb.ForeColor = ThemeColor.PrimaryColor;
            }
        }

        private void ForumForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = "1";
            LoadTheme();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text.Trim(), out int id))
            {
                MessageBox.Show("Будь ласка, введіть числовий ID запису (наприклад, 1 або 11)", "Некоректний ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.logger.LogInformation("Запит до БД (Форум) для Id={Id}", id);
            using IServiceScope serviceScope = this.serviceProvider.CreateScope();
            var _unitOfWork = serviceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
            try
            {
                label3.Hide();
                label3.Text = "";
                var entity = await _unitOfWork._messageRepository.GetAsync(id);
                textBox2.Text = entity?.Message ?? "Запис не знайдено";
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                label3.Show();
                label3.ForeColor = Color.Red;
                label3.Text = "Помилка: " + ex.Message;
                MessageBox.Show("Не вдалося завантажити дані з бази:\n" + ex.Message + "\n\nПереконайтеся, що SQL Server запущено та виконано скрипт MyEventsDb_Create_And_Seed.sql.", "Помилка БД", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
