using Chess.Application.Pieces;

namespace Chess.Application;

public class Board
{
    private readonly Piece?[,] pieces = new Piece[8, 8];
    
    public bool IsPositionInBoard(Position position)
    {
        return position.Row is >= 0 and < 8 && position.Column is >= 0 and < 8;
    }

    public bool IsPositionEmpty(Position position)
    {
        return this[position] == null;
    }

    public void PlaceInitialPieces()
    {
        this[0, 0] = new Rook(Player.Black);
        this[0, 1] = new Knight(Player.Black);
        this[0, 2] = new Bishop(Player.Black);
        this[0, 3] = new Queen(Player.Black);
        this[0, 4] = new King(Player.Black);
        this[0, 5] = new Bishop(Player.Black);
        this[0, 6] = new Knight(Player.Black);
        this[0, 7] = new Rook(Player.Black);

        for (var i = 0; i < 8; i++)
        {
            this[1, i] = new Pawn(Player.Black);
        }

        this[7, 0] = new Rook(Player.White);
        this[7, 1] = new Knight(Player.White);
        this[7, 2] = new Bishop(Player.White);
        this[7, 3] = new Queen(Player.White);
        this[7, 4] = new King(Player.White);
        this[7, 5] = new Bishop(Player.White);
        this[7, 6] = new Knight(Player.White);
        this[7, 7] = new Rook(Player.White);

        for (var i = 0; i < 8; i++)
        {
            this[6, i] = new Pawn(Player.White);
        }
    }

    public Piece? this[int row, int col]
    {
        get => pieces[row, col];
        set => pieces[row, col] = value;
    }

    public Piece? this[Position position]
    {
        get => pieces[position.Row, position.Column];
        set => pieces[position.Row, position.Column] = value;
    }
}