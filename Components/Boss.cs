using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsProjekt
{
    class Boss : Component
    {
        private float speed;
        private Vector2 velocity = new Vector2(0, 1);
        private int desiredYPos;
        private int shootTimer = 0;
        private List<Laser> la = new List<Laser>();
        public int Health { get; set; }
        public Boss(float _speed, int _health, int _desiredYPos)
        {
            speed = _speed;
            Health = _health;
            desiredYPos = _desiredYPos;
        }
        public override void Start()
        {
            GameObject.Transform.Position = new Vector2(GameWorld.Instance.Graphics.PreferredBackBufferWidth/2,0);
        }
        private void Move()
        {
            if (GameObject.Transform.Position.Y < desiredYPos)
            {
                GameObject.Transform.Translate(velocity * GameWorld.DeltaTime * speed);
            }
        }
        public void Shoot()
        {
            if (shootTimer <= 0)
            {
                for (int i = 0; i < 360; i+=10) //Circle laser attack
                {
                    GameObject item = LaserFactory.Instance.CreateObject();
                    item.Transform.Position = GameObject.Transform.Position;
                    item.Tag = "EnemyLaser";

                    Laser l = item.GetComponent<Laser>() as Laser;
                    l.Velocity = new Vector2((float)Math.Cos(i),(float)Math.Sin(i));
                    GameWorld.Instance.Instantiate(item);
                    SpriteRenderer sr = item.GetComponent<SpriteRenderer>() as SpriteRenderer;
                    sr.Rotation = (float)Math.Cos(i)-(float)Math.Sin(i); //----------------------------------------------FIGURE THIS SHIT OUT LATER.
                }
                shootTimer = 60;
                //rend.Rotation = (float)((3.14 / 180) * 90);
            }
            shootTimer--;
        }
        public override void Update(GameTime gameTime)
        {
            Move();
            Shoot();
        }
    }
}
