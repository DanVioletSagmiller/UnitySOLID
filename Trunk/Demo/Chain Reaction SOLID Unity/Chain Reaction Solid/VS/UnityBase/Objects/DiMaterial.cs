using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UnityBase.Objects
{
    public class DiMaterial : IMaterial
    {
        public Material Material { get; set; }

        public Color Color
        {
            get => Material.color;
            set => Material.color = value;
        }
    }
}
