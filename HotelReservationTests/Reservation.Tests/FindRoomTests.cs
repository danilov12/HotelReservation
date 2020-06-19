using HotelReservation.Reservation;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HotelReservationTests.Reservation.Tests
{
    public class FindRoomTests
    {
        private readonly FindRoom _findRoom;

        public FindRoomTests()
        {
            _findRoom = new FindRoom();
        }

        [Fact(DisplayName = "Given method should return number of first free room in specified time period When hotel have free room Then method should return room number")]
        public void ReturnNumberOfFreeRoomReturnsRoomNumber()
        {
            //arrange
            var rooms = new int[3][];
            for (int i = 0; i < rooms.Length; i++)
                rooms[i] = new int[365];

            rooms[0][1] = 1;
            rooms[0][2] = 1;

            //act
            var numberOfFreeRoom = _findRoom.ReturnNumberOfFreeRoom(rooms, 1, 2);
            
            //assert
            Assert.Equal(1, numberOfFreeRoom);
        }

        [Fact(DisplayName = "Given method should return number of first free room in specified time period When hotel don't have free room Then method should return -1")]
        public void ReturnNumberOfFreeRoomReturnsZero()
        {
            //arrange
            var rooms = new int[2][];
            for (int i = 0; i < rooms.Length; i++)
                rooms[i] = new int[365];

            rooms[0][1] = 1;
            rooms[0][2] = 1;
            rooms[1][1] = 1;
            rooms[1][2] = 1;

            //act
            var numberOfFreeRoom = _findRoom.ReturnNumberOfFreeRoom(rooms, 1, 2);

            //assert
            Assert.Equal(-1, numberOfFreeRoom);
        }
    }
}
