using ParkingLotPlace;
using System;
using System.Runtime.ConstrainedExecution;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingLotTest
    {
        [Fact]
        public void Should_return_ticket_when_ParkCar_Given_car()
        {
            ParkingLot parkinglot = new ParkingLot(10);

            string ticket = parkinglot.ParkCar("volvo");

            Assert.Equal("Tvolvo", ticket);
        }

        [Fact]
        public void Should_return_car_when_FetchCar_Given_ticket()
        {
            //given
            ParkingLot parkinglot = new ParkingLot(); // new class not namespace
            string ticket = parkinglot.ParkCar("volvo");
            //when
            string fetchedcar = parkinglot.FetchCar(ticket);
            //then
            Assert.Equal("volvo", fetchedcar);
        }

        [Fact]
        public void Should_throw_exception_when_FetchCar_Given_wrong_ticket()
        {
            //given
            ParkingLot parkinglot = new ParkingLot();
            //when
            string ticket = "12342";
            //then
            var exception = Assert.Throws<ArgumentException>(() => parkinglot.FetchCar(ticket));
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Fact]
        public void Should_throw_exception_when_FetchCar_Given_no_ticket()
        {
            //given
            ParkingLot parkinglot = new ParkingLot();
            //when
            string ticket = string.Empty;
            //then
            var exception = Assert.Throws<ArgumentException>(() => parkinglot.FetchCar(ticket));
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Fact]
        public void Should_throw_exception_when_FetchCar_Given_used_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            string ticket = parkingLot.ParkCar("Benz");
            parkingLot.FetchCar(ticket);

            var exception = Assert.Throws<InvalidOperationException>(() => parkingLot.FetchCar(ticket));
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Fact]
        public void Should_throw_exception_when_FetchCar_Given_full_capacity()
        {
            ParkingLot parkingLot = new ParkingLot(1);
            parkingLot.ParkCar("Benz");

            var exception = Assert.Throws<InvalidOperationException>(() => parkingLot.ParkCar("volvo"));
            Assert.Equal("No available position.", exception.Message);
        }
    }
}
