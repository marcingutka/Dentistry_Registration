using System;
using System.Collections.Generic;

namespace ReservationModule.Output
{
    public interface IOutput
    {
        void Log(ReservationArgs args);
        void Unlog(List<ReservationArgs> list);
        void DeleteAll();
    }
}
