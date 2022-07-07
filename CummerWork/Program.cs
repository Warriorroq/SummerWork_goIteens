using SummerWork;
Random rand = new Random();

RenderWindow.TryCreateInstance();
Game.TryCreateInstance();
RenderWindow.Instance.SetSize(24, 24);
Console.Title = "Snake";

Scene scene = new Scene();
scene.AddObjects(
    new Snake(rand.Next(0, 24),rand.Next(0,24)),
    //new Snake(rand.Next(0, 24), rand.Next(0, 24)),
    new Apple(new Vector2Int(rand.Next(0, 24), rand.Next(0, 24))),
    new Apple(new Vector2Int(rand.Next(0, 24), rand.Next(0, 24))),
    new Apple(new Vector2Int(rand.Next(0, 24), rand.Next(0, 24))),
    new Wall(new Vector2Int(rand.Next(0, 24), rand.Next(0, 24))),
    new Wall(new Vector2Int(rand.Next(0, 24), rand.Next(0, 24))),
    new Wall(new Vector2Int(rand.Next(0, 24), rand.Next(0, 24))),
    new Wall(new Vector2Int(rand.Next(0, 24), rand.Next(0, 24))),
    new Wall(new Vector2Int(rand.Next(0, 24), rand.Next(0, 24))),
    new Wall(new Vector2Int(rand.Next(0, 24), rand.Next(0, 24))),
    new Wall(new Vector2Int(rand.Next(0, 24), rand.Next(0, 24))),
    new Ball(new Vector2Int(rand.Next(0, 24), rand.Next(0, 24)))
);

Game.Instance.LoadScene(scene);
Game.Instance.Start();