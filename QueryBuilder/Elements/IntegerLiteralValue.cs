using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Elements
{
    public class IntegerLiteralValue : LiteralValue<int>
    {
        public IntegerLiteralValue(int literal)
        {
            Literal = literal;
        }

        public override string Render(IRenderer renderer)
        {
            return renderer.Render(this);
        }

        public static implicit operator IntegerLiteralValue(int literalValue)
        {
            return new IntegerLiteralValue(literalValue);
        }
    }
}