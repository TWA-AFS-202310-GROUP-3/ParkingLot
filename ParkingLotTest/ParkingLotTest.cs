using ParkingLotPlace;
using System;
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
        public void Should_throw_exception_when_FetchCar_Given_wrong_ticket()
        {
            //given
            ParkingLot parkinglot = new ParkingLot();
            //when
            string ticket = "12342";
            //then
            Assert.Throws<ArgumentException>(() => parkinglot.FetchCar(ticket));
        }

        [Fact]
        public void Should_throw_exception_when_FetchCar_Given_no_ticket()
        {
            //given
            ParkingLot parkinglot = new ParkingLot();
            //when
            string ticket = string.Empty;
            //then
            Assert.Throws<ArgumentException>(() => parkinglot.FetchCar(ticket));
        }
    }
}
