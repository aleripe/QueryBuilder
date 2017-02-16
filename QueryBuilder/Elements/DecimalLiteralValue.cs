using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Elements
{
    public class DecimalLiteralValue : LiteralValue<double>
    {
        public DecimalLiteralValue(double literal)
        {
            Literal = literal;
        }

        public override string Render(IRenderer renderer)
        {
            return renderer.Render(this);
        }

        public static implicit operator DecimalLiteralValue(double literalValue)
        {
            return new DecimalLiteralValue(literalValue);
        }
    }
}