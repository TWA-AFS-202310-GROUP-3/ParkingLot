using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private ParkingLotPlace parkinglot;

        public ParkingBoy(ParkingLotPlace parkingLot)
        {
            this.parkinglot = parkingLot;
        }

        public string FetchCar(string ticket)
        {
            var car = parkinglot.FetchCar(ticket);
            return car;
        }

        public string ParkCar(string car)
        {
            var ticket = parkinglot.ParkCar(car);
            return ticket;
        }
    }
}
