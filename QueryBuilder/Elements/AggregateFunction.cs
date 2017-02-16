using ReturnTrue.QueryBuilder.Enums;
using ReturnTrue.QueryBuilder.Modifiers;
using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Elements
{
    public class AggregateFunction : Function
    {
        public FunctionType FunctionType { get; private set; }
        public DistinctModifier DistinctModifier { get; private set; }

        public AggregateFunction(FunctionType functionType, IQueryValueExpression expression) 
            : this(functionType, null, expression)
        {
        }

        public AggregateFunction(FunctionType functionType, DistinctModifier distinctModifier, IQueryValueExpression expression) : base(expression)
        {
            FunctionType = functionType;
            DistinctModifier = distinctModifier;
        }

        public override string Render(IRenderer renderer)
        {
            return renderer.Render(this);
        }
    }
}