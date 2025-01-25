using Chess.Application.Moves;

namespace Chess.Application.Pieces;

public sealed class Pawn : Piece
{
    public Pawn(Player color)
    {
        Color = color;

        if (color == Player.White)
        {
            _forward = Direction.N;
        }

        _forward = Direction.S;
    }

    public override Player Color { get; }

    private readonly Direction _forward;

    // pawns move
    // in the direction of the enemy
    // 2 squares as their first move
    // diagonally only if they capture an enemy piece
    public override IEnumerable<Move> GetMoves(Position start, Board board)
    {
        var forwardMoves = GetForwardMovePositions(start, board);
        var diagonalMoves = GetDiagonalMovePositions(start, board);

        return forwardMoves.Concat(diagonalMoves)
            .Select(end => new NormalMove(start, end));
    }

    private IEnumerable<Position> GetForwardMovePositions(Position start, Board board)
    {
        Position oneForward = start + _forward;

        // check if pawn can move one square forward
        if (CanMoveTo(oneForward, board))
        {
            yield return oneForward;

            // pawn can move 2 forward only if it hasn't moved && there's no piece there
            Position twoForward = oneForward + _forward;
            if (!HasMoved && CanMoveTo(twoForward, board))
            {
                yield return twoForward;
            }
        }
    }

    private IEnumerable<Position> GetDiagonalMovePositions(Position start, Board board)
    {
        foreach (var direction in new Direction[] { Direction.E, Direction.W })
        {
            Position end = start + _forward + direction;

            if (CanCapture(end, board))
            {
                yield return end;
            }
        }
    }
}