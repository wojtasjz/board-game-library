using System;

namespace BoardGame.Engine
{
    public class Game
    {
        private readonly IBoard board;

        public Game(IBoardFactory boardFactory, int boardSize, int playersCount)
        {
            if (boardFactory == null)
            {
                throw new ArgumentNullException(nameof(boardFactory), "All arguments needs to provided.");
            }

            if (playersCount != 1)
            {
                throw new ArgumentException("Only one player is supported now.", nameof(playersCount));
            }

            this.board = boardFactory.CreateBoard(boardSize, playersCount);
        }

        public string MovePlayer(string commands)
        {
            foreach (var command in commands.ToUpper())
            {
                switch (command)
                {
                    case 'L':
                        this.board.TurnPlayerLeft(0);
                        break;
                    case 'R':
                        this.board.TurnPlayerRight(0);
                        break;
                    case 'M':
                        this.board.MovePlayer(0);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(commands), "Invalid command");
                }
            }

            var playerPosition = this.board.GetPlayerPosition(0);

            return $"{playerPosition.X} {playerPosition.Y} {playerPosition.Direction.ToShortString()}";
        }
    }
}
