using PhoenixSystem.Engine.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoenixSystem.Engine;
using PhoenixSystem.Engine.Game;
using PhoenixSample.PCL.Monogame.Aspects;
using PhoenixSystem.Engine.Channel;
using Microsoft.Xna.Framework.Graphics;
using PhoenixSample.PCL.Monogame.Components;
using PhoenixSystem.Engine.Extensions;

namespace PhoenixSample.PCL.Systems
{
    public class SpriteRenderSystem : BaseSystem, IDrawableSystem
    {
        private IEnumerable<SpriteRenderAspect> _aspects;
        SpriteBatch _spriteBatch;
        public SpriteRenderSystem(SpriteBatch spriteBatch, IChannelManager channelManager, int priority, string[] channels) : base(channelManager, priority, channels)
        {
            _spriteBatch = spriteBatch;
        }

        public bool IsDrawing
        {
            get; private set;
        } = false;

        public override void AddToGameManager(IGameManager gameManager)
        {
            _aspects = gameManager.GetAspectList<SpriteRenderAspect>();
        }


        public override void RemoveFromGameManager(IGameManager gameManager)
        {

        }

        public override void Update(ITickEvent tickEvent)
        {

        }

        public void Draw(ITickEvent tickEvent)
        {
            foreach (var aspect in _aspects)
            {
                var sprite = aspect.GetComponent<SpriteComponent>();
                var position = aspect.GetComponent<PositionComponent>();
                
                
            }
        }
    }
}
