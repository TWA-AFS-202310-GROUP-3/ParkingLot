using System;
using System.Runtime.Serialization;

namespace ParkingLotSystem
{
    [Serializable]
    public class FullParkingSlotException : Exception
    {
        public FullParkingSlotException()
        {
        }

        public FullParkingSlotException(string message) : base(message)
        {
        }

        public FullParkingSlotException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FullParkingSlotException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}