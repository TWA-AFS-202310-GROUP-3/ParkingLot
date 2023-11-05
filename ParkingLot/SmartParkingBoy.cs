using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class SmartParkingBoy : ParkingBoyBase
    {
        private MinHeap<ParkingLotPlace> minheap;

        public SmartParkingBoy(List<ParkingLotPlace> parkingLotPlaces)
        {
        }
    }
}
