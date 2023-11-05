using ParkingLotProj.ErrorHandling;
using System.Collections.Generic;

namespace ParkingLotProj.ParkingStrategy
{
    public class StandardStrategy : IParkingStrategy
    {
        public string Park(string carId, List<ParkingLot> parkingLots)
        {
            string ticket = parkingLots.Find(parkingLot => !parkingLot.IsFull())?.Park(carId);
            return ticket ?? throw new OutOfCapacityException("No available position.");
        }
    }
}
