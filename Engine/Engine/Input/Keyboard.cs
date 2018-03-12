using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using KeyBoard = Microsoft.Xna.Framework.Input.Keyboard;


namespace Engine.Input
{
    public class Keyboard : InputDevice
    {

        private static List<KeyboardState> states;
        private static int current;
        private static int previous;
        
        
        public static void Initalize()
        {
            BaseInit();
            
            states = new List<KeyboardState>();
        }
        
        
        public static void Update()
        {
            if (Initalized)
            {
                //Build up collection to 5 keyboard states before starting to remove the oldest
                if(states.Count > 5)
                    states.Remove(states[0]);
                
                states.Add(KeyBoard.GetState());

                current = states.Count - 1;
                previous = states.Count - 2;
                if (previous < 0)
                    previous = 0;
            }
        }

        public static bool IsKeyDown(Keys Key)
        {
            if(states[current] == null)
                throw new NullReferenceException("Keyboard State is null, make sure you are initializing first");

            return states[current].IsKeyDown(Key) && states[previous].IsKeyUp(Key);
        }

        public static bool IsKeyHeld(Keys Key)
        {
            if(states[current] == null)
                throw new NullReferenceException("Keyboard State is null, make sure you are initializing first");

            return states[previous].IsKeyDown(Key) && states[current].IsKeyDown(Key);
        }

        public static bool IsKeyUp(Keys Key)
        {
            if (states[current] == null)
                throw new NullReferenceException("Keyboard State is null, make sure you are initializing first");

            return states[current].IsKeyUp(Key) && states[previous].IsKeyDown(Key);
        }

        public static bool DidDoubleClick(Keys Key)
        {
            if (states[current] == null)
                throw new NullReferenceException("Keyboard State is null, make sure you are initializing first");

            return states[current].IsKeyUp(Key) && 
                   states[previous].IsKeyDown(Key) &&
                   states[states.Count - 3].IsKeyUp(Key) && 
                   states[states.Count - 4].IsKeyDown(Key);
        }


        public static void Destroy()
        {
            BaseDestroy();
            
            states.Clear();
            states = null;
        }
        
    }
}