using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerWork
{
    public class Vector2<T>
    {
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
        public T y;
        public T x;
    }
}
