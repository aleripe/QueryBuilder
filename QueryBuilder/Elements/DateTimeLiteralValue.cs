using ReturnTrue.QueryBuilder.Renderers;
using System;

namespace ReturnTrue.QueryBuilder.Elements
{
    public class DateTimeLiteralValue : LiteralValue<DateTime>
    {
        public DateTimeLiteralValue(DateTime literal)
        {
            Literal = literal;
        }

        public override string Render(IRenderer renderer)
        {
            return renderer.Render(this);
        }
    }
}