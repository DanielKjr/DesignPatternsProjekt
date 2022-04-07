using Microsoft.Xna.Framework;

namespace DesignPatternsProjekt
{
 
    public class Laser : Component, IListner
    {
        private float speed;
        private Vector2 velocity;

        public Vector2 Velocity { get => velocity; set => velocity = value; }

        public Laser(int x, int y)
        {
            speed = 500;
            velocity = new Vector2(x, y);
        }

        public override void Update(GameTime gameTime)
        {
            Move();
        }


        public override void Start()
        {
            
        }
        private void Move()
        {
            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }

            velocity *= speed;

            GameObject.Transform.Translate(velocity * GameWorld.DeltaTime);

            //destroy when it reaches any of the edges
            if (GameObject.Transform.Position.Y < 0 ||
                GameObject.Transform.Position.Y >= GameWorld.Instance.Graphics.PreferredBackBufferHeight ||
                GameObject.Transform.Position.X < 0 ||
                GameObject.Transform.Position.X >= GameWorld.Instance.Graphics.PreferredBackBufferWidth)
            {
                GameWorld.Instance.Destroy(this.GameObject);
            }


        }

        public void Notify(CollisionEvent collisionEvent)
        {
            GameObject other = (collisionEvent as CollisionEvent).Other;
            SpriteRenderer otherSr = (SpriteRenderer)other.GetComponent<SpriteRenderer>() as SpriteRenderer;
            SpriteRenderer sr = (SpriteRenderer)GameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;


        }
    }
}
