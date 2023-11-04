using ParkingLotPlace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class StandardParkingBoyTest
    {
        [Fact]
        public void Should_in_first_parkinglot_when_ParkCar_Given_two_avaliable_parkinglots()
        {
            ParkingLot parkinglot1 = new ParkingLot();
            ParkingLot parkinglot2 = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(new List<ParkingLot> { parkinglot1, parkinglot2 });

            string ticket = standardParkingBoy.ParkCar("volvo");

            Assert.Equal("volvo", parkinglot1.FetchCar(ticket));
        }

        [Fact]
        public void Should_in_second_parkinglot_when_ParkCar_Given_first_parkinglot_full()
        {
            ParkingLot parkinglot1 = new ParkingLot(1);
            ParkingLot parkinglot2 = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(new List<ParkingLot> { parkinglot1, parkinglot2 });

            standardParkingBoy.ParkCar("volvo");
            string ticket2 = standardParkingBoy.ParkCar("Benz");

            Assert.Equal("Benz", parkinglot2.FetchCar(ticket2));
        }

        [Fact]
        public void Should_return_ticket_when_ParkCar_Given_car()
        {
            ParkingLot parkinglot = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(new List<ParkingLot> { parkinglot });

            string ticket = standardParkingBoy.ParkCar("volvo");

            Assert.Equal("Tvolvo", ticket);
        }

        [Fact]
        public void Should_return_car_when_FetchCar_Given_ticket()
        {
            ParkingLot parkinglot = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(new List<ParkingLot> { parkinglot });
            string ticket = standardParkingBoy.ParkCar("volvo");

            string fetchedcar = standardParkingBoy.FetchCar(ticket);

            Assert.Equal("volvo", fetchedcar);
        }

        [Fact]
        public void Should_return_right_car_when_FetchCar_twice_Given_two_ticket()
        {
            ParkingLot parkinglot = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(new List<ParkingLot> { parkinglot });
            string ticket1 = standardParkingBoy.ParkCar("volvo");
            string ticket2 = standardParkingBoy.ParkCar("Benz");

            string fetchedcar1 = standardParkingBoy.FetchCar(ticket1);
            string fetchedcar2 = standardParkingBoy.FetchCar(ticket2);

            Assert.Equal("volvo", fetchedcar1);
            Assert.Equal("Benz", fetchedcar2);
        }

        [Fact]
        public void Should_return_right_car_when_FetchCar_twice_Given_two_ticket_and_two_parkinglots()
        {
            ParkingLot parkinglot1 = new ParkingLot(1);
            ParkingLot parkinglot2 = new ParkingLot(1);
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(new List<ParkingLot> { parkinglot1, parkinglot2 });
            string ticket1 = standardParkingBoy.ParkCar("volvo");
            string ticket2 = standardParkingBoy.ParkCar("Benz");

            string fetchedCar1 = standardParkingBoy.FetchCar(ticket1);
            string fetchedCar2 = standardParkingBoy.FetchCar(ticket2);

            Assert.Equal("volvo", fetchedCar1);
            Assert.Equal("Benz", fetchedCar2);
        }

        [Fact]
        public void Should_throw_exception_when_FetchCar_Given_wrong_ticket()
        {
            ParkingLot parkinglot1 = new ParkingLot();
            ParkingLot parkinglot2 = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(new List<ParkingLot> { parkinglot1, parkinglot2 });

            string ticket = "12342";

            var exception = Assert.Throws<ArgumentException>(() => standardParkingBoy.FetchCar(ticket));
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Fact]
        public void Should_throw_exception_when_FetchCar_Given_no_ticket()
        {
            ParkingLot parkinglot1 = new ParkingLot();
            ParkingLot parkinglot2 = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(new List<ParkingLot> { parkinglot1, parkinglot2 });

            string ticket = string.Empty;

            var exception = Assert.Throws<ArgumentException>(() => standardParkingBoy.FetchCar(ticket));
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Fact]
        public void Should_throw_exception_when_FetchCar_Given_used_ticket()
        {
            ParkingLot parkinglot1 = new ParkingLot();
            ParkingLot parkinglot2 = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(new List<ParkingLot> { parkinglot1, parkinglot2 });

            string ticket = standardParkingBoy.ParkCar("Benz");
            standardParkingBoy.FetchCar(ticket);

            var exception = Assert.Throws<ArgumentException>(() => standardParkingBoy.FetchCar(ticket));
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Fact]
        public void Should_throw_exception_when_FetchCar_Given_full_capacity()
        {
            ParkingLot parkinglot1 = new ParkingLot(1);
            ParkingLot parkinglot2 = new ParkingLot(1);
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(new List<ParkingLot> { parkinglot1, parkinglot2 });
            standardParkingBoy.ParkCar("Benz");
            standardParkingBoy.ParkCar("volvo");

            var exception = Assert.Throws<InvalidOperationException>(() => standardParkingBoy.ParkCar("BMW"));
            Assert.Equal("No available position.", exception.Message);
        }
    }
}
