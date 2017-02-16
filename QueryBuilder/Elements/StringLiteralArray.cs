using ReturnTrue.QueryBuilder.Renderers;
using System.Collections.Generic;

namespace ReturnTrue.QueryBuilder.Elements
{
    public class StringLiteralArray : LiteralArray<string>
    {
        public StringLiteralArray(IEnumerable<string> array)
        {
            Array = array;
        }

        public override string Render(IRenderer renderer)
        {
            return renderer.Render(this);
        }
    }
}