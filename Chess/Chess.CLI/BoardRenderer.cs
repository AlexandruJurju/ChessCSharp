using Chess.Application;
using Chess.Application.Pieces;

namespace Chess.CLI;

public class BoardRenderer
{
    public void Render(Board board)
    {
        Console.WriteLine("  a b c d e f g h");
        for (int row = 0; row < 8; row++)
        {
            Console.Write($"{8 - row} ");
            for (int col = 0; col < 8; col++)
            {
                var piece = board[row, col];
                if (piece == null)
                {
                    Console.Write(". ");
                }
                else
                {
                    Console.Write($"{GetPieceSymbol(piece)} ");
                }
            }

            Console.WriteLine($"{8 - row}");
        }

        Console.WriteLine("  a b c d e f g h");
    }

    private string GetPieceSymbol(Piece piece)
    {
        return piece switch
        {
            King => piece.Color == Player.White ? "K" : "k",
            Queen => piece.Color == Player.White ? "Q" : "q",
            Rook => piece.Color == Player.White ? "R" : "r",
            Bishop => piece.Color == Player.White ? "B" : "b",
            Knight => piece.Color == Player.White ? "N" : "n",
            Pawn => piece.Color == Player.White ? "P" : "p",
            _ => "?"
        };
    }
}