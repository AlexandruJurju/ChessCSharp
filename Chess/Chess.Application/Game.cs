using Chess.Application.Moves;
using Chess.Application.Pieces;

namespace Chess.Application;

public sealed class Game(
    Board board,
    Player currentPlayer
)
{
    public Board Board { get; private set; } = board;
    public Player CurrentPlayer { get; private set; } = currentPlayer;
    public Result? Result { get; set; }

    public IEnumerable<Move> GetLegalMoves(Position position)
    {
        if (Board.IsPositionEmpty(position) || Board[position]!.Color != CurrentPlayer)
        {
            return [];
        }

        Piece piece = Board[position]!;

        var possibleMoves = piece.GetMoves(position, Board);

        return possibleMoves.Where(move => move.IsLegal(Board));
    }

    public void MakeMove(Move move)
    {
        move.Execute(Board);
        CurrentPlayer = CurrentPlayer.GetOpponent();
        CheckForGameOver();
    }

    public IEnumerable<Move> GetAllLegalMovesForPlayer(Player player)
    {
        IEnumerable<Move> allPlayerMoves = Board.GetAllPiecePositionsForPlayer(player)
            .SelectMany(position =>
            {
                Piece piece = Board[position]!;
                return piece.GetMoves(position, Board);
            });

        return allPlayerMoves.Where(move => move.IsLegal(Board));
    }

    public void CheckForGameOver()
    {
        if (!GetAllLegalMovesForPlayer(CurrentPlayer).Any())
        {
            if (Board.IsInCheck(CurrentPlayer))
            {
                Result = Result.Win(CurrentPlayer.GetOpponent());
            }

            Result = Result.Draw(EndReason.Stalemate);
        }
    }

    public bool IsGameOver()
    {
        return Result != null;
    }
}