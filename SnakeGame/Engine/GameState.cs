using SnakeGame.Models;

namespace SnakeGame.Engine
{
    public static class GameState
    {
        public static Tile[,] Map { get; set; } = new Tile[GameConfig.WindowWidth, GameConfig.WindowHeight];
        public static Queue<(int x, int y)> Snake { get; set; } = new();
        public static int Score { get; set; } = 0;
        public static Direction? Direction { get; set; } = null;
        public static TimeSpan SleepTime { get; set; }
        public static bool IsExitRequested { get; set; } = false;
    }
}
