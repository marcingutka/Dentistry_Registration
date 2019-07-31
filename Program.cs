using System;

namespace EventHandler
{
    class Program
    {
        static void Main()
        {
            EventHandlerClass handler = new EventHandlerClass();
            Reservation oReservation = new Reservation();
            oReservation.ReservationProcess += handler.LogOperation;
            oReservation.Reserve("Jan Kowalski", "wyrwanie zęba", "11.30.00.20.11.2019", 150.82);
            oReservation.Reserve("Marek Nowak", "przegląd", "09.15.00.19.11.2019", 50.00);
            Console.ReadKey();
        }
    }
}
