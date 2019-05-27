using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IoC
{
    /// <summary>
    /// Expresses that Di should not bind this field.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class DoNotBindAttribute : Attribute
    {

    }
}
