using NUnit.Framework;

namespace BoardGame.Engine.Tests
{
    public class OutOfBoardPositionValidatorTests
    {
        private const int Size = 5;
        private OutOfBoardPositionValidator positionValidator;

        [SetUp]
        public void SetUp()
        {
            this.positionValidator = new OutOfBoardPositionValidator(Size);
        }

        [TestCase(0, Size)]
        [TestCase(Size, 0)]
        [TestCase(Size, Size)]
        [TestCase(1, -1)]
        [TestCase(0, -1)]
        [TestCase(-1, -1)]
        public void ReturnFalse_WhenInvalidPosition(int x, int y)
        {
            var result = this.positionValidator.IsPositionValid(new PlayerPosition(x, y, Direction.North));

            Assert.That(result, Is.False);
        }

        [TestCase(0, Size - 1)]
        [TestCase(Size - 1, 0)]
        [TestCase(Size - 1, Size - 1)]
        [TestCase(0, 0)]
        [TestCase(2, 2)]
        public void ReturnTrue_WhenValidPosition(int x, int y)
        {
            var result = this.positionValidator.IsPositionValid(new PlayerPosition(x, y, Direction.North));

            Assert.That(result, Is.True);
        }
    }
}
