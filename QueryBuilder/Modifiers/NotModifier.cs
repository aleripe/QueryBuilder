using ReturnTrue.QueryBuilder.Elements;
using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Modifiers
{
    public class NotModifier : IQueryElement
    {
        public string Render(IRenderer renderer)
        {
            return renderer.Render(this);
        }
    }
}