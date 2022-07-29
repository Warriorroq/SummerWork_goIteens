using SFML.System;
namespace SummerWork
{
    public class GameTimer : IDisposable
    {
        public float deltaTime;
        public float timeScale;
        public int waitTime;
        public int DeltaTimeInMiliseconds => (int)(deltaTime * 1000);
        private float TotalTimeElapsed => _clock.ElapsedTime.AsSeconds();
        private float _totalTimeBeforeUpdate;
        private float _updateTime;
        private float _previosTimeElapsed;
        private Clock _clock;
        public GameTimer()
        {
            deltaTime = 0f;
            _totalTimeBeforeUpdate = 0f;
            _previosTimeElapsed = 0f;
            timeScale = 1f;
            _clock = new Clock();
        }
        public void Init(float fps)
        {
            waitTime = 1000 / (int)fps;
            _updateTime = 1f / fps;
        }
        public bool IsUpdate()
        {
            _totalTimeBeforeUpdate += TotalTimeElapsed - _previosTimeElapsed;
            _previosTimeElapsed = TotalTimeElapsed;
            if (_totalTimeBeforeUpdate >= _updateTime)
            {
                deltaTime = _totalTimeBeforeUpdate * timeScale;
                _totalTimeBeforeUpdate = 0;
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            _clock.Dispose();
            _clock = null;
        }
    }
}
