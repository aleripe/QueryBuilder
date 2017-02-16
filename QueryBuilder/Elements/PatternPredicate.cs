using ReturnTrue.QueryBuilder.Modifiers;
using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Elements
{
    public class PatternPredicate : Predicate
    {
        public IQueryValueExpression Expression { get; private set; }
        public NotModifier NotModifier { get; private set; }
        public StringLiteralValue Pattern { get; private set; }

        public PatternPredicate(IQueryValueExpression expression, StringLiteralValue pattern) 
            : this(expression, null, pattern)
        {
        }

        public PatternPredicate(IQueryValueExpression expression, NotModifier notModifier, StringLiteralValue pattern)
        {
            Expression = expression;
            NotModifier = notModifier;
            Pattern = pattern;
        }

        public override string Render(IRenderer renderer)
        {
            return renderer.Render(this);
        }
    }
}