using Chess.Application.Pieces;

namespace Chess.Application.Moves;

public class NormalMove(Position startPosition, Position endPosition) : Move(startPosition, endPosition)
{
    public override MoveType Type => MoveType.NORMAL;

    public override void ExecuteMove(Board board)
    {
        var piece = board[StartPosition];

        if (piece is null)
        {
            throw new NullReferenceException();
        }

        board[EndPosition] = piece;
        board[StartPosition] = null;
        piece.HasMoved = true;
    }
}