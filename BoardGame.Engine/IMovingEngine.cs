namespace BoardGame.Engine
{
    public interface IMovingEngine
    {
        PlayerPosition GetNextPlayerPosition(PlayerPosition currentPlayerPosition);
    }
}
