using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using HotelReservation.Hotel;

namespace HotelReservationTests.Hotel.Tests
{
    public class HotelTests
    {
        [Theory(DisplayName = "Given method is constructor When numberOfRooms is not in range Then constructor should throws ")]
        [InlineData(0)]
        [InlineData(1001)]
        public void ConstructorThrowsArgumentOutOfRangeException(int numberOfRooms)
        {
            //arrange

            //act

            //assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new HotelReservation.Hotel.Hotel(numberOfRooms));
        }

        [Fact(DisplayName = "Given method is constructor When constructor get argument in range Them constructor should make new object of type Hotel")]
        public void ConstructorMakeObject()
        {
            //arrange

            //act
            var hotel = new HotelReservation.Hotel.Hotel(20);

            //assert
            Assert.IsType<HotelReservation.Hotel.Hotel>(hotel);
            Assert.NotNull(hotel);
        }
    }
}
