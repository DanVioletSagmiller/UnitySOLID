using Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Behaviours.Views
{
    public class ShrinkReactor : Reactor, IShrinkReactor, IReactor
    {

        private bool CountDownToDestroy = false;

        private bool Ending = false;

        private float CountDownTimer = 0;

        public float ShrinkTime = 1f;

        private float ShrinkBase = 0;

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
                    ShrinkBase = 1 / ShrinkTime;
                }
            }

            if (Ending)
            {
                ShrinkTime -= Time.deltaTime;
                transform.localScale *= ShrinkBase * ShrinkTime;
                if (ShrinkTime < 0) Destroy(gameObject);
            }
        }
    }
}
