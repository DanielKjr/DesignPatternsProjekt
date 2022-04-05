using System;

namespace DesignPatternsProjekt
{
    public class LaserFactory : Factory
    {
        private static LaserFactory instance;
        public static LaserFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LaserFactory();
                }
                return instance;
            }
        }

        private LaserFactory()
        {
           
        }
        public override GameObject CreateObject()
        {
            GameObject go = new GameObject();
            SpriteRenderer sr = (SpriteRenderer)go.AddComponent(new SpriteRenderer());
            go.AddComponent(new Laser(0, -1));
            sr.SetSprite("laserRed04");

            return go;
        }
    }
}
