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
        else
        {
            _forward = Direction.S;
        }
    }

    public override Player Color { get; }

    private readonly Direction _forward;
    public override PieceTypes Type => PieceTypes.Pawn;

    // pawns move
    // in the direction of the enemy
    // 2 squares as their first move
    // diagonally only if they capture an enemy piece
    public override IEnumerable<Move> GetMoves(Position start, Board board)
    {
        var forwardMovePositions = GetForwardMovePositions(start, board).ToList();
        var diagonalMovePositions = GetDiagonalMovePositions(start, board);

        return forwardMovePositions.Concat(diagonalMovePositions)
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

    // override to check just diagonal moves, not forward + diagonal
    public override bool CanCaptureOpponentKing(Position start, Board board)
    {
        var diagonalMoves = GetDiagonalMovePositions(start, board);

        return diagonalMoves.Any(end =>
        {
            Piece? piece = board[end];

            return piece != null && piece.Type == PieceTypes.King;
        });
    }

    public override Piece DeepCopy()
    {
        var copy = new Pawn(Color)
        {
            HasMoved = HasMoved
        };
        return copy;
    }
}