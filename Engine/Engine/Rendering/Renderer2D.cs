namespace Engine.Rendering
{
    public class Renderer2D : Renderer
    {
        public Renderer3D GenRendLink;


        public override void Initalize(Renderer pair)
        {
            GenRendLink = (Renderer3D) pair;
        }

        public override void PreRender()
        {
            
        }

        public override void Render()
        {
        }

        public override void UiRender()
        {
        }

        public override void PreUiRender()
        {
        }
    }
}