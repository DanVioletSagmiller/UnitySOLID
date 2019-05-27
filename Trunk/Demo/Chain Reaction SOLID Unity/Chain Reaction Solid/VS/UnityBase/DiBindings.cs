using IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityBase.Objects;
using UnityBase.Statics;
using UnityEngine;

namespace UnityBase
{
    public class DiBindings : IBindingConfiguration
    {
        public int Order => -1;

        public void Setup()
        {
            Di.Bind<IDebug>().AsSingleton(typeof(DiDebug));



            Di.Bind<GameObject>().AsConversion<IGameObject>((o) =>
            {
                var go = (IGameObject)o;
                return go.GameObject;
            });

            Di.Bind<IGameObject>().AsConversion<GameObject>((o)=>
            {
                return new DiGameObject()
                {
                    GameObject = (GameObject)o
                };
            });

            Di.Bind<IMaterial>().AsConversion<Material>((o) =>
            {
                return new DiMaterial()
                {
                    Material = (Material)o
                };
            });

            Di.Bind<Material>().AsConversion<IMaterial>((o) =>
                {
                    var m = (IMaterial)o;
                    return m.Material;
                });
        }
    }
}
