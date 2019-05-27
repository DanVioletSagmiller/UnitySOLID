using IoC.Exceptions;
using System;
using System.Collections.Generic;

namespace IoC
{
    public class DiBinding : IDiBinding
    {


        public Type FromType;
        public Type ToType;

        private Dictionary<object, object> References = null;
        private object SingletonReference;
        private Func<object, object> Conversion;

        internal BindingStyle Style = BindingStyle.Undefined;
        internal Type ConversionFrom;
        internal Type ConversionTo;

        public IDiBinding AsConversion<TO>(Func<object, object> converter)
        {
            // Conversion is reversed, from becomes the type.  
            ConversionFrom = typeof(TO);
            Style = BindingStyle.ByConversion;
            Conversion = converter;
            ConversionTo = FromType;

            //return
            return this;
        }

        public IDiBinding AsSingleton<TO>()
        {
            return AsSingleton(typeof(TO));
        }

        public IDiBinding AsSingleton(Type to)
        {
            // configure
            ToType = to;
            Style = BindingStyle.BySingleton;

            // return
            return this;
        }


        public IDiBinding AsSingleton(object with, object key = null)
        {
            if (key == null)
            {
                References = null;
                SingletonReference = with;
                return AsSingleton(with.GetType());
            }

            // has key
            if (References == null)
            {
                References = new Dictionary<object, object>();
            }

            References.Add(key, with);
            return AsSingleton(with.GetType());
        }

        public IDiBinding To<T>()
        {
            ToType = typeof(T);

            return this;
        }

        public object GetByKey(object key)
        {
            if (ToType == null)
            {
                throw new BindingPathNotConfiguredException("Attempted to get instance of " + FromType.Name + ", but it has not been bound to an output.  This is likely caused by Di.Bind<...>(); instead of Di.Bind<...>().To<...>()");
            }

            if (Style == BindingStyle.ByInstance)
            {
                throw new BindingNotSingletonException("Attempted to obtain an instance of " + FromType.Name + ", based on the key " + key.ToString() + ", but this was never setup '.AsSingleton(...)");
            }

            if (References == null)
            {
                throw new BindingKeyWithNoReferencesException("Attempted to obtain an instance based on key, but this has not been setup for keys.  I.e. Di.Bind<" + FromType.Name + ">() did not call .AsSingleton(<...>, <key>)");
            }

            if (key == null)
            {
                throw new ArgumentNullException(nameof(key), "Attempted to get an instance based on a key of null.");
            }

            if (!References.ContainsKey(key))
            {
                throw new BindingKeyNotFoundException("Attempted to obtain an instance based on a key that does not exist for this type.  I.e. You need a binding setup with Di.Bind<" + FromType.Name + ">().AsSingleton(objRefernce, key:= " + key.ToString() + ");");
            }

            return References[key];
        }

        public object Get()
        {
            if (ToType == null)
            {
                throw new OutputTypeUndefinedException("Attempted to get instance of " + FromType.Name + ", but it has not been bound to an output.  This is likely caused by Di.Bind<...>(); instead of Di.Bind<...>().To<...>()");
            }

            if (Style == BindingStyle.BySingleton)
            {
                if (SingletonReference == null)
                {
                    SingletonReference = Activator.CreateInstance(ToType);
                }
                return SingletonReference;
            }

            return Activator.CreateInstance(ToType);
        }

        public object Convert(object obj)
        {
            if (Style != BindingStyle.ByConversion)
            {
                throw new BindingNotConversionException("Attempted to get conversion from " + FromType.Name + ", but it is not a conversion. ");
            }

            return Conversion(obj);
        }
    }
}
