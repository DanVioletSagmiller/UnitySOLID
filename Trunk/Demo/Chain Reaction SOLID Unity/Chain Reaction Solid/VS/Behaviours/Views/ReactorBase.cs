using Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityBase;

namespace Behaviours.Views
{
    public abstract class Reactor : InjectBehaviour, IReactor
    {

        public abstract void ActivateDestructionIn(float time);
    }
}
