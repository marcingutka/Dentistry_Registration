using System;
using System.IO;
using System.Collections.Generic;

namespace ReservationModule.Output
{
    public class OutputFile : IOutput
    {
        public void Log(ReservationArgs args)
        {
            string s = "Złożono rezerwację nr " + args.ReservationID + " o następujących danych:" +
                "\nImię i nazwisko: " + args.Name + " " + args.Surname +
                "\nNazwa zabiegu: " + args.Operation +
                "\nData: " + args.Date +
                "\nCena: " + string.Format("{0:C}", args.Price) + " brutto\n";

            string path = "lista_operacji.txt";
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.Write(s);
                sw.Close();
            }
        }
        public void Unlog(List<ReservationArgs> list)
        {

        }
        public void DeleteAll()
        {

        }
    }
}
