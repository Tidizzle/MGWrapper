using System;
using System.Collections.Generic;
using Engine.World;
using Microsoft.Xna.Framework;

namespace Engine.World
{
    public interface IWorld : ILoop
    {
        List<Level> Levels { get; set; }
        List<UserInterface> Uis { get; set; }
        string WorldName { get; set; }
    }
}