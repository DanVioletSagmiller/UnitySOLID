using Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Behaviours.Views
{
    public class FadeReactor : Reactor, IFadeReactor, IReactor
    {

        private bool CountDownToDestroy = false;

        private bool Ending = false;

        private float CountDownTimer = 0;

        public float FadeTime = 1f;

        private float FadeBase = 0;

        private Color Color = Color.white;

        private Renderer Renderer = null;

        public void Start()
        {
            Renderer = GetComponent<Renderer>();
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
                    FadeBase = 1 / FadeTime;
                    Color = Renderer.material.color;
                }
            }

            if (Ending)
            {
                FadeTime -= Time.deltaTime;
                Color.a = FadeBase * FadeTime;
                Renderer.material.color = Color;
                if (FadeTime < 0) Destroy(gameObject);
            }
        }
    }
}
