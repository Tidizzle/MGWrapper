using Engine;

using System;
using System.Collections.Generic;
using Engine.Rendering;

namespace EngineTestApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var param = new GameParams(500, 500, false, false);
            var audio = new Audio();
            var content = new Content();
            var ui = new Ui();
            var level = new Level();

            var rend3 = new Rend3d();
            var rend2 = new Rend2d();
            
            Engine.Application app = new Application(param, audio, content, ui, level, rend3, rend2);
            
            app.Start();
        }
    }
}