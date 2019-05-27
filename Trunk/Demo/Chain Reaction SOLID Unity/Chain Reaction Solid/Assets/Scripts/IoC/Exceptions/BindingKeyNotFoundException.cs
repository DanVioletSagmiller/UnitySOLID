using System;
using System.Runtime.Serialization;

namespace IoC.Exceptions
{
    [Serializable]
    public class BindingKeyNotFoundException : Exception
    {

        public BindingKeyNotFoundException(string message) : base(message)
        {
        }

        public BindingKeyNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BindingKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}