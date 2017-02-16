using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Elements
{
    public class StringLiteralValue : LiteralValue<string>
    {
        public StringLiteralValue(string literal)
        {
            Literal = literal;
        }

        public override string Render(IRenderer renderer)
        {
            return renderer.Render(this);
        }

        public static implicit operator StringLiteralValue(string literalValue)
        {
            return new StringLiteralValue(literalValue);
        }
    }
}