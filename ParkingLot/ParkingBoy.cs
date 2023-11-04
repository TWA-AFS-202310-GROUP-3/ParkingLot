using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotPractice
{
    public class ParkingBoy
    {
        private Strategy strategy;
        private ParkingLot[] parkingLots;
        public ParkingBoy(Strategy strategy, params ParkingLot[] parkingLots)
        {
            this.strategy = strategy;
            this.parkingLots = parkingLots;
        }

        public string Park(string car)
        {
            return strategy.Park(car);
        }

        public string Fetch(string car)
        {
            return strategy.Fetch(car);
        }
    }
}