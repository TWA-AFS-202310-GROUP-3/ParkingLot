using System.Linq;

namespace ParkingLotPractice
{
    public interface Strategy
    {
        public string Park(string car, ParkingLot[] parkingLots);
    }

    public class SmartStrategy : Strategy
    {
        public string Park(string car, ParkingLot[] parkingLots)
        {
            return parkingLots.MaxBy(p => p.GetAvailablePositionAmount()).Park(car);
        }
    }

    public class StandardStragegy : Strategy
    {
        public string Park(string car, ParkingLot[] parkingLots)
        {
            foreach (var parkingLot in parkingLots)
            {
                try
                {
                    return parkingLot.Park(car);
                }
                catch { }
            }

            throw new NoPositionException("No available position. ");
        }
    }
}