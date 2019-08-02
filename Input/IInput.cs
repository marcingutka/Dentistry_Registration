using System.Data;

namespace ReservationModule.Input
{
    public interface IInput
    {
        DataTable GetReservation(ReservationArgs args);
        DataTable GetAll();
    }
}
