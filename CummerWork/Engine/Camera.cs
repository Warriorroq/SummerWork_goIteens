namespace SummerWork
{
    public class Camera : GameObject
    {
        public static Camera main;
        private GameObject _followTo;
        private Vector2Int _offSet;

        public Camera(GameObject follow, Vector2Int position) : base(position)
        {
            _followTo = follow;
            _offSet = RenderWindow.Instance.Size / 2;
            if(main is null)
                main = this;
        }
        public void ChangeCharacter(int height, int width, char symbol)
        {
            Vector2Int newPositon = new Vector2Int(width, height) - position + _offSet;
            RenderWindow.Instance.ChangeCharacter(newPositon.y, newPositon.x, symbol);
        }
        public override void Update()
        {
            if(_followTo is not null)
            {
                position = _followTo.position;
            }
            RenderWindow.Debug(position);
        }
        public override void Dispose()
            =>main = null;
    }
}
