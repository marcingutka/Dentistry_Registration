using System;
using System.Data.SqlClient;
using ReservationModule.SqlAccess;
using System.Collections.Generic;

namespace ReservationModule.Output
{
    public class OutputSQLServer : IOutput
    {
        static string Table { get; } = SqlConnect.Table;
        public void Log(ReservationArgs args)
        {
            using (SqlConnection conn = SqlConnect.Connect())
            {
                var sqlDate = args.Date.ToString("yyyy-MM-dd HH:mm:ss");
                string sql = "INSERT into " + Table + " (Name, Surname, Operation, Date, Price, OperationID) VALUES (@name,@surname,@operation,@date,@price,@operationID)";

                using (SqlCommand cmd = new SqlCommand(sql))
                {
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@name", args.Name);
                    cmd.Parameters.AddWithValue("@surname", args.Surname);
                    cmd.Parameters.AddWithValue("@operation", args.Operation);
                    cmd.Parameters.AddWithValue("@date", sqlDate);
                    cmd.Parameters.AddWithValue("@price", args.Price);
                    cmd.Parameters.AddWithValue("@operationID", args.ReservationID);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }

            }


        }
        public void Unlog(List<ReservationArgs> list)
        {
            using (SqlConnection conn = SqlConnect.Connect())
            {
                foreach (ReservationArgs args in list)
                {
                    string sql = "DELETE FROM " + Table + " WHERE OperationID=@operationID";
                    using (SqlCommand cmd = new SqlCommand(sql))
                    {
                        cmd.Connection = conn;
                        cmd.Parameters.AddWithValue("@operationID", args.ReservationID);

                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            Console.WriteLine("Usunięto zabieg " + args.Operation + " klienta " + args.Name + " " + args.Surname + "(data: " + args.Date + ")");

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Exception: " + ex.Message);
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }
            }
        }
        public void DeleteAll()
        {
            using (SqlConnection conn = SqlConnect.Connect())
            {
                string sql = "DELETE FROM " + Table + " ";
                using (SqlCommand cmd = new SqlCommand(sql))
                {
                    cmd.Connection = conn;

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }

            }

        }
    }
}