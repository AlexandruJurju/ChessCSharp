using Chess.Application;
using Chess.Application.Moves;
using Chess.Application.Pieces;

namespace Chess.CLI;

public class ConsoleGame
{
    private readonly Game _game;

    public ConsoleGame(Game game)
    {
        _game = game;
    }

    public void Render()
    {
        Console.WriteLine("  0 1 2 3 4 5 6 7"); 
        for (int row = 0; row < 8; row++)
        {
            Console.Write($"{row} "); 
            for (int col = 0; col < 8; col++)
            {
                var piece = _game.Board[row, col];
                if (piece == null)
                {
                    Console.Write(". ");
                }
                else
                {
                    Console.Write($"{GetPieceSymbol(piece)} ");
                }
            }

            Console.WriteLine($"{row}");
        }

        Console.WriteLine("  0 1 2 3 4 5 6 7");
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
    
    public void ProcessMove()
    {
        Console.WriteLine($"{_game.CurrentPlayer}'s turn. Enter move (e.g., 'e2 e4'):");
        string? input = Console.ReadLine();

        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Invalid input. Please try again.");
            return;
        }

        string[] parts = input.Split(' ');
        if (parts.Length != 2)
        {
            Console.WriteLine("Invalid input format. Please enter move in the format 'e2 e4'.");
            return;
        }

        Position? from = ParsePosition(parts[0]);
        Position? to = ParsePosition(parts[1]);

        if (from is null || to is null)
        {
            Console.WriteLine("Invalid position. Please try again.");
            return;
        }

        var legalMoves = _game.GetLegalMoves(from);
        Move? move = legalMoves.FirstOrDefault(m => m.End == to);

        if (move == null)
        {
            Console.WriteLine("Invalid move. Please try again.");
            return;
        }

        _game.MakeMove(move);
        Render();
    }

    private Position? ParsePosition(string pos)
    {
        if (pos.Length != 2)
        {
            return null;
        }

        char colChar = pos[0];
        char rowChar = pos[1];

        if (colChar < '0' || colChar > '7' || rowChar < '0' || rowChar > '7')
        {
            return null;
        }

        int col = colChar - '0'; 
        int row = rowChar - '0';

        return new Position(row, col);
    }
}