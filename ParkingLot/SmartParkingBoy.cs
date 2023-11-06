using ParkingLotSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSystem
{
    public class SmartParkingBoy
    {
        private List<ParkingLot> parkingLots;
        public SmartParkingBoy(List<ParkingLot> parkingLots)
        {
            this.parkingLots = parkingLots;
        }

        public string ParkACar(string carNumber)
        {
            ParkingLot parkingLotWithMoreEmptyPositions = parkingLots.OrderByDescending(parkinglot => parkinglot.GetAvailablePositions()).FirstOrDefault();

            if (parkingLotWithMoreEmptyPositions == null || parkingLotWithMoreEmptyPositions.GetAvailablePositions() == 0)
            {
                throw new FullParkingSlotException("No available position.");
            }

            return parkingLotWithMoreEmptyPositions.ParkACar(carNumber);
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
