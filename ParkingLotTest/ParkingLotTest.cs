using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ParkingLotPractice;

namespace ParkingLotTest
{
    public class ParkingLotTest
    {
        [Fact]
        public void Should_get_the_same_car_when_fetch_car_by_ticket()
        {
            // Given
            ParkingLot parkingLot = new ParkingLot();
            string ticket = parkingLot.Park("car");
            string expectedResult = "car";
            // When
            string result = parkingLot.Fetch(ticket);
            // Then
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_get_correct_car_when_fetch_by_corresponding_ticket()
        {
            // Given
            ParkingLot parkingLot = new ParkingLot();
            string ticket1 = parkingLot.Park("car1");
            string ticket2 = parkingLot.Park("car2");
            string expectedResult = "car2";
            // When
            string result = parkingLot.Fetch(ticket2);
            // Then
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_get_no_car_when_ticket_is_wrong()
        {
            // Given
            ParkingLot parkingLot = new ParkingLot();
            string ticket1 = parkingLot.Park("car1");
            string ticket2 = "T-car2";
            string expectedResult = null;
            // When
            string result = parkingLot.Fetch(ticket2);
            // Then
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_get_no_car_when_ticket_is_empty()
        {
            // Given
            ParkingLot parkingLot = new ParkingLot();
            string expectedResult = null;
            // When
            string result = parkingLot.Fetch();
            // Then
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_get_no_car_when_ticket_is_used_before()
        {
            // Given
            ParkingLot parkingLot = new ParkingLot();
            string ticket = parkingLot.Park("car");
            string car = parkingLot.Fetch(ticket);
            string expectedResult = null;
            // When
            string result = parkingLot.Fetch(ticket);
            // Then
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_fail_to_park_when_capacity_is_full()
        {
            // Given
            ParkingLot parkingLot = new ParkingLot();
            for (int i = 0; i < 10; i++)
            {
                parkingLot.Park("car" + i.ToString());
            }

            string expectedResult = null;
            // When
            string result = parkingLot.Park("car");
            // Then
            Assert.Equal(expectedResult, result);
        }
    }
}
