using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class StandardParkingBoyPlus : ParkingBoyBase
    {
        private List<ParkingLotPlace> parkingLotPlaces;
        private int parkingLotToBeUsed;
        public StandardParkingBoyPlus(List<ParkingLotPlace> parkingLotPlaces)
        {
            this.parkingLotPlaces = parkingLotPlaces;
            parkingLotToBeUsed = 0;
        }

        public override string FetchCar(string ticket)
        {
           /* ParkingLotSetterGetter = parkingLotPlaces[parkingLotToBeUsed];
            return $"{base.FetchCar(ticket)}_ParkingLot{parkingLotToBeUsed}";*/
           return base.FetchCar(ticket);
        }

        public override string ParkCar(string car)
        {
            ParkingLotSetterGetter = parkingLotPlaces[parkingLotToBeUsed];
            return $"{base.ParkCar(car)}_ParkingLot_{parkingLotToBeUsed}";
        }
    }
}
