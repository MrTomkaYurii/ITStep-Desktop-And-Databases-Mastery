using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DisconnectedMode_Example_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    SqlDataAdapter da = new SqlDataAdapter("spGetStudents", conn);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    
                    foreach (DataRow dr in dt.Rows)
                    {
                        Console.WriteLine(dr["Name"] + ", " + dr["Email"] + ", " + dr["Mobile"]);
                    }

                    Console.WriteLine("======");

                    DataSet ds = new DataSet();
                    da.Fill(ds,"student");
                    foreach (DataRow dr in ds.Tables["student"].Rows)
                    {
                        Console.WriteLine(dr["Name"] + ", " + dr["Email"] + ", " + dr["Mobile"]);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("!!!! LOL .... something wrong..." + e);
            }
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
