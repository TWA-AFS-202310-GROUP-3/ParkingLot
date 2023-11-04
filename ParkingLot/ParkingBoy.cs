using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotProj
{
    public class ParkingBoy : IParkingBehavior
    {
        private readonly ParkingLot parkingLot;

        public ParkingBoy(ParkingLot parkingLot)
        {
            this.parkingLot = parkingLot;
        }

        public string Fetch(string ticketId)
        {
            return parkingLot.Fetch(ticketId);
        }

        public string Park(string carId)
        {
            return parkingLot.Park(carId);
        }
    }
}
