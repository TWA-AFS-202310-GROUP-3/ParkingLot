namespace ParkingLotPractice
{
    public interface Strategy
    {
        public string Park(string car);
        public string Fetch(string ticket);
    }
}