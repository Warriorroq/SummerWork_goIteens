namespace SummerWork
{
    public class RenderWindow : Singletone<RenderWindow>
    {
        private char[,] _buffer;
        private (int, int) _size;
        public RenderWindow()
        {
            SetSize(1, 1);
            ClearWindow();
        }
        public void SetSize(int height, int width)
        {
            _size = (height, width);
            _buffer = new char[_size.Item1, _size.Item2];
        }
        public void ChangeCharacter(int height, int width, char symbol)
        {
            if (height < 0 || height >= _size.Item1)
                return;
            if (width < 0 || width >= _size.Item2)
                return;
            _buffer[height, width] = symbol;
        }
        public void ClearWindow()
        {
            for (int i = 0; i < _size.Item1; i++)
                for (int j = 0; j < _size.Item2; j++)
                    _buffer[i, j] = DrawCharacters.clearWindow;
        }
        public void Draw()
        {
            for (int i = 0; i < _size.Item1; i++)
            {
                for (int j = 0; j < _size.Item2; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write(_buffer[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

        }
    }
}
