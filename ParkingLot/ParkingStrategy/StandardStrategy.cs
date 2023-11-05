using ParkingLotProj.ErrorHandling;
using System.Collections.Generic;

namespace ParkingLotProj.ParkingStrategy
{
    public class StandardStrategy : IParkingStrategy
    {
        public string Park(string carId, List<ParkingLot> parkingLots)
        {
            foreach (ParkingLot parkingLot in parkingLots)
            {
                if (!parkingLot.IsFull())
                {
                    return parkingLot.Park(carId);
                }
            }

            throw new OutOfCapacityException("No available position.");
        }
    }
}
