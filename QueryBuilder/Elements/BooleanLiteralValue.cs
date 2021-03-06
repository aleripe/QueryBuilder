﻿using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Elements
{
    public class BooleanLiteralValue : LiteralValue<bool>
    {
        public BooleanLiteralValue(bool literal)
        {
            Literal = literal;
        }

        public override string Render(IRenderer renderer)
        {
            return renderer.Render(this);
        }

        public static implicit operator BooleanLiteralValue(bool literalValue)
        {
            return new BooleanLiteralValue(literalValue);
        }
    }
}