using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotPlace
{
    public class StandardParkingBoy //parking boy act as a proxy here
    {
        private List<ParkingLot> parkingLots;
        private int currentParkingLot;

        public StandardParkingBoy(List<ParkingLot> parkingLots)
        {
            this.parkingLots = parkingLots;
            this.currentParkingLot = 0;
        }

        public string ParkCar(string car)
        {
            while (currentParkingLot < parkingLots.Count)
            {
                var parkingLot = parkingLots[currentParkingLot];
                try
                {
                    return parkingLot.ParkCar(car);
                }
                catch (InvalidOperationException)
                {
                    currentParkingLot++;
                }
            }

            throw new InvalidOperationException("No available position.");
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
