using Chess.Application;
using Chess.CLI;

Console.OutputEncoding = System.Text.Encoding.UTF8;


Game game = new Game(new Board(), Player.White);
game.Board.PlaceInitialPieces();

ConsoleGame consoleGame = new ConsoleGame(game);
consoleGame.Render();

while (true)
{
    consoleGame.ProcessMove();
    consoleGame.Render();
}
