using System.Collections.Generic;
using Engine.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace EngineTestApp
{
    
    public class Content : ContentController
    {
        public Dictionary<string, Model> Models;
        public Dictionary<string, Texture2D> Textures;
        public Dictionary<string, SoundEffect> Sounds;
        
        public override void Initalize()
        {
            base.Initalize();
        }

        public override void Load()
        {
            base.Load();
        }

        public override void Update(GameTime time)
        {
            base.Update(time);
        }
    }
}