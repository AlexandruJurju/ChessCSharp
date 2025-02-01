using Chess.Application.Pieces;

namespace Chess.Application.Moves;

public class PawnPromotionMove(Position start, Position end, PieceTypes newPieceType) : Move(start, end)
{
    public override MoveType Type => MoveType.PAWN_PROMOTION;

    private Piece CreatePromotionPiece(Player color)
    {
        return newPieceType switch
        {
            PieceTypes.Knight => new Knight(color),
            PieceTypes.Rook => new Rook(color),
            PieceTypes.Bishop => new Bishop(color),
            _ => new Queen(color),
        };
    }

    public override void Execute(Board board)
    {
        Piece pawn = board[Start]!;
        board[Start] = null;

        Piece promotedPiece = CreatePromotionPiece(pawn.Color);
        promotedPiece.HasMoved = true;
        board[End] = promotedPiece;
    }
}