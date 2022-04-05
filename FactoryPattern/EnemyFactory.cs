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
        }//singleton end
        public override GameObject CreateObject()
        {
            GameObject item = new GameObject();
            SpriteRenderer rend = (SpriteRenderer)item.AddComponent(new SpriteRenderer());

            rend.SetSprite("MinerTest");
            item.AddComponent(new Enemy(2, new Vector2(0,0)));
            return item;
        }
    }
}
