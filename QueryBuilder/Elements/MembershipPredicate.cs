using ReturnTrue.QueryBuilder.Modifiers;
using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Elements
{
    public class MembershipPredicate : Predicate
    {
        public IQueryValueExpression Expression { get; private set; }
        public NotModifier NotModifier { get; private set; }
        public IQueryMembership Membership { get; private set; }

        public MembershipPredicate(IQueryValueExpression expression, IQueryMembership membership) 
            : this(expression, null, membership)
        {
        }

        public MembershipPredicate(IQueryValueExpression expression, NotModifier notModifier, IQueryMembership membership)
        {
            NotModifier = notModifier;
            Expression = expression;
            Membership = membership;
        }

        public override string Render(IRenderer renderer)
        {
            return renderer.Render(this);
        }
    }
}