namespace SummerWork.SnakeGame
{
    public class Apple : GameObject
    {
        public Apple(Vector2Int position) : base(position){}
        public override void Draw()
        {
            Camera.main.ChangeCharacter(position.y, position.x, DrawCharacters.apple);
        }
        public void ChangePosition()
        {
            var random = Game.Instance.random;
            position = new Vector2Int(random.Next(-99, 99), random.Next(-99, 99));
        }
        public override void Start()
        {
            Game.Instance.currentScene.onCollision += Collide;
        }
        public override void Collide(List<GameObject> objects)
        {
            foreach (var obj in objects)
            {
                switch (obj)
                {
                    case Wall:
                        if (position == obj.position)
                            ChangePosition();
                        break;
                    default:
                        break;
                }
            }
        }
        public override void Dispose()
            => Game.Instance.currentScene.onCollision -= Collide;
    }
}
