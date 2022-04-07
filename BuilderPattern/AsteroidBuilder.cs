using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace DesignPatternsProjekt
{
    public class AsteroidBuilder : IBuilder
    {
        private Random rnd = new Random();
        private GameObject gameObject;
        public void BuildGameObject()
        {
            gameObject = new GameObject();
            gameObject.Tag = "Asteroid";
            BuildComponents();
            Animator animator = (Animator)gameObject.GetComponent<Animator>();

            animator.AddAnimation(BuildAnimation("Normal", new string[] {"Astroids/Asteroid1", "Astroids/Asteroid2", "Astroids/Astroid3", "Astroids/Astroid4",
            "Astroids/Astroid5", "Astroids/Astroid6", "Astroids/Astroid7", "Astroids/Astroid8"
            }));
        }


        public void BuildComponents()
        {

            SpriteRenderer sr = (SpriteRenderer)gameObject.AddComponent(new SpriteRenderer());
            sr.SetSprite("Astroids/Asteroid1");
            gameObject.AddComponent(new Animator());
            Collider c = (Collider)gameObject.AddComponent(new Collider());
            sr.Scale = 0.3f;

            
            //GameWorld.Instance.Colliders.Add(c);

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
            gameObject.AddComponent(new Asteroid(80, moveDir, spawnPoint));
        }

        private Animation BuildAnimation(string animationName, string[] spriteNames)
        {
            Texture2D[] sprites = new Texture2D[spriteNames.Length];

            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = GameWorld.Instance.Content.Load<Texture2D>(spriteNames[i]);
            }

            Animation animation = new Animation(animationName, sprites, 10);

            return animation;
        }

        public GameObject GetResult()
        {
            return gameObject;
        }
    }

}
