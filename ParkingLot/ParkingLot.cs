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
        private string car;
        private Dictionary<string, string> ticket_Car = new Dictionary<string, string>();
        public string ParkCar(string car)
        {
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

            string car = ticket_Car[ticket];
            return car;
        }
    }
}