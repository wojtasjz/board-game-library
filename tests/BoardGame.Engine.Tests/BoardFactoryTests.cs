using System;
using Moq;
using NUnit.Framework;

namespace BoardGame.Engine.Tests
{
    public class BoardFactoryTests
    {
        private BoardFactory boardFactory;

        [SetUp]
        public void Setup()
        {
            this.boardFactory = new BoardFactory(new Mock<IMovingEngine>().Object, new Mock<IPositionValidatorsCreator>().Object);
        }

        [Test]
        public void ThrowsException_WhenMovingEngineNotProvided()
        {
            Action action = () => new BoardFactory(null, new Mock<IPositionValidatorsCreator>().Object);

            Assert.That(action, Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ThrowsException_WhenPositionValidatorsCreatorNotProvided()
        {
            Action action = () => new BoardFactory(new Mock<IMovingEngine>().Object, null);

            Assert.That(action, Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ThrowsException_WhenSizeIncorrect()
        {
            Action action = () => this.boardFactory.CreateBoard(1, 1);

            Assert.That(action, Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void ReturnsBoard_WhenAllParametersCorrect()
        {
            var result = this.boardFactory.CreateBoard(5, 1);

            Assert.That(result, Is.Not.Null);
        }
    }
}
