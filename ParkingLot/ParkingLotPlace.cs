using System;
using System.Collections.Generic;

namespace ParkingLot
{
    public class ParkingLotPlace : IComparable<ParkingLotPlace>
    {
        private readonly int capacity = 6;
        private string car = "Benze";

        private Dictionary<string, string> ticketToCar = new Dictionary<string, string>();

        public Dictionary<string, string> TicketToCar
        {
            get { return ticketToCar; }
            set { ticketToCar = value; }
        }

        public string FetchCar(string ticket)
        {
            CheckTicket(ticket);

            var car = ticketToCar[ticket];
            ticketToCar.Remove(ticket);

            return car;
        }

        public void CheckTicket(string ticket)
        {
            if (!ticketToCar.ContainsKey(ticket))
            {
                throw new WrongException("Unrecognized parking ticket.");
            }
        }

        public string ParkCar(string car)
        {
            CheckParkingSpot(car);

            var ticket = $"T_{car}";
            ticketToCar[ticket] = car;
            return ticket;
        }

        public void CheckParkingSpot(string car)
        {
            if (!IsParkingLotAvailable())
            {
                throw new WrongException("No available position.");
            }
        }

        public int CarNumber()
        {
            return ticketToCar.Count;
        }

        public bool IsParkingLotAvailable()
        {
            return CarNumber() < this.capacity;
        }

        public int FreeParkingSpots()
        {
            return this.capacity - CarNumber();
        }

        public int CompareTo(ParkingLotPlace other)
        {
            if (FreeParkingSpots() > other.FreeParkingSpots())
            {
                return -1;
            }
            else if (FreeParkingSpots() < other.FreeParkingSpots())
            {
                return 1;
            }

            return 0;
        }
    }
}