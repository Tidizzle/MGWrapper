using System;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.World.Level
{
    public class TextureCubeAsset : Asset
    {
        public string Name;
        public TextureCube Asset;
        
        public TextureCubeAsset(string name, TextureCube asset, bool usinglifetime = true,  uint lifespan = uint.MaxValue)
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