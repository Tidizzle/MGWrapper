namespace Engine.Rendering
{
    public abstract class Renderer
    {
        
        
        public abstract void PreRender();
        public abstract void Render();
        public abstract void UiRender();
        public abstract void PreUiRender();
    }
}