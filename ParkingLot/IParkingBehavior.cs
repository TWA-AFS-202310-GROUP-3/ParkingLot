using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotProj
{
    public interface IParkingBehavior
    {
        public string Park(string carId);

        public string Fetch(string ticketId);
    }
}
