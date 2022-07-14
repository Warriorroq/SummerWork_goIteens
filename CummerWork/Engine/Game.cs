using System.Diagnostics;
namespace SummerWork
{
    public class Game : Singletone<Game>, IDisposable
    {
        public static event Action<ConsoleKey>? keyPressed;
        public Random random;
        public Scene currentScene;
        public int score;
        private Stopwatch _stopwatch = new Stopwatch();
        private bool _running;
        private int _fps = 1000 / 10;
        public void LoadScene(Scene scene)
        {
            random = new Random();
            currentScene = scene;
        }
        public void Start()
        {
            score = 0;
            if (currentScene is null)
                return;
            currentScene.Start();
            _running = true;
            Update();
        }
        public void EndGame()
        {
            _running = false;
            Console.Clear();
            Console.WriteLine($" Game over\n Score {score}\n");
        }
        private void Update()
        {
            while (_running)
            {
                if (Console.KeyAvailable)
                    keyPressed(Console.ReadKey().Key);
                _stopwatch.Restart();
                currentScene.Update();
                currentScene.Draw();
                Thread.Sleep(Math.Clamp(_fps - _stopwatch.Elapsed.Milliseconds, 0, _fps));
            }
            EndGame();
        }

        public virtual void Dispose()
        {
            currentScene.Dispose();
            ClearInstance();
        }
    }
}
