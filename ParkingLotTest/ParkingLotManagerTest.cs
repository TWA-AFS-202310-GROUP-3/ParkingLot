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
    public class ParkingLotManagerTest
    {
        [Fact]
        public void Should_return_car_When_fetch_Given_ticket()
        {
            var expect_car = "Benze";
            var ticket = "T_Benze";

            ParkingLotManager manager = new ParkingLotManager();

            manager.ParkCar("Benze");
            var actual_car = manager.FetchCar(ticket);

            Assert.Equal(expect_car, actual_car);
        }

        [Fact]
        public void Should_return_ticket_When_park_Given_car()
        {
            var car = "Benze";
            var expect_ticket = "T_Benze";
            ParkingLotManager manager = new ParkingLotManager();

            var actual_ticket = manager.ParkCar(car);

            Assert.Equal(expect_ticket, actual_ticket);
        }

        [Fact]
        public void Should_return_right_car_When_fetch_Given_associated_ticket()
        {
            var expect_car = "Benze";
            ParkingLotManager manager = new ParkingLotManager();
            var ticket = manager.ParkCar("Benze");

            var actual_car = manager.FetchCar(ticket);

            Assert.Equal(expect_car, actual_car);
        }
    }
}
