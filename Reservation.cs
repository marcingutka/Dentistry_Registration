using System;

namespace EventHandler
{
    public delegate void ReservationDelegate(object _o, EventArgs _e);

    public class Reservation
    {
        public event ReservationDelegate ReservationProcess;

        public void Reserve(string _n, string _o, string _d, double _p)
        {
            ReservationArgs args = new ReservationArgs(_n, _o, _d, _p);
            ExecuteReservation(args);
        }

        private void ExecuteReservation(EventArgs _e)
        {
            if (ReservationProcess != null) ReservationProcess(this, _e);
            else Console.WriteLine("Error - no assignment to delegate!");
        }
    }
}
