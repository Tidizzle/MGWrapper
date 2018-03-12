using System;

namespace Engine.Events
{
    public class Inter
    {
                
        public delegate void MouseVisChangedEventHandler(object sender = null, EventArgs args = null);
        public static event MouseVisChangedEventHandler MouseVisChanged;

        public static void OnMouseVisChanged()
        {
            if (MouseVisChanged != null)
                MouseVisChanged();
            
            //TODO: Add subscriber in main game to change mouse vis
        }
        
        
    }
}