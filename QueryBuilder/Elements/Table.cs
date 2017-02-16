using ReturnTrue.QueryBuilder.Renderers;
using ReturnTrue.QueryBuilder.Select.From;

namespace ReturnTrue.QueryBuilder.Elements
{
    public class Table : IQueryElement
    {
        public string Name { get; private set; }

        public Table(string name)
        {
            Name = name;
        }

        public string Render(IRenderer renderer)
        {
            return renderer.Render(this);
        }

        public FromClauses And(Table rightTable)
        {
            return new FromClauses(new TableFromClause(this), new TableFromClause(rightTable));
        }
    }
}