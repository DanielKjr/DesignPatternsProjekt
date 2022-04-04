using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsProjekt
{
    public class StarFactory : Factory
    {
        private static StarFactory instance;
        private Random rnd = new Random();
        public static StarFactory Instance //Singlton start
        {
            get
            {
                if (instance == null)
                {
                    instance = new StarFactory();
                }
                return instance;
            }
        } //Singleton end

        public override void CreateObject(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                GameObject item = new GameObject();
                SpriteRenderer rend = (SpriteRenderer)item.AddComponent(new SpriteRenderer());

                rend.SetSprite("Pixel");
                item.AddComponent(new BackgroundStars(rnd.Next(20, 150)));

                GameWorld.Instance.gameObjects.Add(item);
            }
        }
    }
}
