namespace Chess.Application.Moves;

public abstract class Move(Position startPosition, Position endPosition)
{
    protected Position StartPosition { get; set; } = startPosition;
    protected Position EndPosition { get; set; } = endPosition;
    public abstract MoveType Type { get; }
    public abstract void ExecuteMove(Board board);
}