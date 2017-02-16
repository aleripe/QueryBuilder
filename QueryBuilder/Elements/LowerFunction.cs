using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Elements
{
    public class LowerFunction : Function
    {
        public LowerFunction(IQueryValueExpression expression)
            : base(expression)
        {
        }

        public override string Render(IRenderer renderer)
        {
            return renderer.Render(this);
        }
    }
}