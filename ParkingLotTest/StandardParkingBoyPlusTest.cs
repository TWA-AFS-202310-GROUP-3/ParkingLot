using ParkingLot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class StandardParkingBoyPlusTest
    {

        [Fact]
        public void Should_return_ticket_from_first_parkinglot_When_parkingboyPlus_park_Given_first_parkingLot_available()
        {
            var car = "Benze";
            var expect_ticket = "T_Benze";
            List<ParkingLotPlace> parkingLotPlaces = new List<ParkingLotPlace>();
            ParkingLotPlace parkingLotOne = new ParkingLotPlace();
            ParkingLotPlace parkingLotTwo = new ParkingLotPlace();
            parkingLotPlaces.Add(parkingLotOne);
            parkingLotPlaces.Add(parkingLotTwo);
            ParkingBoyBase parkingBoy = new ParkingLot.StandardParkingBoyPlus(parkingLotPlaces);

            var actual_ticket = parkingBoy.ParkCar(car);

            Assert.Equal(expect_ticket, actual_ticket);
        }

        [Fact]
        public void Should_return_ticket_from_second_parkinglot_When_parkingboyPlus_park_Given_second_parkingLot_available_first_not()
        {
            var mazda = "Mazda";
            List<ParkingLotPlace> parkingLotPlaces = new List<ParkingLotPlace>();
            ParkingLotPlace parkingLotOne = new ParkingLotPlace();
            string[] cars = { "Benze", "BMW", "Rolls-Royce", "Tesla", "Lamborghini", "Porsche" };
            foreach (var car in cars)
            {
                parkingLotOne.ParkCar(car);
            }

            ParkingLotPlace parkingLotTwo = new ParkingLotPlace();
            parkingLotPlaces.Add(parkingLotOne);
            parkingLotPlaces.Add(parkingLotTwo);
            ParkingLot.StandardParkingBoyPlus parkingBoy = new ParkingLot.StandardParkingBoyPlus(parkingLotPlaces);

            var ticket = parkingBoy.ParkCar(mazda);

            Assert.Equal(1, parkingBoy.TellParkingLotIndexCarParked(ticket));
        }

        [Fact]
        public void Should_return_right_cars_from_different_parkingLot_When_parkingboyPlus_fetch_car_Given_right_ticket_of_different_parkingLot()
        {
            var expect_car1 = "Benze";
            var expect_car2 = "BMW";
            var ticket1 = "T_Benze";
            var ticket2 = "T_BMW";
            ParkingLotPlace parkingLotOne = new ParkingLotPlace();
            ParkingLotPlace parkingLotTwo = new ParkingLotPlace();
            parkingLotOne.ParkCar(expect_car1);
            parkingLotTwo.ParkCar(expect_car2);
            List<ParkingLotPlace> parkingLotPlaces = new List<ParkingLotPlace>();
            parkingLotPlaces.Add(parkingLotOne);
            parkingLotPlaces.Add(parkingLotTwo);
            ParkingBoyBase parkingboy = new ParkingLot.StandardParkingBoyPlus(parkingLotPlaces);

            var actual_car1 = parkingboy.FetchCar(ticket1);
            var actual_car2 = parkingboy.FetchCar(ticket2);

            Assert.Equal(expect_car1, actual_car1);
            Assert.Equal(expect_car2, actual_car2);
        }

        [Fact]
        public void Should_throw_unrecognized_exception_When_parkingboyPlus_fetch_Given_wrong_ticket()
        {
            var expect_msg = "Unrecognized parking ticket.";
            var mazda_ticket = "T_Mazda";
            List<ParkingLotPlace> parkingLotPlaces = new List<ParkingLotPlace>();
            ParkingLotPlace parkingLotOne = new ParkingLotPlace();
            string[] cars = { "Benze", "BMW", "Rolls-Royce", "Tesla", "Lamborghini", "Porsche" };
            foreach (var car in cars)
            {
                parkingLotOne.ParkCar(car);
            }

            ParkingLotPlace parkingLotTwo = new ParkingLotPlace();
            parkingLotPlaces.Add(parkingLotOne);
            parkingLotPlaces.Add(parkingLotTwo);
            ParkingLot.StandardParkingBoyPlus parkingBoy = new ParkingLot.StandardParkingBoyPlus(parkingLotPlaces);

            WrongException acturl_wrong_msg = Assert.Throws<WrongException>(() => parkingBoy.FetchCar(mazda_ticket));

            Assert.Equal(expect_msg, acturl_wrong_msg.Message);
        }

        [Fact]
        public void Should_throw_unrecognized_exception_When_parkingboyPlus_fetch_Given_used_ticket()
        {
            var expect_msg = "Unrecognized parking ticket.";
            var benze_ticket = "T_Benze";
            List<ParkingLotPlace> parkingLotPlaces = new List<ParkingLotPlace>();
            ParkingLotPlace parkingLotOne = new ParkingLotPlace();
            ParkingLotPlace parkingLotTwo = new ParkingLotPlace();
            parkingLotPlaces.Add(parkingLotOne);
            parkingLotPlaces.Add(parkingLotTwo);
            ParkingLot.StandardParkingBoyPlus parkingBoy = new ParkingLot.StandardParkingBoyPlus(parkingLotPlaces);
            string[] cars = { "Benze", "BMW", "Rolls-Royce", "Tesla", "Lamborghini", "Porsche", "Mazda" };
            foreach (var car in cars)
            {
                parkingBoy.ParkCar(car);
            }

            parkingBoy.FetchCar(benze_ticket);

            WrongException acturl_wrong_msg = Assert.Throws<WrongException>(() => parkingBoy.FetchCar(benze_ticket));

            Assert.Equal(expect_msg, acturl_wrong_msg.Message);
        }

        [Fact]
        public void Should_throw_noPosition_exception_When_parkingboyPlus_fetch_Given_no_parkingSpot_available()
        {
            var expect_msg = "No available position.";
            var carToPark = "WuLing";
            List<ParkingLotPlace> parkingLotPlaces = new List<ParkingLotPlace>();
            ParkingLotPlace parkingLotOne = new ParkingLotPlace();
            ParkingLotPlace parkingLotTwo = new ParkingLotPlace();
            parkingLotPlaces.Add(parkingLotOne);
            parkingLotPlaces.Add(parkingLotTwo);
            ParkingLot.StandardParkingBoyPlus parkingBoy = new ParkingLot.StandardParkingBoyPlus(parkingLotPlaces);
            string[] cars = { "Benze", "BMW", "Rolls-Royce", "Tesla", "Lamborghini", "Porsche", "Mazda", "Honda", "Bentley", "GTR", "911", "LiXiang" };
            foreach (var car in cars)
            {
                parkingBoy.ParkCar(car);
            }

            WrongException acturl_wrong_msg = Assert.Throws<WrongException>(() => parkingBoy.ParkCar(carToPark));

            Assert.Equal(expect_msg, acturl_wrong_msg.Message);
        }
    }
}
