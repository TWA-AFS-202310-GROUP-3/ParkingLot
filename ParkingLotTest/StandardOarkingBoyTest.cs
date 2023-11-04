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
            ParkingLot parkingLot = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(new List<ParkingLot> { parkingLot });
            string ticket1 = standardParkingBoy.ParkCar("car1");

            string car = standardParkingBoy.FetchCar(ticket1);

            Assert.Equal("car1", car);
        }

        [Fact]
        public void Should_parking_boy_get_correct_car_when_fetch_correct_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(new List<ParkingLot> { parkingLot });
            string ticket1 = standardParkingBoy.ParkCar("car1");
            string ticket2 = standardParkingBoy.ParkCar("car2");

            string car = standardParkingBoy.FetchCar(ticket1);

            Assert.Equal("car1", car);
            Assert.NotEqual("car2", car);
        }

        [Fact]
        public void Should_parking_boy_get_incorrect_car_when_fetch_not_found_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(new List<ParkingLot> { parkingLot });
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
            ParkingLot parkingLot = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(new List<ParkingLot> { parkingLot });
            string ticket1 = standardParkingBoy.ParkCar("car1");
            standardParkingBoy.FetchCar(ticket1);

            //string car = parkingLot.Fetch(ticket1);
            WrongException wrongException = Assert.Throws<WrongException>(() => standardParkingBoy.FetchCar(ticket1));

            Assert.Equal("Unrecognized parking ticket", wrongException.Message);
        }

        [Fact]
        public void Should_parking_boy_get_all_car_when_parking_lot_is_full()
        {
            ParkingLot parkingLot = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(new List<ParkingLot> { parkingLot });
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

        [Fact]
        public void Should_park_first_parking_lot_when_two_parking_lots_both_have_position()
        {
            ParkingLot parkingLot1 = new ParkingLot();
            ParkingLot parkingLot2 = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(new List<ParkingLot> { parkingLot1, parkingLot2 });

            string ticket1 = standardParkingBoy.ParkCar("car1");

            Assert.Equal("car1", parkingLot1.Fetch(ticket1));
        }

        [Fact]
        public void Should_park_second_parking_lot_when_first_parking_lot_is_full()
        {
            ParkingLot parkingLot1 = new ParkingLot();
            ParkingLot parkingLot2 = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(new List<ParkingLot> { parkingLot1, parkingLot2 });
            string ticket1 = parkingLot1.Park("car1");
            string ticket2 = parkingLot1.Park("car2");
            string ticket3 = parkingLot1.Park("car3");
            string ticket4 = parkingLot1.Park("car4");
            string ticket5 = parkingLot1.Park("car5");
            string ticket6 = parkingLot1.Park("car6");
            string ticket7 = parkingLot1.Park("car7");
            string ticket8 = parkingLot1.Park("car8");
            string ticket9 = parkingLot1.Park("car9");
            string ticket10 = parkingLot1.Park("car10");

            string ticket = standardParkingBoy.ParkCar("car11");

            Assert.Equal("car11", parkingLot2.Fetch(ticket));
        }

        [Fact]
        public void Should_get_no_car_when_fetch_used_ticket()
        {
            ParkingLot parkingLot1 = new ParkingLot();
            ParkingLot parkingLot2 = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(new List<ParkingLot> { parkingLot1, parkingLot2 });
            string ticket = standardParkingBoy.ParkCar("car");
            standardParkingBoy.FetchCar(ticket);

            WrongException wrongException = Assert.Throws<WrongException>(() => standardParkingBoy.FetchCar(ticket));

            Assert.Equal("Unrecognized parking ticket", wrongException.Message);
        }

        [Fact]

        public void Should_get_incorrect_car_when_fetch_not_found_ticket()
        {
            ParkingLot parkingLot1 = new ParkingLot();
            ParkingLot parkingLot2 = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(new List<ParkingLot> { parkingLot1, parkingLot2 });
            string ticket1 = standardParkingBoy.ParkCar("car1");
            string ticket2 = "car2";
            WrongException wrongException = Assert.Throws<WrongException>(() => standardParkingBoy.FetchCar(ticket2));

            //Assert.Equal("sorry, this ticket not found!", car);
            Assert.Equal("Unrecognized parking ticket", wrongException.Message);
        }

        [Fact]
        public void Should_return_no_position_when_two_parking_lots_are_full()
        {
            ParkingLot parkingLot1 = new ParkingLot();
            ParkingLot parkingLot2 = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(new List<ParkingLot> { parkingLot1, parkingLot2 });
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
            string ticket12 = standardParkingBoy.ParkCar("car12");
            string ticket13 = standardParkingBoy.ParkCar("car13");
            string ticket14 = standardParkingBoy.ParkCar("car14");
            string ticket15 = standardParkingBoy.ParkCar("car15");
            string ticket16 = standardParkingBoy.ParkCar("car16");
            string ticket17 = standardParkingBoy.ParkCar("car17");
            string ticket18 = standardParkingBoy.ParkCar("car18");
            string ticket19 = standardParkingBoy.ParkCar("car19");
            string ticket20 = standardParkingBoy.ParkCar("car20");

            string ticket21 = standardParkingBoy.ParkCar("car21");

            Assert.Equal("No available position", ticket21);
        }
    }
}
