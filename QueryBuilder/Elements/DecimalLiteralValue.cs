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
    }
}