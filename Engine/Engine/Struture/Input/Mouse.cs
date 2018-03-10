using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Engine.Struture.Input
{
    public class Mouse : InputDevice
    {

        public static Vector2 Position { get; private set; }
        
        private static List<MouseState> _states;
        
        public static void Initalize()
        {
            BaseInit();

        }

        public static void Update()
        {
            if (Initalized)
            {
                if (_states.Count > 5)
                    _states.Remove(_states[0]);
                
                var newestState = Microsoft.Xna.Framework.Input.Mouse.GetState();
                _states.Add(newestState);

                Position = new Vector2(newestState.X, newestState.Y);
            }
        }

        public static void ToggleVisibility()
        {
            Microsoft.Xna.Framework.Input.Mouse.
        }
        
    }
}