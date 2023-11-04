using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace ParkingLotPractice
//{
//    public class SmartParkingBoy
//    {
//        private ParkingLot[] parkingLots;
//        public SmartParkingBoy(params ParkingLot[] parkingLots)
//        {
//            this.parkingLots = parkingLots;
//        }

//        public string Park(string car)
//        {
//            return parkingLots.MaxBy(p => p.GetAvailablePositionAmount()).Park(car);
//        }

//        public string Fetch(string ticket)
//        {
//            foreach (var parkingLot in parkingLots)
//            {
//                try
//                {
//                    return parkingLot.Fetch(ticket);
//                }
//                catch { }
//            }

//            throw new WrongTicketException("Unrecognized parking ticket. ");
//        }
//    }
//}
