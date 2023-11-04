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
        private int parkedCarsCount;

        public ParkingLot(int capacity = 10)
        {
            this.capacity = capacity;
            this.parkedCarsCount = 0;
        }

        public string ParkCar(string car)
        {
            if (ticket_Car.Count >= capacity)
            {
                throw new InvalidOperationException("No available position.");
            }

            var ticket = $"T{car}";
            ticket_Car[ticket] = car;
            parkedCarsCount++;
            return ticket;
        }

        public string FetchCar(string ticket)
        {
            if (!ticket_Car.ContainsKey(ticket))
            {
                throw new ArgumentException("Unrecognized parking ticket.");
            }

            if (usedTickets.Contains(ticket))
            {
                throw new ArgumentException("Unrecognized parking ticket.");
            }

            string car = ticket_Car[ticket];
            usedTickets.Add(ticket);
            return car;
        }

        public int GetAvailablePositions()
        {
            return capacity - parkedCarsCount;
        }
    }
}