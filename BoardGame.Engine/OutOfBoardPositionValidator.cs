namespace BoardGame.Engine
{
    public class OutOfBoardPositionValidator : IPositionValidator
    {
        private readonly int boardWidth;
        private readonly int boardLength;

        public OutOfBoardPositionValidator(int boardSize)
        {
            this.boardLength = boardSize;
            this.boardWidth = boardSize;
        }

        public bool IsPositionValid(PlayerPosition playerPosition)
        {
            return IsPositionValid(playerPosition.X, this.boardWidth) && IsPositionValid(playerPosition.Y, this.boardLength);
        }

        private static bool IsPositionValid(int position, int size)
        {
            return position >= 0 && position < size;
        }
    }
}