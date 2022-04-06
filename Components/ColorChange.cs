using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsProjekt
{
    public class ColorChange : Component, IListner
    {
        Vector2 spawnPoint;
        public ColorChange(Vector2 _spawnPoint)
        {
            spawnPoint = _spawnPoint;
        }

        public void Notify(CollisionEvent collisionEvent)
        {
            GameObject other = (collisionEvent as CollisionEvent).Other;
          
            if (other.Tag == "Player")
            {
               // GameWorld.Instance.Destroy(this.GameObject);
            }
        }

        public override void Start()
        {
            GameObject.Transform.Position = spawnPoint;
        }
        
    }
}
