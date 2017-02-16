using ReturnTrue.QueryBuilder.Enums;
using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Select.Having
{
    public class HavingClauses : HavingClause
    {
        public HavingClause LeftClause { get; private set; }
        public BooleanOperatorType OperatorType { get; private set; }
        public HavingClause RightClause { get; private set; }

        public HavingClauses(HavingClause leftClause, BooleanOperatorType operatorType, HavingClause rightClause)
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