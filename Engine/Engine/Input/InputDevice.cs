namespace Engine.Input
{
    public class InputDevice
    {
        protected static bool Initalized; 
        
        protected static void BaseInit()
        {
            Initalized = true;
        }

        protected static void BaseDestroy()
        {
            Initalized = false;
        }
    }
}