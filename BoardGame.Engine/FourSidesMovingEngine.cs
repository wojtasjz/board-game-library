namespace BoardGame.Engine
{
    public class FourSidesMovingEngine : IMovingEngine
    {
        private const int MoveLength = 1;

        public PlayerPosition GetNextPlayerPosition(PlayerPosition currentPlayerPosition)
        {
            var playerPositionX = currentPlayerPosition.X;
            var playerPositionY = currentPlayerPosition.Y;
            switch (currentPlayerPosition.Direction)
            {
                case Direction.North:
                    playerPositionY += MoveLength;
                    break;
                case Direction.East:
                    playerPositionX += MoveLength;
                    break;
                case Direction.South:
                    playerPositionY -= MoveLength;
                    break;
                case Direction.West:
                    playerPositionX -= MoveLength;
                    break;
            }

            return new PlayerPosition(playerPositionX, playerPositionY, currentPlayerPosition.Direction);
        }
    }
}