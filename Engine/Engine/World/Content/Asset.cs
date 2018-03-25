using System;

namespace Engine.World
{
    public class Asset
    {
        public Guid Guid;
        public bool UsingLifeTime;
        public DateTime CreationTime;
        public DateTime LastUse;
        public uint LifeSpan;
    }
}