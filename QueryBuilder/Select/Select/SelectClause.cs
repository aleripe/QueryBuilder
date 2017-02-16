using ReturnTrue.QueryBuilder.Elements;
using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Select.Select
{
    public class SelectClause : QueryClause
    {
        public IQueryValueExpression Expression { get; private set; }
        public string Alias { get; private set; }

        protected SelectClause()
        {
        }

        public SelectClause(IQueryValueExpression expression)
            : this(expression, null)
        {
        }

        public SelectClause(IQueryValueExpression expression, string alias)
        {
            Expression = expression;
            Alias = alias;
        }

        public override string Render(IRenderer renderer)
        {
            return renderer.Render(this);
        }

        public static SelectClauses operator &(SelectClause leftClause, SelectClause rightClause)
        {
            return new SelectClauses(leftClause, rightClause);
        }

        public static SelectClauses operator &(SelectClause leftClause, Function rightClause)
        {
            return new SelectClauses(leftClause, new SelectClause(rightClause));
        }

        public static SelectClauses operator &(Function leftClause, SelectClause rightClause)
        {
            return new SelectClauses(new SelectClause(leftClause), rightClause);
        }
    }
}