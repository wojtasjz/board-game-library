using NUnit.Framework;

namespace BoardGame.Engine.Tests
{
    public class GameIntegrationTests
    {
        private Game game;

        [SetUp]
        public void Setup()
        {
            this.game = new Game(new BoardFactory(new FourSidesMovingEngine(), new PositionValidatorsCreator()), 5, 1);
        }

        [TestCase("RMMMLMM", "3 2 N")]
        [TestCase("MRMLMRM", "2 2 E")]
        [TestCase("MMMMM", "0 4 N")]
        [TestCase("LMM", "0 0 W")]
        [TestCase("RMMMMMM", "4 0 E")]
        [TestCase("MRMLMRMLMRMLMRMLM", "4 4 N")]
        public void PlayerMovedToTheCorrectPosition(string commands, string position)
        {
            var result = this.game.MovePlayer(commands);

            Assert.That(result, Is.EqualTo(position));
        }
    }
}