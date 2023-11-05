namespace ParkingLot
{
    public class ParkingBoyBase
    {
        private ParkingLotPlace parkinglot;

        public ParkingLotPlace ParkingLotSetterGetter
        {
            get => parkinglot;
            set => parkinglot = value;
        }

        public virtual string FetchCar(string ticket)
        {
            var car = parkinglot.FetchCar(ticket);
            return car;
        }

        public virtual string ParkCar(string car)
        {
            var ticket = parkinglot.ParkCar(car);
            return ticket;
        }
    }
}