namespace ConsoleFlappyBird
{
    public class Vector
    {
        public static readonly Vector zero = new Vector(0, 0);
        public static readonly Vector one = new Vector(1, 1);
        public static readonly Vector right = new Vector(1, 0);
        public static readonly Vector up = new Vector(0, 1);
        public static readonly Vector left = new Vector(-1, 0);
        public static readonly Vector down = new Vector(0, -1);

        public int x;
        public int y;

        public Vector(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector operator +(Vector a, Vector b) => new Vector(a.x + b.x, a.y + b.y);
        public static Vector operator -(Vector a, Vector b) => new Vector(a.x - b.x, a.y - b.y);
        public static Vector operator *(Vector a, Vector b) => new Vector(a.x * b.x, a.y * b.y);
        public static Vector operator /(Vector a, Vector b) => new Vector(a.x / b.x, a.y / b.y);
        public static Vector operator +(Vector a, int b) => new Vector(a.x + b, a.y + b);
        public static Vector operator -(Vector a, int b) => new Vector(a.x - b, a.y - b);
        public static Vector operator *(Vector a, int b) => new Vector(a.x * b, a.y * b);
        public static Vector operator /(Vector a, int b) => new Vector(a.x / b, a.y / b);
        public static bool operator ==(Vector a, Vector b) => a.x == b.x && a.y == b.y;
        public static bool operator !=(Vector a, Vector b) => a.x != b.x || a.y != b.y;

        public override string ToString() => $"{x} {y}";
    }
}
