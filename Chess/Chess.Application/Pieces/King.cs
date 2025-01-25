using Chess.Application.Moves;

namespace Chess.Application.Pieces;

public class King(Player color) : Piece
{
    public override Player Color { get; } = color;

    public override IEnumerable<Move> GetMoves(Position start, Board board)
    {
        return GetMovePositions(start, board)
            .Select(end => new NormalMove(start, end));
    }

    private IEnumerable<Position> GetMovePositions(Position start, Board board)
    {
        foreach (var direction in Direction.All)
        {
            Position end = start + direction;

            if (!board.IsPositionInBoard(end))
            {
                continue;
            }

            if (board.IsPositionEmpty(end) || CanCapture(end, board))
            {
                yield return end;
            }
        }
    }
}