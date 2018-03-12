using Microsoft.Xna.Framework;

namespace Engine.World
{
    
    //Initalize -> Load -> update -> physics step -> late update -> prerender -> render -> pre uirender -> ui render |-> destroy

    
    public class UiController : Manager
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
        
        //would be physics step

        public virtual void LateUpdate(GameTime time)
        {
            
        }
        
        //would be pre render
        
        //would be render

        public virtual void PreUiRender()
        {
            
        }
        
        //would be ui render

        public override void Destroy()
        {
        }
    }
}