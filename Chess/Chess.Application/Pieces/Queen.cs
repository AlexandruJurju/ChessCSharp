using Chess.Application.Moves;

namespace Chess.Application.Pieces;

public class Queen(Player color) : Piece
{
    public override Player Color { get; } = color;

    public override IEnumerable<Move> GetMoves(Position start, Board board)
    {
        var availableEndPositions = GetAvailableMovesInDirections(start, board, Direction.All);
        return availableEndPositions.Select(m => new NormalMove(start, m));
    }
}