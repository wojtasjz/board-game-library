namespace BoardGame.Engine
{
    public interface IBoard
    {
        void TurnPlayerRight(int playerIndex);

        void TurnPlayerLeft(int playerIndex);

        void MovePlayer(int playerIndex);

        PlayerPosition GetPlayerPosition(int playerIndex);
    }
}