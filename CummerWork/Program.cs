using SummerWork;
RenderWindow.TryCreateInstance();
RenderWindow.Instance.SetSize(24, 100);
Game game = new Game("Snake");
game.LoadScene(new Scene());
game.Start();