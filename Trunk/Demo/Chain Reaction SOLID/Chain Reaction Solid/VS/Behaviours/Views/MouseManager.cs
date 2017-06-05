using IoC;
using Lib.Domain.Controllers;
using Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityBase;
using UnityEngine;

namespace Behaviours.Views
{
    public class MouseManager : InjectBehaviour
    {
        public IMouseManagerController Controller { get; set; }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                var didHit = Physics.Raycast(ray, out hit);

                if (didHit)
                {
                    var ball = hit.collider.gameObject.GetComponent<IBall>();
                    if (ball == null)
                    {
                        return;
                    }

                    if (Controller == null)
                    {
                        Controller = Di.Get<IMouseManagerController>();
                    }

                    Controller.BallClicked(ball);
                }
            }
        }
    }
}
