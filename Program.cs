using System;


namespace ReservationModule
{
    class Program
    {
        static void Main()
        {
            EventHandlerClass handler = new EventHandlerClass();
            Reservation oReservation = new Reservation();
            oReservation.GetReservationEvent += handler.GetOperation;
            oReservation.LogProcess += handler.LogOperation;
            oReservation.UnlogProcess += handler.UnlogOperation;
            oReservation.DeleteEverything += handler.DeleteAll;
            oReservation.TakeAll += handler.GetAll;

            oReservation.Reserve("Jan", "Kowal", "masaż", "11:45 20.11.2019", 456);
            oReservation.Reserve("Marek", "Kowal", "noga", "16:45 11.11.2019", 23.87);
            oReservation.Reserve("Jan", "Kowal", "kark", "07:23 20.07.2019", 145);
            oReservation.Reserve("Jan", "Kowal", "ręka", "14:45 16.11.2019", 150.82);
            oReservation.DeleteAll();
            oReservation.Reserve("Marek", "Kowal", "noga", "16:45 11.11.2019", 23.87);
            oReservation.GetReservation("Jan", "Kowal");
            oReservation.GetAll();
            oReservation.Revoke("16:45 11.11.2019");

            Console.ReadKey();
        }
    }
}
