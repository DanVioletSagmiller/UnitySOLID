using Lib.Domain.Enums;
using UnityBase.Objects;

namespace Lib.Domain.Configurations
{
    public interface IGameConfig
    {
        /// <summary>
        /// How long between each chain reaction
        /// </summary>
        float TimeBetweenReactions { get; }

        /// <summary>
        /// How much score for one ball
        /// </summary>
        float ScorePerBall { get; }

        /// <summary>
        /// How much multiplier for each additional ball in the chain
        /// </summary>
        float CountMultiplier { get; }

        /// <summary>
        /// How often does another ball drop.
        /// </summary>
        float BallDropFrequency { get; }

        /// <summary>
        /// How far from another ball to count as touching.
        /// </summary>
        float BallTouchRange { get; }

        /// <summary>
        /// Select a random Prefab
        /// </summary>
        /// <returns></returns>
        IGameObject GetBallPrefab();

        /// <summary>
        /// Select a Random Material
        /// </summary>
        /// <returns></returns>
        IMaterial GetMaterial();

        /// <summary>
        /// Select a Random Reactor
        /// </summary>
        /// <returns></returns>
        ReactorTypes GetReactor();
    }
}
