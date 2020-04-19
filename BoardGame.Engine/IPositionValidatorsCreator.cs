using System.Collections.Generic;

namespace BoardGame.Engine
{
    public interface IPositionValidatorsCreator
    {
        IEnumerable<IPositionValidator> Create(int boardSize);
    }
}