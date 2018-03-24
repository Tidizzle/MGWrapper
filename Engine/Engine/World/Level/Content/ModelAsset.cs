using System;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.World.Level
{
    public class ModelAsset : Asset
    {
        public string Name;
        public Model Asset;

        public ModelAsset(string name, Model asset, bool usingLifeTime = true, uint lifetime = uint.MaxValue)
        {
            Guid = new Guid();
            Name = name;
            Asset = asset;

            if (usingLifeTime)
            {
                UsingLifeTime = true;
                CreationTime = DateTime.Now;
                LastUse = DateTime.Now;
                LifeSpan = lifetime;
            }
            else
                UsingLifeTime = false;
        }
    }
}