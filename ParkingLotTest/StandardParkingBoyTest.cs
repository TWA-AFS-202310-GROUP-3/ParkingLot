using ParkingLotSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class StandardParkingBoyTest
    {
        [Fact]
        public void Should_get_the_right_ticket_when_park_a_car()
        {
            ParkingLot parkingLot = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(new List<ParkingLot> { parkingLot });
            string ticketNumber = standardParkingBoy.ParkACar("car");
            Assert.Equal("T-car", ticketNumber);
        }

        [Fact]
        public void Should_fetch_the_right_car_when_given_the_parking_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(new List<ParkingLot> { parkingLot });
            string ticketNumber = standardParkingBoy.ParkACar("car");
            string fetchedCarNumber = standardParkingBoy.FetchACar(ticketNumber);
            Assert.Equal("car", fetchedCarNumber);
        }

        [Fact]
        public void Should_not_fetch_the_car_when_given_a_incorrect_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(new List<ParkingLot> { parkingLot });
            NotFoundTicketException notFoundTicketException = Assert.Throws<NotFoundTicketException>(() => standardParkingBoy.FetchACar("wrong ticket"));
        }

        [Fact]
        public void Should_throw_exception_when_given_an_empty_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(new List<ParkingLot> { parkingLot });
            EmptyTicketException emptyTicketException = Assert.Throws<EmptyTicketException>(() => standardParkingBoy.FetchACar(string.Empty));
        }

        [Fact]
        public void Should_not_fetch_car_when_ticket_is_already_used()
        {
            ParkingLot parkingLot = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(new List<ParkingLot> { parkingLot });
            string ticketNumber = standardParkingBoy.ParkACar("car");
            string fetchedCarNumber = standardParkingBoy.FetchACar(ticketNumber);
            NotFoundTicketException notFoundTicketException = Assert.Throws<NotFoundTicketException>(() => standardParkingBoy.FetchACar(ticketNumber));
        }

        [Fact]
        public void Should_not_park_car_when_parkinglot_capacity_is_full()
        {
            ParkingLot parkingLot = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(new List<ParkingLot> { parkingLot });
            for (int i = 0; i < 10; i++)
            {
                standardParkingBoy.ParkACar($"{i}car");
            }

            FullParkingSlotException fullParkingSlotException = Assert.Throws<FullParkingSlotException>(() => standardParkingBoy.ParkACar("11st car"));
        }

        [Fact]
        public void Should_park_in_first_parkinglot_when_park_a_car_in_two_available_parkingLot()
        {
            ParkingLot parkingLot1 = new ParkingLot();
            ParkingLot parkingLot2 = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(new List<ParkingLot>() { parkingLot1, parkingLot2 });
            string ticketNumber = standardParkingBoy.ParkACar("car");
            Assert.Equal("T-car", ticketNumber);
        }

        [Fact]
        public void Should_park_in_second_parkinglot_when_first_parkinglot_is_full()
        {
            ParkingLot parkingLot1 = new ParkingLot();
            for (int i = 0; i < 10; i++)
            {
                parkingLot1.ParkACar($"{i}car");
            }

            ParkingLot parkingLot2 = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(new List<ParkingLot>() { parkingLot1, parkingLot2 });
            string ticketNumber = standardParkingBoy.ParkACar("special car");
            string fetchedResult = parkingLot2.FetchACar(ticketNumber);
            Assert.Equal("special car", fetchedResult);
        }

        [Fact]
        public void Should_return_right_car_when_fetch_two_cars_in_tow_parkinglots()
        {
            ParkingLot parkinglot1 = new ParkingLot();
            string ticket1 = parkinglot1.ParkACar("car1");
            ParkingLot parkinglot2 = new ParkingLot();
            string ticket2 = parkinglot2.ParkACar("car2");
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(new List<ParkingLot>() { parkinglot1, parkinglot2 });
            string fetchedResult1 = "car1";
            string fetchedResult2 = "car2";
            string result1 = standardParkingBoy.FetchACar(ticket1);
            string result2 = standardParkingBoy.FetchACar(ticket2);
            Assert.Equal(fetchedResult1, result1);
            Assert.Equal(fetchedResult2, result2);
        }

        [Fact]
        public void Should_show_wrong_message_when_given_wrong_ticket()
        {
            ParkingLot parkinglot1 = new ParkingLot();
            ParkingLot parkinglot2 = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(new List<ParkingLot>() { parkinglot1, parkinglot2 });
            NotFoundTicketException notFoundTicketException = Assert.Throws<NotFoundTicketException>(() => standardParkingBoy.FetchACar("wrong ticket"));
        }

        [Fact]
        public void Should_show_wrong_message_when_given_an_empty_ticket()
        {
            ParkingLot parkinglot1 = new ParkingLot();
            ParkingLot parkinglot2 = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(new List<ParkingLot>() { parkinglot1, parkinglot2 });
            EmptyTicketException emptyTicketException = Assert.Throws<EmptyTicketException>(() => standardParkingBoy.FetchACar(string.Empty));
        }

        [Fact]
        public void Should_show_wrong_message_when_ticket_is_already_used()
        {
            ParkingLot parkinglot1 = new ParkingLot();
            ParkingLot parkinglot2 = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(new List<ParkingLot>() { parkinglot1, parkinglot2 });
            string ticketNumber = standardParkingBoy.ParkACar("car");
            string fetchedCarNumber = standardParkingBoy.FetchACar(ticketNumber);
            NotFoundTicketException notFoundTicketException = Assert.Throws<NotFoundTicketException>(() => standardParkingBoy.FetchACar(ticketNumber));
        }

        [Fact]
        public void Should_not_park_car_when_two_parkinglots_capacity_are_full()
        {
            ParkingLot parkinglot1 = new ParkingLot();
            ParkingLot parkinglot2 = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(new List<ParkingLot>() { parkinglot1, parkinglot2 });
            for (int i = 0; i < 20; i++)
            {
                standardParkingBoy.ParkACar($"{i}car");
            }

            FullParkingSlotException fullParkingSlotException = Assert.Throws<FullParkingSlotException>(() => standardParkingBoy.ParkACar("21st car"));
        }
    }
}
