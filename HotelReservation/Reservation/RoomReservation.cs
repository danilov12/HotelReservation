using HotelReservation.Hotel;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation.Reservation
{
    public class RoomReservation : IRoomReservation
    {
        private readonly IHotel _hotel;
        private readonly IFindRoom _findFreeRoom;
        public RoomReservation(
            IHotel hotel,
            IFindRoom findFreeRoom)
        {
            _hotel = hotel;
            _findFreeRoom = findFreeRoom;
        }

        public bool ReserveRoom(ValueTuple<int, int> reservationDays)
        {
            int numberOfFreeRoom = _findFreeRoom.ReturnNumberOfFreeRoom(_hotel.Rooms, reservationDays.Item1, reservationDays.Item2);

            if (numberOfFreeRoom == -1)
                return false;
            else
            {
                for (int i = reservationDays.Item1; i <= reservationDays.Item2; i++)
                {
                    _hotel.Rooms[numberOfFreeRoom][i] = 1;
                }
                return true;
            }
        }
    }
}
