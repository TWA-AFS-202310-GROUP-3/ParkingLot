using ParkingLotPractice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class SmartParkingBoyTest
    {
        [Fact]
        public void Should_return_ticket_when_parkingBoy_park_a_car()
        {
            // Given
            ParkingLot parkingLot = new ParkingLot();
            StrategicParkingBoy smartParkingBoy = new StrategicParkingBoy(new SmartStrategy(), parkingLot);
            string car = "car1";
            string expectedResult = "T-car1";
            // When
            string result = smartParkingBoy.Park(car);
            // Then
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_return_car_when_parkingBoy_fetch_a_car_with_ticket()
        {
            // Given
            ParkingLot parkingLot = new ParkingLot();
            string car = "car1";
            string ticket = parkingLot.Park(car);
            StrategicParkingBoy smartParkingBoy = new StrategicParkingBoy(new SmartStrategy(), parkingLot);
            string expectedResult = "car1";
            // When
            string result = smartParkingBoy.Fetch(ticket);
            // Then
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_return_right_car_when_parkingBoy_fetch_with_different_tickets()
        {
            // Given
            ParkingLot parkingLot = new ParkingLot();
            string car1 = "car1";
            string car2 = "car2";
            string ticket1 = parkingLot.Park(car1);
            string ticket2 = parkingLot.Park(car2);
            StrategicParkingBoy smartParkingBoy = new StrategicParkingBoy(new SmartStrategy(), parkingLot);
            string expectedResult1 = "car1";
            string expectedResult2 = "car2";
            // When
            string result1 = smartParkingBoy.Fetch(ticket1);
            string result2 = smartParkingBoy.Fetch(ticket2);
            // Then
            Assert.Equal(expectedResult1, result1);
            Assert.Equal(expectedResult2, result2);
        }

        [Fact]
        public void Should_get_WrongTicketException_when_parkingBoy_fetch_with_ticket_is_wrong()
        {
            // Given
            ParkingLot parkingLot = new ParkingLot();
            string ticket1 = parkingLot.Park("car1");
            string ticket2 = "T-car2";
            StrategicParkingBoy smartParkingBoy = new StrategicParkingBoy(new SmartStrategy(), parkingLot);
            // When// Then
            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => smartParkingBoy.Fetch(ticket2));
        }

        [Fact]
        public void Should_get_WrongTicketException_when_parkingBoy_fetch_with_ticket_used_before()
        {
            // Given
            ParkingLot parkingLot = new ParkingLot();
            string ticket = parkingLot.Park("car");
            string car = parkingLot.Fetch(ticket);
            StrategicParkingBoy smartParkingBoy = new StrategicParkingBoy(new SmartStrategy(), parkingLot);
            // When// Then
            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => smartParkingBoy.Fetch(ticket));
        }

        [Fact]
        public void Should_return_NoPositionException_when_capacity_is_full()
        {
            // Given
            ParkingLot parkingLot = new ParkingLot(1);
            parkingLot.Park("car1");
            StrategicParkingBoy smartParkingBoy = new StrategicParkingBoy(new SmartStrategy(), parkingLot);
            // When// Then
            NoPositionException noPositionException = Assert.Throws<NoPositionException>(() => smartParkingBoy.Park("car"));
        }

        [Fact]
        public void Should_park_in_parkingLot_having_more_positions_when_park_a_car_between_2_available_parkingLot()
        {
            // Given
            ParkingLot parkingLot1 = new ParkingLot(5);
            ParkingLot parkingLot2 = new ParkingLot(10);
            StrategicParkingBoy smartParkingBoy = new StrategicParkingBoy(new SmartStrategy(), parkingLot1, parkingLot2);
            string ticket = smartParkingBoy.Park("car");
            string expectedResult = "car";
            // When
            string result = parkingLot2.Fetch(ticket);
            // Then
            Assert.Equal(expectedResult, result);
        }
    }
}
