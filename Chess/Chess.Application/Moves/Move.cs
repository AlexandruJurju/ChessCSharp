namespace Chess.Application.Moves;

public abstract class Move(Position start, Position end)
{
    public Position Start { get; protected set; } = start;
    public Position End { get; protected set; } = end;
    public abstract MoveType Type { get; }
    public abstract void ExecuteMove(Board board);
}