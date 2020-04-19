using NUnit.Framework;

namespace BoardGame.Engine.Tests
{
    public class PlayerTests
    {
        [TestCase(Direction.North, Direction.East)]
        [TestCase(Direction.East, Direction.South)]
        [TestCase(Direction.South, Direction.West)]
        [TestCase(Direction.West, Direction.North)]
        public void TurnRight_TurnsPlayerToCorrectDirection(Direction start, Direction expected)
        {
            var player = new Player(0, 0, start);

            player.TurnRight();

            var playerPosition = player.GetPosition();
            Assert.That(playerPosition.Direction, Is.EqualTo(expected));
            Assert.That(playerPosition.X, Is.EqualTo(0));
            Assert.That(playerPosition.Y, Is.EqualTo(0));
        }

        [TestCase(Direction.North, Direction.West)]
        [TestCase(Direction.West, Direction.South)]
        [TestCase(Direction.South, Direction.East)]
        [TestCase(Direction.East, Direction.North)]
        public void TurnLeft_TurnsPlayerToCorrectDirection(Direction start, Direction expected)
        {
            var player = new Player(0, 0, start);

            player.TurnLeft();

            var playerPosition = player.GetPosition();
            Assert.That(playerPosition.Direction, Is.EqualTo(expected));
            Assert.That(playerPosition.X, Is.EqualTo(0));
            Assert.That(playerPosition.Y, Is.EqualTo(0));
        }

        [Test]
        public void SetPosition_SetsCorrectPosition()
        {
            var player = new Player();
            var newPosition = new PlayerPosition(2, 3, Direction.South);

            player.SetPosition(newPosition);

            var position = player.GetPosition();
            Assert.That(position, Is.EqualTo(newPosition));
        }
    }
}
