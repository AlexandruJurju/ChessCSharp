using Chess.Application.Moves;
using Chess.Application.Pieces;

namespace Chess.Application;

public sealed class Game(
    Board board,
    Player currentPlayer
)
{
    public Board Board { get; private set; } = board;
    public Player CurrentPlayer { get; private set; } = currentPlayer;

    public IEnumerable<Move> GetLegalMoves(Position position)
    {
        if (Board.IsPositionEmpty(position) || Board[position]!.Color != CurrentPlayer)
        {
            return [];
        }

        Piece piece = Board[position]!;

        var possibleMoves = piece.GetMoves(position, Board);

        return possibleMoves.Where(move => move.IsLegal(Board));
    }

    public void MakeMove(Move move)
    {
        move.Execute(Board);
        CurrentPlayer = CurrentPlayer.GetOpponent();
    }
}