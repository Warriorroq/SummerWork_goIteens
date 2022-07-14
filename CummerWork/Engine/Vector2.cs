namespace SummerWork
{
    public class Vector2<T>
    {
        public T y;
        public T x;

        public Vector2()
        {
            x = default;
            y = default;
        }
        public Vector2(T x, T y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
