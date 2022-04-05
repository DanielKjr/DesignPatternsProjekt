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

            rend.SetSprite("EvilGirth");
            item.AddComponent(new Enemy(5, new Vector2(0,1)));
            return item;
        }
    }
}
