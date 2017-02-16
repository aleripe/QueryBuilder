using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Elements
{
    public abstract class QueryClause : IQueryElement
    {
        public abstract string Render(IRenderer renderer);
    }
}