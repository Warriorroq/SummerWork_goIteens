namespace SummerWork.SnakeGame
{
    public class Wall : GameObject
    {
        public Wall(Vector2Int position) : base(position) { }
        public override void Draw()
            =>Camera.main.ChangeCharacter(position.y, position.x, DrawCharacters.wall);
    }
}
