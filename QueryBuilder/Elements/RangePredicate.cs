using ReturnTrue.QueryBuilder.Modifiers;
using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Elements
{
    public class RangePredicate : Predicate
    {
        public IQueryValueExpression LeftExpression { get; private set; }
        public NotModifier NotModifier { get; private set; }
        public IQueryValueExpression MiddleExpression { get; private set; }
        public IQueryValueExpression RightExpression { get; private set; }

        public RangePredicate(IQueryValueExpression leftExpression, IQueryValueExpression middleExpression, IQueryValueExpression rightExpression) 
            : this(leftExpression, null, middleExpression, rightExpression)
        {
        }

        public RangePredicate(IQueryValueExpression leftExpression, NotModifier notModifier,
            IQueryValueExpression middleExpression, IQueryValueExpression rightExpression)
        {
            LeftExpression = leftExpression;
            NotModifier = notModifier;
            MiddleExpression = middleExpression;
            RightExpression = rightExpression;
        }

        public override string Render(IRenderer renderer)
        {
            return renderer.Render(this);
        }
    }
}