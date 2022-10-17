namespace ConsoleFlappyBird
{
    public class Player
    {
        public Vector pos;
        public int score;

        public Grid grid;
        public Grid origGrid;

        public bool isAlive;

        public Player(Vector pos, Grid grid)
        {
            this.pos = pos;
            this.score = 0;

            this.grid = grid;

            this.isAlive = true;

            grid.SetTile(pos, Tiles.Bird);
        }

        public MoveStatus Move(Vector v)
        {
            MoveStatus r = MoveStatus.Fail;
            var lastPos = pos;
            v += pos;
            if (!grid.PosInRange(v)) return r;
            if (grid.GetTile(v) == Tiles.Pipe) r = MoveStatus.Pipe;
            grid.SetTile(v, Tiles.Bird);
            grid.SetTile(lastPos, Tiles.Sky);
            pos = v;
            r = r != MoveStatus.Pipe ? MoveStatus.Success : MoveStatus.Pipe;
            return r;
        }

        public void Kill() => this.isAlive = false;
    }
}
