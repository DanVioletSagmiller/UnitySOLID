using System;
using System.Runtime.Serialization;

namespace IoC.Exceptions
{
    [Serializable]
    public class BindingPathNotConfiguredException : Exception
    {
        public BindingPathNotConfiguredException(string message) : base(message)
        {
        }

        public BindingPathNotConfiguredException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BindingPathNotConfiguredException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}