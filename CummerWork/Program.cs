using SummerWork;
using System.Text;
using SummerWork.SnakeGame;
Random rand = new Random();

RenderWindow.TryCreateInstance();
Game.TryCreateInstance();

int width = 36;
int height = 24;
RenderWindow.Instance.ChangeScreenResolution(height, width);
RenderWindow.Instance.CreateLayer(0, DrawCharacters.clearWindow);
RenderWindow.Instance.CreateLayer(1);
RenderWindow.Instance.CreateLayer(2);

Console.Title = "Snake";
Console.OutputEncoding = Encoding.Unicode;

Game.keyPressed += GameKeyPressed;

void GameKeyPressed(ConsoleKey obj)
{
    if (obj == ConsoleKey.NumPad1)
    {
        width++;
        RenderWindow.Instance.ChangeScreenResolution(height, width);       
    }
    else if (obj == ConsoleKey.NumPad0)
    {
        width--;
        RenderWindow.Instance.ChangeScreenResolution(height, width);
    }
}

while (true)
{
    Console.Clear();

    Scene scene = new Scene();
    var snake = new Snake(rand.Next(-5, 5), rand.Next(-5, 5), 3);
    scene.AddObjects(
        snake,
        new Ball(new Vector2Int(0, 0)),
        new Camera(snake, snake.position)
    );
    scene.AddObjects(new Fog(9, '■'));
    //creating box
    for (int i = -100; i < 100; i++)
        scene.AddObjects(new Wall(new Vector2Int(-100, i)),
            new Wall(new Vector2Int(100, i)),
            new Wall(new Vector2Int(i, -100)),
            new Wall(new Vector2Int(i, 100))
            );
    for (int i = 0; i < 1000; i++)
        scene.AddObjects(new Wall(new Vector2Int(rand.Next(-100, 100), rand.Next(-100, 100))));

    for (int i = 0; i < 100; i++)
        scene.AddObjects(new Apple(new Vector2Int(rand.Next(-99, 100), rand.Next(-99, 100))));

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