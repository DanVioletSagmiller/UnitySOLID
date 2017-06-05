using Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Behaviours.Views
{
    public class SlipReactor : Reactor, ISlipReactor, IReactor
    {

        public Vector3 LaunchForce = Vector3.one;

        public float LowestPosition = 0;

        private bool CountDownToDestroy = false;

        private bool Ending = false;

        private float CountDownTimer = 0;

        private Rigidbody Body = null;



        public void Start()
        {
            Body = GetComponent<Rigidbody>();
        }

        public override void ActivateDestructionIn(float time)
        {
            CountDownToDestroy = true;
            CountDownTimer = time;
        }

        // Update is called once per frame
        void Update()
        {
            if (!CountDownToDestroy && !Ending) return;

            if (CountDownToDestroy)
            {
                CountDownTimer -= Time.deltaTime;
                if (CountDownTimer < 0)
                {
                    CountDownToDestroy = false;
                    Ending = true;
                    Body.constraints = RigidbodyConstraints.None;
                    Body.AddForce(LaunchForce);
                }
            }

            if (Ending)
            {
                if (transform.position.y < LowestPosition) Destroy(gameObject);
            }
        }
    }
}
