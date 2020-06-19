using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation.Reservation
{
    public interface IRoomReservation
    {
        bool ReserveRoom(ValueTuple<int, int> reservationDays);
    }
}
