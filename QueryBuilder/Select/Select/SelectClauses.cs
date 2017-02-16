using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Select.Select
{
    public class SelectClauses : SelectClause
    {
        public SelectClause LeftClause { get; private set; }
        public SelectClause RightClause { get; private set; }

        public SelectClauses(SelectClause leftClause, SelectClause rightClause)
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