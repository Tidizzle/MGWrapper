using Microsoft.Xna.Framework;

namespace Engine.World
{
    
    // initalize   load    update                                    Draw                                             dispose
    //{‾‾‾‾‾‾‾‾‾‾}{‾‾‾‾‾‾}{‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾}{‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾}{‾‾‾‾‾‾‾‾‾‾}  
    //Initalize -> Load -> update -> physics step -> late update -> prerender -> render -> pre uirender -> ui render |-> destroy
    
    public abstract class  UIManager : Manager
    {
        
        public abstract override void Initalize();
        
        public abstract override void Load();
        
        public abstract override void Update(GameTime time);
        //would be physics step
        public abstract void LateUpdate(GameTime time);
        
        //would be pre render
        //would be render
        public abstract void PreUiRender();
        //would be ui render
        
        public abstract override void Destroy();
    }
}