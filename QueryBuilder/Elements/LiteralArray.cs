using ReturnTrue.QueryBuilder.Renderers;
using System.Collections.Generic;

namespace ReturnTrue.QueryBuilder.Elements
{
    public abstract class LiteralArray<T> : IQueryMembership
    {
        public IEnumerable<T> Array { get; protected set; }

        public abstract string Render(IRenderer renderer);
    }
}