using System.Collections.Generic;
using System.Linq;

namespace ParkingLotProj.ParkingStrategy
{
    public class SmartStrategy : IParkingStrategy
    {
        public string Park(string carId, List<ParkingLot> parkingLots)
        {
            ParkingLot parkingLot = SearchMostEmpty(parkingLots);
            return parkingLot.Park(carId);
        }

        public ParkingLot SearchMostEmpty(List<ParkingLot> parkingLots)
        {
            return parkingLots.OrderBy(parkingLot => parkingLot.CurrentCapacity).ToList()[0];
        }
    }
}
