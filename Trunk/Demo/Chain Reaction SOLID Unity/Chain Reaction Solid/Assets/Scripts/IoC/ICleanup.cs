using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IoC
{
    public interface ICleanup
    {
        void Add(IDisposable disposable);
        void DisposeAll();
        void Dispose(IDisposable disposable);
    }
}
