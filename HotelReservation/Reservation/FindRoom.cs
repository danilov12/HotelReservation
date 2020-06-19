using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation.Reservation
{
    public class FindRoom : IFindRoom
    {
        public FindRoom()
        {

        }

        public int ReturnNumberOfFreeRoom(int[][] rooms, int startDay, int endDay)
        {
            int counter = 0;
            int numOfDays = endDay - startDay + 1;
            for (int i = 0; i <= rooms.Length; i++)
            {
                if (counter == numOfDays)
                    return i - 1;

                if (i == rooms.Length)
                    break;

                counter = 0;
                for (int j = startDay; j <= endDay; j++)
                {
                    if (rooms[i][j] == 0)
                    {
                        ++counter;
                    }
                }
            }
            return -1;
        }
    }
}
