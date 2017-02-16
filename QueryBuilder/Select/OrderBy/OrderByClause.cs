using ReturnTrue.QueryBuilder.Elements;
using ReturnTrue.QueryBuilder.Enums;
using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Select.OrderBy
{
    public class OrderByClause : QueryClause
    {
        public Column Column { get; private set; }
        public OrderType OrderType { get; private set; }

        protected OrderByClause()
        {
        }

        public OrderByClause(Column column) 
            : this(column, OrderType.Ascending)
        {
        }

        public OrderByClause(Column column, OrderType orderType)
        {
            Column = column;
            OrderType = orderType;
        }

        public override string Render(IRenderer renderer)
        {
            return renderer.Render(this);
        }

        public static OrderByClauses operator &(OrderByClause leftClause, OrderByClause rightClause)
        {
            return new OrderByClauses(leftClause, rightClause);
        }
    }
}