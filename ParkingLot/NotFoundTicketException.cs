using System;
using System.Runtime.Serialization;

namespace ParkingLotSystem
{
    [Serializable]
    public class NotFoundTicketException : Exception
    {
        public NotFoundTicketException()
        {
        }

        public NotFoundTicketException(string message) : base(message)
        {
        }

        public NotFoundTicketException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotFoundTicketException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}