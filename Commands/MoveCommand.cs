using Microsoft.Xna.Framework;
using System;

namespace DesignPatternsProjekt
{
    public partial class MoveCommand : ICommand
    {
        private Vector2 velocity;

        public float rotation;

        public MoveCommand(Vector2 _velocity)
        {
            velocity = _velocity;
        }

        public MoveCommand(float rotationAmount)
        {
            rotation = rotationAmount;
        }

        public void Execute(Player player)
        {
            player.Move(velocity);
            SpriteRenderer sr = player.GameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;
            sr.Rotation += rotation;
          
          


        }
    }
}
