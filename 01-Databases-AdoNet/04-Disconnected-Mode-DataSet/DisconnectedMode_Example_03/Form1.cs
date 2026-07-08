using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisconnectedMode_Example_03
{
    public partial class Form1 : Form
    {
        SqlConnection conn = null;
        SqlDataAdapter da = null;
        DataSet ds = null;
        string fileName = "";
        string conn_string = Properties.Settings.Default.MyConnString;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Picture Library";
            conn = new SqlConnection(conn_string);  //подключение к БД
        }

        /// <summary>
        /// В этом обработчике пользователь может выбрать картинку
        /// для загрузки в БД. После выбора картинки вызывается метод
        /// LoadPicture() в котором картинка преобразовывается в байтовый
        /// массив и заносится в БД
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Graphics File|*.bmp;*.gif;*.jpg;*.png";
            ofd.FileName = "";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileName = ofd.FileName;
                LoadPicture();
            }
        }

        /// <summary>
        /// В этом методе создается и выполняется параметризированный запрос
        /// insert, который заносит уменьшенную копию выбранной картинки в БД
        /// Уменьшенная копия создается в методе CreateCopy()
        /// </summary>
        private void LoadPicture()
        {
            try
            {
                byte[] bytes;
                bytes = CreateCopy();
                conn.Open();
                SqlCommand comm = new SqlCommand("insert into Pictures (bookid, name, picture) values (@bookid, @name, @picture);", conn);

                if (tbIndex.Text == null || tbIndex.Text.Length == 0) return;
                int index = -1;
                int.TryParse(tbIndex.Text, out index);
                if (index == -1) return;

                comm.Parameters.Add("@bookid", SqlDbType.Int).Value = index;
                comm.Parameters.Add("@name", SqlDbType.NVarChar, 255).Value = fileName;
                comm.Parameters.Add("@picture", SqlDbType.Image, bytes.Length).Value = bytes;
                comm.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }

        /// <summary>
        /// В этом методе анализируется ориентация картинки и создается
        /// копия этой картинки таким образом, чтобы максимальный размер
        /// картинки (высота или ширина) не превышал 300 пикселей
        /// Пропорции картинки при этом не искажаются
        /// </summary>
        /// <returns>байтовый массив, содержащий уменьшенную копию </returns>
        private byte[] CreateCopy()
        {
            Image img = Image.FromFile(fileName);
            int maxWidth = 300, maxHeight = 300;
            double ratioX = (double)maxWidth / img.Width;
            double ratioY = (double)maxHeight / img.Height;
            double ratio = Math.Min(ratioX, ratioY);

            int newWidth = (int)(img.Width * ratio);
            int newHeight = (int)(img.Height * ratio);

            Image mi = new Bitmap(newWidth, newHeight);// рисунок в памяти
            Graphics g = Graphics.FromImage(mi);
            g.DrawImage(img, 0, 0, newWidth, newHeight);
            MemoryStream ms = new MemoryStream();// поток для ввода|вывода байт из памяти
            mi.Save(ms, ImageFormat.Jpeg);
            ms.Flush();// выносим в поток все данные из буфера
            ms.Seek(0, SeekOrigin.Begin);
            BinaryReader br = new BinaryReader(ms);
            byte[] buf = br.ReadBytes((int)ms.Length);
            return buf;
        }

        /// <summary>
        /// в этом методе выполняется запрос, выводящий все записи
        /// таблицы Pictures
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAll_Click(object sender, EventArgs e)
        {
            try
            {
                da = new SqlDataAdapter("select * from Pictures;", conn);
                SqlCommandBuilder cmb = new SqlCommandBuilder(da);
                ds = new DataSet();
                da.Fill(ds, "picture");
                dgvPictures.DataSource = ds.Tables["picture"];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// в этом методе выполняется запрос, выводящий запись
        /// таблицы Pictures по заданному id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIndex_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbIndex.Text == null || tbIndex.Text.Length == 0)
                {
                    MessageBox.Show("Укажите id книги!");
                    return;
                }
                int index = -1;
                int.TryParse(tbIndex.Text, out index);
                if (index == -1)
                {
                    MessageBox.Show("Укажите id книги в правильном формате!");
                    return;
                }

                da = new SqlDataAdapter("select picture from Pictures where id = @id;", conn);
                SqlCommandBuilder cmb = new SqlCommandBuilder(da);
                da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = index;
                ds = new DataSet();
                da.Fill(ds);
                byte[] bytes = (byte[])ds.Tables[0].Rows[0]["picture"];
                MemoryStream ms = new MemoryStream(bytes);
                pbShowPictures.Image = Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Запретить вводить в TextBox не числовые значения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbIndex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 48 || e.KeyChar >= 59) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}
