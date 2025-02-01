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
        var forwardMoves = GetForwardMovePositions(start, board).ToList();
        var diagonalMoves = GetDiagonalMovePositions(start, board);

        return forwardMoves.Concat(diagonalMoves);
    }

    private IEnumerable<Move> GetForwardMovePositions(Position start, Board board)
    {
        Position oneForward = start + _forward;

        // check if pawn can move one square forward
        if (CanMoveTo(oneForward, board))
        {
            if (oneForward.Row == 0 || oneForward.Row == 7)
            {
                var promotionMoves = new List<Move>()
                {
                    new PawnPromotionMove(start, oneForward, PieceTypes.Knight),
                    new PawnPromotionMove(start, oneForward, PieceTypes.Bishop),
                    new PawnPromotionMove(start, oneForward, PieceTypes.Rook),
                    new PawnPromotionMove(start, oneForward, PieceTypes.Queen),
                };

                foreach (var promotionMove in promotionMoves)
                {
                    yield return promotionMove;
                }
            }
            else
            {
                yield return new NormalMove(start, oneForward);
            }

            // pawn can move 2 forward only if it hasn't moved && there's no piece there
            Position twoForward = oneForward + _forward;
            if (!HasMoved && CanMoveTo(twoForward, board))
            {
                yield return new NormalMove(start, twoForward);
            }
        }
    }

    private IEnumerable<Move> GetDiagonalMovePositions(Position start, Board board)
    {
        foreach (var direction in new[] { Direction.E, Direction.W })
        {
            Position end = start + _forward + direction;

            if (CanCapture(end, board))
            {
                if (end.Row == 0 || end.Row == 7)
                {
                    var promotionMoves = new List<Move>()
                    {
                        new PawnPromotionMove(start, end, PieceTypes.Knight),
                        new PawnPromotionMove(start, end, PieceTypes.Bishop),
                        new PawnPromotionMove(start, end, PieceTypes.Rook),
                        new PawnPromotionMove(start, end, PieceTypes.Queen),
                    };

                    foreach (var promotionMove in promotionMoves)
                    {
                        yield return promotionMove;
                    }
                }
                else
                {
                    yield return new NormalMove(start, end);
                }
            }
        }
    }

    // override to check just diagonal moves, not forward + diagonal
    public override bool CanCaptureOpponentKing(Position start, Board board)
    {
        var diagonalMoves = GetDiagonalMovePositions(start, board);

        return diagonalMoves.Any(move =>
        {
            Piece? piece = board[move.End];

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