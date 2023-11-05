using System;
using System.Runtime.Serialization;

namespace ParkingLotns
{
    [Serializable]
    public class WrongException : Exception
    {
        public WrongException()
        {
        }

        public WrongException(string message) : base(message)
        {
        }

        public WrongException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WrongException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}