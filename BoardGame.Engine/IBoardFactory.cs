namespace BoardGame.Engine
{
    public interface IBoardFactory
    {
        IBoard CreateBoard(int size, int playersCount);
    }
}
