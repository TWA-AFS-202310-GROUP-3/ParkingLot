using ParkingLotProj;
using ParkingLotProj.ErrorHandling;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingLotTest
    {
        [Fact]
        public void Should_Get_Same_Car_When_Fetch_By_Ticket()
        {
            ParkingLot parkingLot = new ParkingLot();

            string ticket = parkingLot.Park("car");
            string car = parkingLot.Fetch(ticket);

            Assert.Equal("car", car);
        }

        [Fact]
        public void Should_Get_Correct_Car_When_Fetch_By_Corresponding_Ticket()
        {
            string car1 = "car1";
            string car2 = "car2";
            ParkingLot parkingLot = new ParkingLot();
            string ticket1 = parkingLot.Park(car1);
            string ticket2 = parkingLot.Park(car2);

            string actualCar1 = parkingLot.Fetch(ticket1);
            string actualCar2 = parkingLot.Fetch(ticket2);

            Assert.Equal(car1, actualCar1);
            Assert.Equal(car2, actualCar2);
        }

        [Fact]
        public void Should_Not_Return_Car_When_Fetch_With_Wrong_Ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            string ticket1 = parkingLot.Park("car1");

            InvalidTicketException exception = Assert.Throws<InvalidTicketException>(() => parkingLot.Fetch("wrongTicketId"));
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Fact]
        public void Should_Not_Return_Car_When_Fetch_With_Used_Ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            string ticket1 = parkingLot.Park("car1");

            string actualCar1 = parkingLot.Fetch(ticket1);

            InvalidTicketException exception = Assert.Throws<InvalidTicketException>(() => parkingLot.Fetch(ticket1));
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Fact]
        public void Should_Not_Allow_Parking_When_ParkingLot_Full()
        {
            ParkingLot parkingLot = new ParkingLot();
            for (int i = 0; i < 10; i++)
            {
                parkingLot.Park($"{i}");
            }

            OutOfCapacityException exception = Assert.Throws<OutOfCapacityException>(() => parkingLot.Park("car1"));
            Assert.Equal("No available position.", exception.Message);
        }

        [Fact]
        public void Should_Not_Allow_Parking_When_Park_a_Parked_Car()
        {
            ParkingLot parkingLot = new ParkingLot();

            string ticket1 = parkingLot.Park("car1");
            string actualResult = parkingLot.Park("car1");

            Assert.Null(actualResult);
        }

        [Fact]
        public void Should_Not_Allow_Parking_When_Park_With_Null_Car()
        {
            ParkingLot parkingLot = new ParkingLot();

            string actualResult = parkingLot.Park(null);

            Assert.Null(actualResult);
        }

        [Fact]
        public void Should_Not_Allow_Fetch_When_Fetch_With_Null_Ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            string ticket1 = parkingLot.Park("car1");

            string actualResult = parkingLot.Fetch(null);

            Assert.Null(actualResult);
        }
    }
}
