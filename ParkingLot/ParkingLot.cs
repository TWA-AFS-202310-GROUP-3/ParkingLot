namespace ParkingLotProj
{
    using System;
    using System.Collections.Generic;

    public class ParkingLot
    {
        private string car;
        private Dictionary<string, string> parkingTicket = new Dictionary<string, string>();
        public string Fetch(string ticket)
        {
            if (!parkingTicket.ContainsKey(ticket))
            {
                return null;
            }

            string car = parkingTicket[ticket];
            parkingTicket.Remove(ticket);
            return car;
        }

        public string Park(string car)
        {
            string ticketId = Guid.NewGuid().ToString();
            parkingTicket.Add(ticketId, car);
            return ticketId;
        }
    }
}
