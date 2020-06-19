using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation.Hotel
{
    public class Hotel : IHotel
    {
        public int[][] Rooms { get; set; }

        public Hotel(int roomsNumber)
        {
            if (roomsNumber >= 1000 || roomsNumber < 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                this.Rooms = new int[roomsNumber][];
                for (int i = 0; i < roomsNumber; i++)
                    this.Rooms[i] = new int[365];
            }
        }
    }
}
