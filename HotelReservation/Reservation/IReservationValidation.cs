using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation.Reservation
{
    public interface IReservationValidation
    {
        bool ValidateTuple((int, int) reservationDays);
    }
}
