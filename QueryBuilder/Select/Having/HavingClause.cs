using ReturnTrue.QueryBuilder.Elements;
using ReturnTrue.QueryBuilder.Enums;
using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Select.Having
{
    public class HavingClause : QueryClause
    {
        public IQueryPredicate Predicate { get; private set; }

        protected HavingClause()
        {
        }

        public HavingClause(IQueryPredicate predicate)
        {
            Predicate = predicate;
        }

        public override string Render(IRenderer renderer)
        {
            return renderer.Render(this);
        }

        public static implicit operator HavingClause(Predicate predicate)
        {
            return new HavingClause(predicate);
        }

        public static HavingClause operator &(HavingClause leftClause, HavingClause rightClause)
        {
            return new HavingClauses(leftClause, BooleanOperatorType.And, rightClause);
        }

        public static HavingClause operator |(HavingClause leftClause, HavingClause rightClause)
        {
            return new HavingClauses(leftClause, BooleanOperatorType.Or, rightClause);
        }
    }
}