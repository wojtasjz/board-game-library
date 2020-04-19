using System;
using Moq;
using NUnit.Framework;

namespace BoardGame.Engine.Tests
{
    public class GameUnitTests
    {
        private Mock<IBoardFactory> boardFactoryMock;
        private Mock<IBoard> boardMock;
        private Game game;

        [SetUp]
        public void Setup()
        {
            this.boardFactoryMock = new Mock<IBoardFactory>();
            this.boardMock = new Mock<IBoard>();
            this.boardFactoryMock.Setup(x => x.CreateBoard(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(this.boardMock.Object);
            this.game = new Game(this.boardFactoryMock.Object, 5, 1);
        }

        [Test]
        public void ThrowsException_WhenBoardFactoryNotProvided()
        {
            Action action = () => new Game(null, 5, 1);

            Assert.That(action, Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ThrowsException_WhenPlayersCountDifferentThan1()
        {
            Action action = () => new Game(new Mock<IBoardFactory>().Object, 5, 2);

            Assert.That(action, Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void ThrowsException_WhenInvalidCommand()
        {
            Action action = () => this.game.MovePlayer("S");

            Assert.That(action, Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void ReturnsPlayerPosition_WhenValidCommand()
        {
            this.boardMock.Setup(x => x.GetPlayerPosition(It.IsAny<int>()))
                .Returns(new PlayerPosition(0, 1, Direction.North));

            var result = this.game.MovePlayer("M");

            Assert.That(result, Is.EqualTo("0 1 N"));
        }

        [Test]
        public void TurnPlayerLeft_WhenLCommand()
        {
            this.boardMock.Setup(x => x.GetPlayerPosition(It.IsAny<int>()))
                .Returns(new PlayerPosition(0, 1, Direction.North));

            var result = this.game.MovePlayer("L");

            this.boardMock.Verify(x => x.TurnPlayerLeft(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void TurnPlayerRight_WhenRCommand()
        {
            this.boardMock.Setup(x => x.GetPlayerPosition(It.IsAny<int>()))
                .Returns(new PlayerPosition(0, 1, Direction.North));

            var result = this.game.MovePlayer("R");

            this.boardMock.Verify(x => x.TurnPlayerRight(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void MovesPlayer_WhenMCommand()
        {
            this.boardMock.Setup(x => x.GetPlayerPosition(It.IsAny<int>()))
                .Returns(new PlayerPosition(0, 1, Direction.North));

            var result = this.game.MovePlayer("M");

            this.boardMock.Verify(x => x.MovePlayer(It.IsAny<int>()), Times.Once);
        }
    }
}