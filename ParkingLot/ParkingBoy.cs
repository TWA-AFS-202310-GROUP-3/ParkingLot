using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private List<ParkingLotPlace> parkinglot = new List<ParkingLotPlace>();

        public string FetchCar()
        {
            var car = parkinglot[1].FetchCar("car");
            return car;
        }
    }
}
