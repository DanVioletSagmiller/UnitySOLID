using System;
using System.Runtime.Serialization;

namespace IoC.Exceptions
{
    [Serializable]
    public class OutputTypeUndefinedException : Exception
    {
        public OutputTypeUndefinedException(string message) : base(message)
        {
        }

        public OutputTypeUndefinedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OutputTypeUndefinedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}