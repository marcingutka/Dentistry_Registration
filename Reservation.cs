using System;
using System.Collections.Generic;
using ReservationModule.Output;
using System.Linq;

namespace ReservationModule
{
    public delegate void LogDelegate(object _object, EventArgs _event);
    public delegate void AllDelgate();
    public delegate List<ReservationArgs> ListDelegate(object _object, EventArgs _event);
    public delegate List<ReservationArgs> ListVoidDelegate();

    public class Reservation
    {
        public event LogDelegate LogProcess;
        public event ListDelegate UnlogProcess;
        public event ListDelegate GetReservationEvent;
        public event AllDelgate DeleteEverything;
        public event ListVoidDelegate TakeAll;

        public ReservationArgs Reserve(string _name, string _surname, string _operation, string _date, double _price)
        {
            ReservationArgs comparison = new ReservationArgs(_date);
            try
            {
                List<ReservationArgs> toCompare = ExecuteGetReservation(comparison);

                if ((toCompare.Count == 0) || (toCompare == null))
                {
                    ReservationArgs args = new ReservationArgs(_name, _surname, _operation, _date, _price);
                    ExecuteReservation(args);
                    Console.WriteLine("Rezerwacja się udała!");
                    return args;
                }
                else Console.WriteLine("Data jest zajęta!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            return new ReservationArgs();
        }

        public List<ReservationArgs> GetReservation(string _name, string _surname)
        {
            ReservationArgs args = new ReservationArgs(_name, _surname);
            try
            {
                List<ReservationArgs> list = ExecuteGetReservation(args);
                Display(list);
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            return new List<ReservationArgs>();
        }
        
        public List<ReservationArgs> Revoke(string _date)
        {
            ReservationArgs args = new ReservationArgs(_date);
            return ExecuteRevoke(args);
        }

        public void DeleteAll()
        {
            DeleteEverything?.Invoke();
            if (DeleteEverything == null) Console.WriteLine("brak funkcji DELETE ALL!");
        }

        public List<ReservationArgs> GetAll()
        {
            List<ReservationArgs> list = TakeAll?.Invoke();
            if (TakeAll == null)
            {
                Console.WriteLine("brak funkcji Get ALL!");
                return new List<ReservationArgs>();
            }
            else
            {
                Display(list);
                return list;
            }
        }

        private void ExecuteReservation(EventArgs _event)
        {
            LogProcess?.Invoke(this, _event);
            if (LogProcess == null) Console.WriteLine("brak funkcji LOGOWANIA!");
        }
        
        private List<ReservationArgs> ExecuteGetReservation(EventArgs _event)
        {
            if (GetReservationEvent == null) Console.WriteLine("brak funkcji POBIERANIA!");
            return GetReservationEvent?.Invoke(this, _event);
        }

        private List<ReservationArgs> ExecuteRevoke(EventArgs _event)
        {
            if (UnlogProcess == null) Console.WriteLine("brak funkcji WYLOGOWANIA!");
            return UnlogProcess?.Invoke(this, _event);
        }

        private void Display(List<ReservationArgs> list)
        {
            OutputConsole output = new OutputConsole();
            var l = list.OrderBy(x => x.Date);
            foreach (ReservationArgs o in l)
            {
                output.Log(o);
            }
        }

    }
}
