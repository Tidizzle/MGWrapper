using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using KeyBoard = Microsoft.Xna.Framework.Input.Keyboard;


namespace Engine.Struture.Input
{
    public class Keyboard : InputDevice
    {

        private static List<KeyboardState> _states;

        public static void Initalize()
        {
            BaseInit();
            
            _states = new List<KeyboardState>();
        }
        
        
        public static void Update()
        {
            if (Initalized)
            {
                //Build up collection to 5 keyboard states before starting to remove the oldest
                if(_states.Count > 5)
                    _states.Remove(_states[0]);
                
                _states.Add(KeyBoard.GetState());
            }
        }

        public static bool IsKeyDown(Keys Key)
        {
            if(_states[_states.Count - 1] == null)
                throw new NullReferenceException("Keyboard State is null, make sure you are initializing first");

            return _states[_states.Count - 1].IsKeyDown(Key);
        }

        public static bool IsKeyHeld(Keys Key)
        {
            if(_states[_states.Count - 1] == null)
                throw new NullReferenceException("Keyboard State is null, make sure you are initializing first");

            return _states[_states.Count - 2].IsKeyDown(Key) && _states[_states.Count - 1].IsKeyDown(Key);
        }

        public static bool IsKeyUp(Keys Key)
        {
            if (_states[_states.Count - 1] == null)
                throw new NullReferenceException("Keyboard State is null, make sure you are initializing first");

            return _states[_states.Count -1].IsKeyUp(Key);
        }

        public static bool DidDoubleClick(Keys Key)
        {
            if (_states[_states.Count - 1] == null)
                throw new NullReferenceException("Keyboard State is null, make sure you are initializing first");

            return _states[_states.Count - 1].IsKeyUp(Key)     && 
                   _states[_states.Count - 2].IsKeyDown(Key)   &&
                   _states[_states.Count - 3].IsKeyUp(Key)     && 
                   _states[_states.Count - 4].IsKeyDown(Key);
        }


        public static void Destroy()
        {
            BaseDestroy();
            
            _states.Clear();
            _states = null;
        }
        
    }
}