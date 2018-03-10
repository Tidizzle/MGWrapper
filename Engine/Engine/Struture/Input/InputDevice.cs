using System.Collections.Generic;
using System.Globalization;
using Microsoft.Xna.Framework.Input;

namespace Engine.Struture.Input
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