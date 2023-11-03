using ParkingLot;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var ticket = "T-Benze";

            PackingLotManager manager = new PackingLotManager();

            var actual_car = manager.FetchCar(ticket);

            Assert.Equal(expect_car, actual_car);
        }
    }
}
