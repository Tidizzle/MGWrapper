using System;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.World.Level
{
    public class Texture3DAsset : Asset
    {
        public string Name;
        public Texture3D Asset;
        
        public Texture3DAsset(string name, Texture3D asset, bool usinglifetime = true,  uint lifespan = uint.MaxValue)
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