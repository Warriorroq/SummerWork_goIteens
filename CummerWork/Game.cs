using System.Diagnostics;
namespace SummerWork
{
    public class Game
    {
        private Stopwatch _stopwatch = new Stopwatch();
        private bool _running;
        private const int _fps = 1000 / 2;
        private Scene _scene;
        public Game(string name)
        {
            Console.Title = name;
            _scene = null;
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
                _stopwatch.Restart();
                _scene.Update();
                _scene.Draw();
                Thread.Sleep(Math.Clamp(_fps - _stopwatch.Elapsed.Milliseconds, 0, _fps));
            }
        }
    }
}
