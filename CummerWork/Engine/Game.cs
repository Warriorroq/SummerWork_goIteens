using System.Diagnostics;
using SFML.System;
namespace SummerWork
{
    public class Game : Singletone<Game>, IDisposable
    {
        public static event Action<ConsoleKey>? keyPressed;
        public Random random;
        public Scene currentScene;
        private GameTimer _timer;
        private bool _running;
        private int _fps = 10;
        public void LoadScene(Scene scene)
        {
            random = new Random();
            currentScene = scene;
        }
        public void Start()
        {
            _timer = new GameTimer();
            _timer.Init(_fps);
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
            while (true)
            {
                if (Console.KeyAvailable)
                    keyPressed(Console.ReadKey().Key);
                if (_timer.IsUpdate())
                {
                    currentScene.Update();
                    if (!_running)
                        break;
                    currentScene.Draw();
                }
                Thread.Sleep(Math.Clamp(_timer.waitTime - _timer.DeltaTimeInMiliseconds, 0, _timer.waitTime));
            }
        }
        public virtual void Dispose()
        {
            currentScene.Dispose();
            currentScene = null;
            ClearInstance();
        }
    }
}
