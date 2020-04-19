using NUnit.Framework;

namespace BoardGame.Engine.Tests
{
    public class FourSidesMovingEngineTests
    {
        [TestCase(Direction.North, 1, 2)]
        [TestCase(Direction.South, 1, 0)]
        [TestCase(Direction.East, 2, 1)]
        [TestCase(Direction.West, 0, 1)]
        public void ReturnsCorrectNewPosition(Direction startDirection, int expectedX, int expectedY)
        {
            var movingEngine = new FourSidesMovingEngine();

            var result = movingEngine.GetNextPlayerPosition(new PlayerPosition(1, 1, startDirection));

            var expectedPosition = new PlayerPosition(expectedX, expectedY, startDirection);
            Assert.That(result, Is.EqualTo(expectedPosition));
        }
    }
}
