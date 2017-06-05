using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UnityBase.Objects
{
    public interface IMaterial
    {
        Material Material { get; set; }

        Color Color { get; set; }
    }
}
