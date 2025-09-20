using SnakeGame.Engine;
using SnakeGame.Models;

Console.CursorVisible = false;
Console.Write("Select speed [1], [2] (default), or [3]: ");

InputHandler.SetGameSpeed();

if (GameState.IsExitRequested)
{
    UIManager.DisplayGameOverMessage();
    return;
}

(var snakeX, var snakeY) = (GameConfig.StartX, GameConfig.StartY);

try
{
    Console.Clear();

    GameState.Snake.Enqueue((snakeX, snakeY));
    GameState.Map[snakeX, snakeY] = Tile.Snake;

    UIManager.RenderBorder();
    UIManager.DropFood(GameState.Map);

    Console.SetCursorPosition(snakeX, snakeY);
    Console.Write('@');

    while (!GameState.Direction.HasValue && !GameState.IsExitRequested)
    {
        InputHandler.GetDirection();
    }

    while (!GameState.IsExitRequested)
    {
        if (Console.WindowWidth != GameConfig.WindowWidth || Console.WindowHeight != GameConfig.WindowHeight)
        {
            UIManager.DisplayGameOverMessage();
            return;
        }

        switch (GameState.Direction)
        {
            case Direction.Up:
                snakeY = (snakeY - 1 < 1) ? GameConfig.WindowHeight - 2 : snakeY - 1;
                break;

            case Direction.Down:
                snakeY = (snakeY + 1 > GameConfig.WindowHeight - 2) ? 1 : snakeY + 1;
                break;

            case Direction.Left:
                snakeX = (snakeX - 1 < 1) ? GameConfig.WindowWidth - 2 : snakeX - 1;
                break;

            case Direction.Right:
                snakeX = (snakeX + 1 > GameConfig.WindowWidth - 2) ? 1 : snakeX + 1;
                break;
        }

        if (GameState.Map[snakeX, snakeY] == Tile.Snake) return;

        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(snakeX, snakeY);

        switch (GameState.Direction)
        {
            case Direction.Up:
                Console.Write(GameConfig.DirectionChars[0]);
                break;

            case Direction.Right:
                Console.Write(GameConfig.DirectionChars[1]);
                break;

            case Direction.Down:
                Console.Write(GameConfig.DirectionChars[2]);
                break;

            case Direction.Left:
                Console.Write(GameConfig.DirectionChars[3]);
                break;
        }

        Console.ResetColor();

        GameState.Snake.Enqueue((snakeX, snakeY));

        if (GameState.Map[snakeX, snakeY] == Tile.Food)
        {
            UIManager.DropFood(GameState.Map);
            UIManager.DisplayScore(GameState.Score += 1);
        }
        else
        {
            (int x, int y) = GameState.Snake.Dequeue();
            GameState.Map[x, y] = Tile.Open;

            Console.SetCursorPosition(x, y);
            Console.Write(' ');
        }

        GameState.Map[snakeX, snakeY] = Tile.Snake;

        if (Console.KeyAvailable)
            InputHandler.GetDirection();

        Thread.Sleep(GameState.SleepTime);
    }
}
finally
{
    UIManager.DisplayGameOverMessage();
}
