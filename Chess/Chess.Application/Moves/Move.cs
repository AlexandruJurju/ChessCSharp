namespace Chess.Application.Moves;

public abstract class Move(Position start, Position end)
{
    protected Position Start { get; set; } = start;
    protected Position End { get; set; } = end;
    public abstract MoveType Type { get; }
    public abstract void ExecuteMove(Board board);
}