using ParkingLotPlace;
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
        public void Should_in_second_parkinglot_when_ParkCar_Given_second_parkinglot_more_empty()
        {
            ParkingLot parkinglot1 = new ParkingLot(5);
            ParkingLot parkinglot2 = new ParkingLot(8);
            SmartParkingBoy smartParkingBoy = new SmartParkingBoy(new List<ParkingLot> { parkinglot1, parkinglot2 });

            string ticket = smartParkingBoy.ParkCar("volvo");

            Assert.Equal("volvo", parkinglot2.FetchCar(ticket));
        }
    }
}
