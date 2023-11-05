using ParkingLotProj.ErrorHandling;
using ParkingLotProj.ParkingStrategy;
using System;
using System.Collections.Generic;

namespace ParkingLotProj
{
    public class ParkingBoy : IParkingBehavior
    {
        private readonly List<ParkingLot> parkingLots = new List<ParkingLot>();
        private IParkingStrategy parkingStrategy = new StandardStrategy();

        public ParkingBoy()
        {
        }

        public ParkingBoy(ParkingLot parkingLot)
        {
            this.parkingLots.Add(parkingLot);
        }

        public ParkingBoy(List<ParkingLot> parkingLots)
        {
            this.parkingLots = parkingLots;
        }

        public void SetParkingStrategy(IParkingStrategy parkingStrategy)
        {
            this.parkingStrategy = parkingStrategy;
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
            return this.parkingStrategy.Park(carId, this.parkingLots);
        }
    }
}
