using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Modifiers
{
    public class DistinctModifier
    {
        public string Render(IRenderer renderer)
        {
            return renderer.Render(this);
        }
    }
}