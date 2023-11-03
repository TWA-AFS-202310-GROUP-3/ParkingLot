using System.Collections.Generic;

namespace ParkingLot
{
    public class ParkingLotManager
    {
        private string car = "Benze";
        private Dictionary<string, string> ticketToCar = new Dictionary<string, string>();

        public string FetchCar(string ticket)
        {
            var car = ticketToCar[ticket];
            return car;
        }

        public string ParkCar(string car)
        {
            var ticket = $"T_{car}";
            ticketToCar[ticket] = car;
            return ticket;
        }
    }
}