using ReturnTrue.QueryBuilder.Elements;
using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Select.GroupBy
{
    public class GroupByClause : QueryClause
    {
        public Column Column { get; private set; }

        protected GroupByClause()
        {
        }

        public GroupByClause(Column column)
        {
            Column = column;
        }

        public override string Render(IRenderer renderer)
        {
            return renderer.Render(this);
        }

        public static GroupByClauses operator &(GroupByClause leftClause, GroupByClause rightClause)
        {
            return new GroupByClauses(leftClause, rightClause);
        }
    }
}