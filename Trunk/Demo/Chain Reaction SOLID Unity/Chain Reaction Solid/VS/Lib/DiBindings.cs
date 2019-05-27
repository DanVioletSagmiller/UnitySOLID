using IoC;
using Lib.Domain.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib
{
    public class DiBindings : IBindingConfiguration
    {
        public int Order => 0;

        public void Setup()
        {
            Di.Bind<IBallController>()
                .AsSingleton<BallController>();
            Di.Bind<IGameController>()
                .AsSingleton<GameController>();
            Di.Bind<IMouseManagerController>()
                .AsSingleton<MouseManagerController>();

        }
    }
}
