using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Engine.World
{
    // Initialize (-> Load) -> update -> physics step -> late update -> Render -> Ui Render
    
    public class LevelManager : Manager
    {
        
        public override void Initalize()
        {
        }

        public override void Load()
        {
            
        }

        public override void Update(GameTime time)
        {
            
        }

        public virtual void PhysicsUpdate(GameTime time)
        {
            
        }

        public virtual void LateUpdate(GameTime time)
        {
            
        }

        //used to push all objects to draw to the renderer
        public virtual void PreRender()
        {
            
        }
        
        //Would be render

        //would be preui render
        
        //would be ui render

        public override void Destroy()
        {
            
        }
        
        //Initalize -> Load -> update -> physics step -> late update -> prerender -> render -> pre uirender -> ui render |-> destroy
    }
}