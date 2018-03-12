using System;
using System.Collections.Generic;
using Engine.Events;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Engine.Input
{
    public class Mouse : InputDevice
    {

        public static Vector2 Position { get; private set; }
        
        
        private static List<MouseState> states;
        private static int current;
        private static int previous;
        private const int oldest = 0;
        
        
        public static void Initalize()
        {
            BaseInit();

            states = new List<MouseState>();
        }

        public static void Update()
        {
            if (Initalized)
            {
                if (states.Count > 5)
                    states.Remove(states[oldest]);

                current = states.Count - 1;
                previous = states.Count - 2;
                if (previous < 0)
                    previous = 0;
                
                
                var newestState = Microsoft.Xna.Framework.Input.Mouse.GetState();
                states.Add(newestState);

                Position = new Vector2(newestState.X, newestState.Y);
            }
        }

        public static bool IsLeftClick()
        {
            if (states[current] == null)
                throw new NullReferenceException("Mouse State is Null, ensure that it is initalized");
            
            return states[current].LeftButton == ButtonState.Pressed && states[previous].LeftButton == ButtonState.Released;
        }

        public static bool IsLeftDoubleClick()
        {
            if (states[current] == null)
                throw new NullReferenceException("Mouse State is Null, ensure that it is initalized");

            return states[current].LeftButton == ButtonState.Pressed &&
                   states[previous].LeftButton == ButtonState.Released &&
                   states[states.Count - 3].LeftButton == ButtonState.Pressed &&
                   states[states.Count - 4].LeftButton == ButtonState.Released;
        }

        public static bool IsLeftUp()
        {
            if (states[current] == null)
                throw new NullReferenceException("Mouse State is Null, ensure that it is initalized");

            return states[current].LeftButton == ButtonState.Released &&
                   states[previous].LeftButton == ButtonState.Pressed;
        }

        public static bool IsLeftHeld()
        {
            if(states[current] == null)
                throw new NullReferenceException("Mouse state is null, ensure that it is initalized");

            return states[current].LeftButton == ButtonState.Pressed &&
                   states[previous].LeftButton == ButtonState.Pressed;
        }

        public static bool IsRightClick()
        {
            if(states[current] == null)
                throw new NullReferenceException("Mouse state is null, ensure that it is initalized");

            return states[current].RightButton == ButtonState.Pressed &&
                   states[previous].RightButton == ButtonState.Released;
        }

        public static bool IsRightDoubleClick()
        {
            if(states[current] == null)
                throw new NullReferenceException("Mouse state is null, ensure that it is initalized");

            return states[current].RightButton == ButtonState.Pressed &&
                   states[previous].RightButton == ButtonState.Released &&
                   states[states.Count - 3].RightButton == ButtonState.Pressed &&
                   states[states.Count - 4].RightButton == ButtonState.Released;
        }

        public static bool IsRightUp()
        {
            if(states[current] == null)
                throw new NullReferenceException("Mouse state is null, ensure that it is initalized");

            return states[current].RightButton == ButtonState.Released &&
                   states[previous].RightButton == ButtonState.Pressed;
        }

        public static bool IsRightHeld()
        {
            if(states[current] == null)
                throw new NullReferenceException("Mouse state is null, ensure that it is initalized");
            
            return states[current].RightButton == ButtonState.Released &&
                   states[current].RightButton == ButtonState.Released;
        }

        public static bool IsWheelUp(out int Amount)
        {
            if (states[current] == null)
                throw new NullReferenceException("Mouse state is null, ensure that it is initalized");

            int difference = states[current].ScrollWheelValue - states[previous].ScrollWheelValue;
            
            if (difference > 0)
            {
                Amount = difference;
                return true;
            }

            if (difference < 0)
            {
                Amount = -difference;
                return false;
            }

            Amount = 0;
            return false;
        }

        public static bool IsWheenDown(out int Amount)
        {
            if (states[current] == null)
                throw new NullReferenceException("Mouse state is null, ensure that it is initalized");

            int difference = states[current].ScrollWheelValue - states[previous].ScrollWheelValue;

            if (difference < 0)
            {
                Amount = Math.Abs(difference);
                return true;
            }
            
            if (difference > 0)
            {
                Amount = difference;
                return false;
            }

            Amount = 0;
            return false;
        }

        
        public static bool IsContainingCursor(Rectangle bounds) => bounds.Contains(Position);
        public static void ToggleVisibility() => Inter.OnMouseVisChanged();
        
    }
}