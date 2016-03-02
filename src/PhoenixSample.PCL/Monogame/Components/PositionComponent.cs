using Microsoft.Xna.Framework;
using PhoenixSystem.Engine.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoenixSample.PCL.Monogame.Components
{
    public class PositionComponent : BaseComponent
    {
        private Vector2 _position = Vector2.Zero;

        public PositionComponent() { }
        public PositionComponent(float x, float y)
        {
            _position = new Vector2(x, y);
        }

        public float X
        {
            get { return _position.X; }
            set { _position.X = value; }
        }
        
        public float Y
        {
            get { return _position.Y; }
            set { _position.Y = value; }
        }

        public Vector2 Vector { get { return _position; } }

        public override IComponent Clone()
        {
            return new PositionComponent(X, Y);
        }

        public override void Reset()
        {
            _position = Vector2.Zero;
        }
    }
}
