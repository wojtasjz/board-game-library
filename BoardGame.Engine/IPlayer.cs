namespace BoardGame.Engine
{
    public interface IPlayer
    {
        void TurnLeft();

        void TurnRight();

        PlayerPosition GetPosition();

        void SetPosition(PlayerPosition newPlayerPosition);
    }
}