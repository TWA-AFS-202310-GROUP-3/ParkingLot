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

        public string ParkACar(string carNumber)
        {
            if (ticketToCar.Count >= parkingLotCapacity)
            {
                throw new FullParkingSlotException("the parkinglot is full!");
            }

            string ticketNumber = $"T-{carNumber}";
            ticketToCar.Add(ticketNumber, carNumber);

            return ticketNumber;
        }

        public string FetchACar(string ticketNumber)
        {
            if (ticketNumber == string.Empty)
            {
                throw new EmptyTicketException("ticket is empty!");
            }

            if (!ticketToCar.ContainsKey(ticketNumber))
            {
                throw new NotFoundTicketException("ticket number not found!");
            }

            string fetchedCarNumber = ticketToCar[ticketNumber];
            ticketToCar.Remove(ticketNumber);
            return fetchedCarNumber;
        }
    }
}
