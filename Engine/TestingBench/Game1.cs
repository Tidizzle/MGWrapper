using System.Collections;
using System.Diagnostics;
using System.Resources;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TestingBench
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        private GraphicsDevice device;

        private BasicEffect effect;
        private VertexPositionColor[] Verticies;
        private int[] Indicies;

        private Matrix ViewMatrix;
        private Matrix ProjMatrix;
        private Matrix WorldMatrix;

        private float angle;
        
        int vertWidth = 5;
        int vertHeight = 5;

        private float scale = .5f;

        private Vector3 Position;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager( this );
            
            
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
            graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            scale = 1;
            
            base.Initialize();

            effect = new BasicEffect(GraphicsDevice)
            {
                Alpha = 1f,
                VertexColorEnabled = true
            };

            
            ViewMatrix = Matrix.CreateScale(.5f, .5f, .5f) *  Matrix.CreateLookAt(new Vector3(10, 50, -10), new Vector3(10, 0, -10), Vector3.Forward) ;
            ProjMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45f), device.Viewport.AspectRatio, 1f, 10000f);
            WorldMatrix = Matrix.CreateWorld(new Vector3(0, 0, 0), Vector3.Forward, Vector3.Up);
            
            var rs = new RasterizerState();
            rs.CullMode = CullMode.None;
            rs.FillMode = FillMode.WireFrame;    
            device.RasterizerState = rs;

            Position = new Vector3(10, 50, -10);
        }

        protected override void LoadContent()
        {
            device = graphics.GraphicsDevice;
        }

        protected override void Update( GameTime gameTime )
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                vertHeight++;
                vertWidth++;
            }
            
            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {

                if (vertHeight > 1 && vertWidth > 1)
                {
                    vertHeight--;
                    vertWidth--;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                Position.Y += 5;
            }
            
            if (Keyboard.GetState().IsKeyDown(Keys.F))
            {
                Position.Y -= 5;
            }
            
            ViewMatrix = Matrix.CreateScale(scale, scale, scale) *  Matrix.CreateLookAt(Position, new Vector3(10, 0, -10), Vector3.Forward) ;

            base.Update(gameTime);

            var numVerticies = vertHeight * vertWidth;
            Verticies = new VertexPositionColor[numVerticies];

            for (var i = 0; i < numVerticies ; i++)
            {
                var y = i / vertWidth;
                var x = i - (y * vertWidth);

                Verticies[i].Position = new Vector3(x * 5, 0f, -(y * 5));
                Verticies[i].Color = Color.White;
            }

            
            
            Indicies = new int[(vertWidth - 1) * (vertHeight - 1) * 3];
            int counter = 0;
            for (int y = 0; y < vertHeight - 1; y++)
            {
                for (int x = 0; x < vertWidth - 1; x++)
                {
                    int lowerLeft = x + y*vertWidth;
                    int lowerRight = (x + 1) + y*vertWidth;
                    int topLeft = x + (y + 1) * vertWidth;
                    int topRight = (x + 1) + (y + 1) * vertWidth;
 
                    Indicies[counter++] = topLeft;
                    Indicies[counter++] = lowerRight;
                    Indicies[counter++] = lowerLeft;
                }
            }
            
        }

        protected override void Draw( GameTime gameTime )
        {
            GraphicsDevice.Clear( Color.CornflowerBlue  );

            effect.View = ViewMatrix;
            effect.Projection = ProjMatrix;
            effect.World = Matrix.Identity;
            
            foreach (var pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                
                device.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, Verticies, 0, Verticies.Length, Indicies, 0, Indicies.Length / 3, VertexPositionColor.VertexDeclaration);
            }
            
            
            base.Draw( gameTime );
        }
    }
}
