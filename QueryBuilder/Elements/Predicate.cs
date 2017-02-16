using ReturnTrue.QueryBuilder.Enums;
using ReturnTrue.QueryBuilder.Renderers;
using ReturnTrue.QueryBuilder.Select.Where;

namespace ReturnTrue.QueryBuilder.Elements
{
    public abstract class Predicate : IQueryPredicate
    {
        public abstract string Render(IRenderer renderer);

        public static WhereClauses operator &(Predicate leftPredicate, Predicate rightPredicate)
        {
            return new WhereClauses(new WhereClause(leftPredicate), BooleanOperatorType.And, new WhereClause(rightPredicate));
        }

        public static WhereClauses operator |(Predicate leftPredicate, Predicate rightPredicate)
        {
            return new WhereClauses(new WhereClause(leftPredicate), BooleanOperatorType.Or, new WhereClause(rightPredicate));
        }
    }
}