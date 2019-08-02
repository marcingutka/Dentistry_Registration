using System;
using System.Globalization;

namespace ReservationModule
{
    public class ReservationArgs : EventArgs
    {
        public string ReservationID { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Operation { get; private set; }
        public DateTime Date { get; private set; }
        public double Price { get; private set; }
                
        public ReservationArgs(string _name, string _surname, string _operation, string _date, double _price)
        {
            ReservationID = System.Guid.NewGuid().ToString();
            Name = _name;
            Surname = _surname;
            Operation = _operation;
            Date = DateTime.ParseExact(_date, "HH:mm dd.MM.yyyy", CultureInfo.InvariantCulture);
            Price = _price;
        }

        public ReservationArgs(string _name, string _surname, string _operation, DateTime _date, double _price, string _reservationID)
        {
            ReservationID = _reservationID;
            Name = _name;
            Surname = _surname;
            Operation = _operation;
            Date = _date;
            Price = _price;
        }

        public ReservationArgs(string _name, string _surname)
        {
            ReservationID = default;
            Name = _name;
            Surname = _surname;
            Operation = default;
            Date = default;
            Price = default;
        }

        public ReservationArgs(string _date)
        {
            ReservationID = default;
            Name = default;
            Surname = default;
            Operation = default;
            try
            {
                Date = DateTime.ParseExact(_date, "HH:mm dd.MM.yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                Date = DateTime.Now;
            }
            Price = default;
        }
        public ReservationArgs()
        {
            ReservationID = default;
            Name = default;
            Surname = default;
            Operation = default;
            Date = default;
            Price = default;
        }

        public static bool Comparison(ReservationArgs left, ReservationArgs right)
        {
            if ((left.Name == right.Name) && (left.Surname == right.Surname) && (left.Date == right.Date)) return true;
            else return false;
        }
    }
}
