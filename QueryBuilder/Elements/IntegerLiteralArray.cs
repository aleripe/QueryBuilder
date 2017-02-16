using ReturnTrue.QueryBuilder.Renderers;
using System.Collections.Generic;

namespace ReturnTrue.QueryBuilder.Elements
{
    public class IntegerLiteralArray : LiteralArray<int>
    {
        public IntegerLiteralArray(IEnumerable<int> array)
        {
            Array = array;
        }

        public override string Render(IRenderer renderer)
        {
            return renderer.Render(this);
        }
    }
}