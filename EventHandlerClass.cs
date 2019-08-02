using System;
using System.Collections.Generic;
using ReservationModule.Output;
using ReservationModule.Input;
using ReservationModule.Adapter;

namespace ReservationModule
{
    public class EventHandlerClass
    {
        IOutput IOutput_Device { get; set; } = new OutputSQLServer();
        IInput IInput_Device { get; set; } = new InputSQLServer();
        IAdapterToReservationArgs IAdapter { get; set; } = new DataTableToReservationArgsAdapter();

        public EventHandlerClass() { }
        public EventHandlerClass(IOutput _ODevice, IInput _IDevice, IAdapterToReservationArgs _Adapter)
        {
            IOutput_Device = _ODevice;
            IInput_Device = _IDevice;
            IAdapter = _Adapter;
        }
        public void LogOperation(object _o, EventArgs _event)
        {
            ReservationArgs args = _event as ReservationArgs;

            IOutput_Device.Log(args);            
        }

        public List<ReservationArgs> UnlogOperation(object _o, EventArgs _event)
        {
            List<ReservationArgs> list = GetOperation(_o, _event);
            IOutput_Device.Unlog(GetOperation(_o, _event));
            return list;
        }

        public List<ReservationArgs> GetOperation(object _o, EventArgs _event)
        {
            ReservationArgs args = _event as ReservationArgs;

            return IAdapter.Convert(IInput_Device.GetReservation(args));
        }

        public List<ReservationArgs> GetAll()
        {
            return IAdapter.Convert(IInput_Device.GetAll());
        }

        public void DeleteAll()
        {
            IOutput_Device.DeleteAll();
        }
    }
}
