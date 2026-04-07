namespace RogueLib.Entities
{
    public struct Vector2
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Vector2() : this(0, 0) { }

        public static Vector2 operator +(Vector2 a, Vector2 b)
            => new Vector2(a.X + b.X, a.Y + b.Y);

        public static Vector2 operator -(Vector2 a, Vector2 b)
            => new Vector2(a.X - b.X, a.Y - b.Y);

        public static bool operator ==(Vector2 a, Vector2 b)
            => a.Equals(b);

        public static bool operator !=(Vector2 a, Vector2 b)
            => !a.Equals(b);

        public override bool Equals(object? obj)
        {
            if (obj is Vector2 other)
                return X == other.X && Y == other.Y;

            return false;
        }

        public override int GetHashCode()
            => HashCode.Combine(X, Y);

        public override string ToString()
            => $"({X}, {Y})";

        public static int ManhattanDistance(Vector2 a, Vector2 b)
            => Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
    }
}