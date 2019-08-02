using System;
using System.Data;
using System.Collections.Generic;

namespace ReservationModule.Adapter
{
    public interface IAdapterToReservationArgs
    {
        List<ReservationArgs> Convert(DataTable dt);
    }
}
