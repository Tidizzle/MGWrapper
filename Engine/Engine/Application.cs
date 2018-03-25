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
        public UIManager UI;
        public LevelManager Level;

        public GraphicsDevice Graphics;
        public GraphicsDeviceManager GraphicsManager;

        public Renderer3D GeneralRenderer;
        public Renderer2D UiRenderer;
        
        
        // initalize   load    update                                    Draw                                             dispose
        //{‾‾‾‾‾‾‾‾‾‾}{‾‾‾‾‾‾}{‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾}{‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾}{‾‾‾‾‾‾‾‾‾‾}  
        //Initalize -> Load -> update -> physics step -> late update -> prerender -> render -> pre uirender -> ui render |-> destroy
        
        
        /// <summary>
        /// Constructor of Game
        /// </summary>
        /// <param name="inputParamaters">Packet of startup info </param>
        /// <param name="audio">Audio manager instance</param>
        /// <param name="content">Content manager instance</param>
        /// <param name="ui">Ui manager instance</param>
        /// <param name="level"> Level manager instance</param>
        /// <param name="rend3d">3D Renderer instance</param>
        /// <param name="rend2d">2D (UI Primarilly) Renderer instance </param>
        public Application(GameParams inputParamaters, Manager audio, Manager content, UIManager ui, LevelManager level, Renderer3D rend3d, Renderer2D rend2d)
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

        /// <summary>
        /// Starts game loop execution
        /// </summary>
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

            //load this first
            Content.Load();
            
            //have all the other types request loads from the content controller and pass back a reference to that asset in the content controller
            Audio.Load();
            UI.Load();
            Level.Load();
            
        }
        
        protected override void Update(GameTime gameTime)
        {
            
            base.Update(gameTime);
            
            ///3 update stages
            GeneralUpdate(gameTime);
            PhysicsUpdate(gameTime);
            LateUpdate(gameTime);
        }

        protected void GeneralUpdate(GameTime gameTime)
        {
            Content.Update(gameTime);
            Audio.Update(gameTime);
            UI.Update(gameTime);
            Level.Update(gameTime);
        }

        protected void PhysicsUpdate(GameTime gameTime)
        {
            Level.PhysicsUpdate(gameTime);
        }

        protected void LateUpdate(GameTime gameTime)
        {
            Level.LateUpdate(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);
            
            //render in 2 stages
            //Render and Ui render, both with 2 more stages
            //prerender sends all of the items to be rendered with a packet of data along side it
            //render is only used by the renderers and goes through the items and renders them 3d and 2d
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

    /// <summary>
    /// Parameter packet for game initalization
    /// </summary>
    public struct GameParams
    {
        public int WindowWidth;
        public int WindowHeight;
        public bool IsFullScreen;
        public bool PreferMultisampling;
        public RasterizerState Rasterizer;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="windowWidth">Width of window in pixels</param>
        /// <param name="windowHeight">Height of window in pixels</param>
        /// <param name="isFullscreen">Fullscreen enabled or not</param>
        /// <param name="multiSampling">Multisampling enabled or not</param>
        /// <param name="rasterizerState">Optional rasterizer state input</param>
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