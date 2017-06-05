using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UnityBase.Objects
{
    public interface IGameObject
    {
        GameObject GameObject { get; }

        Vector3 TransformPosition { get; set; }

        T GetComponent<T>();
    }
}
