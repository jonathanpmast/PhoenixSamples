﻿using PhoenixSample.PCL.Monogame.Components;
using PhoenixSystem.Engine.Aspect;
using PhoenixSystem.Engine.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoenixSample.PCL.Monogame.Aspects
{
    [AssociatedComponents(typeof(AnimationComponent),typeof(TextureRenderComponent))]
    public class SpriteAnimationAspect :BaseAspect
    {
    }
}
