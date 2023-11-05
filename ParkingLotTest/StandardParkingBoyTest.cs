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
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkingLot);
            string ticketNumber = standardParkingBoy.ParkACar("car");
            Assert.Equal("T-car", ticketNumber);
        }

        [Fact]
        public void Should_fetch_the_right_car_when_given_the_parking_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkingLot);
            string ticketNumber = standardParkingBoy.ParkACar("car");
            string fetchedCarNumber = standardParkingBoy.FetchACar(ticketNumber);
            Assert.Equal("car", fetchedCarNumber);
        }

        [Fact]
        public void Should_not_fetch_the_car_when_given_a_incorrect_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkingLot);
            NotFoundTicketException notFoundTicketException = Assert.Throws<NotFoundTicketException>(() => standardParkingBoy.FetchACar("wrong ticket"));
        }

        [Fact]
        public void Should_throw_exception_when_given_an_empty_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkingLot);
            EmptyTicketException emptyTicketException = Assert.Throws<EmptyTicketException>(() => standardParkingBoy.FetchACar(string.Empty));
        }

        [Fact]
        public void Should_not_fetch_car_when_ticket_is_already_used()
        {
            ParkingLot parkingLot = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkingLot);
            string ticketNumber = standardParkingBoy.ParkACar("car");
            string fetchedCarNumber = standardParkingBoy.FetchACar(ticketNumber);
            NotFoundTicketException notFoundTicketException = Assert.Throws<NotFoundTicketException>(() => standardParkingBoy.FetchACar(ticketNumber));
        }

        [Fact]
        public void Should_not_park_car_when_parkinglot_capacity_is_full()
        {
            ParkingLot parkingLot = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkingLot);
            for (int i = 0; i < 10; i++)
            {
                standardParkingBoy.ParkACar($"{i}car");
            }

            FullParkingSlotException fullParkingSlotException = Assert.Throws<FullParkingSlotException>(() => standardParkingBoy.ParkACar("11st car"));
        }
    }
}
