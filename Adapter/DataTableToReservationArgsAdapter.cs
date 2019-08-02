using System;
using System.Data;
using System.Collections.Generic;
using System.Globalization;


namespace ReservationModule.Adapter
{
    public class DataTableToReservationArgsAdapter : IAdapterToReservationArgs
    {
        public List<ReservationArgs> Convert(DataTable dt)
        {
            List<ReservationArgs> list = new List<ReservationArgs>();

            foreach (DataRow r in dt.Rows)
            {
                list.Add(new ReservationArgs(r[dt.Columns[0]].ToString(), r[dt.Columns[1]].ToString(), r[dt.Columns[2]].ToString(), System.Convert.ToDateTime(r[dt.Columns[3]]), double.Parse(r[dt.Columns[4]].ToString(), CultureInfo.InvariantCulture), r[dt.Columns[5]].ToString()));
            }

            return list;
        }
        
    }
}
