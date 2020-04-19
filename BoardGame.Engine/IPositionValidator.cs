namespace BoardGame.Engine
{
    public interface IPositionValidator
    {
        bool IsPositionValid(PlayerPosition playerPosition);
    }
}