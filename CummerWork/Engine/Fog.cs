namespace SummerWork
{
    public class Fog : GameObject
    {
        private int _distance = 0;
        private char _forSymbol;
        public Fog(int distance, char fogChar, Vector2Int position = null) : base(position)
        {
            _forSymbol = fogChar;
            _distance = distance;
        }
        public override void Draw()
        {
            var renderSize = RenderWindow.Instance.Size;
            var renderCenter = renderSize / 2;
            int sqrtRadius = _distance * _distance;
            for (int y = 0; y < renderSize.y; y++)
            {
                for (int x = 0; x < renderSize.x; x++)
                {
                    int x1 = x - renderCenter.x;
                    int y1 = y - renderCenter.y;
                    int leftPartOfCircleFormula = x1 * x1 + y1 * y1;
                    if (leftPartOfCircleFormula >= sqrtRadius)
                        RenderWindow.Instance.ChangeCharacter(y,x,_forSymbol,1);
                }
            }
        }
    }
}
