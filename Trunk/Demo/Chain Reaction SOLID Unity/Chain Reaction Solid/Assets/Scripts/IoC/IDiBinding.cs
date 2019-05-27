using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IoC
{
    public interface IDiBinding
    {
        IDiBinding AsConversion<TO>(Func<object, object> converter);
        IDiBinding AsSingleton<TO>();
        IDiBinding AsSingleton(Type to);
        IDiBinding AsSingleton(object with, object key = null);
        IDiBinding To<T>();
    }
}
