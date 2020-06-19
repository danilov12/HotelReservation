using HotelReservation.DecoratorPattern;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HotelReservationTests
{
    public class TestCases
    {
        [Theory(DisplayName = "Given method should make reservation in hotel When start date or end date are not valid Then method should return false.")]
        [InlineData(-4, 2)]
        [InlineData(200, 400)]
        public void TestCasesForRequestsOutsidePlanningPeriod(int startDate, int endDate)
        {
            //arrange
            var composition = new ReservationComposition(1);

            //act
            var booking = composition.ReserveRoom((startDate, endDate));

            //assert
            Assert.False(booking);
        }

        [Fact(DisplayName = "Given method should make reservation in hotel When dates are ok Then method should make reservation and returun true.")]
        public void TestCasesAreAllAccepted()
        {
            //arrange
            var composition = new ReservationComposition(3);
            bool[] bookings = new bool[6];

            //act
            bookings[0] = composition.ReserveRoom((0, 5));
            bookings[1] = composition.ReserveRoom((7, 13));
            bookings[2] = composition.ReserveRoom((3, 9));
            bookings[3] = composition.ReserveRoom((5, 7));
            bookings[4] = composition.ReserveRoom((6, 6));
            bookings[5] = composition.ReserveRoom((0, 4));

            //assert
            Assert.All(bookings, x => Assert.True(x));
        }

        [Fact(DisplayName = "Given method should make reservation in hotel When room is already reservated Then method should decline reservation and return false.")]
        public void TestCasesDeclinedRequests()
        {
            //arrange
            var composition = new ReservationComposition(3);

            //act
            var booking1 = composition.ReserveRoom((1, 3));
            var booking2 = composition.ReserveRoom((2, 5));
            var booking3 = composition.ReserveRoom((1, 9));
            var booking4 = composition.ReserveRoom((0, 15));

            //assert
            Assert.True(booking1);
            Assert.True(booking2);
            Assert.True(booking3);
            Assert.False(booking4);
        }

        [Fact(DisplayName = "Given method should make reservation in hotel When one reservation is decline Then method should accept next reservation if dates are in range.")]
        public void TestCasesRequestCanBeAccpetedAfterDecline()
        {
            //arrange
            var composition = new ReservationComposition(3);

            //act
            var booking1 = composition.ReserveRoom((1, 3));
            var booking2 = composition.ReserveRoom((0, 15));
            var booking3 = composition.ReserveRoom((1, 9));
            var booking4 = composition.ReserveRoom((2, 5));
            var booking5 = composition.ReserveRoom((4, 9));

            //assert
            Assert.True(booking1);
            Assert.True(booking2);
            Assert.True(booking3);
            Assert.False(booking4);
            Assert.True(booking5);
        }

        [Fact(DisplayName = "Given method should make reservation in hotel When method gets complex requests Then method should accpet all requests that are in range and decline all that are not in range.")]
        public void TestCasesComplexRequests()
        {
            //arrange
            var composition = new ReservationComposition(2);

            //act
            var booking1 = composition.ReserveRoom((1, 3));
            var booking2 = composition.ReserveRoom((0, 4));
            var booking3 = composition.ReserveRoom((2, 3));
            var booking4 = composition.ReserveRoom((5, 5));
            var booking5 = composition.ReserveRoom((4, 10));
            var booking6 = composition.ReserveRoom((10, 10));
            var booking7 = composition.ReserveRoom((6, 7));
            var booking8 = composition.ReserveRoom((8, 10));
            var booking9 = composition.ReserveRoom((8, 9));

            //assert
            Assert.True(booking1);
            Assert.True(booking2);
            Assert.False(booking3);
            Assert.True(booking4);
            Assert.False(booking5);
            Assert.True(booking6);
            Assert.True(booking7);
            Assert.True(booking8);
            Assert.True(booking9);
        }
    }
}
