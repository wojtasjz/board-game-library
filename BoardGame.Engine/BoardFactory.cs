using System;
using System.Linq;

namespace BoardGame.Engine
{
    public class BoardFactory : IBoardFactory
    {
        private readonly IMovingEngine movingEngine;
        private readonly IPositionValidatorsCreator positionValidatorsCreator;

        public BoardFactory(IMovingEngine movingEngine, IPositionValidatorsCreator positionValidatorsCreator)
        {
            this.movingEngine = movingEngine ?? throw new ArgumentNullException(nameof(movingEngine), "All arguments needs to provided.");
            this.positionValidatorsCreator = positionValidatorsCreator ?? throw new ArgumentNullException(nameof(positionValidatorsCreator), "All arguments needs to provided.");
        }

        public IBoard CreateBoard(int size, int playersCount)
        {
            if (size < 2)
            {
                throw new ArgumentException("Board size needs to be greater than 1.", nameof(size));
            }

            return new Board(
                this.movingEngine,
                this.positionValidatorsCreator,
                Enumerable.Repeat<IPlayer>(new Player(), playersCount),
                size);
        }
    }
}