using System.Collections.Generic;

namespace ParkingLot
{
    public class ParkingLotPlace
    {
        private string car = "Benze";
        private int capacity = 10;

        private Dictionary<string, string> ticketToCar = new Dictionary<string, string>();

        public string FetchCar(string ticket)
        {
            if (!ticketToCar.ContainsKey(ticket))
            {
                return string.Empty;
            }

            var car = ticketToCar[ticket];
            ticketToCar.Remove(ticket);

            return car;
        }

        public string ParkCar(string car)
        {
            int car_number = ticketToCar.Count;
            var ticket = $"T_{car}";
            ticketToCar[ticket] = car;
            return ticket;
        }

        public int CarNumber()
        {
            return ticketToCar.Count;
        }
    }
}