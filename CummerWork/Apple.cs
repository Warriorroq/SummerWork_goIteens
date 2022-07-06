namespace SummerWork
{
    public class Apple : GameObject
    {
        public Apple(Vector2Int position) : base(position){}
        public override void Draw()
        {
            RenderWindow.Instance.ChangeCharacter(position.y, position.x, DrawCharacters.apple);
        }
        public void ChangePosition()
        {
            var random = Game.Instance.random;
            position = new Vector2Int(random.Next(0, 24), random.Next(0, 24));
        }
    }
}
