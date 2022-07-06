namespace SummerWork
{
    public class Scene
    {
        private List<object> _objects;
        private List<object> _objectsForDestroy;
        public Scene()
        {
            _objects = new List<object>();
            _objectsForDestroy = new List<object>();
        }
        public void AddObjects(params object[] objects)
            =>_objects.Add(objects);
        public void Update()
        {

        }
        public void Draw()
        {
            RenderWindow.Instance.ClearWindow();
            RenderWindow.Instance.Draw();
        }
    }
}
