using ParkingLotSystem;
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
        public void Should_in_first_parkinglot_when_ParkCar_Given_first_parkinglot_more_empty()
        {
            ParkingLot parkinglot1 = new ParkingLot();
            ParkingLot parkinglot2 = new ParkingLot();
            SmartParkingBoy smartParkingBoy = new SmartParkingBoy(new List<ParkingLot>() { parkinglot1, parkinglot2 });
            parkinglot1.ParkACar("car");
            string ticket = smartParkingBoy.ParkACar("car2");

            Assert.Equal("car2", parkinglot2.FetchACar(ticket));
        }
    }
}
