using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingBoys_ForStrategyDesign
    {
        private ParkingBoyBase parkingboy;
        public ParkingBoyBase ParkingBoy
        {
            get => parkingboy;
            set => parkingboy = value;
        }

        public ParkingBoys_ForStrategyDesign(ParkingBoyBase parkingBoy)
        {
            this.parkingboy = parkingBoy;
        }

        public string FetchCar(string ticket)
        {
            return this.parkingboy.FetchCar(ticket);
        }

        public string ParkCar(string car)
        {
            return this.parkingboy.ParkCar(car);
        }
    }
}
