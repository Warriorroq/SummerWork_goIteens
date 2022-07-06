using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerWork
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
            =>RenderWindow.Instance.ChangeCharacter(position.y, position.x, DrawCharacters.wall);
    }
}
