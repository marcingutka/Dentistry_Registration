using System;
using System.Collections.Generic;

namespace ReservationModule.Output
{
    public class OutputConsole : IOutput
    {
        public void Log(ReservationArgs args)
        {
            string s = "Złożono rezerwację nr " + args.ReservationID + " o następujących danych:" +
                "\nImię i nazwisko: " + args.Name + " " + args.Surname +
                "\nNazwa zabiegu: " + args.Operation +
                "\nData: " + args.Date +
                "\nCena: " + string.Format("{0:C}", args.Price) + " brutto\n";

            Console.WriteLine(s);
        }

        public void Unlog(List<ReservationArgs> list)
        {

        }

        public void DeleteAll()
        {

        }
        
    }
}
