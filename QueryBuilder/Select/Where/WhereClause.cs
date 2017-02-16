using ReturnTrue.QueryBuilder.Elements;
using ReturnTrue.QueryBuilder.Enums;
using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Select.Where
{
    public class WhereClause : QueryClause
    {
        public IQueryPredicate Predicate { get; private set; }

        protected WhereClause()
        {
        }

        public WhereClause(IQueryPredicate predicate)
        {
            Predicate = predicate;
        }

        public override string Render(IRenderer renderer)
        {
            return renderer.Render(this);
        }

        public static implicit operator WhereClause(Predicate predicate)
        {
            return new WhereClause(predicate);
        }

        public static WhereClauses operator &(WhereClause leftClause, WhereClause rightClause)
        {
            return new WhereClauses(leftClause, BooleanOperatorType.And, rightClause);
        }

        public static WhereClauses operator |(WhereClause leftClause, WhereClause rightClause)
        {
            return new WhereClauses(leftClause, BooleanOperatorType.Or, rightClause);
        }
    }
}