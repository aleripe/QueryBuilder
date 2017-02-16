using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Select.GroupBy
{
    public class GroupByClauses : GroupByClause
    {
        public GroupByClause LeftClause { get; private set; }
        public GroupByClause RightClause { get; private set; }

        public GroupByClauses(GroupByClause leftClause, GroupByClause rightClause)
        {
            LeftClause = leftClause;
            RightClause = rightClause;
        }

        public override string Render(IRenderer renderer)
        {
            return renderer.Render(this);
        }
    }
}