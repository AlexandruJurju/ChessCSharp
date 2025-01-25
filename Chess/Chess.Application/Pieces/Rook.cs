using Chess.Application.Moves;

namespace Chess.Application.Pieces;

public class Rook(Player color) : Piece
{
    public override Player Color { get; } = color;

    public override IEnumerable<Move> GetMoves(Position start, Board board)
    {
        var availableEndPositions = GetAvailableMovesInDirections(start, board, Direction.Cardinals);
        return availableEndPositions.Select(end => new NormalMove(start, end));
    }
}