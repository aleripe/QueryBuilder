using ReturnTrue.QueryBuilder.Modifiers;
using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Elements
{
    public class NullPredicate : Predicate
    {
        public IQueryValueExpression Expression { get; private set; }
        public NotModifier NotModifier { get; private set; }

        public NullPredicate(IQueryValueExpression expression) : 
            this(expression, null) 
        {
        }

        public NullPredicate(IQueryValueExpression expression, NotModifier notModifier)
        {
            NotModifier = notModifier;
            Expression = expression;
        }

        public override string Render(IRenderer renderer)
        {
            return renderer.Render(this);
        }
    }
}