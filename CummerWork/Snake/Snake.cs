namespace SummerWork.SnakeGame
{
    public class Snake : SnakeBody
    {
        public Vector2Int direction;
        private Dictionary<ConsoleKey, Vector2Int> _inputMap;
        private int _score;
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
            if(key == ConsoleKey.Spacebar)
                CreateBody();
        }
        public override void Update()
        {
            body?.Update();
            position += direction;
        }
        public override void Draw()
        {
            Camera.main.ChangeCharacter(position.y, position.x, DrawCharacters.snakeCharacter, 2);
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
                            (obj as Ball)?.AddRandomnessToVelocity();
                            (obj as Apple).ChangePosition();
                            _score++;
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
                                EndGameSessionWithMessage();
                                break;
                            }
                            body = body.body;
                        }
                        break;
                    case Wall:
                        if (position == obj.position)
                            EndGameSessionWithMessage();
                        break;
                    default:
                        break;
                }
            }
        }
        private void EndGameSessionWithMessage()
        {
            Game.Instance.EndGame();
            Console.Clear();
            Console.WriteLine($"Score: {_score}");
        }
        public override string ToString()
            =>$"Snake, posision x:{position.x} y:{position.y}";
        public override void Dispose()
            => Game.Instance.currentScene.onCollision -= Collide;
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
            Camera.main.ChangeCharacter(position.y, position.x, DrawCharacters.snakeBody, 2);
            body?.Draw();
        }
    }
}
