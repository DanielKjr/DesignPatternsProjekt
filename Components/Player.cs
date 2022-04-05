using Microsoft.Xna.Framework;

namespace DesignPatternsProjekt
{
    public class Player : Component
    {
        private float speed;
        private bool canShoot = true;

        private Animator animator;



        public void Move(Vector2 _velocity)
        {
            if (_velocity != Vector2.Zero)
            {
                _velocity.Normalize();
            }

            _velocity *= speed;

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

        public void Shoot()
        {
            if (canShoot)
            {
                GameObject go = LaserFactory.Instance.CreateObject();
                go.Transform.Position = GameObject.Transform.Position;
                GameWorld.Instance.Instantiate(go);
            }
            canShoot = false;
        }
    }
}
