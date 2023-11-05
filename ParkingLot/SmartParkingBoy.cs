using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class SmartParkingBoy : ParkingBoyBase
    {
        private MinHeap<ParkingLotPlace> freeSpotsNumberMaxnHeap;
        private Dictionary<string, ParkingLotPlace> ticketToParkingLot;

        public SmartParkingBoy(List<ParkingLotPlace> parkingLotPlaces)
        {
            freeSpotsNumberMaxnHeap = new MinHeap<ParkingLotPlace>(parkingLotPlaces);
            ticketToParkingLot = new Dictionary<string, ParkingLotPlace>();
        }

        public override string ParkCar(string car)
        {
            ParkingLotSetterGetter = freeSpotsNumberMaxnHeap.Pop();
            string ticket = base.ParkCar(car);
            ticketToParkingLot.Add(ticket, ParkingLotSetterGetter);
            freeSpotsNumberMaxnHeap.Push(ParkingLotSetterGetter);

            return ticket;
        }

        public override string FetchCar(string ticket)
        {
            TicketCheckBeforeFetch(ticket);
            ParkingLotSetterGetter = ticketToParkingLot[ticket];
            var car = base.FetchCar(ticket);
            freeSpotsNumberMaxnHeap.DecreaseKey(ParkingLotSetterGetter);

            return car;
        }

        private void TicketCheckBeforeFetch(string ticket)
        {
            if (!this.ticketToParkingLot.ContainsKey(ticket))
            {
                throw new WrongException("Unrecognized parking ticket.");
            }
        }
    }
}
