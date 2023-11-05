using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSystem
{
    public class ParkingLot
    {
        private int parkingLotCapacity = 10;
        private Dictionary<string, string> ticketToCar = new Dictionary<string, string>();
        private int parkedCarsNumber = 0;

        public string ParkACar(string carNumber)
        {
            if (ticketToCar.Count >= parkingLotCapacity)
            {
                throw new FullParkingSlotException("No available position.");
            }

            string ticketNumber = $"T-{carNumber}";
            ticketToCar.Add(ticketNumber, carNumber);
            parkedCarsNumber++;

            return ticketNumber;
        }

        public string FetchACar(string ticketNumber)
        {
            if (ticketNumber == string.Empty)
            {
                throw new EmptyTicketException("Parking ticket is empty.");
            }

            if (!ticketToCar.ContainsKey(ticketNumber))
            {
                throw new NotFoundTicketException("Unrecognized parking ticket.");
            }

            string fetchedCarNumber = ticketToCar[ticketNumber];
            ticketToCar.Remove(ticketNumber);
            return fetchedCarNumber;
        }

        public int GetAvailablePositions()
        {
            return parkingLotCapacity - parkedCarsNumber;
        }
    }
}
