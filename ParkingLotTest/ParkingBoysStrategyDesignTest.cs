using ParkingLot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingBoysStrategyDesignTest
    {
        [Fact]
        public void Should_inject_different_parkingBoy_object_When_use_stratege_pattern()
        {
            ParkingBoys_ForStrategyDesign boy1 = new ParkingBoys_ForStrategyDesign(new StandardParkingBoy(new ParkingLotPlace()));
            Assert.True(boy1.ParkingBoy is StandardParkingBoy);

            ParkingBoys_ForStrategyDesign boy2 = new ParkingBoys_ForStrategyDesign(new StandardParkingBoyPlus(new List<ParkingLotPlace>()));
            Assert.True(boy2.ParkingBoy is StandardParkingBoyPlus);

            ParkingBoys_ForStrategyDesign boy3 = new ParkingBoys_ForStrategyDesign(new SmartParkingBoy(new List<ParkingLotPlace>()));
            Assert.True(boy3.ParkingBoy is SmartParkingBoy);
        }
    }
}
