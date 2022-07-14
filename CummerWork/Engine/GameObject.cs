namespace SummerWork
{
    public abstract class GameObject : IDisposable
    {
        public Vector2Int position;
        public GameObject(Vector2Int position) 
            => this.position = position;
        public virtual void Start() { }
        public virtual void Draw() { }
        public virtual void Update() { }
        public virtual void Collide(List<GameObject> objects) { }
        public virtual void Dispose() { }
    }
}
