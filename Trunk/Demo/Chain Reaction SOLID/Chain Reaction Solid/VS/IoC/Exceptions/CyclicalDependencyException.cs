using System;
using System.Runtime.Serialization;

namespace IoC.Exceptions
{
    [Serializable]
    public class CyclicalDependencyException : Exception
    {
        public CyclicalDependencyException(string message) : base(message)
        {
        }

        public CyclicalDependencyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CyclicalDependencyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}