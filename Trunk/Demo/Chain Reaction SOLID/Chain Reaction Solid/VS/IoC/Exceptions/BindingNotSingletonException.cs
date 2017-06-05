using System;
using System.Runtime.Serialization;

namespace IoC.Exceptions
{
    [Serializable]
    public class BindingNotSingletonException : Exception
    {
        public BindingNotSingletonException(string message) : base(message)
        {
        }

        public BindingNotSingletonException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BindingNotSingletonException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}