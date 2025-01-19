using Chess.Application.Moves;

namespace Chess.Application.Pieces;

public class Rook(Player color) : Piece
{
    public override Player Color { get; } = color;

    public override IEnumerable<Move> GetMoves(Position startPosition, Board board)
    {
        var availableEndPositions = GetAvailableMovesInDirections(startPosition, board, Direction.Cardinals);
        return availableEndPositions.Select(m => new NormalMove(startPosition, m));
    }
}