using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotPractice
{
    public class StandardParkingBoy
    {
        private ParkingLot[] parkingLots;
        public StandardParkingBoy(params ParkingLot[] parkingLots)
        {
            this.parkingLots = parkingLots;
        }

        public string Park(string car)
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
