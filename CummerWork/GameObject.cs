﻿namespace SummerWork
{
    public abstract class GameObject
    {
        public Vector2Int position;
        public GameObject(Vector2Int position) 
            => this.position = position;
        public virtual void Draw() { }
        public virtual void Update() { }
    }
}