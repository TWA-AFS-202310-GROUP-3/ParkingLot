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
        public void Should_in_first_parkinglot_when_ParkCar_Given_first_parkinglot_more_empty()
        {
            ParkingLot parkinglot1 = new ParkingLot(8);
            ParkingLot parkinglot2 = new ParkingLot(5);
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(new List<ParkingLot> { parkinglot1, parkinglot2 });

            string ticket = standardParkingBoy.ParkCar("volvo");

            Assert.Equal("volvo", parkinglot1.FetchCar(ticket));
        }
    }
}
