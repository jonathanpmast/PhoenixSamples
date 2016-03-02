using PhoenixSystem.Engine.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoenixSystem.Engine.Channel;
using PhoenixSystem.Engine.Entity;

namespace PhoenixSample.PCL
{
    public class SampleGameManager : BaseGameManager
    {
        public SampleGameManager(IEntityAspectManager entityAspectManager, IEntityManager entityManager, IChannelManager channelManager) : base(entityAspectManager, entityManager, channelManager)
        {
        }
    }
}
