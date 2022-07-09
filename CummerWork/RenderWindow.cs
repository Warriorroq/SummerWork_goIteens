namespace SummerWork
{
    public class RenderWindow : Singletone<RenderWindow>
    {
        private char[,] _buffer;
        private Vector2Int _size;
        private static int _debugLine;
        public RenderWindow()
        {
            SetSize(1, 1);
            ClearWindow();
        }
        public void SetSize(int height, int width)
        {
            _size = new Vector2Int(width, height);
            _buffer = new char[_size.y, _size.x];
        }
        public void ChangeCharacter(int height, int width, char symbol)
        {
            if (height < 0 || height >= _size.y)
                return;
            if (width < 0 || width >= _size.x)
                return;
            _buffer[height, width] = symbol;
        }
        public void ClearWindow()
        {
            for (int i = 0; i < _size.y; i++)
                for (int j = 0; j < _size.x; j++)
                    _buffer[i, j] = DrawCharacters.clearWindow;
        }
        public void Draw()
        {
            for (int i = 0; i < _size.y; i++)
            {
                for (int j = 0; j < _size.x; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write(_buffer[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

        }
        public static void Debug(object obj, bool clear = true)
        {
            Console.SetCursorPosition(0, Instance._size.y);
            if(clear)
                Console.Write(new string(' ', Console.WindowWidth));
            Console.Write(obj.ToString());
        }
    }
}
