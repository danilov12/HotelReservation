using HotelReservation.Decorator;
using HotelReservation.Reservation;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HotelReservationTests.DecoratorPattern.Tests
{
    public class RoomReservationDecoratorTests
    {
        private readonly IRoomReservation _hotelReservation;
        private readonly IReservationValidation _validation;
        private readonly RoomReservationDecorator _roomReservationDecorator;

        public RoomReservationDecoratorTests()
        {
            _hotelReservation = Substitute.For<IRoomReservation>();
            _validation = Substitute.For<IReservationValidation>();
            _roomReservationDecorator = new RoomReservationDecorator(_hotelReservation, _validation);
        }

        [Fact(DisplayName = "Given method should validate reservation days and call ReserveRoom method When reservation days are not valid Then method should return false and call ReserveRoom 0 times.")]
        public void DecoratorReserveRoomReturnsFalse()
        {
            //arrange
            _validation.ValidateTuple(Arg.Any<ValueTuple<int, int>>()).Returns(false);

            //act
            var reservationResult = _roomReservationDecorator.ReserveRoom((1, 1));

            //assert
            Assert.False(reservationResult);
            _hotelReservation.Received(0).ReserveRoom(Arg.Any<ValueTuple<int, int>>());
        }

        [Fact(DisplayName = "Given method should validate reservation days and call ReserveRoom method When reservation days are valid but hotel haven't any free rooms Then method should call ReserveRoom method once and return false.")]
        public void DecoratorReserveRoomReturnsFalseWhenValidationIsOk()
        {
            //arrange
            _validation.ValidateTuple(Arg.Any<ValueTuple<int, int>>()).Returns(true);
            _hotelReservation.ReserveRoom(Arg.Any<ValueTuple<int, int>>()).Returns(false);

            //act
            var reservationResult = _roomReservationDecorator.ReserveRoom((1, 1));

            //assert
            Assert.False(reservationResult);
            _hotelReservation.Received(1).ReserveRoom(Arg.Any<ValueTuple<int, int>>());
        }

        [Fact(DisplayName = "Given method should validate reservation days and call ReserveRoom method When reservation days are valid and hotel have free room Then method should call ReserveRoom method once and return true.")]
        public void DecoratorReserveRoomReturnsTrueWhenValidationAndReservationAreOk()
        {
            //arrange
            _validation.ValidateTuple(Arg.Any<ValueTuple<int, int>>()).Returns(true);
            _hotelReservation.ReserveRoom(Arg.Any<ValueTuple<int, int>>()).Returns(true);

            //act
            var reservationResult = _roomReservationDecorator.ReserveRoom((1, 1));

            //assert
            Assert.True(reservationResult);
            _hotelReservation.Received(1).ReserveRoom(Arg.Any<ValueTuple<int, int>>());
        }
    }
}
