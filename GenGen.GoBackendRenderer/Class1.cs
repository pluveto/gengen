using GenGen.Renderer;
using System;

namespace GenGen.GoBackendRenderer
{
    public class Renderer : IRenderer
    {
        public Renderer(TemplateContext.TemplateContext templateContext)
        {
            TemplateContext = templateContext;
        }

        public TemplateContext.TemplateContext TemplateContext { get; }

        public void Render()
        {
            
        }
    }
}
