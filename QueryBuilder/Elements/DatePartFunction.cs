using ReturnTrue.QueryBuilder.Enums;
using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Elements
{
    public class DatePartFunction : Function
    {
        public DatePartType PartType { get; private set; }

        public DatePartFunction(DatePartType partType, IQueryValueExpression expression) : base(expression) 
        {
            PartType = partType;
        }

        public override string Render(IRenderer renderer)
        {
            return renderer.Render(this);
        }
    }
}