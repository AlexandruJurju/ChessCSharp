namespace Chess.Application;

public sealed class Direction(int rowDelta, int colDelta)
{
    public int RowDelta { get; set; } = rowDelta;
    public int ColDelta { get; set; } = colDelta;

    public static Direction operator +(Direction direction1, Direction direction2)
    {
        return new Direction(direction1.RowDelta + direction2.RowDelta, direction1.ColDelta + direction2.ColDelta);
    }

    public static Direction operator -(Direction direction1, Direction direction2)
    {
        return new Direction(direction1.RowDelta - direction2.RowDelta, direction1.ColDelta - direction2.ColDelta);
    }

    public static Direction operator *(Direction direction1, int scalar)
    {
        return new Direction(direction1.RowDelta * scalar, direction1.ColDelta * scalar);
    }

    public static Direction E => new(0, 1);
    public static Direction W => new(0, -1);
    public static Direction N => new(-1, 0);
    public static Direction S => new(1, 0);

    public static Direction NE => N + E;
    public static Direction NW => N + W;
    public static Direction SE => S + E;
    public static Direction SW => S + W;

    public static Direction[] Horizontal = [E, W];
    public static Direction[] Vertical = [N, S];
    public static Direction[] Diagonals = [NE, SE, SW, NW];
    public static Direction[] Cardinals = [N, E, S, W];
    public static Direction[] All = [N, NE, E, SE, S, SW, W, NW];
}