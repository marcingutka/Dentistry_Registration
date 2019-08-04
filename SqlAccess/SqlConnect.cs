
﻿using System.Data.SqlClient;

namespace ReservationModule.SqlAccess
{
    class SqlConnect
    {
        static string Server { get; } = "DESKOP-GUCIO";
        static string Database { get; } = "CLIENTS_REPORTS";
        internal static string Table { get; } = "Operations";

        public static SqlConnection Connect()
        {
            string connString = @"Server =" + Server +"; Database = "+ Database +"; Trusted_Connection = True;";

            return new SqlConnection(connString);
        }
    }
}

