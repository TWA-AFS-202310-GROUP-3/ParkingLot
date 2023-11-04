using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotns
{
    public class StandardParkingBoy
    {
        //private List<ParkingLot> parkingLots;
        private ParkingLot parkingLots = new ParkingLot();

        //public StandardParkingBoy(ParkingLot parkingLots)
        //{
        //    this.parkingLots = parkingLots;
        //}

        public string FetchCar(string ticket)
        {
            return parkingLots.Fetch(ticket);
        }

        public string ParkCar(string car)
        {
            return parkingLots.Park(car);
        }
    }
}
