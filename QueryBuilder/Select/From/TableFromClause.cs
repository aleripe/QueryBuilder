using ReturnTrue.QueryBuilder.Elements;
using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Select.From
{
    public class TableFromClause : FromClause
    {
        public Table Table { get; private set; }

        public TableFromClause(Table table) : this(table, null) { }

        public TableFromClause(Table table, string alias) : base(alias)
        {
            Table = table;
        }

        public override string Render(IRenderer renderer)
        {
            return renderer.Render(this);
        }
    }
}