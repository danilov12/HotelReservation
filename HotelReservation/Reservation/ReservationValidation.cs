using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation.Reservation
{
    public class ReservationValidation : IReservationValidation
    {
        public ReservationValidation()
        {

        }
        public bool ValidateTuple((int, int) reservationDays)
        {
            if (reservationDays.Item1 < 0 || reservationDays.Item1 > reservationDays.Item2 || reservationDays.Item2 > 365)
            {
                return false;
            }
            return true;
        }
    }
}
