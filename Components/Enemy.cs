using Microsoft.Xna.Framework;
using System;

namespace DesignPatternsProjekt
{
    public class Enemy : Component, IListner
    {
        private float speed;
        private Vector2 velocity = new Vector2(0, 1);
        private Vector2 spawnPoint = new Vector2(0, 0);
        private Random rnd = new Random();
        private bool canShoot = true;
        private float shootTime = 0;


        public Enemy(float _speed, Vector2 _velocity, Vector2 _spawnPoint)
        {
            speed = _speed;
            velocity = new Vector2(_velocity.X, _velocity.Y);
            spawnPoint = _spawnPoint;
        }
        public override void Start()
        {
            GameObject.Transform.Position = spawnPoint;
        }
        public void Move()
        {
            GameObject.Transform.Translate(velocity * GameWorld.DeltaTime * speed);
        }

        public void Shoot()
        {
            if (canShoot)
            {
                GameObject go = LaserFactory.Instance.CreateObject();
                go.Transform.Position = GameObject.Transform.Position;
                go.Tag = "EnemyLaser";

                Laser l = go.GetComponent<Laser>() as Laser;
                l.Velocity = this.velocity;

                //for at ændre rotationen på laseren til at passe med retningen 
                SpriteRenderer sr = go.GetComponent<SpriteRenderer>() as SpriteRenderer;

                if (l.Velocity.X == 1 || l.Velocity.X == -1)
                {
                    sr.Rotation = 1.58f;
                }
                 



                GameWorld.Instance.Instantiate(go);
            }
            canShoot = false;
        }

        public override void Update(GameTime gameTime)
        {
            Move();
            Shoot();
            shootTime += GameWorld.DeltaTime;

            if (shootTime > 1)
            {
                canShoot = true;
                shootTime = 0;
            }
        }

        public void Notify(CollisionEvent collisionEvent)
        {
            GameObject other = (collisionEvent as CollisionEvent).Other;
            SpriteRenderer sr = other.GetComponent<SpriteRenderer>() as SpriteRenderer;
            if (other.Tag == "Player")
            {
              //  sr.Color = Color.Black;
            }
        }
    }
}
