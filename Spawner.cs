using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsProjekt
{
    public class Spawner
    {

        private static Spawner instance;
        public static Spawner Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Spawner();
                }
                return instance;
            }
        }
        float dt;
        float colorChangeTimer = 0;
        float colorChangeTimerMax = 3;
        Random rnd = new Random();
        private Color[] colors = new Color[] {Color.Red, Color.Blue, Color.Green};

        public void Update(GameTime gameTime)
        {
            dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            colorChangeTimer += dt;
            if (colorChangeTimer >= colorChangeTimerMax)
            {
                SpawnColorChange();
                colorChangeTimer = 0;
            }

        }

        public void SpawnColorChange()
        {
            GameObject go = new GameObject();
            SpriteRenderer sr = (SpriteRenderer)go.AddComponent(new SpriteRenderer());
            Collider c = (Collider)go.AddComponent(new Collider());
            ColorChange cc = (ColorChange)go.GetComponent<ColorChange>();
            sr.SetSprite("ball");
            go.Tag = "ColorChange";
            sr.Color = colors[rnd.Next(colors.Length)];
            go.AddComponent(new ColorChange(new Vector2(rnd.Next(0, GameWorld.Instance.Graphics.PreferredBackBufferWidth), rnd.Next(0, GameWorld.Instance.Graphics.PreferredBackBufferHeight))));

            GameWorld.Instance.Instantiate(go);

            

        }
    }

}
