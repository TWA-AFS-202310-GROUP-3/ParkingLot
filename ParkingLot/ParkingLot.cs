using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotns
{
    public class ParkingLot
    {
        private int capacity = 10;
        private Dictionary<string, string> ticket2Car = new Dictionary<string, string>();
        private List<string> usedTickets = new List<string>();

        public string Fetch(string ticket)
        {
            if (ticket2Car.ContainsKey(ticket))
            {
                string foundCar = ticket2Car[ticket];
                usedTickets.Add(ticket);
                ticket2Car.Remove(ticket);
                return foundCar;
            }
            else if (usedTickets.Contains(ticket))
            {
                throw new WrongException("Unrecognized parking ticket");
                //return "sorry, this ticket used!";
            }
            else
            {
                throw new WrongException("Unrecognized parking ticket");
                //return "sorry, this ticket not found!";
            }
        }

        public string Park(string car)
        {
            string ticket = "T-" + car;
            if (ticket2Car.Count < capacity)
            {
                ticket2Car.Add(ticket, car);
                return ticket;
            }
            else
            {
                return "No available position";
            }
        }

        public bool HasAvailablePosition()
        {
            return ticket2Car.Count < capacity;
        }
    }
}
