using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsProjekt
{
    class Boss : Component
    {
        private float speed;
        private Vector2 velocity = new Vector2(0, 1);
        private int desiredYPos;
        public int Health { get; set; }
        public Boss(float _speed, int _health, int _desiredYPos)
        {
            speed = _speed;
            Health = _health;
            desiredYPos = _desiredYPos;
        }
        public override void Start()
        {
            GameObject.Transform.Position = new Vector2(GameWorld.Instance.Graphics.PreferredBackBufferWidth/2,0);
        }
        private void Move()
        {
            if (GameObject.Transform.Position.Y < desiredYPos)
            {
                GameObject.Transform.Translate(velocity * GameWorld.DeltaTime * speed);
            }
        }
        public override void Update(GameTime gameTime)
        {
            Move();
        }
    }
}
