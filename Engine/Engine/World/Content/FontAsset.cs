using System;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.World
{
    public class FontAsset : Asset
    {
        public string Name;
        public SpriteFont Asset;
        
        public FontAsset(string name, SpriteFont asset, bool usinglifetime = true,  uint lifespan = uint.MaxValue)
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