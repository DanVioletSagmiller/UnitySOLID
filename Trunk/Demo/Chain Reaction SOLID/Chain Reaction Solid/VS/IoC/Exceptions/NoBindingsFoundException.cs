using System;
using System.Runtime.Serialization;

namespace IoC.Exceptions
{
    [Serializable]
    public class NoBindingsFoundException : Exception
    {
        public NoBindingsFoundException(string message) : base(message)
        {
        }

        public NoBindingsFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoBindingsFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}