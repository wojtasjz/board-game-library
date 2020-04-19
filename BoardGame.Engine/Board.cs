using System.Collections.Generic;
using System.Linq;

namespace BoardGame.Engine
{
    public class Board : IBoard
    {
        private readonly int width;
        private readonly int length;
        private readonly IEnumerable<IPlayer> players;
        private readonly IMovingEngine movingEngine;
        private readonly IEnumerable<IPositionValidator> positionValidators;

        public Board(IMovingEngine movingEngine, IPositionValidatorsCreator positionValidatorsCreator, IEnumerable<IPlayer> players, int size)
        {
            this.movingEngine = movingEngine;
            this.positionValidators = positionValidatorsCreator.Create(size);
            this.players = players;
            this.width = size;
            this.length = size;
        }

        public void TurnPlayerRight(int playerIndex)
        {
            this.players.ElementAt(playerIndex).TurnRight();
        }

        public void TurnPlayerLeft(int playerIndex)
        {
            this.players.ElementAt(playerIndex).TurnLeft();
        }

        public void MovePlayer(int playerIndex)
        {
            var player = this.players.ElementAt(playerIndex);
            var currentPlayerPosition = player.GetPosition();
            var newPlayerPosition = this.movingEngine.GetNextPlayerPosition(currentPlayerPosition);

            if (this.CanMoveToPosition(newPlayerPosition))
            {
                player.SetPosition(newPlayerPosition);
            }
        }

        public PlayerPosition GetPlayerPosition(int playerIndex)
        {
            return this.players.ElementAt(playerIndex).GetPosition();
        }

        private bool CanMoveToPosition(PlayerPosition playerPosition)
        {
            return this.positionValidators.All(validator => validator.IsPositionValid(playerPosition));
        }
    }
}
