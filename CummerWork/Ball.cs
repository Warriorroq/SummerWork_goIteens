﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerWork
{
    public class Ball : Apple
    {
        private Vector2Int _velocity;
        public Ball(Vector2Int position) : base(position) {}
        public override void Start()
        {
            Game.Instance.currentScene.onCollision += Collide;
            var random = Game.Instance.random;
            _velocity = new Vector2Int(random.Next(-1, 2), random.Next(-1, 2));
        }
        public override void Update()
        {
            position += _velocity;
            if (position.x < 0 || position.x >= 23)
            {
                if(position.x >= 23)
                    position.x = 23;
                else
                    position.x = 0;
                ReflectHoriosontal();
                AddRandomnessToVelocity();
            }
            if (position.y < 0 || position.y >= 23)
            {
                if (position.y >= 23)
                    position.y = 23;
                else
                    position.y = 0;
                ReflectVertical();
                AddRandomnessToVelocity();
            }
        }
        public override void Collide(List<GameObject> objects)
        {
            foreach (var obj in objects)
            {
                switch (obj)
                {
                    case Wall:
                        if (position + _velocity == obj.position)
                            AddRandomnessToVelocity();
                        break;
                    case Snake:
                        SnakeBody body = (obj as Snake).body;
                        while (body is not null)
                        {
                            if (body.position == position + _velocity)
                            {
                                var temp = body.position - position;
                                if (temp.y == 0)
                                    ReflectHoriosontal();
                                if (temp.x == 0)
                                    ReflectVertical();
                                if(temp.x != 0 && temp.y != 0)
                                {
                                    ReflectVertical();
                                    ReflectHoriosontal();
                                }
                                break;
                            }
                            body = body.body;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        public void AddRandomnessToVelocity()
        {
            var random = Game.Instance.random;
            if (random.Next(0, 3) == 0)
                _velocity = new Vector2Int(random.Next(-1, 2), random.Next(-1, 2));
        }
        private void ReflectHoriosontal()
            => _velocity.x *= -1;
        private void ReflectVertical()
            => _velocity.y *= -1;        
        public override void Draw()
            => RenderWindow.Instance.ChangeCharacter(position.y, position.x, DrawCharacters.ball);
    }
}
