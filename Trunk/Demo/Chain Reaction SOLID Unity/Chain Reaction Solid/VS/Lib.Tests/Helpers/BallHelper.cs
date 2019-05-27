using Lib.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Lib.Tests.Helpers
{
    public static class BallHelper
    {
        public static List<Mock<IBall>> CreateMoqBallList(int howMany)
        {
            var ballList = new List<Mock<IBall>>();

            for(int i = 0; i < howMany; i++)
            {
                var moqBall = new Mock<IBall>();
                ballList.Add(moqBall);
            }

            return ballList;
        }

        public static List<IBall> CreateBallList(this List<Mock<IBall>> list)
        {
            var result = new List<IBall>();
            foreach(var mb in list)
            {
                result.Add(mb.Object);
            }

            return result;
        }

        public static List<Mock<IBall>> SetAllMaterialNames(
            this List<Mock<IBall>> list, 
            string name)
        {
            foreach(var mb in list)
            {
                mb.SetupGet(x => x.MaterialName).Returns(name);
            }

            return list;
        }

        public static List<Mock<IBall>> SetPositionsInRow(
            this List<Mock<IBall>> list, 
            float distance)
        {
            Vector3 position = Vector3.zero;
            Vector3 increment = new Vector3(distance, 0, 0);

            foreach(var mb in list)
            {
                mb.SetupGet(x => x.TransformPosition).Returns(position);
                position += increment;
            }

            return list;
        }

        public static List<Mock<IBall>> SetReactorCommands(
            this List<Mock<IBall>> list,
            Mock<IFadeReactor> fade = null,
            Mock<IShrinkReactor> shrink = null,
            Mock<ISlipReactor> slip = null)
        {

            if (fade == null)
            {
                fade = new Mock<IFadeReactor>();
                fade.Setup(x => x.ActivateDestructionIn(It.IsAny<float>()));
            }

            if (shrink == null)
            {
                shrink = new Mock<IShrinkReactor>();
                shrink.Setup(x => x.ActivateDestructionIn(It.IsAny<float>()));
            }

            if (slip == null)
            {
                slip = new Mock<ISlipReactor>();
                slip.Setup(x => x.ActivateDestructionIn(It.IsAny<float>()));
            }

            foreach (var mb in list)
            {
                mb.Setup(x => x.GetComponent<IFadeReactor>()).Returns(fade.Object);
                mb.Setup(x => x.GetComponent<IShrinkReactor>()).Returns(shrink.Object);
                mb.Setup(x => x.GetComponent<ISlipReactor>()).Returns(slip.Object);
            }

            return list;
        }
    }
}
