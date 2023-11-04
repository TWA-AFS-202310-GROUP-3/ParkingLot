using ParkingLotPlace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class StandardParkingBoyTest
    {
        [Fact]
        public void Should_return_ticket_when_ParkCar_Given_car()
        {
            ParkingLot parkinglot = new ParkingLot(10);
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkinglot); //parking boy act as a proxy here

            string ticket = standardParkingBoy.ParkCar("volvo");

            Assert.Equal("Tvolvo", ticket);
        }

        [Fact]
        public void Should_return_car_when_FetchCar_Given_ticket()
        {
            ParkingLot parkinglot = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkinglot);
            string ticket = standardParkingBoy.ParkCar("volvo");

            string fetchedcar = standardParkingBoy.FetchCar(ticket);

            Assert.Equal("volvo", fetchedcar);
        }

        [Fact]
        public void Should_return_right_car_when_FetchCar_twice_Given_two_ticket()
        {
            ParkingLot parkinglot = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkinglot);
            string ticket1 = standardParkingBoy.ParkCar("volvo");
            string ticket2 = standardParkingBoy.ParkCar("Benz");

            string fetchedcar1 = standardParkingBoy.FetchCar(ticket1);
            string fetchedcar2 = standardParkingBoy.FetchCar(ticket2);

            Assert.Equal("volvo", fetchedcar1);
            Assert.Equal("Benz", fetchedcar2);
        }

        [Fact]
        public void Should_throw_exception_when_FetchCar_Given_wrong_ticket()
        {
            ParkingLot parkinglot = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkinglot);

            string ticket = "12342";

            var exception = Assert.Throws<ArgumentException>(() => standardParkingBoy.FetchCar(ticket));
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Fact]
        public void Should_throw_exception_when_FetchCar_Given_no_ticket()
        {
            ParkingLot parkinglot = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkinglot);

            string ticket = string.Empty;

            var exception = Assert.Throws<ArgumentException>(() => standardParkingBoy.FetchCar(ticket));
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Fact]
        public void Should_throw_exception_when_FetchCar_Given_used_ticket()
        {
            ParkingLot parkinglot = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkinglot);

            string ticket = standardParkingBoy.ParkCar("Benz");
            standardParkingBoy.FetchCar(ticket);

            var exception = Assert.Throws<InvalidOperationException>(() => standardParkingBoy.FetchCar(ticket));
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Fact]
        public void Should_throw_exception_when_FetchCar_Given_full_capacity()
        {
            ParkingLot parkinglot = new ParkingLot(1);
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkinglot);
            standardParkingBoy.ParkCar("Benz");

            var exception = Assert.Throws<InvalidOperationException>(() => standardParkingBoy.ParkCar("volvo"));
            Assert.Equal("No available position.", exception.Message);
        }
    }
}
