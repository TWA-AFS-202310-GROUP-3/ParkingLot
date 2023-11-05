using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSystem
{
    public class StandardParkingBoy
    {
        private List<ParkingLot> parkingLots;
        private int parkingLotNumber;
        public StandardParkingBoy(List<ParkingLot> parkingLots)
        {
            this.parkingLots = parkingLots;
            this.parkingLotNumber = 0;
        }

        public string ParkACar(string carNumber)
        {
            while (parkingLotNumber < parkingLots.Count)
            {
                var parkingLot = parkingLots[parkingLotNumber];
                try
                {
                    return parkingLot.ParkACar(carNumber);
                }
                catch (FullParkingSlotException)
                {
                    parkingLotNumber++;
                }
            }

            throw new FullParkingSlotException("No available position.");
        }

        public string FetchACar(string ticketNumber)
        {
            foreach (var parkingLot in parkingLots)
            {
                try
                {
                    return parkingLot.FetchACar(ticketNumber);
                }
                catch (NotFoundTicketException)
                {
                }
            }

            throw new NotFoundTicketException("Unrecognized parking ticket.");
        }
    }
}
