namespace SummerWork.SnakeGame
{
    public class Wall : GameObject
    {
        public Wall(Vector2Int position) : base(position) { }
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
                    case Ball:
                        break;
                    case Apple:
                        if (position == obj.position)
                            (obj as Apple).ChangePosition();
                        break;
                    default:
                        break;
                }
            }
        }
        public override void Draw()
            =>Camera.main.ChangeCharacter(position.y, position.x, DrawCharacters.wall);
        public override void Dispose()
            => Game.Instance.currentScene.onCollision -= Collide;
    }
}
