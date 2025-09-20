using SnakeGame.Models;

namespace SnakeGame.Engine
{
    public static class UIManager
    {
        public static void RenderBorder()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write('┌' + new string('─', GameConfig.WindowWidth - 2) + '┐');

            for (int i = 1; i < GameConfig.WindowHeight - 1; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write('│');

                Console.SetCursorPosition(GameConfig.WindowWidth - 1, i);
                Console.Write('│');
            }

            Console.SetCursorPosition(0, GameConfig.WindowHeight - 1);
            Console.Write('└' + new string('─', GameConfig.WindowWidth - 2) + '┘');
        }

        public static void DropFood(Tile[,] map)
        {
            var possibleCoordinates = new List<(int X, int Y)>();

            for (int i = 1; i < GameConfig.WindowWidth - 1; i++)
            {
                for (int j = 1; j < GameConfig.WindowHeight - 1; j++)
                {
                    if (map[i, j] == Tile.Open)
                        possibleCoordinates.Add((i, j));
                }
            }

            if (possibleCoordinates.Count == 0) return;

            (int x, int y) = possibleCoordinates[Random.Shared.Next(possibleCoordinates.Count)];

            map[x, y] = Tile.Food;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(x, y);
            Console.Write('+');
            Console.ResetColor();
        }

        public static void DisplayScore(int score)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, 0);
            Console.Write($"[Score: {score}]");
            Console.ResetColor();
        }

        public static void DisplayGameOverMessage()
        {
            Console.Clear();

            var message = $"=== GAME OVER - Score: {GameState.Score} ===";
            var exitMessage = "Press any key to exit...";

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.WindowHeight / 2);
            Console.WriteLine(message);
            Console.SetCursorPosition((Console.WindowWidth - exitMessage.Length) / 2, Console.WindowHeight / 2 + 2);
            Console.Write(exitMessage);
            Console.ResetColor();

            Console.ReadKey(true);
        }
    }
}
