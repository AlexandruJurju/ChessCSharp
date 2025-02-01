namespace Chess.Application.Moves;

// todo: later
public class CastlingMove(Position start, Position end) : Move(start, end)
{
    public override MoveType Type => MoveType.CASTLE;
    public override void Execute(Board board)
    {
        throw new NotImplementedException();
    }
}