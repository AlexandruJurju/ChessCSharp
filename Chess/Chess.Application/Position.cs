namespace Chess.Application;

public sealed class Position(int row, int column)
{
    public int Row { get; set; } = row;
    public int Column { get; set; } = column;

    public Player GetSquareColor()
    {
        if ((Row + Column) % 2 == 0)
        {
            return Player.White;
        }

        return Player.Black;
    }

    public static bool operator ==(Position position1, Position position2)
    {
        return position1.Equals(position2);
    }

    public static bool operator !=(Position position1, Position position2)
    {
        return !(position1 == position2);
    }


    public static Position operator +(Position position, Direction direction)
    {
        return new Position(position.Row + direction.RowDelta, position.Column + direction.ColDelta);
    }

    private bool Equals(Position other)
    {
        return Row == other.Row && Column == other.Column;
    }

    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) || obj is Position other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Row, Column);
    }
}