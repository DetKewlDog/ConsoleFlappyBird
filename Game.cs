using System;
using static ConsoleFlappyBird.Core;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleFlappyBird
{
    public class Game
    {
        public Grid grid;

        public const int width = 15;

        public Player player;

        public int highScore = 0;
        public List<Pipe> pipes;

        public void Start()
        {
            grid = new Grid(width, width);
            CreateGrid(grid);

            pipes = new List<Pipe>();

            player = new Player(new Vector(width / 3, width / 2), grid);

            pipes.Add(new Pipe(grid));
        }

        public void Update()
        {
            if (player.isAlive)
            {
                pipes = pipes.Where(x => x.Move(Vector.left) != MoveStatus.Fail).ToList();
                grid.PrintGrid();
                Print(grid.height, "Score:", player.score, "\t\t\t\t\t\t\t\t\tHigh Score:", highScore);
                var mstatus = HandleInput();
                if (mstatus == MoveStatus.Success && PlayerPassedPipe())
                {
                    player.score++;
                    pipes.Add(new Pipe(grid));
                }
                if (mstatus == MoveStatus.Pipe || mstatus == MoveStatus.Fail) player.Kill();
            }
            else
            {
                highScore = Math.Max(highScore, player.score);

                Print(grid.height, "Game Over");
                Print(grid.height + 1, "Your score is", player.score, (highScore == player.score ? "(New high score!)" : ""));
                Print(grid.height + 2, "Your high score is", highScore);
                Print(grid.height + 3, "Press Enter to restart!");
                if (Console.KeyAvailable && Console.ReadKey().Key == ConsoleKey.Enter) NewGame();
            }
        }


        MoveStatus HandleInput()
        {
            Console.SetCursorPosition(width + 1, width + 1);
            Console.ForegroundColor = ConsoleColor.Black;
            return player.Move(Console.KeyAvailable && Console.ReadKey().Key == ConsoleKey.W ? Vector.down * 2 : Vector.up);
        }


        void CreateGrid(Grid g)
        {
            foreach (var pos in grid.AllPositionsWithin()) g.SetTile(pos, Tiles.Sky);
        }

        bool PlayerPassedPipe()
        {
            var v = new Vector(player.pos.x, 0);
            for (int i = 0; i < grid.height; i++)
            {
                if (grid.GetTile(v + Vector.up * i) == Tiles.Pipe) return true;
            }
            return false;
        }
    }
}
