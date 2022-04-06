using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace DesignPatternsProjekt
{
    public partial class Collider : Component
    {
        private SpriteRenderer spriteRenderer;
        private Texture2D texture;
        public CollisionEvent CollisionEvent { get; set; } = new CollisionEvent();

        public Rectangle CollisionBox
        {
            get
            {

                if (GameObject.Tag == "Player")
                {
                    return new Rectangle(
                         (int)(GameObject.Transform.Position.X - 45),
                    (int)(GameObject.Transform.Position.Y - 55),
                    spriteRenderer.Sprite.Width / 4,
                    spriteRenderer.Sprite.Height / 3
                    );
                }
                else if (GameObject.Tag == "ColorChange")
                {
                    return new Rectangle(
                  (int)(GameObject.Transform.Position.X - spriteRenderer.Sprite.Width + 72),
                  (int)(GameObject.Transform.Position.Y - spriteRenderer.Sprite.Height + 72),
                  spriteRenderer.Sprite.Width / 2,
                  spriteRenderer.Sprite.Height / 2
                  );
                }
                else
                {
                    return new Rectangle(
                  (int)(GameObject.Transform.Position.X - spriteRenderer.Sprite.Width / 2),
                  (int)(GameObject.Transform.Position.Y - spriteRenderer.Sprite.Height / 2),
                  spriteRenderer.Sprite.Width,
                  spriteRenderer.Sprite.Height
                  );
                }

            }

        }

        public override void Start()
        {
            spriteRenderer = (SpriteRenderer)GameObject.GetComponent<SpriteRenderer>();
            texture = GameWorld.Instance.Content.Load<Texture2D>("Pixel");

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            DrawRectangle(CollisionBox, spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            CheckCollision();
        }

        private void DrawRectangle(Rectangle collisionBox, SpriteBatch spriteBatch)
        {
            Rectangle topLine = new Rectangle(collisionBox.X, collisionBox.Y, collisionBox.Width, 1);
            Rectangle bottomLine = new Rectangle(collisionBox.X, collisionBox.Y + collisionBox.Height, collisionBox.Width, 1);
            Rectangle rightLine = new Rectangle(collisionBox.X + collisionBox.Width, collisionBox.Y, 1, collisionBox.Height);
            Rectangle leftLine = new Rectangle(collisionBox.X, collisionBox.Y, 1, collisionBox.Height);

            spriteBatch.Draw(texture, topLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(texture, bottomLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(texture, rightLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(texture, leftLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
        }

        private void CheckCollision()
        {
            foreach (Collider other in GameWorld.Instance.Colliders)
            {
                if (other != this && other.CollisionBox.Intersects(CollisionBox))
                {

                    
                    if (other.GameObject.Tag == "Enemy" && this.GameObject.Tag != "EnemyLaser" && this.GameObject.Tag != "Enemy" || other.GameObject.Tag == "ColorChange")
                    {
                        CollisionEvent.OnCollision(other.GameObject);

                        // GameWorld.Instance.Destroy(other.GameObject);



                    }

                }


            }
        }
    }
}
