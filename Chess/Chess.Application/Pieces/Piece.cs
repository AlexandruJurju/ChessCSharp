using Chess.Application.Moves;

namespace Chess.Application.Pieces;

public abstract class Piece
{
    public abstract Player Color { get; }
    public bool HasMoved { get; set; } = false;
    public abstract IEnumerable<Move> GetMoves(Position start, Board board);

    // method will be used to look at the directions that a piece can move to look for the pieces on the board
    protected IEnumerable<Position> GetAvailableMovesInDirections(Position start, Board board, Direction[] directions)
    {
        return directions.SelectMany(dir => GetAvailableMovesInDirection(start, board, dir));
    }
    private IEnumerable<Position> GetAvailableMovesInDirection(Position piecePosition, Board board, Direction direction)
    {
        // look for all positions in a given direction
        for (Position lookPosition = piecePosition + direction; board.IsPositionInBoard(lookPosition); lookPosition += direction)
        {
            // if empty - its valid position for move
            if (board.IsPositionEmpty(lookPosition))
            {
                yield return lookPosition;
                continue;
            }

            Piece piece = board[lookPosition]!;

            // if found piece is a different color then it can be captured and position is valid
            if (piece.Color != Color)
            {
                yield return lookPosition;
            }

            // Bishop, Rook, Queen cannot jump - don't need to continue checking direction if a friendly piece is encountered
            yield break;
        }
    }
    
    protected bool CanMoveTo(Position position, Board board)
    {
        return board.IsPositionInBoard(position) && board.IsPositionEmpty(position);
    }

    protected bool CanCapture(Position position, Board board)
    {
        if (!board.IsPositionInBoard(position) || board.IsPositionEmpty(position))
        {
            return false;
        }

        return board[position]!.Color != Color;
    }
}