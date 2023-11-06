using System;
using System.Runtime.Serialization;

namespace ParkingLotSystem
{
    [Serializable]
    public class EmptyTicketException : Exception
    {
        public EmptyTicketException()
        {
        }

        public EmptyTicketException(string message) : base(message)
        {
        }

        public EmptyTicketException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmptyTicketException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}