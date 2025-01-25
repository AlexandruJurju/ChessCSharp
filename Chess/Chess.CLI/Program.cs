using Chess.Application;
using Chess.CLI;

Console.OutputEncoding = System.Text.Encoding.UTF8; 

Board board = new Board();
board.PlaceInitialPieces();

BoardRenderer boardRenderer = new BoardRenderer();
boardRenderer.Render(board);