using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsProjekt
{
    public class ColorChange : Component
    {
        Vector2 spawnPoint;
        public ColorChange(Vector2 _spawnPoint)
        {
            spawnPoint = _spawnPoint;
        }
        public override void Start()
        {
            GameObject.Transform.Position = spawnPoint;
        }
        
    }
}
