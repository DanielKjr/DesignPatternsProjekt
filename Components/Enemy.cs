using Microsoft.Xna.Framework;
using System;

namespace DesignPatternsProjekt
{
    public class Enemy : Component
    {
        private float speed;
        private Vector2 velocity = new Vector2(0, 1);
        private Random rnd = new Random();

        public Enemy(float _speed, Vector2 _velocity)
        {
            speed = _speed;
            velocity = new Vector2(_velocity.X, _velocity.Y);
        }
        public override void Start()
        {
            GameObject.Transform.Position = new Vector2(rnd.Next(0, GameWorld.Instance.GraphicsDevice.Viewport.Width), 0);
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
