using Microsoft.Xna.Framework.Graphics;
using PhoenixSystem.Engine.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoenixSample.PCL.Monogame.Components
{
    public class SpriteComponent : BaseComponent
    {
        public bool IsAnimating { get; set; } = true;
        public Texture2D Texture{ get; set; }
        public float FrameRate { get; set; }
        public string CurrentAnimation { get; set; }

        public override IComponent Clone()
        {
            return new SpriteComponent()
            {
                IsAnimating = this.IsAnimating,
                Texture = this.Texture,
                FrameRate = this.FrameRate,
                CurrentAnimation = this.CurrentAnimation
            };      
        }

        public override void Reset()
        {
            IsAnimating = true;
            Texture = null;
            FrameRate = 0.0f;
            CurrentAnimation = String.Empty;
        }
    }
}
