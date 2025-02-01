using Chess.Application.Moves;

namespace Chess.Application.Pieces;

public class Bishop(Player color) : Piece
{
    public override Player Color { get; } = color;
    public override PieceTypes Type => PieceTypes.Bishop;

    public override IEnumerable<Move> GetMoves(Position start, Board board)
    {
        var availableEndPositions = GetAvailableMovesInDirections(start, board, Direction.Diagonals);
        return availableEndPositions.Select(end => new NormalMove(start, end));
    }

    public override Piece DeepCopy()
    {
        Bishop copy = new Bishop(Color);
        copy.HasMoved = HasMoved;
        return copy;
    }
}