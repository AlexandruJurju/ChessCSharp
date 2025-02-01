namespace Chess.Application.Moves;

public abstract class Move(Position start, Position end)
{
    public Position Start { get; protected set; } = start;
    public Position End { get; protected set; } = end;
    public abstract MoveType Type { get; }

    public abstract void Execute(Board board);

    // todo: make this faster for min-max
    public virtual bool IsLegal(Board board)
    {
        // to find out if a move is legal - make a copy of the board and execute the move
        // then check to see if the king is in check

        Player currentPlayer = board[Start]!.Color;
        Board boardCopy = board.DeepCopy();
        Execute(boardCopy);
        return !board.IsInCheck(currentPlayer);
    }
}