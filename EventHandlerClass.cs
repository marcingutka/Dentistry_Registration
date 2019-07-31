using System;
using System.IO;

namespace EventHandler
{
    class EventHandlerClass
    {
        public void LogOperation (object _o, EventArgs _e)
        {
            ReservationArgs args = _e as ReservationArgs;
            string path = "lista_operacji.txt";
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.Write("Złożono rezerwację nr " + args.ReservationID + " o następujących danych:" +
                "\nImię i nazwisko: " + args.Name +
                "\nNazwa zabiegu: " + args.Operation +
                "\nData: " + args.Date +
                "\nCena: " + string.Format("{0:C}", args.Price) + " brutto\n");

                sw.Close();
            }
            Console.WriteLine(File.ReadAllText(path)+ "\n");
        }
    }
}
