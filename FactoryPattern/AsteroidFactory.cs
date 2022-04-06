using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsProjekt
{

    class AsteroidFactory : Factory
    {
        private static AsteroidFactory instance;
        private Random rnd = new Random();
        public static AsteroidFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AsteroidFactory();
                }
                return instance;
            }
        }



        public override GameObject CreateObject()
        {
            GameObject aste = new GameObject();
            SpriteRenderer sr = (SpriteRenderer)aste.AddComponent(new SpriteRenderer());

            Collider c = (Collider)aste.AddComponent(new Collider());

            aste.Tag = "Asteroid";
            GameWorld.Instance.Colliders.Add(c);

            sr.SetSprite("asteroid");
            Vector2 moveDir = new Vector2(0, 0);
            Vector2 spawnPoint = new Vector2(0, 0);
            switch (rnd.Next(0, 4))
            {
                case 0:
                    moveDir = new Vector2(0, 1);
                    spawnPoint = new Vector2(rnd.Next(0, GameWorld.Instance.Graphics.PreferredBackBufferWidth), 0);
                    break;
                case 1:
                    moveDir = new Vector2(0, -1);
                    spawnPoint = new Vector2(rnd.Next(0, GameWorld.Instance.Graphics.PreferredBackBufferWidth), GameWorld.Instance.Graphics.PreferredBackBufferHeight);
                    break;
                case 2:
                    moveDir = new Vector2(-1, 0);
                    spawnPoint = new Vector2(GameWorld.Instance.Graphics.PreferredBackBufferWidth, rnd.Next(0, GameWorld.Instance.Graphics.PreferredBackBufferHeight));
                    break;
                case 3:
                    moveDir = new Vector2(1, 0);
                    spawnPoint = new Vector2(0, rnd.Next(0, GameWorld.Instance.Graphics.PreferredBackBufferHeight));
                    break;
            }
            aste.AddComponent(new Asteroid(80, moveDir, spawnPoint));
            sr.Rotation = rnd.Next(0, 100);

            return aste;
        }
    }
}
