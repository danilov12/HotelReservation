using HotelReservation.Reservation;
using System;
using System.Collections.Generic;
using System.Text;
using HotelReservation.Decorator;

namespace HotelReservation.DecoratorPattern
{
    public class ReservationComposition
    {
        private IRoomReservation _reservation;

        private readonly int _numberOfRoom;

        public ReservationComposition(int numberOfRoom)
        {
            _numberOfRoom = numberOfRoom;
            Compose();
        }

        private void Compose()
        {
            var hotel = new Hotel.Hotel(_numberOfRoom);
            var findRoom = new FindRoom();
            var reservation = new RoomReservation(hotel, findRoom);

            var validation = new ReservationValidation();
            _reservation = new RoomReservationDecorator(reservation,validation);
        }

        public bool ReserveRoom((int, int) reservedDates)
        {
            var result = _reservation.ReserveRoom(reservedDates);
            return result;
        }
    }
}
