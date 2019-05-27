using Behaviours.ViewModels;
using IoC;
using Lib.Domain.Configurations;
using Lib.Domain.Controllers;
using Lib.Interfaces;
using System.Collections.Generic;
using UnityBase;
using UnityEngine;

namespace Behaviours.Views
{
    public class Game : InjectBehaviour, IGame
    {
        public IGameController GameController { get; set; }

        public GameConfig Configuration;

        public Transform[] BallDropLocations;
        
        /// <summary>
        /// when @0, ball drops, resets to ball drop frequency.
        /// </summary>
        private float DropCounter = 0;

        public Game()
        {            
            Di.Bind<IGame>().AsSingleton(this);
        }

        void Start()
        {
            Di.Bind<IGameConfig>().AsSingleton(Configuration);
        }

        // Update is called once per frame
        void Update()
        {
            DropCounter -= Time.deltaTime;
            if (DropCounter > 0) return;

            DropCounter = Configuration.ballDropFrequency;

            var dropPrefab = Configuration.GetBallPrefab().GameObject;
            var dropLocation = GetBallDropLocation();

            var ball = GameObject.Instantiate<GameObject>(
                dropPrefab,
                dropLocation.position,
                Quaternion.identity);
        }

        private Transform GetBallDropLocation()
        {
            var index = Random.Range(
                0,
                BallDropLocations.Length);

            return BallDropLocations[index];
        }
    }
}
