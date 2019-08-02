using System.Data.SqlClient;

namespace ReservationModule.SqlAccess
{
    class SqlConnect
    {
        public static SqlConnection Connect()
        {
            string server = "DESKOP-GUCIO";
            string database = "CLIENTS_REPORTS";

            string connString = @"Server =" + server +"; Database = "+ database +"; Trusted_Connection = True;";

            return new SqlConnection(connString);
        }
    }
}
