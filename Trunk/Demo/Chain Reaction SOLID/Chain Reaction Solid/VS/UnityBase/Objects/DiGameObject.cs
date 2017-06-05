using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UnityBase.Objects
{
    public class DiGameObject : IGameObject
    {
        public GameObject GameObject { get; set; }

        public Vector3 TransformPosition
        {
            get => GameObject.transform.position;
            set => GameObject.transform.position = value;
        }

        public T GetComponent<T>()
        {
            return GameObject.GetComponent<T>();
        }

        public override bool Equals(object obj)
        {
            if (obj is DiGameObject)
            {
                var diGO = (DiGameObject)obj;
                obj = diGO.GameObject;
            }

            return GameObject.Equals(obj);
        }
    }
}
