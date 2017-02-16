using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Select.From
{
    public class QueryFromClause : FromClause
    {
        public SelectQuery Query { get; private set; }

        public QueryFromClause(SelectQuery query)
        {
            Query = query;
        }

        public QueryFromClause(SelectQuery query, string alias) 
            : base(alias)
        {
            Query = query;
        }

        public override string Render(IRenderer renderer)
        {
            return renderer.Render(this);
        }
    }
}