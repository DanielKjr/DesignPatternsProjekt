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
        float colorChangeTimerMax = 6;
        float enemyTimer = 0;
        float enemyTimerMax = 2;
        float bossTimer = 0;
        float bossTimerMax = 20;

        Random rnd = new Random();
        private Color[] colors = new Color[] {Color.Red, Color.Blue, Color.Green};

        public void Update(GameTime gameTime)
        {
            dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            SpawnTimers();


        }
        public void SpawnTimers()
        {
            colorChangeTimer += dt;
            enemyTimer += dt;
            bossTimer += dt;
            if (colorChangeTimer >= colorChangeTimerMax)
            {
                SpawnColorChange();
                colorChangeTimer = 0;
            }
            if (enemyTimer >= enemyTimerMax)
            {
                SpawnEnemy();
                enemyTimer = 0;
            }
            if (bossTimer >= bossTimerMax)
            {
                SpawnBoss();
                bossTimerMax = 300;
                enemyTimerMax = 300;
            }

        }

        public void SpawnColorChange()
        {
            
            GameObject go = new GameObject();
            SpriteRenderer sr = (SpriteRenderer)go.AddComponent(new SpriteRenderer());
            Collider c = (Collider)go.AddComponent(new Collider());
         //   ColorChange cc = (ColorChange)go.AddComponent(new ColorChange());
            
            sr.SetSprite("ball");
            go.Tag = "ColorChange";
            sr.Color = colors[rnd.Next(colors.Length)];
          ColorChange cc =  (ColorChange)go.AddComponent(new ColorChange(new Vector2(rnd.Next(0, GameWorld.Instance.Graphics.PreferredBackBufferWidth), rnd.Next(0, GameWorld.Instance.Graphics.PreferredBackBufferHeight))));

            c.CollisionEvent.Attach(cc);

            GameWorld.Instance.Instantiate(go);

            

        }

        public void SpawnEnemy()
        {
            GameObject go = EnemyFactory.Instance.CreateObject();
            SpriteRenderer sr = go.GetComponent<SpriteRenderer>() as SpriteRenderer;
            //sr.Color = colors[rnd.Next(colors.Length)];
            GameWorld.Instance.Instantiate(go);
            //GameWorld.Instance.gameObjects.Add(EnemyFactory.Instance.CreateObject());
        }

        public void SpawnBoss()
        {

            GameObject go = EnemyFactory.Instance.BossCreater();
            SpriteRenderer sr = go.GetComponent<SpriteRenderer>() as SpriteRenderer;
            GameWorld.Instance.Instantiate(go);
            //GameWorld.Instance.gameObjects.Add(EnemyFactory.Instance.BossCreater());
        }
    }

}
