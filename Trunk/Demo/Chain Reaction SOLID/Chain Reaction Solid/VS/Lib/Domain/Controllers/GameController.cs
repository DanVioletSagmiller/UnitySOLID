using Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib.Domain.Controllers
{
    public interface IGameController
    {
        List<IBall> BallCollection { get; }
    }
    public class GameController : IGameController
    {
        private List<IBall> _BallCollection = new List<IBall>();
        public List<IBall> BallCollection { get => _BallCollection; }
    }
}
