using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsProjekt
{
    class BackgroundStars : Component
    {
        private Random rnd = new Random();
        private Vector2 velocity = new Vector2(0, 1);
        private SpriteRenderer rend;
            
        public override void Start()
        {
            rend = GameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;
            rend.SetSprite("Pixel");
            Reset();
            GameObject.Transform.Position = new Vector2(rnd.Next(0, GameWorld.Instance.Graphics.PreferredBackBufferWidth), rnd.Next(0, GameWorld.Instance.Graphics.PreferredBackBufferHeight));
        }
        private void Move()
        {
            //velocity *= speed;
            GameObject.Transform.Translate(velocity * GameWorld.DeltaTime);
        }
        private void Reset()
        {
            GameObject.Transform.Position = new Vector2(rnd.Next(0, GameWorld.Instance.Graphics.PreferredBackBufferWidth), 0);
            velocity = new Vector2(0, rnd.Next(20, 150));
            float variance = rnd.Next(-13, 24) /100;
            rend.Scale = (velocity.Y / 150) + variance;
        }
        public override void Update(GameTime gameTime)
        {
            if (GameObject.Transform.Position.Y > GameWorld.Instance.Graphics.PreferredBackBufferHeight)
            {
                Reset();
            }
            Move();
        }
    }
}
