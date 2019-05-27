using System;
using System.Runtime.Serialization;

namespace IoC.Exceptions
{
    [Serializable]
    public class BindingNotConversionException : Exception
    {
        public BindingNotConversionException(string message) : base(message)
        {
        }

        public BindingNotConversionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BindingNotConversionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}