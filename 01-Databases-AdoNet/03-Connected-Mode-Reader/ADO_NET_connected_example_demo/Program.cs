using System;
using System.Data.SqlClient;

namespace ADO_NET_connected_example_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CreateTable();
            //InsertRecord();
            //GetRecords();
            //DeleteRecord();
            //ConnnectingToDb();
            //AllInOne();
            //ReadInDetails();
            //ReadWithhelpOfProcedure();
            ReadWithhelpOfParam_Procedure();
            Console.ReadKey(); 
        }

        public static void CreateTable() 
        {
            SqlConnection con = null;
            try 
            {  
                con = new SqlConnection("Data Source=DESKTOP-TOMKA;Initial Catalog=Student;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"); 
                SqlCommand cmd = new SqlCommand("CREATE TABLE STUDENT (Id int not null, Name varchar(100), Email varchar(50), Join_Date date)",con);

                con.Open();

                cmd.ExecuteNonQuery();

                Console.WriteLine("Yeah! Table is created!");
            }
            catch (Exception e)
            {
                Console.WriteLine("NOOO!!! Something went wrong!" + e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public static void InsertRecord()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("Data Source=DESKTOP-TOMKA;Initial Catalog=Student;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                SqlCommand cmd = new SqlCommand("INSERT INTO STUDENT (id, Name,Email, Join_Date) VALUES ('101','Vasy BBB', 'dnskdfskd@gmail.com', '1/12/2017')", con);

                con.Open();

                cmd.ExecuteNonQuery();

                Console.WriteLine("Yeah! Record is created!");
            }
            catch (Exception e)
            {
                Console.WriteLine("NOOO!!! Something went wrong!" + e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public static void GetRecords()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("Data Source=DESKTOP-TOMKA;Initial Catalog=Student;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                SqlCommand cmd = new SqlCommand("SELECT * FROM STUDENT", con);

                con.Open();

                SqlDataReader sdr = cmd.ExecuteReader();

                while(sdr.Read())
                {
                    Console.WriteLine(sdr["Id"]+ " " + sdr["Name"] + " " + sdr["Email"]);
                }

                Console.WriteLine("Yeah! Nice!");
            }
            catch (Exception e)
            {
                Console.WriteLine("NOOO!!! Something went wrong!" + e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public static void DeleteRecord()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("Data Source=DESKTOP-TOMKA;Initial Catalog=Student;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                SqlCommand cmd = new SqlCommand("DELETE FROM STUDENT WHERE Id = '101'", con);

                con.Open();

                cmd.ExecuteNonQuery();

                Console.WriteLine("Yeah! Record is deleted!");
            }
            catch (Exception e)
            {
                Console.WriteLine("NOOO!!! Something went wrong!" + e.Message);
            }
            finally
            {
                con.Close();
            }
        }


        public static void ConnnectingToDb()
        {
            string ConnectionString = "Data Source=DESKTOP-TOMKA;Initial Catalog=Student;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                Console.WriteLine("Connection is opened!");
            }
        }

        /// <summary>
        /// example for transaction
        /// </summary>
        public static void AllInOne()
        {
            try
            {
                string ConnectionString = "Data Source=DESKTOP-TOMKA;Initial Catalog=StudentDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO STUDENT (id, Name, Email, Mobile ) VALUES ('191','Vasy BBB', 'dnskdfskd@gmail.com', '3809566666')", con);
                    con.Open();

                    Console.WriteLine("Connection is opened!");

                    int rowsaffected = cmd.ExecuteNonQuery();
                    Console.WriteLine("Inserted rows - " + rowsaffected);

                    cmd.CommandText = "UPDATE STUDENT SET Name = 'Yurii' WHERE Id = 191";
                    rowsaffected = cmd.ExecuteNonQuery();
                    Console.WriteLine("Updated rows - " + rowsaffected);

                    cmd.CommandText = "DELETE FROM STUDENT WHERE Id = 191";
                    rowsaffected = cmd.ExecuteNonQuery();
                    Console.WriteLine("Deleted rows - " + rowsaffected);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("!!!! STOP! ....." + e);
            }
        }

        public static void ReadInDetails()
        {
            try
            {
                string ConnectionString = "Data Source=DESKTOP-TOMKA;Initial Catalog=StudentDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("Select Name, Email, Mobile from STUDENT", con);
                    con.Open();

                    Console.WriteLine("Connection is opened!");

                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Console.WriteLine(sdr[0] + ", " + sdr[1] + ", "+ sdr[2]);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("!!!! STOP! ....." + e);
            }
        }

        public static void ReadWithhelpOfProcedure()
        {
            try
            {
                string ConnectionString = "Data Source=DESKTOP-TOMKA;Initial Catalog=StudentDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetStudents", con)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    con.Open();

                    Console.WriteLine("Connection is opened!");

                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Console.WriteLine(sdr["Id"] + ", " + sdr["Name"] + ", " + sdr["Mobile"]);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("!!!! STOP! ....." + e);
            }
        }


        public static void ReadWithhelpOfParam_Procedure()
        {
            try
            {
                string ConnectionString = "Data Source=DESKTOP-TOMKA;Initial Catalog=StudentDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand()
                    {
                        CommandText = "spGetStudentId",
                        Connection = con,
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    SqlParameter param1 = new SqlParameter
                    {
                        ParameterName = "@Id",
                        SqlDbType = System.Data.SqlDbType.Int,
                        Value = 101,
                        Direction = System.Data.ParameterDirection.Input
                    };

                    cmd.Parameters.Add(param1);

                    con.Open();

                    Console.WriteLine("Connection is opened!");

                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Console.WriteLine(sdr["Id"] + ", " + sdr["Name"] + ", " + sdr["Mobile"]);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("!!!! STOP! ....." + e);
            }
        }





    }


}


//