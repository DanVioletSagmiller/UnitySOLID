using IoC;
using Lib.Domain.Configurations;
using Lib.Domain.Enums;
using Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Lib.Domain.Controllers
{
    public interface IBallController
    {
        void StartReaction(IBall original);
    }
    public class BallController : IBallController
    {
        public IGameController GameController { get; set; }

        public void StartReaction(IBall original)
        {
            var config = Di.Get<IGameConfig>();
            var all = new List<IBall>(GameController.BallCollection.Where(x => x.MaterialName == original.MaterialName));
            var consumables = new List<IBall>();
            var consumed = new List<IBall>();
            consumables.Add(original);
            all.Remove(original);

            while (consumables.Count > 0)
            {
                var tester = consumables[0];
                consumables.RemoveAt(0);
                consumed.Add(tester);
                for (int i = all.Count - 1; i > -1; i--)
                {
                    var b = all[i];
                    var distance = Vector3.Distance(tester.TransformPosition, b.TransformPosition);
                    if (distance > config.BallTouchRange) continue;

                    consumables.Add(b);
                    all.Remove(b);
                }
            }

            var score = 0f;
            var triggerIn = 0f;
            var reactorChoice = config.GetReactor();
            IReactor reactor = null;
            foreach (var b in consumed)
            {
                if (reactorChoice == ReactorTypes.Fade) reactor = b.GetComponent<IFadeReactor>();
                if (reactorChoice == ReactorTypes.Shrink) reactor = b.GetComponent<IShrinkReactor>();
                if (reactorChoice == ReactorTypes.Slip) reactor = b.GetComponent<ISlipReactor>();

                reactor.ActivateDestructionIn(triggerIn);
                triggerIn += config.TimeBetweenReactions;

                score += config.ScorePerBall;
                score *= config.CountMultiplier;

                
            }

            Di.Get<IScore>().TotalScore += (int)score;
        }
    }
}
