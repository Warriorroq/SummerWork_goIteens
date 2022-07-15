namespace SummerWork
{
    public class RenderWindow : Singletone<RenderWindow>
    {
        public Vector2Int Size
        {
            get => _size;
        }
        private Vector2Int _size;
        private Dictionary<uint, (char[,], char)> _buffers;
        private const char NonDrawableSymbol = '\0';
        public RenderWindow()
        {
            _buffers = new Dictionary<uint, (char[,], char)>();
            SetSize(1, 1);
            ClearWindows();
        }
        public void CreateLayer(uint layer, char clearChar = NonDrawableSymbol)
            => _buffers.Add(layer, (new char[_size.y, _size.x], clearChar));
        public void SetSize(int height, int width)
        {
            _size = new Vector2Int(width, height);
            foreach (var key in _buffers.Keys)
                _buffers[key] = (new char[height, width], _buffers[key].Item2);
            ClearWindows();
        }
        public void ChangeCharacter(int height, int width, char symbol, uint layer = 0)
        {
            if (height < 0 || height >= _size.y)
                return;
            if (width < 0 || width >= _size.x)
                return;
            if(_buffers.ContainsKey(layer))
                _buffers[layer].Item1[height, width] = symbol;
        }
        public void ClearWindows()
        {
            foreach (var key in _buffers.Keys)
            {
                for (int i = 0; i < _size.y; i++)
                    for (int j = 0; j < _size.x; j++)
                        _buffers[key].Item1[i, j] = _buffers[key].Item2;
            }
        }
        public void Draw()
        {
            var result = new char[_size.y, _size.x];
            foreach (var key in _buffers.Keys)
            {
                var buffer = _buffers[key];
                for (int i = 0; i < _size.y; i++)
                {
                    for (int j = 0; j < _size.x; j++)
                    {
                        if (NonDrawableSymbol == buffer.Item1[i, j])
                            continue;
                        result[i, j] = buffer.Item1[i, j];
                    }
                }
            }
            for (int i = 0; i < _size.y; i++)
            {
                for (int j = 0; j < _size.x; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write(result[i, j]);
                }
                Console.WriteLine();
            }
        }
        public static void Debug(object obj, bool clear = true)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (clear)
                ClearDebug();
            Console.SetCursorPosition(0, Instance._size.y);
            Console.Write(obj);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private static void ClearDebug()
        {
            Console.SetCursorPosition(0, Instance._size.y);
            Console.Write(new string(' ', Console.WindowWidth));
        }
    }
}
