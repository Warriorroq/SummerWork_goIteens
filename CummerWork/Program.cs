using SummerWork;
using System.Text;
using SummerWork.SnakeGame;
Random rand = new Random();
RenderWindow.TryCreateInstance();
RenderWindow.Instance.SetSize(24, 36);
Console.Title = "Snake";
Console.OutputEncoding = Encoding.Unicode;

while (true)
{
    Console.Clear();
    Game.TryCreateInstance();

    Scene scene = new Scene();
    var snake = new Snake(rand.Next(0, 24), rand.Next(0, 24));
    scene.AddObjects(
        snake,
        new Ball(new Vector2Int(rand.Next(0, 24), rand.Next(0, 24))),
        new Camera(snake, snake.position)
    );
    //creating box
    for (int i = -100; i < 100; i++)
        scene.AddObjects(new Wall(new Vector2Int(-100, i)), 
            new Wall(new Vector2Int(100, i)), 
            new Wall(new Vector2Int(i, -100)), 
            new Wall(new Vector2Int(i, 100)));

    for (int i = 0; i < 1000; i++)
        scene.AddObjects(new Wall(new Vector2Int(rand.Next(-100, 100), rand.Next(-100, 100))));

    for (int i = 0; i < 100; i++)
        scene.AddObjects(new Apple(new Vector2Int(rand.Next(-99, 100), rand.Next(-99, 100))));
    scene.AddObjects(new Fog(4, '-'));
    Game.Instance.LoadScene(scene);
    Game.Instance.Start();
    Game.Instance.Dispose();

    Console.WriteLine("Replay?");
    var key = Console.ReadKey().Key;
    if (key != ConsoleKey.Y)
        break;
}
Console.Clear();
Console.WriteLine("Thanks For Playing!");