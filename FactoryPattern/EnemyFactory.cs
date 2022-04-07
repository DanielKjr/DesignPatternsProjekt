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

            switch (rnd.Next(0, 3))
            {
                case 0:
                    rend.Color = Color.Red;
                    gameObject.Tag = "EnemyRed";
                    break;
                case 1:
                    rend.Color = Color.Blue;
                    gameObject.Tag = "EnemyBlue";
                    break;
                case 2:
                    rend.Color = Color.Green;
                    gameObject.Tag = "EnemyGreen";
                    break;
            }

            Enemy e = (Enemy)gameObject.AddComponent(new Enemy(40, moveDir, spawnPoint));
            Collider c = (Collider)gameObject.AddComponent(new Collider());
            c.CollisionEvent.Attach(e);

            return gameObject;


        }
        public GameObject BossCreater()
        {
            gameObject = new GameObject();
            gameObject.Tag = "Enemy";

            SpriteRenderer rend = (SpriteRenderer)gameObject.AddComponent(new SpriteRenderer());
            rend.SetSprite("MinerTest");
            rend.Scale = 2f;

            Boss b = (Boss)gameObject.AddComponent(new Boss(50f, 10, GameWorld.Instance.Graphics.PreferredBackBufferHeight / 4));
            Collider c = (Collider)gameObject.AddComponent(new Collider());
            c.CollisionEvent.Attach(b);

            return gameObject;
        }
    }
}
