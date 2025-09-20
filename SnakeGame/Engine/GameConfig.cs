namespace SnakeGame.Engine
{
    public static class GameConfig
    {
        public static char[] DirectionChars { get; } = ['^', '>', 'v', '<'];
        public static int[] Velocities { get; } = [100, 70, 50];
        public static int WindowWidth { get; } = Console.WindowWidth;
        public static int WindowHeight { get; } = Console.WindowHeight;
        public static int StartX { get; } = WindowWidth / 2;
        public static int StartY { get; } = WindowHeight / 2;
    }
}
