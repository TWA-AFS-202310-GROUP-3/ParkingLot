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
                if (parkingLot.ContainsCar(ticket))
                {
                    return parkingLot.Fetch(ticket);
                }
            }

            throw new WrongException("Unrecognized parking ticket");
        }

        public string ParkCar(string car)
        {
            ParkingLot whichHaveMostPositions = null;
            int maxAvailablePositions = -1;

            foreach (var parkingLot in parkingLots)
            {
                if (parkingLot.HasAvailablePosition() && parkingLot.GetAvailablePositions() > maxAvailablePositions)
                {
                    whichHaveMostPositions = parkingLot;
                    maxAvailablePositions = parkingLot.GetAvailablePositions();
                }
            }

            if (whichHaveMostPositions == null)
            {
                throw new WrongException("No available position");
            }

            return whichHaveMostPositions.Park(car);
        }
    }
}
