using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityBase.Objects;

namespace Lib.Interfaces
{
    public interface IBall : IGameObject
    {
        string MaterialName { get; }
    }
}
