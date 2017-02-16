using ReturnTrue.QueryBuilder.Enums;
using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Elements
{
    public class ComparisonPredicate : Predicate
    {
        public IQueryValueExpression LeftExpression { get; private set; }
        public ComparisonPredicateType ComparisonType { get; private set; }
        public IQueryValueExpression RightExpression { get; private set; }

        public ComparisonPredicate(IQueryValueExpression leftExpression, ComparisonPredicateType comparisonType, IQueryValueExpression rightExpression)
        {
            LeftExpression = leftExpression;
            ComparisonType = comparisonType;
            RightExpression = rightExpression;
        }

        public override string Render(IRenderer renderer)
        {
            return renderer.Render(this);
        }
    }
}