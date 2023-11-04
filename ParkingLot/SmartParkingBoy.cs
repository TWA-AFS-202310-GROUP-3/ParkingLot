using ParkingLotProj.ErrorHandling;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ParkingLotProj
{
    public class SmartParkingBoy : IParkingBehavior
    {
        private readonly List<ParkingLot> parkingLots = new List<ParkingLot>();

        public SmartParkingBoy()
        {
        }

        public SmartParkingBoy(ParkingLot parkingLot)
        {
            this.parkingLots.Add(parkingLot);
        }

        public SmartParkingBoy(List<ParkingLot> parkingLots)
        {
            this.parkingLots = parkingLots;
        }

        public void AddManageParkingLot(ParkingLot parkingLot)
        {
            this.parkingLots.Add(parkingLot);
        }

        public string Fetch(string ticketId)
        {
            foreach (ParkingLot parkingLot in parkingLots)
            {
                if (parkingLot.IsContainTicket(ticketId))
                {
                    return parkingLot.Fetch(ticketId);
                }
            }

            throw new InvalidTicketException("Unrecognized parking ticket.");
        }

        public string Park(string carId)
        {
            ParkingLot parkingLot = SearchMostEmpty();
            return parkingLot.Park(carId);
        }

        public ParkingLot SearchMostEmpty()
        {
            return parkingLots.OrderBy(parkingLot => parkingLot.CurrentCapacity).ToList()[0];
        }
    }
}
