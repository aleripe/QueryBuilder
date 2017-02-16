using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Elements
{
    public abstract class LiteralValue<T> : ILiteralValue, IQueryValueExpression, IQueryMembership
    {
        public T Literal { get; protected set; }

        public abstract string Render(IRenderer renderer);
    }
}