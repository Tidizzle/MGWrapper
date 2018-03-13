using Engine;

using System;
using System.Collections.Generic;

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
            
            Engine.Application app = new Application(param, audio, content, ui, level);
            
            app.Start();
        }
    }
}