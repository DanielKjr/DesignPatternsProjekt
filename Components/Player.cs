using Microsoft.Xna.Framework;

namespace DesignPatternsProjekt
{
    public class Player : Component, IListner
    { 
        private float speed;
        private bool canShoot = true;
        private Vector2 velocity;
        private Animator animator;



        public void Move(Vector2 _velocity)
        {
            if (_velocity != Vector2.Zero)
            {
                _velocity.Normalize();
            }

            _velocity *= speed;
            velocity = _velocity;
            GameObject.Transform.Translate(_velocity * GameWorld.DeltaTime);
        }

        public override void Awake()
        {
            speed = 200;
        }


        public override void Start()
        {
            SpriteRenderer sr = GameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;
            // sr.SetSprite("Insert sprite path here");
            sr.SetSprite("PlayerAnimation/Ship1");
            sr.Scale = 0.3f;
            sr.Rotation = 4.7f;
            GameObject.Transform.Position = new Vector2(GameWorld.Instance.Graphics.PreferredBackBufferWidth / 2, GameWorld.Instance.Graphics.PreferredBackBufferHeight / 2);
            animator = (Animator)GameObject.GetComponent<Animator>();
        }

        private float shootTime = 0;
        public override void Update(GameTime gameTime)
        {
            InputHandler.Instance.Execute(this);

            if (!canShoot)
            {
                shootTime += GameWorld.DeltaTime;

                if (shootTime > 1)
                {
                    canShoot = true;
                    shootTime = 0;
                }
            }
            animator.PlayAnimation("Normal");

        }
        private Vector2 temptVelocity = new Vector2(0,-1);
        public void Shoot()
        {
            if (canShoot)
            {
                GameObject go = LaserFactory.Instance.CreateObject();
                go.Transform.Position = GameObject.Transform.Position;

                SpriteRenderer sr = go.GetComponent<SpriteRenderer>() as SpriteRenderer;

                Laser l = go.GetComponent<Laser>() as Laser;

                
                //if (velocity == Vector2.Zero)
                //{
                //    l.Velocity = new Vector2(0, -1);

                //}

                if (velocity != Vector2.Zero)
                {
                    l.Velocity = velocity;
                    temptVelocity = velocity;
                }
                else
                {
                    l.Velocity = temptVelocity;
                }
               

                if (l.Velocity.Y != -1 && l.Velocity.Y != 1)
                {
                    sr.Rotation = 1.58f;
                }

                GameWorld.Instance.Instantiate(go);
            }
            canShoot = false;
        }

        public void Notify(CollisionEvent collisionEvent)
        {
            GameObject other = (collisionEvent as CollisionEvent).Other;

            if (other.Tag == "Enemy")
            {
              //  GameWorld.Instance.Destroy(other);
            }
        }
    }
}
