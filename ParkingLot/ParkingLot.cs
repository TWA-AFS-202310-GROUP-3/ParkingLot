using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotPlace
{
    public class ParkingLot
    {
        private Dictionary<string, string> ticket_Car = new Dictionary<string, string>();
        private HashSet<string> usedTickets = new HashSet<string>();
        private int capacity;

        public ParkingLot(int capacity = 10)
        {
            this.capacity = capacity;
        }

        public string ParkCar(string car)
        {
            if (ticket_Car.Count >= capacity)
            {
                throw new InvalidOperationException("No available parking space.");
            }

            var ticket = $"T{car}";
            ticket_Car[ticket] = car;
            return ticket;
        }

        public string FetchCar(string ticket)
        {
            if (!ticket_Car.ContainsKey(ticket))
            {
                throw new ArgumentException("Invalid ticket number.");
            }

            if (usedTickets.Contains(ticket))
            {
                throw new InvalidOperationException("Ticket has already been used.");
            }

            string car = ticket_Car[ticket];
            usedTickets.Add(ticket);
            return car;
        }
    }
}