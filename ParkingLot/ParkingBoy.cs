using ParkingLotProj.ErrorHandling;
using ParkingLotProj.ParkingStrategy;
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
            string car = parkingLots.Find(parkingLot => parkingLot.IsContainTicket(ticketId))?.Fetch(ticketId);
            return car ?? throw new InvalidTicketException("Unrecognized parking ticket.");
        }

        public string Park(string carId)
        {
            if (IsCarParked(carId))
            {
                return null;
            }

            return this.parkingStrategy.Park(carId, this.parkingLots);
        }

        public bool IsCarParked(string carId)
        {
            return parkingLots.FindIndex(parkingLot => parkingLot.IsContainCar(carId)) >= 0;
        }
    }
}
