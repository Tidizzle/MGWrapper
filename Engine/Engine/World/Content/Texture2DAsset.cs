using System;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.World
{
    public class Texture2DAsset : Asset
    {
        public string Name;
        public Texture2D Asset;

        public Texture2DAsset(string name, Texture2D asset, bool usinglifetime = true,  uint lifespan = uint.MaxValue)
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