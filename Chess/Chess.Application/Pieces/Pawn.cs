using Chess.Application.Moves;

namespace Chess.Application.Pieces;

public sealed class Pawn(Player color) : Piece
{
    public override Player Color { get; } = color;

    public override IEnumerable<Move> GetMoves(Position startPosition, Board board)
    {
        throw new NotImplementedException();
    }
}