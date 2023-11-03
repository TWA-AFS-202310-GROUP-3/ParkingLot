namespace ParkingLotProj
{
    using System;
    using System.Collections.Generic;

    public class ParkingLot
    {
        private int capacity = 10;
        private int currentCarParked = 0;
        private Dictionary<string, string> parkingTicket = new Dictionary<string, string>();
        private object retun;

        public string Fetch(string ticket)
        {
            if (ticket == null || !parkingTicket.ContainsKey(ticket))
            {
                return null;
            }

            string car = parkingTicket[ticket];
            parkingTicket.Remove(ticket);
            return car;
        }

        public string Park(string car)
        {
            if (car == null || currentCarParked >= capacity || parkingTicket.ContainsValue(car))
            {
                return null;
            }

            currentCarParked++;
            string ticketId = Guid.NewGuid().ToString();
            parkingTicket.Add(ticketId, car);
            return ticketId;
        }
    }
}
