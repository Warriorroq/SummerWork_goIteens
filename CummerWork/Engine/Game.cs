using System.Diagnostics;
namespace SummerWork
{
    public class Game : Singletone<Game>, IDisposable
    {
        public static event Action<ConsoleKey>? keyPressed;
        public Random random;
        public Scene currentScene;
        private Stopwatch _stopwatch = new Stopwatch();
        private bool _running;
        private int _fps = 10;
        public void LoadScene(Scene scene)
        {
            random = new Random();
            currentScene = scene;
        }
        public void Start()
        {
            if (currentScene is null)
                return;
            currentScene.Start();
            _running = true;
            Update();
        }
        public void EndGame()
            =>_running = false;
        private void Update()
        {
            int waitTime = 1000 / _fps;
            while (true)
            {
                if (Console.KeyAvailable)
                    keyPressed(Console.ReadKey().Key);
                _stopwatch.Restart();
                currentScene.Update();
                if (!_running)
                    break;
                currentScene.Draw();
                Thread.Sleep(Math.Clamp(waitTime - _stopwatch.Elapsed.Milliseconds, 0, waitTime));
            }
        }
        public virtual void Dispose()
        {
            currentScene.Dispose();
            ClearInstance();
        }
    }
}
