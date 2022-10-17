using System;
using System.Threading;

namespace ConsoleFlappyBird
{
    public static class Core
    {
        const int FPS = 10;
        public static Game currentGame;

        static void Main(string[] args) => NewGame();

        public static void NewGame()
        {
            Console.Clear();
            Console.CursorVisible = false;
            var sleep = 1000 / FPS;

            int highScore = (currentGame != null ? currentGame.highScore : 0);

            currentGame = new Game();
            currentGame.highScore = highScore;
            currentGame.Start();
            while (true)
            {
                Thread.Sleep(sleep);
                currentGame.Update();
            }
        }

        public static void Print(int y, params dynamic[] objs)
        {
            Console.ForegroundColor = ConsoleColor.White;
            var s = string.Join(" ", objs);
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.SetCursorPosition(i, y);
                Console.Write(i < s.Length ? s[i] : ' ');
            }
        }
    }
}
