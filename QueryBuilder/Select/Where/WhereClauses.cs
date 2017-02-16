using ReturnTrue.QueryBuilder.Enums;
using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Select.Where
{
    public class WhereClauses : WhereClause
    {
        public WhereClause LeftClause { get; private set; }
        public BooleanOperatorType OperatorType { get; private set; }
        public WhereClause RightClause { get; private set; }

        public WhereClauses(WhereClause leftClause, BooleanOperatorType operatorType, WhereClause rightClause)
        {
            LeftClause = leftClause;
            OperatorType = operatorType;
            RightClause = rightClause;
        }

        public override string Render(IRenderer renderer)
        {
            return renderer.Render(this);
        }
    }
}