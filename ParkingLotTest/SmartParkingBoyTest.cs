using ParkingLot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class SmartParkingBoyTest
    {
        [Fact]
        public void Should_return_ticket_from_parkinglot_When_smartParkingBoy_park_Given_all_three_parkingLot_empty()
        {
            var car = "Benze";
            var expect_ticket = "T_Benze";
            List<ParkingLotPlace> parkingLotPlaces = new List<ParkingLotPlace>();
            ParkingLotPlace parkingLotOne = new ParkingLotPlace();
            ParkingLotPlace parkingLotTwo = new ParkingLotPlace();
            ParkingLotPlace parkingLotThree = new ParkingLotPlace();
            parkingLotPlaces.Add(parkingLotOne);
            parkingLotPlaces.Add(parkingLotTwo);
            parkingLotPlaces.Add(parkingLotThree);
            ParkingBoyBase parkingBoy = new SmartParkingBoy(parkingLotPlaces);

            var actual_ticket = parkingBoy.ParkCar(car);

            Assert.Equal(expect_ticket, actual_ticket);
        }

        [Fact]
        public void Should_return_ticket_from_parkingLot_has_most_freeParkingSpot_When_smartParkingBoy_park_Given_three_parkingLot()
        {
            List<ParkingLotPlace> parkingLotPlaces = new List<ParkingLotPlace>();
            ParkingLotPlace parkingLotOne = new ParkingLotPlace();
            string[] carsOne = { "Benze", "BMW" };
            foreach (var car in carsOne)
            {
                parkingLotOne.ParkCar(car);
            }

            ParkingLotPlace parkingLotTwo = new ParkingLotPlace();
            string[] carsTwo = { "Mazda" };
            foreach (var car in carsTwo)
            {
                parkingLotTwo.ParkCar(car);
            }

            ParkingLotPlace parkingLotThree = new ParkingLotPlace();
            parkingLotPlaces.Add(parkingLotOne);
            parkingLotPlaces.Add(parkingLotTwo);
            parkingLotPlaces.Add(parkingLotThree);
            ParkingBoyBase parkingBoy = new SmartParkingBoy(parkingLotPlaces);

            var actual_ticket = parkingBoy.ParkCar("GTR");

            Assert.True(parkingLotThree.TicketToCar.ContainsKey("T_GTR"));
        }

        [Fact]
        public void Should_return_ticket_from_parkingLot_has_most_freeParkingSpot_When_smartParkingBoy_park_Given_three_parkingLot_with_multiple_parkCar_fetchCar_operations()
        {
            List<ParkingLotPlace> parkingLotPlaces = new List<ParkingLotPlace>();
            string[] cars = { "Benze", "BMW", "Rolls-Royce", "Tesla", "Lamborghini", "Porsche", "Honda", "Bentley", "GTR", "911", "LiXiang", "Bieke" };
            ParkingLotPlace parkingLotOne = new ParkingLotPlace();
            ParkingLotPlace parkingLotTwo = new ParkingLotPlace();
            ParkingLotPlace parkingLotThree = new ParkingLotPlace();
            parkingLotPlaces.Add(parkingLotOne);
            parkingLotPlaces.Add(parkingLotTwo);
            parkingLotPlaces.Add(parkingLotThree);
            SmartParkingBoy parkingBoy = new SmartParkingBoy(parkingLotPlaces);

            for (int i = 0; i < cars.Length; i++)
            {
                parkingBoy.ParkCar(cars[i]);
                if (i % 3 == 2)
                {
                    Assert.Equal(parkingLotOne.TicketToCar.Count, parkingLotThree.TicketToCar.Count);
                    Assert.Equal(parkingLotOne.TicketToCar.Count, parkingLotTwo.TicketToCar.Count);
                }

                if (i > 2)
                {
                    parkingBoy.FetchCar("T_Benze");
                    parkingBoy.FetchCar("T_BMW");
                    parkingBoy.FetchCar("T_Rolls-Royce");
                    parkingBoy.ParkCar("Benze");
                    parkingBoy.ParkCar("BMW");
                    parkingBoy.ParkCar("Rolls-Royce");
                }
            }
        }

        [Fact]
        public void Should_return_right_cars_from_different_parkingLot_When_smartParkingBot_fetch_car_Given_right_ticket_of_different_parkingLot()
        {
            List<ParkingLotPlace> parkingLotPlaces = new List<ParkingLotPlace>();
            ParkingLotPlace parkingLotOne = new ParkingLotPlace();
            string[] carsOne = { "Benze", "BMW", "Jieda" };
            foreach (var car in carsOne)
            {
                parkingLotOne.ParkCar(car);
            }

            ParkingLotPlace parkingLotTwo = new ParkingLotPlace();
            string[] carsTwo = { "Mazda" };
            foreach (var car in carsTwo)
            {
                parkingLotTwo.ParkCar(car);
            }

            ParkingLotPlace parkingLotThree = new ParkingLotPlace();
            parkingLotPlaces.Add(parkingLotOne);
            parkingLotPlaces.Add(parkingLotTwo);
            parkingLotPlaces.Add(parkingLotThree);
            ParkingBoyBase parkingBoy = new SmartParkingBoy(parkingLotPlaces);
            var expect_car = "GTR";
            var actual_ticket = parkingBoy.ParkCar(expect_car);
            var actual_car = parkingBoy.FetchCar(actual_ticket);

            Assert.Equal(expect_car, actual_car);
        }

        [Fact]
        public void Should_throw_unrecognized_exception_When_smartparkingboyPlus_fetch_Given_wrong_ticket()
        {
            var expect_msg = "Unrecognized parking ticket.";
            var mazda_ticket = "T_Mazda";
            string[] cars = { "Benze", "BMW", "Rolls-Royce", "Tesla", "Lamborghini", "Porsche", "Honda", "Bentley", "GTR", "911", "LiXiang" };
            List<ParkingLotPlace> parkingLotPlaces = new List<ParkingLotPlace>();
            ParkingLotPlace parkingLotOne = new ParkingLotPlace();
            ParkingLotPlace parkingLotTwo = new ParkingLotPlace();
            ParkingLotPlace parkingLotThree = new ParkingLotPlace();
            parkingLotPlaces.Add(parkingLotOne);
            parkingLotPlaces.Add(parkingLotTwo);
            parkingLotPlaces.Add(parkingLotThree);
            SmartParkingBoy parkingBoy = new SmartParkingBoy(parkingLotPlaces);
            foreach (var car in cars)
            {
                parkingBoy.ParkCar(car);
            }

            WrongException acturl_wrong_msg = Assert.Throws<WrongException>(() => parkingBoy.FetchCar(mazda_ticket));

            Assert.Equal(expect_msg, acturl_wrong_msg.Message);
        }

        [Fact]
        public void Should_throw_unrecognized_exception_When_smartparkingboy_fetch_Given_used_ticket()
        {
            var expect_msg = "Unrecognized parking ticket.";
            var benze_ticket = "T_Benze";
            List<ParkingLotPlace> parkingLotPlaces = new List<ParkingLotPlace>();
            ParkingLotPlace parkingLotOne = new ParkingLotPlace();
            ParkingLotPlace parkingLotTwo = new ParkingLotPlace();
            parkingLotPlaces.Add(parkingLotOne);
            parkingLotPlaces.Add(parkingLotTwo);
            SmartParkingBoy parkingBoy = new SmartParkingBoy(parkingLotPlaces);
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
        public void Should_throw_noPosition_exception_When_smartParkingboy_fetch_Given_no_parkingSpot_available()
        {
            var expect_msg = "No available position.";
            var carToPark = "WuLing";
            List<ParkingLotPlace> parkingLotPlaces = new List<ParkingLotPlace>();
            ParkingLotPlace parkingLotOne = new ParkingLotPlace();
            ParkingLotPlace parkingLotTwo = new ParkingLotPlace();
            parkingLotPlaces.Add(parkingLotOne);
            parkingLotPlaces.Add(parkingLotTwo);
            SmartParkingBoy parkingBoy = new SmartParkingBoy(parkingLotPlaces);
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
