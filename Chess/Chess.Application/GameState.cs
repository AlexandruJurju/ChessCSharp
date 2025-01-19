namespace Chess.Application;

internal sealed class GameState(
    Board board,
    Player currentPlayer
)
{
    public Board Board { get; private set; } = board;
    public Player CurrentPlayer { get; private set; } = currentPlayer;
}