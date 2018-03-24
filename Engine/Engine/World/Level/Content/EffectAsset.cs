using System;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.World.Level
{
    public class EffectAsset : Asset
    {
        public string Name;
        public Effect Asset;
       
        public EffectAsset(string name, Effect asset, bool usinglifetime = true,  uint lifespan = uint.MaxValue)
        {
            Guid = new Guid();
            Name = name;
            Asset = asset;

            if (usinglifetime)
            {
                UsingLifeTime = true;
                CreationTime = DateTime.Now;
                LastUse = DateTime.Now;
                LifeSpan = lifespan;
            }
            else
                UsingLifeTime = false;
        }
    }
}