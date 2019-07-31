using System;

namespace EventHandler
{
    public class ReservationArgs : EventArgs
    {
        public string ReservationID { get; private set; }
        public string Name { get; private set; }
        public string Operation { get; private set; }
        public DateTime Date { get; private set; }
        public double Price { get; private set; }

        public ReservationArgs(string _n, string _o, string _d, double _p)
        {
            ReservationID = System.Guid.NewGuid().ToString();
            Name = _n;
            Operation = _o;
            Date = ConvertDate(_d);
            Price = _p;
        }

        private DateTime ConvertDate(string _d)
        {
            string[] date = _d.Split('.');
            int[] iDate = new int [date.Length];
            for (int i = 0; i<date.Length; i++)
            {
                iDate[i] = Convert.ToInt32(date[i]);
            }

            if(date.Length == 6) return new DateTime(iDate[5], iDate[4], iDate[3], iDate[0], iDate[1], iDate[2]);
            return DateTime.Now;
        }
    }
}
