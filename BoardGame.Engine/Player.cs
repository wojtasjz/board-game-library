namespace BoardGame.Engine
{
    public class Player : IPlayer
    {
        private PlayerPosition playerPosition;

        public Player() : this(0, 0, Direction.North)
        {
        }

        public Player(int positionX, int positionY, Direction direction)
        {
            this.SetPosition(positionX, positionY, direction);
        }

        public void TurnLeft()
        {
            this.SetPosition(this.playerPosition.X, this.playerPosition.Y, this.playerPosition.Direction.Previous());
        }

        public void TurnRight()
        {
            this.SetPosition(this.playerPosition.X, this.playerPosition.Y, this.playerPosition.Direction.Next());
        }

        public PlayerPosition GetPosition()
        {
            return this.playerPosition;
        }

        public void SetPosition(PlayerPosition newPlayerPosition)
        {
            this.playerPosition = newPlayerPosition;
        }

        private void SetPosition(int x, int y, Direction newDirection)
        {
            this.SetPosition(new PlayerPosition(x, y, newDirection));
        }
    }
}
