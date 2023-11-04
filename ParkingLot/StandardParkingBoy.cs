using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotPlace
{
    public class StandardParkingBoy
    {
        private ParkingLot parkingLot;

        public StandardParkingBoy(ParkingLot parkingLot)
        {
            this.parkingLot = parkingLot;
        }

        public string ParkCar(string car)
        {
            return parkingLot.ParkCar(car);
        }

        public string FetchCar(string ticket)
        {
            return parkingLot.FetchCar(ticket);
        }
    }
}
