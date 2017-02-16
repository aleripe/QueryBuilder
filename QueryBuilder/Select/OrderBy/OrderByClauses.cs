using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Select.OrderBy
{
    public class OrderByClauses : OrderByClause
    {
        public OrderByClause LeftClause { get; private set; }
        public OrderByClause RightClause { get; private set; }

        public OrderByClauses(OrderByClause leftClause, OrderByClause rightClause)
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