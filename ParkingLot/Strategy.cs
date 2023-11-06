using System.Linq;

namespace ParkingLotPractice
{
    public interface Strategy
    {
        public ParkingLot ChooseParkingLot(ParkingLot[] parkingLots);
    }

    public class SmartStrategy : Strategy
    {
        public ParkingLot ChooseParkingLot(ParkingLot[] parkingLots)
        {
            return parkingLots.MaxBy(p => p.GetAvailablePositionAmount());
        }
    }

    public class StandardStragegy : Strategy
    {
        public ParkingLot ChooseParkingLot(ParkingLot[] parkingLots)
        {
            foreach (var parkingLot in parkingLots.Where(parkingLot => parkingLot.GetAvailablePositionAmount() > 0))
            {
                return parkingLot;
            }

            return parkingLots[0];
        }
    }
}