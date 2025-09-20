using SnakeGame.Models;

namespace SnakeGame.Engine
{
    public static class InputHandler
    {
        public static void SetGameSpeed()
        {
            while (true)
            {
                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.D1:
                        GameState.SleepTime = TimeSpan.FromMilliseconds(GameConfig.Velocities[0]);
                        return;

                    case ConsoleKey.Enter or ConsoleKey.D2:
                        GameState.SleepTime = TimeSpan.FromMilliseconds(GameConfig.Velocities[1]);
                        return;

                    case ConsoleKey.D3:
                        GameState.SleepTime = TimeSpan.FromMilliseconds(GameConfig.Velocities[2]);
                        return;

                    case ConsoleKey.Escape:
                        GameState.IsExitRequested = true;
                        return;

                    default:
                        Console.Clear();
                        Console.Write("Invalid input. Please select [1], [2], or [3]: ");
                        break;
                }
            }
        }

        public static void GetDirection()
        {
            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.W or ConsoleKey.UpArrow:
                    if (GameState.Direction != Direction.Down)
                        GameState.Direction = Direction.Up;
                    break;

                case ConsoleKey.D or ConsoleKey.RightArrow:
                    if (GameState.Direction != Direction.Left)
                        GameState.Direction = Direction.Right;
                    break;

                case ConsoleKey.S or ConsoleKey.DownArrow:
                    if (GameState.Direction != Direction.Up)
                        GameState.Direction = Direction.Down;
                    break;

                case ConsoleKey.A or ConsoleKey.LeftArrow:
                    if (GameState.Direction != Direction.Right)
                        GameState.Direction = Direction.Left;
                    break;

                case ConsoleKey.Escape:
                    GameState.IsExitRequested = true;
                    break;
            }
        }
    }
}
