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
            direction = new Vector2Int(0, 0);
            CreateDefaultInputMap();
        }
        public override void Start()
        {
            Game.keyPressed += GameKeyPressed;
            Game.Instance.currentScene.onCollision += Collide;
        }
        private void CreateDefaultInputMap()
        {
            _inputMap = new Dictionary<ConsoleKey, Vector2Int>();
            _inputMap.Add(ConsoleKey.S, new Vector2Int(0, 1));
            _inputMap.Add(ConsoleKey.W, new Vector2Int(0, -1));
            _inputMap.Add(ConsoleKey.A, new Vector2Int(-1, 0));
            _inputMap.Add(ConsoleKey.D, new Vector2Int(1, 0));
        }

        private void GameKeyPressed(ConsoleKey key)
        {
            if(_inputMap.ContainsKey(key))
                direction = _inputMap[key];
        }
        public override void Update()
        {
            body?.Update();
            position += direction;
        }
        public override void Draw()
        {
            RenderWindow.Instance.ChangeCharacter(position.y, position.x, DrawCharacters.snakeCharacter);
            body?.Draw();
        }
        public override void CreateBody()
        {
            if (body is not null)
            {
                body.CreateBody();
            }
            else
            {
                body = new SnakeBody(this, position - direction);
            }

        }
        public override void Collide(List<GameObject> objects)
        {
            foreach (var obj in objects)
            {
                switch (obj)
                {
                    case Apple:
                        if(position == obj.position)
                        {
                            (obj as Apple)?.ChangePosition();
                            CreateBody();
                        }
                        break;
                    case Snake:
                        Snake snake = obj as Snake;
                        SnakeBody body = snake.body;
                        while(body is not null)
                        {
                            if(body.position == position)
                            {
                                Game.Instance.EndGame();
                                break;
                            }
                            body = body.body;
                        }
                        break;
                }
            }
        }
    }
    public class SnakeBody : GameObject
    {

        public SnakeBody body;
        private SnakeBody _head;

        public SnakeBody(SnakeBody head, Vector2Int position) : base(position)
        {
            _head = head;
        }
        public virtual void CreateBody()
        {
            if (body is not null)
            {
                body.CreateBody();
            }
            else
            {
                body = new SnakeBody(this, position - _head.position);
            }
        }
        public override void Update()
        {
            body?.Update();
            position = _head.position;
        }
        public override void Draw()
        {
            RenderWindow.Instance.ChangeCharacter(position.y, position.x, DrawCharacters.snakeBody);
            body?.Draw();
        }
    }
}
