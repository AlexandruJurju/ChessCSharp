using Chess.Application.Moves;

namespace Chess.Application.Pieces;

public class Bishop(Player color) : Piece
{
    public override Player Color { get; } = color;

    public override IEnumerable<Move> GetMoves(Position startPosition, Board board)
    {
        var availableEndPositions = GetAvailableMovesInDirections(startPosition, board, Direction.Diagonals);
        return availableEndPositions.Select(m => new NormalMove(startPosition, m));
    }
}