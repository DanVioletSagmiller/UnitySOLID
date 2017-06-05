using IoC;
using Lib.Domain.Enums;
using Lib.Domain.Configurations;
using Lib.Interfaces;
using UnityBase.Objects;
using UnityEngine;

namespace Behaviours.ViewModels
{
    [CreateAssetMenu(fileName = "Config", menuName = "Configuration", order = 0)]
    public class GameConfig : ScriptableObject, IGameConfig
    {
        public GameObject[] ballPrefabs;

        public Material[] materials;

        public ReactorTypes[] Reactors;

        /// <summary>
        /// How long between each chain reaction
        /// </summary>
        public float timeBetweenReactions = 0.2f;
        public float TimeBetweenReactions => timeBetweenReactions;

        /// <summary>
        /// How much score for one ball
        /// </summary>
        public float scorePerBall = 1;
        public float ScorePerBall => scorePerBall;

        /// <summary>
        /// How much multiplier for each additional ball in the chain
        /// </summary>
        public float countMultiplier = 2;
        public float CountMultiplier => countMultiplier;

        /// <summary>
        /// How often does another ball drop.
        /// </summary>
        public float ballDropFrequency = 0.2f;

        /// <summary>
        /// How far from another ball to count as touching.
        /// </summary>
        public float ballTouchRange = 1.5f;

        public float BallDropFrequency => ballDropFrequency;
        public float BallTouchRange => ballTouchRange;


        public IGameObject GetBallPrefab()
        {
            var index = Random.Range(
                0,
                ballPrefabs.Length);

            return Di.Convert<IGameObject>(ballPrefabs[index]);
        }

        public IMaterial GetMaterial()
        {
            var index = Random.Range(
                0,
                materials.Length);

            return Di.Convert<IMaterial>(materials[index]);
        }

        public ReactorTypes GetReactor()
        {
            var index = Random.Range(
                0,
                Reactors.Length);

            return Reactors[index];
        }
    }
}
