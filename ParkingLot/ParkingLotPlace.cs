using System.Collections.Generic;

namespace ParkingLot
{
    public class ParkingLotPlace
    {
        private readonly int capacity = 6;
        private string car = "Benze";

        private Dictionary<string, string> ticketToCar = new Dictionary<string, string>();

        public Dictionary<string, string> TicketToCar
        {
            get { return ticketToCar; }
            set { ticketToCar = value; }
        }

        public string FetchCar(string ticket)
        {
            if (!ticketToCar.ContainsKey(ticket))
            {
                throw new WrongException("Unrecognized parking ticket.");
            }

            var car = ticketToCar[ticket];
            ticketToCar.Remove(ticket);

            return car;
        }

        public string ParkCar(string car)
        {
            if (!IsParkingLotAvailable())
            {
                throw new WrongException("No available position.");
            }

            var ticket = $"T_{car}";
            ticketToCar[ticket] = car;
            return ticket;
        }

        public int CarNumber()
        {
            return ticketToCar.Count;
        }

        public bool IsParkingLotAvailable()
        {
            return CarNumber() < this.capacity;
        }
    }
}