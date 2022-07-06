namespace SummerWork
{
    public class Scene
    {
        private List<GameObject> _objects;
        private List<GameObject> _objectsForDestroy;

        public Scene()
        {
            _objects = new List<GameObject>();
            _objectsForDestroy = new List<GameObject>();
        }
        public void AddObjects(params GameObject[] objects)
            => _objects.AddRange(objects);
        public void Update()
        {
            foreach (var obj in _objects)
                obj.Update();
            foreach (var obj in _objectsForDestroy)
                _objects.Remove(obj);
            _objectsForDestroy.Clear();
        }
        public void Draw()
        {
            RenderWindow.Instance.ClearWindow();
            foreach (var obj in _objects)
                obj.Draw();
            RenderWindow.Instance.Draw();
        }
    }
}
