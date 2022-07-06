namespace SummerWork
{
    public class Scene
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
            RenderWindow.Instance.ClearWindow();
            foreach (var obj in _objects)
                obj.Draw();
            RenderWindow.Instance.Draw();
        }
    }
}
