using ParkingLotProj.ErrorHandling;
using System;
using System.Collections.Generic;

namespace ParkingLotProj
{
    public class ParkingBoy : IParkingBehavior
    {
        private readonly List<ParkingLot> parkingLots = new List<ParkingLot>();

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

            Console.WriteLine("error");
            throw new InvalidTicketException("Unrecognized parking ticket.");
        }

        public string Park(string carId)
        {
            foreach (ParkingLot parkingLot in parkingLots)
            {
                if (!parkingLot.IsFull())
                {
                    return parkingLot.Park(carId);
                }
            }

            Console.WriteLine("error");
            throw new OutOfCapacityException("No available position.");
        }
    }
}
