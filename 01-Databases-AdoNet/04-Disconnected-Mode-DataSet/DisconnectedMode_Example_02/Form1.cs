using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisconnectedMode_Example_02
{
    public partial class Form1 : Form
    {
        private SqlConnection conn = null;
        SqlDataAdapter da = null;
        DataSet set = null;
        SqlCommandBuilder cmd = null;
        string cs = "";

        public object InputFileStream { get; private set; }
        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection();
            cs = Properties.Settings.Default.MyConnString;
            conn.ConnectionString = cs;
        }

        private void show_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(cs);
                set = new DataSet();
                string sql = tbRequest.Text;
                da = new SqlDataAdapter(sql, conn);
                dataGridView1.DataSource = null;

                //cmd = new SqlCommandBuilder(da);
                //Debug.WriteLine(cmd.GetInsertCommand().CommandText);
                //Debug.WriteLine(cmd.GetUpdateCommand().CommandText);
                //Debug.WriteLine(cmd.GetDeleteCommand().CommandText);
                da.Fill(set, "myResult");

                dataGridView1.DataSource = set.Tables["myResult"];
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            da.Update(set, "myResult");
        }
    }
}
