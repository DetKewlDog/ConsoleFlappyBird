using System;

namespace ConsoleFlappyBird
{
    public class Grid
    {
        public int width, height;
        public Tiles[,] grid;

        public Grid(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.grid = new Tiles[width, height];
        }

        public Grid(Grid other)
        {
            this.width = other.width;
            this.height = other.height;
            this.grid = other.grid;
        }

        public bool PosInRange(Vector pos) => PosInRange(pos.x, pos.y);
        public bool PosInRange(int x, int y) => x >= 0 && x < width && y >= 0 && y < height;

        public void SetTile(Vector pos, Tiles tile)
        {
            if (!PosInRange(pos)) return;
            grid[pos.x, pos.y] = tile;
        }

        public Tiles GetTile(Vector pos) => GetTile(pos.x, pos.y);
        public Tiles GetTile(int x, int y) => PosInRange(x, y) ? grid[x, y] : Tiles.Null;

        public Vector[] AllPositionsWithin()
        {
            Vector[] list = new Vector[width * height];
            for (int y = height - 1; y >= 0; y--)
            {
                for (int x = 0; x < width; x++)
                {
                    list[y * height + x] = new Vector(x, y);
                }
            }
            return list;
        }

        public void PrintGrid()
        {
            for (int y = height - 1; y >= 0; y--)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.SetCursorPosition(x * 2, y);
                    Console.BackgroundColor = Console.ForegroundColor = (ConsoleColor)GetTile(x, y);
                    Console.Write("  ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
    }
}
