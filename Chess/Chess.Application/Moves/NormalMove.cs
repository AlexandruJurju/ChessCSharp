using Chess.Application.Pieces;

namespace Chess.Application.Moves;

public class NormalMove(Position start, Position end) : Move(start, end)
{
    public override MoveType Type => MoveType.NORMAL;

    public override void Execute(Board board)
    {
        var piece = board[Start];

        if (piece is null)
        {
            throw new NullReferenceException();
        }

        board[End] = piece;
        board[Start] = null;
        piece.HasMoved = true;
    }
}