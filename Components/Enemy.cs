using Microsoft.Xna.Framework;
using System;

namespace DesignPatternsProjekt
{
    public class Enemy : Component
    {
        private float speed;
        private Vector2 velocity = new Vector2(0, 1);
        private Vector2 spawnPoint = new Vector2(0, 0);
        private Random rnd = new Random();

        public Enemy(float _speed, Vector2 _velocity, Vector2 _spawnPoint)
        {
            speed = _speed;
            velocity = new Vector2(_velocity.X, _velocity.Y);
            spawnPoint = _spawnPoint;
        }
        public override void Start()
        {
            GameObject.Transform.Position = spawnPoint;
        }
        public void Move()
        {
            GameObject.Transform.Translate(velocity * GameWorld.DeltaTime * speed);
        }
        public override void Update(GameTime gameTime)
        {
            Move();
        }
    }
}
