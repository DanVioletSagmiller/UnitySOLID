using IoC;
using Lib.Domain.Enums;
using Lib.Domain.Configurations;
using Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityBase;
using UnityEngine;
using Lib.Domain.Controllers;

namespace Behaviours.Views
{
    public class Ball : InjectBehaviour, IBall
    {

        public GameObject GameObject => gameObject;

        public Material Material { get; set; }


        public IGame Game { get; set; }

        public IGameController GameController {get; set;}

        public IScore Score { get; set; }

        public IGameConfig Config { get; set; }


        public string MaterialName
        {
            get => Material.name;
        }

        public Vector3 TransformPosition
        {
            get => gameObject.transform.position;
            set => gameObject.transform.position = value;
        }


        

        // Use this for initialization
        void Start()
        {
            GameController.BallCollection.Add(this);
            Material = Config.GetMaterial().Material;
            GetComponent<Renderer>().material = Material;
            this.Score = Di.Get<IScore>();
            this.Config = Di.Get<IGameConfig>();
        }

        private void OnDestroy()
        {
            GameController.BallCollection.Remove(this);
        }
    }
}
