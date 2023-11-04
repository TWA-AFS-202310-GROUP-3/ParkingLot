using ParkingLot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingLotPlaceTest
    {
        [Fact]
        public void Should_return_car_When_fetch_Given_ticket()
        {
            var expect_car = "Benze";
            var ticket = "T_Benze";

            ParkingLotPlace parkingLot = new ParkingLotPlace();

            parkingLot.ParkCar("Benze");
            var actual_car = parkingLot.FetchCar(ticket);

            Assert.Equal(expect_car, actual_car);
        }

        [Fact]
        public void Should_return_ticket_When_park_Given_car()
        {
            var car = "Benze";
            var expect_ticket = "T_Benze";
            ParkingLotPlace parkingLot = new ParkingLotPlace();

            var actual_ticket = parkingLot.ParkCar(car);

            Assert.Equal(expect_ticket, actual_ticket);
        }

        [Fact]
        public void Should_return_right_car_When_fetch_Given_right_ticket()
        {
            var car1 = "Benze";
            var car2 = "BMW";
            var expect_ticket1 = "T_Benze";
            var expect_ticket2 = "T_BMW";
            ParkingLotPlace parkingLot = new ParkingLotPlace();

            var actual_ticket1 = parkingLot.ParkCar(car1);
            var actual_ticket2 = parkingLot.ParkCar(car2);

            Assert.Equal(expect_ticket1, actual_ticket1);
            Assert.Equal(expect_ticket2, actual_ticket2);
        }

        [Fact]
        public void Should_return_right_car_When_fetch_Given_associated_ticket()
        {
            var expect_car = "Benze";
            ParkingLotPlace parkingLot = new ParkingLotPlace();
            var ticket = parkingLot.ParkCar("Benze");

            var actual_car = parkingLot.FetchCar(ticket);

            Assert.Equal(expect_car, actual_car);
        }

        [Fact]
        public void Should_throw_exception_When_fetch_Given_wrong_or_no_ticket()
        {
            var expect_msg = "Unrecognized parking ticket.";
            var wrong_ticket = "WRONG Ticket";
            var empty_ticket = string.Empty;
            ParkingLotPlace parkingLot = new ParkingLotPlace();

            WrongException acturl_wrong_ticket = Assert.Throws<WrongException>(() => parkingLot.FetchCar(wrong_ticket));
            WrongException acturl_empty_ticket = Assert.Throws<WrongException>(() => parkingLot.FetchCar(empty_ticket));

            Assert.Equal(expect_msg, acturl_wrong_ticket.Message);
            Assert.Equal(expect_msg, acturl_empty_ticket.Message);
        }

        [Fact]
        public void Should_throw_exception_When_fetch_Given_used_ticket()
        {
            var car = "Benze";
            ParkingLotPlace parkingLot = new ParkingLotPlace();
            var ticket = parkingLot.ParkCar(car);
            parkingLot.FetchCar(ticket);
            var expect_msg = "Unrecognized parking ticket.";

            WrongException acturl_wrong_ticket = Assert.Throws<WrongException>(() => parkingLot.FetchCar(car));

            Assert.Equal(expect_msg, acturl_wrong_ticket.Message);
        }

        [Fact]
        public void Should_throw_exception_When_fetch_Given_no_parkingSpot()
        {
            string[] cars = { "Benze", "BMW", "Rolls-Royce", "Tesla", "Lamborghini", "Porsche" };
            ParkingLotPlace parkingLot = new ParkingLotPlace();
            foreach (var car in cars)
            {
                parkingLot.ParkCar(car);
            }

            var expect_msg = "No available position.";

            WrongException acturl_wrong_msg = Assert.Throws<WrongException>(() => parkingLot.ParkCar("Mazda"));

            Assert.Equal(expect_msg, acturl_wrong_msg.Message);
        }

        [Fact]
        public void Should_return_ticket_When_parkingboy_park_Given_car()
        {
            var car = "Benze";
            var expect_ticket = "T_Benze";
            ParkingBoy parkingBoy = new ParkingBoy(new ParkingLotPlace());

            var actual_ticket = parkingBoy.ParkCar(car);

            Assert.Equal(expect_ticket, actual_ticket);
        }

        [Fact]
        public void Should_return_car_When_parkingboy_fetch_Given_ticket()
        {
            var expect_car = "Benze";
            var ticket = "T_Benze";
            ParkingLotPlace parkingLot = new ParkingLotPlace();
            parkingLot.ParkCar(expect_car);
            ParkingBoy parkingboy = new ParkingBoy(parkingLot);

            var actual_car = parkingboy.FetchCar(ticket);

            Assert.Equal(expect_car, actual_car);
        }

        [Fact]
        public void Should_return_right_car_When_parkingboy_fetch_car_Given_right_ticket()
        {
            var expect_car1 = "Benze";
            var expect_car2 = "BMW";
            var ticket1 = "T_Benze";
            var ticket2 = "T_BMW";
            ParkingLotPlace parkingLot = new ParkingLotPlace();
            parkingLot.ParkCar(expect_car1);
            parkingLot.ParkCar(expect_car2);
            ParkingBoy parkingboy = new ParkingBoy(parkingLot);

            var actual_car1 = parkingboy.FetchCar(ticket1);
            var actual_car2 = parkingboy.FetchCar(ticket2);

            Assert.Equal(expect_car1, actual_car1);
            Assert.Equal(expect_car2, actual_car2);
        }

        [Fact]
        public void Should_throw_exception_When_parkingboy_fetch_Given_wrong_or_no_ticket()
        {
            var expect_msg = "Unrecognized parking ticket.";
            var wrong_ticket = "WRONG Ticket";
            var empty_ticket = string.Empty;
            ParkingLotPlace parkingLot = new ParkingLotPlace();
            ParkingBoy parkingBoy = new ParkingBoy(parkingLot);

            WrongException acturl_wrong_ticket = Assert.Throws<WrongException>(() => parkingBoy.FetchCar(wrong_ticket));
            WrongException acturl_empty_ticket = Assert.Throws<WrongException>(() => parkingBoy.FetchCar(empty_ticket));

            Assert.Equal(expect_msg, acturl_wrong_ticket.Message);
            Assert.Equal(expect_msg, acturl_empty_ticket.Message);
        }

        [Fact]
        public void Should_throw_exception_When_parkingboy_fetch_Given_used_ticket()
        {
            var car = "Benze";
            ParkingLotPlace parkingLot = new ParkingLotPlace();
            var ticket = parkingLot.ParkCar(car);
            parkingLot.FetchCar(ticket);
            ParkingBoy parkingBoy = new ParkingBoy(parkingLot);
            var expect_msg = "Unrecognized parking ticket.";

            WrongException acturl_wrong_ticket = Assert.Throws<WrongException>(() => parkingBoy.FetchCar(car));

            Assert.Equal(expect_msg, acturl_wrong_ticket.Message);
        }

        [Fact]
        public void Should_throw_exception_When_parkingBoy_fetch_Given_no_parkingSpot()
        {
            string[] cars = { "Benze", "BMW", "Rolls-Royce", "Tesla", "Lamborghini", "Porsche" };
            ParkingLotPlace parkingLot = new ParkingLotPlace();
            foreach (var car in cars)
            {
                parkingLot.ParkCar(car);
            }

            ParkingBoy parkingBoy = new ParkingBoy(parkingLot);

            var expect_msg = "No available position.";

            WrongException acturl_wrong_msg = Assert.Throws<WrongException>(() => parkingBoy.ParkCar("Mazda"));

            Assert.Equal(expect_msg, acturl_wrong_msg.Message);
        }
    }
}
