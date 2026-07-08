using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisconnectedMode_Example_05
{
    public partial class Form1 : Form
    {
        private SqlConnection conn = null;
        SqlDataAdapter da = null;
        DataSet set = null;
        SqlCommandBuilder cmd = null;
        DataTable table = null;
        string cs = "";

        public object InputFileStream { get; private set; }

        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection();
            cs = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
            conn.ConnectionString = cs;
        }

        /// <summary>
        /// FILL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void show_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(cs);
                set = new DataSet();
                string sql = tbRequest.Text;
                da = new SqlDataAdapter(sql, conn);
                dataGridView1.DataSource = null;

                cmd = new SqlCommandBuilder(da);
                Debug.WriteLine(cmd.GetInsertCommand().CommandText);
                Debug.WriteLine(cmd.GetUpdateCommand().CommandText);
                Debug.WriteLine(cmd.GetDeleteCommand().CommandText);

                // create a new DataSet to receive the table schema
                DataSet ds = new DataSet();
                //// read the schema for the Orders table from the data source and
                //// create a table in the DataSet called "Orders" with the same schema
                //da.FillSchema(ds, SchemaType.Source, "Books");

                //// create a new DataTable to receive the schema
                //DataTable dt = new DataTable("Books");
                //da.FillSchema(dt, SchemaType.Source);

                da.Fill(set, "Authors");

                DataViewManager dvm = new DataViewManager(set);

                //задаем условия отбора и сортировки для требуемой таблицы в DataSet
                dvm.DataViewSettings["Authors"].RowFilter = "id < 5";
                dvm.DataViewSettings["Authors"].Sort = "LastName DESC";
                DataView dataView1 = dvm.CreateDataView(set.Tables["Authors"]);

                dataGridView1.DataSource = dataView1;
                //dataGridView1.DataSource = set.Tables["Authors"];
                //dataGridView1.DataSource = dt;
                //dataGridView1.DataSource = set.Tables['Table1'];
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

        /// <summary>
        /// UPDATE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            da.Update(set, "mybook");
        }

        /// <summary>
        /// TRANSACTION
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(cs);
            SqlCommand comm = conn.CreateCommand();
            SqlTransaction tran = null;
            try
            {
                conn.Open();
                tran = conn.BeginTransaction();
                comm = conn.CreateCommand();
                comm.Transaction = tran;
                comm.CommandText = @"create table tmp3(id int not null identity(1,1) primary key, f1 varchar(20), f2 int)";
                comm.ExecuteNonQuery();
                comm.CommandText = @"insert into tmp3(f1, f2) values('lalala', 333)";
                comm.ExecuteNonQuery();
                //comm.CommandText = @"insert into tmp4(f1, f2) values('rampampam', 777)";
                //comm.ExecuteNonQuery();

                tran.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                tran.Rollback();
            }
            finally
            {
                conn.Close();
            }

        }


        /// <summary>
        /// Async OLD METHOD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btAsync_Click(object sender, EventArgs e)
        {
            const string AsyncEnabled = "Asynchronous Processing=true";
            if (!cs.Contains(AsyncEnabled))
            {
                cs = String.Format("{0}; {1}", cs, AsyncEnabled);
            }

            conn = new SqlConnection(cs);
            SqlCommand comm = conn.CreateCommand();
            comm.CommandText = "WAITFOR DELAY '00:00:05'; SELECT * FROM Books;";
            comm.CommandType = CommandType.Text;
            comm.CommandTimeout = 30;
            try
            {
                conn.Open();
                // create AsyncCallback delegate 
                AsyncCallback callback = new AsyncCallback(GetDataCallback);

                comm.BeginExecuteReader(callback, comm);
                //MessageBox.Show("Added thread is working...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetDataCallback(IAsyncResult result)
        {
            SqlDataReader reader = null;

            try
            {
                SqlCommand command = (SqlCommand)result.AsyncState;
                reader = command.EndExecuteReader(result);
                table = new DataTable();
                //dataGridView1.DataSource = null;

                int line = 0;

                do
                {
                    while (reader.Read())
                    {
                        if (line == 0)
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                table.Columns.Add(reader.GetName(i));
                            }
                            line++;
                        }
                        DataRow row = table.NewRow();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row[i] = reader[i];
                        }
                        table.Rows.Add(row);
                    }
                } while (reader.NextResult());
                DgvAction();

            }
            catch (Exception ex)
            {
                MessageBox.Show("From Callback 1:" + ex.Message);
            }
            finally
            {
                try
                {
                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("From Callback 2:" + ex.Message);
                }
            }
        }

        /// <summary>
        /// ASYNC 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btAsync2_Click(object sender, EventArgs e)
        {
            const string AsyncEnabled = "Asynchronous Processing=true";
            if (!cs.Contains(AsyncEnabled))
            {
                cs = String.Format("{0}; {1}", cs, AsyncEnabled);
            }

            conn = new SqlConnection(cs);
            SqlCommand comm = conn.CreateCommand();
            comm.CommandText = "WAITFOR DELAY '00:00:05'; SELECT * FROM Books;";
            comm.CommandType = CommandType.Text;
            comm.CommandTimeout = 30;
            try
            {
                conn.Open();

                IAsyncResult iar = comm.BeginExecuteReader();
                WaitHandle handle = iar.AsyncWaitHandle;

                if (handle.WaitOne(10000))
                {
                    GetData(comm, iar);
                }
                else
                {
                    MessageBox.Show("TimeOut exceeded");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetData(SqlCommand command, IAsyncResult ia)
        {
            SqlDataReader reader = null;
            try
            {
                reader = command.EndExecuteReader(ia);
                DataTable table = new DataTable();
                dataGridView1.DataSource = null;

                int line = 0;

                do
                {
                    while (reader.Read())
                    {
                        if (line == 0)
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                table.Columns.Add(reader.GetName(i));
                            }
                            line++;
                        }
                        DataRow row = table.NewRow();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row[i] = reader[i];
                        }
                        table.Rows.Add(row);
                    }
                } while (reader.NextResult());
                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("From GetData 1:" + ex.Message);
            }
            finally
            {
                try
                {
                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("From GetData 2:" + ex.Message);
                }
            }
        }

        private void DgvAction()
        {
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke(new Action(DgvAction));
                return;
            }
            dataGridView1.DataSource = table;
        }

        /// <summary>
        /// ASYNC_3 -> ASYNC FILE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button3_Click(object sender, EventArgs e)
        {
            await GetDataAsync("1.txt");
            Console.WriteLine("After async call");
        }

        async private Task GetDataAsync(string filename)
        {
            byte[] data = null;

            using (FileStream fs = File.Open(filename, FileMode.Open))
            {
                data = new byte[fs.Length];
                await fs.ReadAsync(data, 0, (int)fs.Length);
            }
            tbRequest.Text = System.Text.Encoding.UTF8.GetString(data);
        }

    }
}

