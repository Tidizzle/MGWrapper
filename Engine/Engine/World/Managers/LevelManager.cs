using Microsoft.Xna.Framework;

namespace Engine.World
{

    // initalize   load    update                                    Draw                                             dispose
    //{‾‾‾‾‾‾‾‾‾‾}{‾‾‾‾‾‾}{‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾}{‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾}{‾‾‾‾‾‾‾‾‾‾}  
    //Initalize -> Load -> update -> physics step -> late update -> prerender -> render -> pre uirender -> ui render |-> destroy
    
    public abstract class LevelManager : Manager
    {

        public abstract override void Initalize();
        
        public abstract override void Load();
        
        public abstract override void Update(GameTime time);
        public abstract void PhysicsUpdate(GameTime time);
        public abstract void LateUpdate(GameTime time);
        
        public abstract void PreRender();
        //Would be render
        //would be preui render
        //would be ui render
        
        public abstract override void Destroy();
    }
}