using Microsoft.Xna.Framework;

namespace Engine.World
{
    public interface ILoop
    {
        void Initalize();
        void Load();
        void Update(GameTime time);
        void PhysicsUpdate(GameTime time);
        void LateUpdate(GameTime time);
        void PreRender();
        void PreUIRender();
        void Destroy();
    }
}