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
            ParkingLot parkinglot = new ParkingLot();

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
        public void Should_return_right_car_when_FetchCar_twice_Given_two_ticket()
        {
            ParkingLot parkinglot = new ParkingLot();
            string ticket1 = parkinglot.ParkCar("volvo");
            string ticket2 = parkinglot.ParkCar("Benz");

            string fetchedcar1 = parkinglot.FetchCar(ticket1);
            string fetchedcar2 = parkinglot.FetchCar(ticket2);

            Assert.Equal("volvo", fetchedcar1);
            Assert.Equal("Benz", fetchedcar2);
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

            var exception = Assert.Throws<ArgumentException>(() => parkingLot.FetchCar(ticket));
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
