using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSystem
{
    public class StandardParkingBoy
    {
        private ParkingLot parkingLot;
        public StandardParkingBoy(ParkingLot parkingLot)
        {
            this.parkingLot = parkingLot;
        }

        public string ParkACar(string carNumber)
        {
            return parkingLot.ParkACar(carNumber);
        }

        public string FetchACar(string ticketNumber)
        {
            return parkingLot.FetchACar(ticketNumber);
        }
    }
}
