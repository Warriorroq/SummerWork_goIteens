using System.Diagnostics;
namespace SummerWork
{
    public class Game
    {
        public static event Action<ConsoleKey>? keyPressed;
        private Stopwatch _stopwatch = new Stopwatch();
        private bool _running;
        private const int _fps = 1000 / 10;
        private Scene _scene;
        public Game(string name)
        {
            Console.Title = name;
        }
        public void LoadScene(Scene scene)
        {
            _scene = scene;
        }
        public void Start()
        {
            if (_scene is null)
                return;
            _running = true;
            Update();
        }
        private void Update()
        {
            while (_running)
            {
                if (Console.KeyAvailable)
                    keyPressed(Console.ReadKey().Key);
                _stopwatch.Restart();
                _scene.Update();
                _scene.Draw();
                Thread.Sleep(Math.Clamp(_fps - _stopwatch.Elapsed.Milliseconds, 0, _fps));
            }
        }
    }
}
