using ReturnTrue.QueryBuilder.Elements;
using ReturnTrue.QueryBuilder.Enums;
using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Select.From
{
    public class JoinFromClause : TableFromClause
    {
        public TableFromClause LeftTable { get; private set; }
        public TableFromClause RightTable { get; private set; }
        public JoinType JoinType { get; private set; }
        public ComparisonPredicate Predicate { get; private set; }

        public JoinFromClause(TableFromClause leftTable, TableFromClause rightTable, ComparisonPredicate predicate)
        {
            LeftTable = leftTable;
            RightTable = rightTable;
            Predicate = predicate;
        }

        public override string Render(IRenderer renderer)
        {
            return renderer.Render(this);
        }
    }
}