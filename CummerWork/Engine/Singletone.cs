namespace SummerWork
{
    public class Singletone<T> where T : new()
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                TryCreateInstance();
                return _instance;
            }
        }
        public static void TryCreateInstance()
        {
            if (_instance is null)
                _instance = new T();
        }
        protected virtual void ClearInstance()
            => _instance = default(T);
    }
}
