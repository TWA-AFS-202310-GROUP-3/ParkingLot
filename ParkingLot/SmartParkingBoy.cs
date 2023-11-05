using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class SmartParkingBoy : ParkingBoyBase
    {
        private MinHeap<ParkingLotPlace> carNumberMinHeap;

        public SmartParkingBoy(List<ParkingLotPlace> parkingLotPlaces)
        {
            carNumberMinHeap = new MinHeap<ParkingLotPlace>(parkingLotPlaces);
        }

        public override string ParkCar(string car)
        {
            ParkingLotSetterGetter = carNumberMinHeap.Pop();
            string ticket = base.ParkCar(car);
            carNumberMinHeap.Push(ParkingLotSetterGetter);

            return ticket;
        }
    }
}
