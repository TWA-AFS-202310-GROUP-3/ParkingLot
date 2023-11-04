using ParkingLotProj.ErrorHandling;
using System;
using System.Collections.Generic;

namespace ParkingLotProj
{
    public class ParkingLot : IParkingBehavior
    {
        private int capacity = 10;
        private int currentCapacity = 0;
        private Dictionary<string, string> parkingTicket = new Dictionary<string, string>();

        public ParkingLot()
        {
        }

        public ParkingLot(int capacity)
        {
            this.capacity = capacity;
        }

        public int CurrentCapacity { get => currentCapacity; }

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
            currentCapacity--;
            return car;
        }

        public string Park(string car)
        {
            if (car == null || parkingTicket.ContainsValue(car))
            {
                return null;
            }

            if (currentCapacity >= capacity)
            {
                throw new OutOfCapacityException("No available position.");
            }

            currentCapacity++;
            string ticketId = Guid.NewGuid().ToString();
            parkingTicket.Add(ticketId, car);
            return ticketId;
        }

        public bool IsContainTicket(string ticketId)
        {
            return parkingTicket.ContainsKey(ticketId);
        }

        public bool IsFull()
        {
            return currentCapacity >= capacity;
        }
    }
}
