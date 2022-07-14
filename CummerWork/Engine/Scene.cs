namespace SummerWork
{
    public class Scene : IDisposable
    {
        public event Action<List<GameObject>> onCollision;
        private List<GameObject> _objects;
        private List<GameObject> _objectsForDestroy;
        public Scene()
        {
            _objects = new List<GameObject>();
            _objectsForDestroy = new List<GameObject>();
        }
        public void Start()
        {
            foreach (var obj in _objects)
                obj.Start();
        }
        public void AddObjects(params GameObject[] objects)
            => _objects.AddRange(objects);
        public void Update()
        {
            onCollision(_objects);
            foreach (var obj in _objects)
                obj.Update();
            foreach (var obj in _objectsForDestroy)
                _objects.Remove(obj);
            _objectsForDestroy.Clear();
        }
        public void Destroy(GameObject obj)
            => _objectsForDestroy.Add(obj);
        public void Draw()
        {
            RenderWindow.Instance.ClearWindows();
            foreach (var obj in _objects)
                obj.Draw();
            RenderWindow.Instance.Draw();
        }
        public virtual void Dispose()
        {
            DisposeList(_objects);
            DisposeList(_objectsForDestroy);
        }
        private void DisposeList(List<GameObject> list)
        {
            foreach (var obj in list)
                obj.Dispose();
            list.Clear();
        }
    }
}
