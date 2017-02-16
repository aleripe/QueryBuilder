using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Elements
{
    public class UpperFunction : Function
    {
        public UpperFunction(IQueryValueExpression expression) 
            : base(expression)
        {
        }

        public override string Render(IRenderer renderer)
        {
            return renderer.Render(this);
        }
    }
}