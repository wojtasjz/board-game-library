using System.Collections.Generic;

namespace BoardGame.Engine
{
    public class PositionValidatorsCreator : IPositionValidatorsCreator
    {
        public IEnumerable<IPositionValidator> Create(int boardSize)
        {
            return new[] {new OutOfBoardPositionValidator(boardSize)};
        }
    }
}