using Moq;
using NUnit.Framework;

namespace BoardGame.Engine.Tests
{
    public class BoardTests
    {
        private const int Size = 5;
        private Mock<IPlayer> playerMock;
        private Mock<IMovingEngine> movingEngineMock;
        private Mock<IPositionValidatorsCreator> positionValidatorsCreatorMock;
        private Mock<IPositionValidator> positionValidatorMock;
        private Board board;

        [SetUp]
        public void Setup()
        {
            this.playerMock = new Mock<IPlayer>();
            this.movingEngineMock = new Mock<IMovingEngine>();
            this.positionValidatorsCreatorMock = new Mock<IPositionValidatorsCreator>();
            this.positionValidatorMock = new Mock<IPositionValidator>();
            this.positionValidatorsCreatorMock.Setup(x => x.Create(It.IsAny<int>()))
                .Returns(new[] {this.positionValidatorMock.Object});

            this.board = new Board(
                this.movingEngineMock.Object,
                this.positionValidatorsCreatorMock.Object,
                new[] { this.playerMock.Object },
                5);
        }

        [Test]
        public void TurnPlayerLeft_TurnsPlayer()
        {
            this.board.TurnPlayerLeft(0);

            this.playerMock.Verify(x => x.TurnLeft(), Times.Once);
        }

        [Test]
        public void TurnPlayerRight_TurnsPlayer()
        {
            this.board.TurnPlayerRight(0);

            this.playerMock.Verify(x => x.TurnRight(), Times.Once);
        }

        [Test]
        public void MovePlayer_GetsPlayerCurrentPosition()
        {
            this.playerMock.Setup(x => x.GetPosition()).Returns(new PlayerPosition(1, 1, Direction.North));
            this.movingEngineMock.Setup(x => x.GetNextPlayerPosition(It.IsAny<PlayerPosition>()))
                .Returns(new PlayerPosition(2, 2, Direction.South));
            this.positionValidatorMock.Setup(x => x.IsPositionValid(It.IsAny<PlayerPosition>())).Returns(true);

            this.board.MovePlayer(0);

            this.playerMock.Verify(x => x.GetPosition(), Times.Once);
        }

        [Test]
        public void MovePlayer_GetsPlayerNextPosition()
        {
            var currentPosition = new PlayerPosition(1, 1, Direction.North);
            this.playerMock.Setup(x => x.GetPosition()).Returns(currentPosition);
            this.movingEngineMock.Setup(x => x.GetNextPlayerPosition(It.IsAny<PlayerPosition>()))
                .Returns(new PlayerPosition(2, 2, Direction.South));
            this.positionValidatorMock.Setup(x => x.IsPositionValid(It.IsAny<PlayerPosition>())).Returns(true);

            this.board.MovePlayer(0);

            this.movingEngineMock.Verify(x => x.GetNextPlayerPosition(currentPosition), Times.Once);
        }

        [Test]
        public void MovePlayer_ChecksIfNextPlayerPositionIsValid()
        {
            var nextPosition = new PlayerPosition(1, 1, Direction.North);
            this.playerMock.Setup(x => x.GetPosition()).Returns(new PlayerPosition(1, 1, Direction.North));
            this.movingEngineMock.Setup(x => x.GetNextPlayerPosition(It.IsAny<PlayerPosition>()))
                .Returns(nextPosition);
            this.positionValidatorMock.Setup(x => x.IsPositionValid(It.IsAny<PlayerPosition>())).Returns(true);

            this.board.MovePlayer(0);

            this.positionValidatorMock.Verify(x => x.IsPositionValid(nextPosition), Times.Once);
        }

        [Test]
        public void MovePlayer_SetsPlayersPosition_IfNextPositionIsValid()
        {
            var nextPosition = new PlayerPosition(1, 1, Direction.North);
            this.playerMock.Setup(x => x.GetPosition()).Returns(new PlayerPosition(1, 1, Direction.North));
            this.movingEngineMock.Setup(x => x.GetNextPlayerPosition(It.IsAny<PlayerPosition>()))
                .Returns(nextPosition);
            this.positionValidatorMock.Setup(x => x.IsPositionValid(It.IsAny<PlayerPosition>())).Returns(true);

            this.board.MovePlayer(0);

            this.playerMock.Verify(x => x.SetPosition(nextPosition), Times.Once);
        } 

        [Test]
        public void MovePlayer_DoesNotSetPlayersPosition_IfNextPositionIsInvalid()
        {
            this.playerMock.Setup(x => x.GetPosition()).Returns(new PlayerPosition(1, 1, Direction.North));
            this.movingEngineMock.Setup(x => x.GetNextPlayerPosition(It.IsAny<PlayerPosition>()))
                .Returns(new PlayerPosition(2, 2, Direction.South));
            this.positionValidatorMock.Setup(x => x.IsPositionValid(It.IsAny<PlayerPosition>())).Returns(false);

            this.board.MovePlayer(0);

            this.playerMock.Verify(x => x.SetPosition(It.IsAny<PlayerPosition>()), Times.Never);
        }
    }
}
