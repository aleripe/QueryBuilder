using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Select.From
{
    public class FromClauses : FromClause
    {
        public FromClause LeftClause { get; private set; }
        public FromClause RightClause { get; private set; }

        public FromClauses(FromClause leftClause, FromClause rightClause)
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