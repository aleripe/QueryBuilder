using ReturnTrue.QueryBuilder.Elements;

namespace ReturnTrue.QueryBuilder.Select.From
{
    public abstract class FromClause : QueryClause
    {
        public string Alias { get; private set; }

        protected FromClause()
        {
        }

        protected FromClause(string alias)
        {
            Alias = alias;
        }

        public static FromClauses operator &(FromClause leftClause, FromClause rightClause)
        {
            return new FromClauses(leftClause, rightClause);
        }
    }
}