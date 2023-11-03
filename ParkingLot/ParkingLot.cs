using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotPractice
{
    public class ParkingLot
    {
        private string car;
        private int maxcapacity = 10;
        private Dictionary<string, string> ticket2Car = new Dictionary<string, string>();
        public string Fetch(string ticket)
        {
            if (!ticket2Car.ContainsKey(ticket))
            {
                return null;
            }
            else
            {
                string fetchedCar = ticket2Car[ticket];
                ticket2Car.Remove(ticket);
                return fetchedCar;
            }
        }

        public string Fetch()
        {
            return null;
        }

        public string Park(string car)
        {
            if (ticket2Car.Count == maxcapacity)
            {
                return null;
            }

            string ticket = "T-" + car;
            ticket2Car.Add(ticket, car);
            return ticket;
        }
    }
}
