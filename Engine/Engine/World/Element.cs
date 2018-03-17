using Microsoft.Xna.Framework;

namespace Engine.World
{
    public abstract class Element
    {
        public abstract void Initalize();
        public abstract void Load();
        public abstract void Update(GameTime time);
        public abstract void PhysicsUpdate(GameTime time);
        public abstract void LateUpdate(GameTime time);
        public virtual void PreRender(){}
        public virtual void PreUiRender(){}
        public virtual void Destroy(){}

    }
}