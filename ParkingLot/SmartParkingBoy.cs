using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotPlace
{
    public class SmartParkingBoy
    {
        private List<ParkingLot> parkingLots;

        public SmartParkingBoy(List<ParkingLot> parkingLots)
        {
            this.parkingLots = parkingLots;
        }

        public string ParkCar(string car)
        {
            ParkingLot parkingLotWithMostEmptyPositions = parkingLots
                .OrderByDescending(s => s.GetAvailablePositions())
                .FirstOrDefault();

            if (parkingLotWithMostEmptyPositions == null || parkingLotWithMostEmptyPositions.GetAvailablePositions() == 0)
            {
                throw new InvalidOperationException("No available position.");
            }

            return parkingLotWithMostEmptyPositions.ParkCar(car);
        }

        public string FetchCar(string ticket)
        {
            foreach (var parkingLot in parkingLots)
            {
                try
                {
                    return parkingLot.FetchCar(ticket);
                }
                catch (ArgumentException)
                {
                }
            }

            throw new ArgumentException("Unrecognized parking ticket.");
        }
    }
}
