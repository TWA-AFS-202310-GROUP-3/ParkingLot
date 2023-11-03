using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLotns;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingLotTest
    {
        [Fact]
        public void Should_get_same_car_when_fetch_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            string ticket1 = parkingLot.Park("car1");

            string car = parkingLot.Fetch(ticket1);

            Assert.Equal("car1", car);
        }

        [Fact]
        public void Should_get_correct_car_when_fetch_correct_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            string ticket1 = parkingLot.Park("car1");
            string ticket2 = parkingLot.Park("car2");

            string car = parkingLot.Fetch(ticket1);

            Assert.Equal("car1", car);
            Assert.NotEqual("car2", car);
        }

        [Fact]
        public void Should_get_incorrect_car_when_fetch_not_found_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            string ticket1 = parkingLot.Park("car1");
            string ticket2 = "car2";

            //string car = parkingLot.Fetch(ticket2);

            WrongException wrongException = Assert.Throws<WrongException>(() => parkingLot.Fetch(ticket2));

            //Assert.Equal("sorry, this ticket not found!", car);
            Assert.Equal("Unrecognized parking ticket", wrongException.Message);
        }

        [Fact]
        public void Should_get_no_car_when_fetch_used_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            string ticket1 = parkingLot.Park("car1");
            parkingLot.Fetch(ticket1);

            string car = parkingLot.Fetch(ticket1);

            Assert.Equal("sorry, this ticket used!", car);
        }

        [Fact]
        public void Should_get_all_car_when_parking_lot_is_full()
        {
            ParkingLot parkingLot = new ParkingLot();
            string ticket1 = parkingLot.Park("car1");
            string ticket2 = parkingLot.Park("car2");
            string ticket3 = parkingLot.Park("car3");
            string ticket4 = parkingLot.Park("car4");
            string ticket5 = parkingLot.Park("car5");
            string ticket6 = parkingLot.Park("car6");
            string ticket7 = parkingLot.Park("car7");
            string ticket8 = parkingLot.Park("car8");
            string ticket9 = parkingLot.Park("car9");
            string ticket10 = parkingLot.Park("car10");

            string ticket11 = parkingLot.Park("car11");

            Assert.Equal("The parking lot is full", ticket11);
        }
    }
}
