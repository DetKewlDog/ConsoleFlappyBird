using System;
using System.Collections.Generic;

namespace ConsoleFlappyBird
{
    public class Pipe
    {
        public List<Vector> positions;
        private Grid grid;

        public Pipe(Grid grid)
        {
            this.grid = grid;
            this.positions = new List<Vector>();

            Random rnd = new Random();
            var holePos = rnd.Next(4, grid.height - 4);

            var v = new Vector(grid.width - 1, 0);
            for (int i = 0; i < grid.height; i++)
            {
                if (i >= holePos - 1 && i <= holePos + 1) continue;
                positions.Add(v + Vector.up * i);
            }

            foreach (var p in positions)
            {
                grid.SetTile(p, Tiles.Pipe);
            }
        }

        public MoveStatus Move(Vector v)
        {
            foreach (var p in positions) grid.SetTile(p, Tiles.Sky);
            for (int i = 0; i < positions.Count; i++)
            {
                positions[i] += v;
                if (!grid.PosInRange(positions[i])) return MoveStatus.Fail;
                grid.SetTile(positions[i], Tiles.Pipe);
            }
            return MoveStatus.Success;
        }
    }
}
