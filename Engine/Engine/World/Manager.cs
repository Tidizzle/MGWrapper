using Microsoft.Xna.Framework;

namespace Engine.World
{
    public abstract class Manager
    {
        public abstract void Initalize();
        public abstract void Load();
        public abstract void Update(GameTime time);
        public abstract void Destroy();
    }
}