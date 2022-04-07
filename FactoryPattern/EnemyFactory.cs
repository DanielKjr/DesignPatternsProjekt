using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsProjekt
{
    class EnemyFactory : Factory
    {
        private static EnemyFactory instance;
        private Random rnd = new Random();
        private GameObject gameObject;
        public static EnemyFactory Instance //Singlton start
        {
            get
            {
                if (instance == null)
                {
                    instance = new EnemyFactory();
                }
                return instance;
            }
        } //Singleton end

        public override GameObject CreateObject()
        {

            gameObject = new GameObject();
            SpriteRenderer rend = (SpriteRenderer)gameObject.AddComponent(new SpriteRenderer());

            Collider c = (Collider)gameObject.AddComponent(new Collider());
            
            gameObject.Tag = "Enemy";
            GameWorld.Instance.Colliders.Add(c);

            // item.AddComponent(new Enemy(2, new Vector2(0, 0)));


            rend.SetSprite("enemyBlack1");
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
                    rend.Rotation = 3.1f;
                    spawnPoint = new Vector2(rnd.Next(0, GameWorld.Instance.Graphics.PreferredBackBufferWidth), GameWorld.Instance.Graphics.PreferredBackBufferHeight);
                    break;
                case 2:
                    moveDir = new Vector2(-1, 0);
                    rend.Rotation = 1.5f;
                    spawnPoint = new Vector2(GameWorld.Instance.Graphics.PreferredBackBufferWidth, rnd.Next(0, GameWorld.Instance.Graphics.PreferredBackBufferHeight));
                    break;
                case 3:
                    moveDir = new Vector2(1, 0);
                    rend.Rotation = 4.7f;
                    spawnPoint = new Vector2(0, rnd.Next(0, GameWorld.Instance.Graphics.PreferredBackBufferHeight));
                    break;
            }

           
          Enemy e = (Enemy)gameObject.AddComponent(new Enemy(20, moveDir, spawnPoint));

            c.CollisionEvent.Attach(e);
            return gameObject;


        }
        public GameObject BossCreater()
        {
            GameObject item = new GameObject();
            SpriteRenderer rend = (SpriteRenderer)item.AddComponent(new SpriteRenderer());
            Collider c = (Collider)item.AddComponent(new Collider());
            GameWorld.Instance.Colliders.Add(c);
            item.Tag = "Enemy";

            rend.SetSprite("EvilGirth");
            rend.Scale = 2f;
            

            item.AddComponent(new Boss(50f, 1000, GameWorld.Instance.Graphics.PreferredBackBufferHeight / 4));

            return item;
        }
    }
}
