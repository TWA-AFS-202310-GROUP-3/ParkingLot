using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class StandardParkingBoyPlus : ParkingBoyBase
    {
        private List<ParkingLotPlace> parkingLotPlaces;
        private int parkingLotToBeUsed;
        private Dictionary<string, int> ticketToParkingLotIndex;

        public StandardParkingBoyPlus(List<ParkingLotPlace> parkingLotPlaces)
        {
            this.parkingLotPlaces = parkingLotPlaces;
            ticketToParkingLotIndex = new Dictionary<string, int>();
            parkingLotToBeUsed = CreateTicketToParkingLotMap(parkingLotPlaces, ticketToParkingLotIndex);
        }

        public override string FetchCar(string ticket)
        {
            TicketCheckBeforeFetch(ticket);
            int parkingLotIndex = TellParkingLotIndexCarParked(ticket);
            ParkingLotSetterGetter = this.parkingLotPlaces[parkingLotIndex];
            if (parkingLotIndex < parkingLotToBeUsed)
            {
                parkingLotToBeUsed = parkingLotIndex;
            }

            return base.FetchCar(ticket);
        }

        public int TellParkingLotIndexCarParked(string ticket)
        {
            return ticketToParkingLotIndex[ticket];
        }

        public override string ParkCar(string car)
        {
            int availableParkingLotIndex = parkingLotToBeUsed;
            for (; availableParkingLotIndex < parkingLotPlaces.Count; availableParkingLotIndex++)
            {
                if (parkingLotPlaces[availableParkingLotIndex].IsParkingLotAvailable())
                {
                    ParkingLotSetterGetter = parkingLotPlaces[availableParkingLotIndex];
                    break;
                }
            }

            if (availableParkingLotIndex == parkingLotPlaces.Count)
            {
                throw new WrongException("No available position.");
            }

            parkingLotToBeUsed = availableParkingLotIndex;
            string ticket = base.ParkCar(car);
            ticketToParkingLotIndex[ticket] = availableParkingLotIndex;
            return ticket;
        }

        private int CreateTicketToParkingLotMap(List<ParkingLotPlace> parkingLotPlaces, Dictionary<string, int> ticketToParkingLotIndex)
        {
            int firstAvailableParkingLotIndex = parkingLotPlaces.Count - 1;
            for (int i = parkingLotPlaces.Count - 1; i >= 0; i--)
            {
                ParkingLotPlace parkingLot = parkingLotPlaces[i];
                if (parkingLot.IsParkingLotAvailable())
                {
                    firstAvailableParkingLotIndex = i;
                }

                foreach (var entry in parkingLot.TicketToCar)
                {
                    var ticket = entry.Key;
                    ticketToParkingLotIndex[ticket] = i;
                }
            }

            return firstAvailableParkingLotIndex;
        }

        private void TicketCheckBeforeFetch(string ticket)
        {
            if (!this.ticketToParkingLotIndex.ContainsKey(ticket))
            {
                throw new WrongException("Unrecognized parking ticket.");
            }
        }
    }
}
