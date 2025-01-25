namespace Chess.Application;

public static class PlayerExtensions
{
    public static Player GetOpponent(this Player player) => player switch
    {
        Player.White => Player.Black,
        Player.Black => Player.White,
        Player.None => Player.None,
        _ => throw new ArgumentOutOfRangeException(nameof(player))
    };
}