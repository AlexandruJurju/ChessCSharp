using Chess.Application.Moves;

namespace Chess.Application.Pieces;

public class Knight(Player color) : Piece
{
    public override Player Color { get; } = color;
    public override PieceTypes Type => PieceTypes.Knight;
    
    public override IEnumerable<Move> GetMoves(Position start, Board board)
    {
        return GetMovePositions(start, board)
            .Select(end => new NormalMove(start, end));
    }

    public override Piece DeepCopy()
    {
        var copy = new Knight(Color)
        {
            HasMoved = HasMoved
        };
        return copy;
    }

    private IEnumerable<Position> GetPossibleMovePositions(Position start)
    {
        foreach (var verticalDirection in Direction.Vertical)
        {
            foreach (var horizontalDirection in Direction.Horizontal)
            {
                yield return start + verticalDirection * 2 + horizontalDirection;
                yield return start + horizontalDirection * 2 + verticalDirection;
            }
        }
    }

    private IEnumerable<Position> GetMovePositions(Position start, Board board)
    {
        return GetPossibleMovePositions(start)
            .Where(position => board.IsPositionInBoard(position) &&
                               (board.IsPositionEmpty(position) || CanCapture(position, board)));
    }
}