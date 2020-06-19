using HotelReservation.Reservation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation.Decorator
{
    public class RoomReservationDecorator : IRoomReservation
    {
        private readonly IRoomReservation _roomReservation;
        private readonly IReservationValidation _validation;
        public RoomReservationDecorator(
            IRoomReservation hotelReservation,
            IReservationValidation validation
            )
        {
            _roomReservation = hotelReservation;
            _validation = validation;
        }

        public bool ReserveRoom((int, int) reservationDays)
        {
            var validation = _validation.ValidateTuple(reservationDays);
            if (validation)
            {
                var isRoomReserved = _roomReservation.ReserveRoom(reservationDays);
                return isRoomReserved;
            }
            else
            {
                return false;
            }
        }
    }
}
