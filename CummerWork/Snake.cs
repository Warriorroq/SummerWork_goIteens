using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerWork
{
    public class Snake : SnakeBody
    {
        public Vector2Int direction;
        private Dictionary<ConsoleKey, Vector2Int> _inputMap;
        public Snake(int x, int y) : base(null, new Vector2Int(x,y))
        {
            Game.keyPressed += GameKeyPressed;
            direction = new Vector2Int(0, 0);
            CreateDefaultInputMap();
        }
        private void CreateDefaultInputMap()
        {
            _inputMap = new Dictionary<ConsoleKey, Vector2Int>();
            _inputMap.Add(ConsoleKey.S, new Vector2Int(0, 1));
            _inputMap.Add(ConsoleKey.W, new Vector2Int(0, -1));
            _inputMap.Add(ConsoleKey.A, new Vector2Int(-1, 0));
            _inputMap.Add(ConsoleKey.D, new Vector2Int(1, 0));
        }

        private void GameKeyPressed(ConsoleKey obj)
        {
            if (obj == ConsoleKey.Spacebar)
            {
                CreateBody();
                return;
            }
            direction = _inputMap[obj];
        }
        public override void Update()
        {
            _down?.Update();
            position += direction;
        }
        public override void Draw()
        {
            RenderWindow.Instance.ChangeCharacter(position.y, position.x, DrawCharacters.snakeCharacter);
            _down?.Draw();
        }
        public override void CreateBody()
        {
            if (_down is not null)
            {
                _down.CreateBody();
            }
            else
            {
                _down = new SnakeBody(this, position - direction);
            }

        }
    }
    public class SnakeBody : GameObject
    {

        private SnakeBody _head;
        protected SnakeBody _down;
        public SnakeBody(SnakeBody head, Vector2Int position) : base(position)
        {
            _head = head;
        }
        public virtual void CreateBody()
        {
            if (_down is not null)
            {
                _down.CreateBody();
            }
            else
            {
                _down = new SnakeBody(this, position - _head.position);
            }
        }
        public override void Update()
        {
            _down?.Update();
            position = _head.position;
        }
        public override void Draw()
        {
            RenderWindow.Instance.ChangeCharacter(position.y, position.x, DrawCharacters.snakeBody);
            _down?.Draw();
        }
    }
}
