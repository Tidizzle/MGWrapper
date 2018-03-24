using System;
using System.Collections.Generic;
using Engine.Rendering;
using Engine.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public class Application : Game
    {   
        public Manager Audio;
        public Manager Content;
        public Manager UI;
        public LevelManager Level;

        public GraphicsDevice Graphics;
        public GraphicsDeviceManager GraphicsManager;

        public Renderer3D GeneralRenderer;
        public Renderer2D UiRenderer;
        
        
        // initalize   load    update                                    Draw                                             dispose
        //{‾‾‾‾‾‾‾‾‾‾}{‾‾‾‾‾‾}{‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾}{‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾}{‾‾‾‾‾‾‾‾‾‾}  
        //Initalize -> Load -> update -> physics step -> late update -> prerender -> render -> pre uirender -> ui render |-> destroy
        
        public Application(GameParams inputParamaters, Manager audio, Manager content, UiController ui, LevelManager level, Renderer3D rend3d, Renderer2D rend2d)
        {

            GraphicsManager = new GraphicsDeviceManager(this);
            Graphics = GraphicsManager.GraphicsDevice;

            GraphicsManager.PreferredBackBufferWidth     =     inputParamaters.WindowWidth;
            GraphicsManager.PreferredBackBufferHeight    =     inputParamaters.WindowHeight;
            GraphicsManager.IsFullScreen                 =     inputParamaters.IsFullScreen;
            GraphicsManager.PreferMultiSampling          =     inputParamaters.PreferMultisampling;

            if (inputParamaters.Rasterizer != null)
                Graphics.RasterizerState = inputParamaters.Rasterizer;
            
            Content = content;
            Audio = audio;
            UI = ui;
            Level = level;

            GeneralRenderer = rend3d;
            UiRenderer = rend2d;
        }

        public void Start()
        {
            Run();
        }
        
        protected override void Initialize()
        {
            
            if (Audio == null || Content == null || UI == null || Level == null)
                throw new NullReferenceException("A manager is null, make sure to initalize them");
            
            Content.Initalize();
            Audio.Initalize();
            UI.Initalize();
            Level.Initalize();
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            
            base.LoadContent();

            Content.Load();
            Audio.Load();
            UI.Load();
            Level.Load();
        }
        
        protected override void Update(GameTime gameTime)
        {
            
            base.Update(gameTime);
            
            Content.Update(gameTime);
            Audio.Update(gameTime);
            UI.Update(gameTime);
            Level.Update(gameTime);
            
            
            PhysicsUpdate(gameTime);
            LateUpdate(gameTime);
        }

        protected void PhysicsUpdate(GameTime gameTime)
        {
            Level.PhysicsUpdate(gameTime);
        }

        protected void LateUpdate(GameTime gameTimee)
        {
            Level.LateUpdate(gameTimee);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);
            
            PreRender();
            Render();
            
            PreUiRender();
            UiRender();
        }
        
        protected void PreRender()
        {
            Level.PreRender();
        }

        protected void Render()
        {
            GeneralRenderer.Render();
            UiRenderer.Render();
        }

        protected void PreUiRender()
        {
            UI.PreUiRender();
        }

        protected void UiRender()
        {
            GeneralRenderer.UiRender();
            UiRenderer.UiRender();
        }
        


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            
            Audio.Destroy();
            UI.Destroy();
            Level.Destroy();
            Content.Destroy();
        }
    }

    public struct GameParams
    {
        public int WindowWidth;
        public int WindowHeight;
        public bool IsFullScreen;
        public bool PreferMultisampling;
        public RasterizerState Rasterizer;
        
        public GameParams(int windowWidth, int windowHeight, bool isFullscreen, bool multiSampling, RasterizerState rasterizerState = null)
        {
            WindowWidth = windowWidth;
            WindowHeight = windowHeight;
            IsFullScreen = isFullscreen;
            Rasterizer = rasterizerState;
            PreferMultisampling = multiSampling;
            
        }
    }
}