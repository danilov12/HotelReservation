using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation.Reservation
{
    public interface IFindRoom
    {
        int ReturnNumberOfFreeRoom(int[][] rooms, int startDay, int endDay);
    }
}
