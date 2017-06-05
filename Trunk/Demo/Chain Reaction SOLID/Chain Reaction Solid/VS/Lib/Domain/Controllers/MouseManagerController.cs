using IoC;
using Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib.Domain.Controllers
{
    public interface IMouseManagerController
    {
        void BallClicked(IBall ball);
    }
    public class MouseManagerController : IMouseManagerController
    {
        public void BallClicked(IBall ball)
        {
            Di.Get<IBallController>().StartReaction(ball);
        }
    }
}
