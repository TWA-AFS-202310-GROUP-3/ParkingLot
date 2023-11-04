using ParkingLotProj.ErrorHandling;
using System;
using System.Collections.Generic;

namespace ParkingLotProj
{
    public class ParkingLot : IParkingBehavior
    {
        private int capacity = 10;
        private int currentCarParked = 0;
        private Dictionary<string, string> parkingTicket = new Dictionary<string, string>();

        public string Fetch(string ticket)
        {
            if (ticket == null)
            {
                return null;
            }

            if (!parkingTicket.ContainsKey(ticket))
            {
                throw new InvalidTicketException("Unrecognized parking ticket.");
            }

            string car = parkingTicket[ticket];
            parkingTicket.Remove(ticket);
            return car;
        }

        public string Park(string car)
        {
            if (car == null || parkingTicket.ContainsValue(car))
            {
                return null;
            }

            if (currentCarParked >= capacity)
            {
                throw new OutOfCapacityException("No available position.");
            }

            currentCarParked++;
            string ticketId = Guid.NewGuid().ToString();
            parkingTicket.Add(ticketId, car);
            return ticketId;
        }
    }
}
