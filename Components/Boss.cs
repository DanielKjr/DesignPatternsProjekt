using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsProjekt
{
    class Boss : Component, IListner
    {
        private float speed;
        private Vector2 velocity = new Vector2(0, 1);
        private int newDirTimer = 0;
        private bool blockNewDir;
        private int desiredYPos;
        private int shotgunTimer = 0;
        private int megaAttackTimer = 120;
        private int megaAttackStep = 0;
        private Random rnd = new Random();
        private Color[] colors = new Color[] { Color.Red, Color.Blue, Color.Green, Color.Magenta, Color.Brown, Color.Yellow, Color.Teal};
        private float bossColorTimer = 0;
        private float bossColorTimerMax = 1;
        public int Health { get; set; }
        public Boss(float _speed, int _health, int _desiredYPos)
        {
            speed = _speed;
            Health = _health;
            desiredYPos = _desiredYPos;
        }
        public override void Start()
        {
            GameObject.Transform.Position = new Vector2(GameWorld.Instance.Graphics.PreferredBackBufferWidth / 2, 0);
        }
        private void Move()
        {
            if (GameObject.Transform.Position.Y > desiredYPos && newDirTimer <= 0)
            {
                velocity = new Vector2(rnd.Next(-1, 2), 0);
                newDirTimer = rnd.Next(60, 180);
            }
            CheckBoundaries();

            if (!blockNewDir) newDirTimer--; //Countdown until new random movement
            else
            { //If too far left, re-center using this.
                if (GameObject.Transform.Position.X > (GameWorld.Instance.Graphics.PreferredBackBufferWidth / 2) - 50 && GameObject.Transform.Position.X > (GameWorld.Instance.Graphics.PreferredBackBufferWidth / 2) + 50)
                {
                    blockNewDir = false;
                    newDirTimer = 0;
                }
            }

            GameObject.Transform.Translate(velocity * GameWorld.DeltaTime * speed);
        }
        private void CheckBoundaries()
        {
            if (GameObject.Transform.Position.X < GameWorld.Instance.Graphics.PreferredBackBufferWidth / 6)
            {
                //If too far left or right, re-center
                blockNewDir = true;
                velocity = new Vector2(1, 0);
            }
            if (GameObject.Transform.Position.X > GameWorld.Instance.Graphics.PreferredBackBufferWidth - GameWorld.Instance.Graphics.PreferredBackBufferWidth / 6)
            {
                blockNewDir = true;
                velocity = new Vector2(-1, 0);
            }
        }
        public void Shoot()
        {
            if (shotgunTimer <= 0)
            {
                Shotgun(AngleToPlayer());
            }
            shotgunTimer--;

            if(megaAttackTimer <= 0) MegaAttack();
            megaAttackTimer--;
        }
        public override void Update(GameTime gameTime)
        {
            Move();
            Shoot();
            ChangeColor();
            if (Health <= 0)
            {
                GameWorld.Instance.Destroy(this.GameObject);
            }
        }
        private int AngleToPlayer()
        {
            Player player = (Player)GameWorld.Instance.FindObjectOfType<Player>();
            float angleToPlayer = (float)Math.Atan2(GameObject.Transform.Position.X - player.GameObject.Transform.Position.X, player.GameObject.Transform.Position.Y - GameObject.Transform.Position.Y);
            angleToPlayer = (angleToPlayer * (180 / (float)Math.PI)) + 180;
            return (int)angleToPlayer;
        }
        private void Shotgun(int angle)
        {
            for (int i = angle - 30; i < angle + 40; i += 15) //Shotgun attack
            {
                RadialAttack(i);
            }
            shotgunTimer = 180;
        }
        private void MegaAttack()
        {
            RadialAttack(90 + megaAttackStep);
            RadialAttack(270 - megaAttackStep);
            megaAttackStep += 10;
            megaAttackTimer = 15;
            if (megaAttackStep >= 90)
            {
                megaAttackStep = 0;
                megaAttackTimer = 1200;
            }
            shotgunTimer = 120;
        }
        private void RadialAttack(int angle)
        {
            GameObject item = LaserFactory.Instance.CreateObject();
            item.Transform.Position = GameObject.Transform.Position;
            item.Tag = "EnemyLaser";

            Laser l = item.GetComponent<Laser>() as Laser;
            l.Velocity = new Vector2((float)Math.Cos(((Math.PI / 180) * (angle - 90))), (float)Math.Sin(((Math.PI / 180) * (angle - 90))));
            GameWorld.Instance.Instantiate(item);
            SpriteRenderer sr = item.GetComponent<SpriteRenderer>() as SpriteRenderer;
            sr.Rotation = (float)((Math.PI / 180) * (angle + 180));
        }

        private void ChangeColor()
        {
            bossColorTimer += GameWorld.DeltaTime;
            if (bossColorTimer >= bossColorTimerMax)
            {
                SpriteRenderer eSr = this.GameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;
                eSr.Color = colors[rnd.Next(colors.Length)];
                bossColorTimer = 0;
            }
            
        }

        public void Notify(CollisionEvent collisionEvent)
        {
            GameObject other = (collisionEvent as CollisionEvent).Other;
            if (other.Tag == "PlayerLaser")
            {
                Health--;
                GameWorld.Instance.Destroy(other);
            }
        }
    }
}
