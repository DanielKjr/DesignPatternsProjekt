using Microsoft.Xna.Framework;

namespace DesignPatternsProjekt
{
    public class Enemy : Component
    {
        private float speed;
        private Vector2 velocity = new Vector2(0, 1);

        public Enemy(float _speed, Vector2 _velocity)
        {
            speed = _speed;
            velocity = new Vector2(_velocity.X, _velocity.Y);
        }
        public void Move()
        {
            GameObject.Transform.Translate(velocity * GameWorld.DeltaTime);
        }
    }
}
