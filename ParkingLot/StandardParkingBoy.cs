using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotns
{
    public class StandardParkingBoy
    {
        private List<ParkingLot> parkingLots;
        //private ParkingLot parkingLots = new ParkingLot();

        public StandardParkingBoy(List<ParkingLot> parkingLots)
        {
            this.parkingLots = parkingLots;
        }

        public string FetchCar(string ticket)
        {
            foreach (var parkingLot in parkingLots)
            {
                return parkingLot.Fetch(ticket);
            }

            throw new WrongException("Unrecognized parking ticket");
        }

        public string ParkCar(string car)
        {
            foreach (var parkingLot in parkingLots)
            {
                if (parkingLot.HasAvailablePosition())
                {
                    return parkingLot.Park(car);
                }
            }

            return "No available position";
        }
    }
}
