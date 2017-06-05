using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IoC;
using Moq;
using Lib.Domain.Controllers;
using System.Collections.Generic;
using Lib.Interfaces;
using Lib.Domain.Configurations;
using Lib.Domain.Enums;
using Lib.Tests.Helpers;

namespace Lib.Tests.Domain.Controllers
{
    [TestClass]
    public class BallControllerTests
    {
        [TestCleanup]
        public void Cleanup()
        {
            Di.ResetDefaults();
        }

        [TestMethod]
        public void StartReaction_GivenOneBallWithMaterial_TriggersReactionForThatBall()
        {
            // Arrange
            var moqGameController = new Mock<IGameController>();
            var moqBallList = BallHelper.CreateMoqBallList(10);
            moqBallList = moqBallList.SetPositionsInRow(distance: 1f);
            moqBallList = moqBallList.SetAllMaterialNames("red");
            moqBallList[0].SetupGet(x => x.MaterialName).Returns("blue");
            var moqFade = new Mock<IFadeReactor>();
            moqFade.Setup(x => x.ActivateDestructionIn(It.IsAny<float>()));
            moqBallList.SetReactorCommands(fade: moqFade);
            var ballList = moqBallList.CreateBallList();
            moqGameController.SetupGet(x => x.BallCollection).Returns(ballList);
            Di.Bind<IGameController>().AsSingleton(moqGameController.Object);

            var moqGameConfig = new Mock<IGameConfig>();
            moqGameConfig.SetupGet(x => x.BallTouchRange).Returns(1.5f);
            moqGameConfig.SetupGet(x => x.CountMultiplier).Returns(1.01f);
            moqGameConfig.SetupGet(x => x.ScorePerBall).Returns(1);
            moqGameConfig.SetupGet(x => x.TimeBetweenReactions).Returns(0.02f);
            moqGameConfig.Setup(x => x.GetReactor()).Returns(ReactorTypes.Fade);
            Di.Bind<IGameConfig>().AsSingleton(moqGameConfig.Object);

            var moqScore = new Mock<IScore>();
            moqScore.SetupAllProperties();
            Di.Bind<IScore>().AsSingleton(moqScore.Object);

            var ballController = Di.Get<IBallController>();

            // Act
            ballController.StartReaction(ballList[0]);

            // Assert
            moqFade.Verify(x => x.ActivateDestructionIn(It.IsAny<float>()), Times.Once);
        }


        [TestMethod]
        public void StartReaction_GivenRedBallWithAnotherRedBall_WillTriggerTwice()
        {
            // Arrange
            var moqGameController = new Mock<IGameController>();
            var moqBallList = BallHelper.CreateMoqBallList(10);
            moqBallList = moqBallList.SetPositionsInRow(distance: 1f);
            moqBallList = moqBallList.SetAllMaterialNames("red");
            moqBallList[0].SetupGet(x => x.MaterialName).Returns("blue");
            moqBallList[1].SetupGet(x => x.MaterialName).Returns("blue");
            var moqFade = new Mock<IFadeReactor>();
            moqFade.Setup(x => x.ActivateDestructionIn(It.IsAny<float>()));
            moqBallList.SetReactorCommands(fade: moqFade);
            var ballList = moqBallList.CreateBallList();
            moqGameController.SetupGet(x => x.BallCollection).Returns(ballList);
            Di.Bind<IGameController>().AsSingleton(moqGameController.Object);

            var moqGameConfig = new Mock<IGameConfig>();
            moqGameConfig.SetupGet(x => x.BallTouchRange).Returns(1.5f);
            moqGameConfig.SetupGet(x => x.CountMultiplier).Returns(1.01f);
            moqGameConfig.SetupGet(x => x.ScorePerBall).Returns(1);
            moqGameConfig.SetupGet(x => x.TimeBetweenReactions).Returns(0.02f);
            moqGameConfig.Setup(x => x.GetReactor()).Returns(ReactorTypes.Fade);
            Di.Bind<IGameConfig>().AsSingleton(moqGameConfig.Object);

            var moqScore = new Mock<IScore>();
            moqScore.SetupAllProperties();
            Di.Bind<IScore>().AsSingleton(moqScore.Object);

            var ballController = Di.Get<IBallController>();

            // Act
            ballController.StartReaction(ballList[0]);

            // Assert
            moqFade.Verify(x => x.ActivateDestructionIn(It.IsAny<float>()), Times.Exactly(2));
        }
    }
}
