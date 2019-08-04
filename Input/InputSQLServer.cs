using System;
using System.Data.SqlClient;
using System.Data;
using ReservationModule.SqlAccess;

namespace ReservationModule.Input
{
    public class InputSQLServer : IInput
    {
        static string Table { get; } = SqlConnect.Table;
        public DataTable GetReservation(ReservationArgs args)
        {
            using (SqlConnection conn = SqlConnect.Connect())
            {
                var sqlDate = args.Date.ToString("yyyy-MM-dd HH:mm:ss");
                string sql;

                if (args.Name == default) sql = "SELECT * FROM " + Table + " WHERE Date=@date";
                else sql = "SELECT * FROM " + Table + " WHERE Name=@name AND Surname=@surname";

                using (SqlCommand cmd = new SqlCommand(sql))
                {
                    cmd.Connection = conn;

                    if (args.Name == default) cmd.Parameters.AddWithValue("@date", sqlDate);
                    else
                    {
                        cmd.Parameters.AddWithValue("@name", args.Name);
                        cmd.Parameters.AddWithValue("@surname", args.Surname);
                    }

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    try
                    {
                        conn.Open();
                        dataAdapter.Fill(ds, Table);                        
                        dt = ds.Tables[Table];
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }

                    return dt;
                }

            }
            
        }

        public DataTable GetAll()
        {
            using (SqlConnection conn = SqlConnect.Connect())
            {
                
                string sql = "SELECT * FROM " + Table + " ";               

                using (SqlCommand cmd = new SqlCommand(sql))
                {
                    cmd.Connection = conn;                   

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    try
                    {
                        conn.Open();
                        dataAdapter.Fill(ds, Table);
                        dt = ds.Tables[Table];
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }

                    return dt;
                }

            }
        }
    }
}
