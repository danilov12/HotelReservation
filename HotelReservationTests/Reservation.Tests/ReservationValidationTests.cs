using HotelReservation.Reservation;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HotelReservationTests.Reservation.Tests
{
    public class ReservationValidationTests
    {
        private readonly ReservationValidation _reservationValidation;

        public ReservationValidationTests()
        {
            _reservationValidation = new ReservationValidation();
        }

        [Theory(DisplayName = "Given method should validate tuple When arguments are ok Then method should return true.")]
        [InlineData(1,2)]
        [InlineData(100,200)]
        public void ValidateTupleMethodReturnsTrue(int startDate, int endDate)
        {
            //arrange

            //act
            var validationResult = _reservationValidation.ValidateTuple((startDate, endDate));

            //assert
            Assert.True(validationResult);
        }

        [Theory(DisplayName = "Given method should validate tuple When first argument is less than 0 Then method should return false.")]
        [InlineData(-1,2)]
        [InlineData(-5,2)]
        public void ValidateTupleMethodReturnsFalseWhenFirstArgumentIsLessThanZero(int startDate, int endDate)
        {
            //arrange

            //act
            var validationResult = _reservationValidation.ValidateTuple((startDate, endDate));

            //assert
            Assert.False(validationResult);
        }

        [Theory(DisplayName = "Given method should validate tuple When first argument is greater than second argument Then method should return false.")]
        [InlineData(3,1)]
        [InlineData(135,115)]
        public void ValidateTupleMethodReturnsFalseWhenFirstArgumentIsGreateThanSecondArgument(int startDate, int endDate)
        {
            //arrange

            //act
            var validationResult = _reservationValidation.ValidateTuple((startDate, endDate));

            //assert
            Assert.False(validationResult);
        }

        [Theory(DisplayName = "Given method should validate tuple When second argument is greater than 365 Then method should return false.")]
        [InlineData(10,366)]
        public void ValidateTupleMethodReturnsFalseWhenSecondArgumentIsNotInRange(int startDate, int endDate)
        {
            //arrange

            //act
            var validationResult = _reservationValidation.ValidateTuple((startDate, endDate));

            //assert
            Assert.False(validationResult);
        }

    }
}
