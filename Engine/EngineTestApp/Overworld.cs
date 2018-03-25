using System.Collections.Generic;
using Engine.World;
using Engine.World.Level;
using Microsoft.Xna.Framework;


namespace EngineTestApp
{
    public class Overworld : IWorld
    {
        public List<Level.Level> Levels { get; set; }
        public List<Screen> Uis { get; set; }
        
        public string WorldName { get; set; }
        
        public void Initalize()
        {
            
        }

        public void Load()
        {
        }

        public void Update(GameTime time)
        {
        }

        public void PhysicsUpdate(GameTime time)
        {
        }

        public void LateUpdate(GameTime time)
        {
        }

        public void PreRender()
        {
        }

        public void PreUIRender()
        {
        }

        public void Destroy()
        {
        }

    }
}