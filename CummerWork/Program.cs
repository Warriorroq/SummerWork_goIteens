using SummerWork;

Random rand = new Random();

RenderWindow.TryCreateInstance();
RenderWindow.Instance.SetSize(24, 100);

Scene scene = new Scene();
scene.AddObjects(
    new Snake(rand.Next(0,100),rand.Next(0,24))
);

Game game = new Game("Snake");
game.LoadScene(scene);
game.Start();