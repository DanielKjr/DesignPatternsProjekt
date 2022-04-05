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
        private float speed = 1f;
        private SpriteRenderer rend;

        public BackgroundStars(float _speed)
        {
            speed = _speed;
        }
        public override void Start()
        {
            rend = GameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;
            Reset();
            GameObject.Transform.Position = new Vector2(rnd.Next(0, GameWorld.Instance.Graphics.PreferredBackBufferWidth), rnd.Next(0, GameWorld.Instance.Graphics.PreferredBackBufferHeight));
        }
        private void Move()
        {
            GameObject.Transform.Translate(velocity * GameWorld.DeltaTime * speed); //Move star
        }
        /// <summary>
        /// Reset position to random X, and Y=0 to look like new star appearing.
        /// New speed and scale values added too.
        /// </summary>
        private void Reset()
        {
            GameObject.Transform.Position = new Vector2(rnd.Next(0, GameWorld.Instance.Graphics.PreferredBackBufferWidth), 0);
            speed = rnd.Next(20, 150);
            rend.Scale = (speed / 150) + (rnd.Next(-15, 40) / 100); //scale depens on speed with a randomized variance added on top.
            rend.SetSprite("Star" + rnd.Next(1, 4)); //New random sprite
            rend.Rotation = rnd.Next(0, 4); //New random rotation
            float temp = rnd.Next(-2, 2); //Didnt want to work normaly... eh.
            velocity = new Vector2(temp / 100, 1); //new random dir, still full down but maybe a bit sideways too
        }
        public override void Update(GameTime gameTime)
        {
            if (GameObject.Transform.Position.Y > GameWorld.Instance.Graphics.PreferredBackBufferHeight) //If outside bottom of screen, reset.
            {
                Reset();
            }
            Move(); //If not outside, keep moving.
        }
    }
}
