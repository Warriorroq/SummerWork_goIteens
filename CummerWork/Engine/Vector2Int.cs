namespace SummerWork
{
    public class Vector2Int : Vector2<int>
    {
        public Vector2Int(int x, int y) : base(x, y) { }
        public static Vector2Int operator -(Vector2Int a) 
            => new Vector2Int(-a.x, a.y);
        public static Vector2Int operator +(Vector2Int a, Vector2Int b)
            => new Vector2Int(a.x + b.x, a.y + b.y);
        public static Vector2Int operator -(Vector2Int a, Vector2Int b)
            => new Vector2Int(a.x - b.x, a.y - b.y);
        public static Vector2Int operator *(Vector2Int a, Vector2Int b)
            => new Vector2Int(a.x * b.x, a.y * b.y);
        public static Vector2Int operator /(Vector2Int a, Vector2Int b)
            => new Vector2Int(a.x / b.x, a.y / b.y);
        public static Vector2Int operator /(Vector2Int a, int b)
            => new Vector2Int(a.x / b, a.y / b);
        public static Vector2Int operator *(Vector2Int a, int b)
            => new Vector2Int(a.x * b, a.y * b);
        public static bool operator ==(Vector2Int a, Vector2Int b)
            => a.x == b.x && a.y == b.y;
        public static bool operator !=(Vector2Int a, Vector2Int b)
            => a.x != b.x && a.y != b.y;
        public override string ToString() => $"({x}:{y})";
    }
}
