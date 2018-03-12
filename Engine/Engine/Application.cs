using Engine.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public class Application : Game
    {
        public AudioController Audio;
        public ContentController Content;
        public UiController UI;
        public LevelController Level;

        public GraphicsDevice Graphics;
        public GraphicsDeviceManager GraphicsManager;
        

        // Initialize (-> Load) -> update -> physics step -> late update -> Render -> Ui Render -> Post render update 
        
        public Application(GameParams inputParamaters, AudioController audio, ContentController content, UiController ui, LevelController level)
        {

            GraphicsManager = new GraphicsDeviceManager(this);
            Graphics = GraphicsManager.GraphicsDevice;

            GraphicsManager.PreferredBackBufferWidth     =     inputParamaters.WindowWidth;
            GraphicsManager.PreferredBackBufferHeight    =     inputParamaters.WindowHeight;
            GraphicsManager.IsFullScreen                 =     inputParamaters.IsFullScreen;
            GraphicsManager.PreferMultiSampling          =     inputParamaters.PreferMultisampling;

            if (inputParamaters.Rasterizer != null)
                Graphics.RasterizerState = inputParamaters.Rasterizer;
            
            Audio = audio;
            Content = content;
            UI = ui;
            Level = level;
        }

        public void Start()
        {
            Run();
        }

        protected override void Initialize()
        {
            base.Initialize();
            
            
        }

        protected override void LoadContent()
        {
            base.LoadContent();

        }
        
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            
            
        }
        
        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
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