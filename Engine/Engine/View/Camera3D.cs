using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.View
{
    public class Camera3D
    {
        public Matrix WorldMatrix;
        public Matrix ViewMatrix;
        public Matrix ProjectionMatrix;

        public Queue<int> RenderPipe;

    }
}