using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotPractice
{
    public class StrategicParkingBoy
    {
        private Strategy strategy;
        private ParkingLot[] parkingLots;
        public StrategicParkingBoy(Strategy strategy, params ParkingLot[] parkingLots)
        {
            this.strategy = strategy;
            this.parkingLots = parkingLots;
        }

        public string Park(string car)
        {
            return strategy.Park(car, parkingLots);
        }

        public string Fetch(string ticket)
        {
            foreach (var parkingLot in parkingLots)
            {
                try
                {
                    return parkingLot.Fetch(ticket);
                }
                catch { }
            }

            throw new WrongTicketException("Unrecognized parking ticket. ");
        }
    }
}