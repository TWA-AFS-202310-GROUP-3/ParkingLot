using System.Collections.Generic;

namespace ParkingLotProj.ParkingStrategy
{
    public interface IParkingStrategy
    {
        public string Park(string carId, List<ParkingLot> parkingLots);
    }
}
