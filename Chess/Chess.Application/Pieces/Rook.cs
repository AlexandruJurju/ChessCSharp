using Chess.Application.Moves;

namespace Chess.Application.Pieces;

public class Rook(Player color) : Piece
{
    public override Player Color { get; } = color;
    public override PieceTypes Type => PieceTypes.Rook;

    public override IEnumerable<Move> GetMoves(Position start, Board board)
    {
        var availableEndPositions = GetAvailableMovesInDirections(start, board, Direction.Cardinals);
        return availableEndPositions.Select(end => new NormalMove(start, end));
    }

    public override Piece DeepCopy()
    {
        var copy = new Rook(Color)
        {
            HasMoved = HasMoved
        };
        return copy;
    }
}