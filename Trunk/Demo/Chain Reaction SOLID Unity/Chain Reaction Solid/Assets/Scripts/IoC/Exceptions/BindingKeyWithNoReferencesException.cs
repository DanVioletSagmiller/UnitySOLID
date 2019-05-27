using System;
using System.Runtime.Serialization;

namespace IoC.Exceptions
{
    [Serializable]
    public  class BindingKeyWithNoReferencesException : Exception
    {
        public BindingKeyWithNoReferencesException(string message) : base(message)
        {
        }

        public BindingKeyWithNoReferencesException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BindingKeyWithNoReferencesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}