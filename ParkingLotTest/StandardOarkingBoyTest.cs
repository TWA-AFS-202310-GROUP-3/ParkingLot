using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLotns;
using Xunit;

namespace ParkingLotTest
{
    public class StandardOarkingBoyTest
    {
        [Fact]
        public void Should_parking_boy_get_same_car_when_fetch_ticket()
        {
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy();
            string ticket1 = standardParkingBoy.ParkCar("car1");

            string car = standardParkingBoy.FetchCar(ticket1);

            Assert.Equal("car1", car);
        }

        [Fact]
        public void Should_parking_boy_get_correct_car_when_fetch_correct_ticket()
        {
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy();
            string ticket1 = standardParkingBoy.ParkCar("car1");
            string ticket2 = standardParkingBoy.ParkCar("car2");

            string car = standardParkingBoy.FetchCar(ticket1);

            Assert.Equal("car1", car);
            Assert.NotEqual("car2", car);
        }

        [Fact]
        public void Should_parking_boy_get_incorrect_car_when_fetch_not_found_ticket()
        {
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy();
            string ticket1 = standardParkingBoy.ParkCar("car1");
            string ticket2 = "car2";

            //string car = parkingLot.Fetch(ticket2);

            WrongException wrongException = Assert.Throws<WrongException>(() => standardParkingBoy.FetchCar(ticket2));

            //Assert.Equal("sorry, this ticket not found!", car);
            Assert.Equal("Unrecognized parking ticket", wrongException.Message);
        }

        [Fact]
        public void Should_parking_boy_get_no_car_when_fetch_used_ticket()
        {
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy();
            string ticket1 = standardParkingBoy.ParkCar("car1");
            standardParkingBoy.FetchCar(ticket1);

            //string car = parkingLot.Fetch(ticket1);
            WrongException wrongException = Assert.Throws<WrongException>(() => standardParkingBoy.FetchCar(ticket1));

            Assert.Equal("Unrecognized parking ticket", wrongException.Message);
        }

        [Fact]
        public void Should_parking_boy_get_all_car_when_parking_lot_is_full()
        {
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy();
            string ticket1 = standardParkingBoy.ParkCar("car1");
            string ticket2 = standardParkingBoy.ParkCar("car2");
            string ticket3 = standardParkingBoy.ParkCar("car3");
            string ticket4 = standardParkingBoy.ParkCar("car4");
            string ticket5 = standardParkingBoy.ParkCar("car5");
            string ticket6 = standardParkingBoy.ParkCar("car6");
            string ticket7 = standardParkingBoy.ParkCar("car7");
            string ticket8 = standardParkingBoy.ParkCar("car8");
            string ticket9 = standardParkingBoy.ParkCar("car9");
            string ticket10 = standardParkingBoy.ParkCar("car10");

            string ticket11 = standardParkingBoy.ParkCar("car11");

            Assert.Equal("No available position", ticket11);
        }
    }
}
