using HotelReservation.Hotel;
using HotelReservation.Reservation;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HotelReservationTests.Reservation.Tests
{
    public class RoomReservavtionTests
    {
        private readonly IHotel _hotel;
        private readonly IFindRoom _findFreeRoom;
        private readonly RoomReservation _roomReservation;

        public RoomReservavtionTests()
        {
            _hotel = Substitute.For<IHotel>();
            _hotel.Rooms = HotelRooms();
            _findFreeRoom = Substitute.For<IFindRoom>();
            _roomReservation = new RoomReservation(_hotel, _findFreeRoom);
        }

        [Fact(DisplayName = "Given method shoud make reservation of room When there is no free room in hotel Then method should return false and call ReturnNumberOfFreeRoom once.")]
        public void ReserveRoomReturnsFalse()
        {
            //arrange
            _findFreeRoom.ReturnNumberOfFreeRoom(Arg.Any<int[][]>(), Arg.Any<int>(), Arg.Any<int>()).Returns(-1);

            //act
            var roomReservationResult = _roomReservation.ReserveRoom((1, 2));

            //assert
            Assert.False(roomReservationResult);
            _findFreeRoom.Received(1).ReturnNumberOfFreeRoom(Arg.Any<int[][]>(), Arg.Any<int>(), Arg.Any<int>());
        }

        [Fact(DisplayName = "Given method shoud make reservation of room When there is free room in hotel Then method should return true and call ReturnNumberOfFreeRoom once.")]
        public void ReserveRoomReturnsTrue()
        {
            //arrange
            _findFreeRoom.ReturnNumberOfFreeRoom(Arg.Any<int[][]>(), Arg.Any<int>(), Arg.Any<int>()).Returns(1);

            //act
            var roomReservationResult = _roomReservation.ReserveRoom((1, 2));

            //assert
            Assert.True(roomReservationResult);
            _findFreeRoom.Received(1).ReturnNumberOfFreeRoom(Arg.Any<int[][]>(), Arg.Any<int>(), Arg.Any<int>());
        }

        private int[][] HotelRooms()
        {
            int[][] rooms = new int[3][];
            for (int i = 0; i < rooms.Length; i++)
                rooms[i] = new int[365];
            return rooms;
        }
    }
}
