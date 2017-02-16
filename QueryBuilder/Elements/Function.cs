using ReturnTrue.QueryBuilder.Enums;
using ReturnTrue.QueryBuilder.Renderers;
using ReturnTrue.QueryBuilder.Select.Select;
using System;

namespace ReturnTrue.QueryBuilder.Elements
{
    public abstract class Function : IQueryValueExpression
    {
        public IQueryValueExpression Expression { get; private set; }

        public Function(IQueryValueExpression expression)
        {
            Expression = expression;
        }

        public abstract string Render(IRenderer renderer);

        public static ComparisonPredicate operator ==(Function function, bool literalValue)
        {
            return new ComparisonPredicate(function, ComparisonPredicateType.Equals, new BooleanLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator ==(Function function, DateTime literalValue)
        {
            return new ComparisonPredicate(function, ComparisonPredicateType.Equals, new DateTimeLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator ==(Function function, int literalValue)
        {
            return new ComparisonPredicate(function, ComparisonPredicateType.Equals, new IntegerLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator ==(Function function, double literalValue)
        {
            return new ComparisonPredicate(function, ComparisonPredicateType.Equals, new DecimalLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator ==(Function function, string literalValue)
        {
            return new ComparisonPredicate(function, ComparisonPredicateType.Equals, new StringLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator ==(Function function, Column rightColumn)
        {
            return new ComparisonPredicate(function, ComparisonPredicateType.Equals, rightColumn);
        }

        public static ComparisonPredicate operator !=(Function function, bool literalValue)
        {
            return new ComparisonPredicate(function, ComparisonPredicateType.NotEquals, new BooleanLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator !=(Function function, DateTime literalValue)
        {
            return new ComparisonPredicate(function, ComparisonPredicateType.NotEquals, new DateTimeLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator !=(Function function, int literalValue)
        {
            return new ComparisonPredicate(function, ComparisonPredicateType.NotEquals, new IntegerLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator !=(Function function, double literalValue)
        {
            return new ComparisonPredicate(function, ComparisonPredicateType.NotEquals, new DecimalLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator !=(Function function, string literalValue)
        {
            return new ComparisonPredicate(function, ComparisonPredicateType.NotEquals, new StringLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator !=(Function function, Column rightColumn)
        {
            return new ComparisonPredicate(function, ComparisonPredicateType.NotEquals, rightColumn);
        }

        public static ComparisonPredicate operator <(Function function, bool literalValue)
        {
            return new ComparisonPredicate(function, ComparisonPredicateType.LessThan, new BooleanLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <(Function function, DateTime literalValue)
        {
            return new ComparisonPredicate(function, ComparisonPredicateType.LessThan, new DateTimeLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <(Function function, int literalValue)
        {
            return new ComparisonPredicate(function, ComparisonPredicateType.LessThan, new IntegerLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <(Function function, double literalValue)
        {
            return new ComparisonPredicate(function, ComparisonPredicateType.LessThan, new DecimalLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <(Function function, string literalValue)
        {
            return new ComparisonPredicate(function, ComparisonPredicateType.LessThan, new StringLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <(Function function, Column rightColumn)
        {
            return new ComparisonPredicate(function, ComparisonPredicateType.LessThan, rightColumn);
        }

        public static ComparisonPredicate operator >(Function function, bool literalValue)
        {
            return new ComparisonPredicate(function, ComparisonPredicateType.GreaterThan, new BooleanLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >(Function function, DateTime literalValue)
        {
            return new ComparisonPredicate(function, ComparisonPredicateType.GreaterThan, new DateTimeLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >(Function function, int literalValue)
        {
            return new ComparisonPredicate(function, ComparisonPredicateType.GreaterThan, new IntegerLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >(Function function, double literalValue)
        {
            return new ComparisonPredicate(function, ComparisonPredicateType.GreaterThan, new DecimalLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >(Function function, string literalValue)
        {
            return new ComparisonPredicate(function, ComparisonPredicateType.GreaterThan, new StringLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >(Function function, Column rightColumn)
        {
            return new ComparisonPredicate(function, ComparisonPredicateType.GreaterThan, rightColumn);
        }

        public static ComparisonPredicate operator >=(Function function, bool literalValue)
        {
            return new ComparisonPredicate(function, ComparisonPredicateType.GreaterOrEqualsThan, new BooleanLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >=(Function function, DateTime literalValue)
        {
            return new ComparisonPredicate(function, ComparisonPredicateType.GreaterOrEqualsThan, new DateTimeLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >=(Function function, int literalValue)
        {
            return new ComparisonPredicate(function, ComparisonPredicateType.GreaterOrEqualsThan, new IntegerLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >=(Function function, double literalValue)
        {
            return new ComparisonPredicate(function, ComparisonPredicateType.GreaterOrEqualsThan, new DecimalLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >=(Function function, string literalValue)
        {
            return new ComparisonPredicate(function, ComparisonPredicateType.GreaterOrEqualsThan, new StringLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >=(Function function, Column rightColumn)
        {
            return new ComparisonPredicate(function, ComparisonPredicateType.GreaterOrEqualsThan, rightColumn);
        }

        public static ComparisonPredicate operator <=(Function function, bool literalValue)
        {
            return new ComparisonPredicate(function, ComparisonPredicateType.LessOrEqualsThan, new BooleanLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <=(Function function, DateTime literalValue)
        {
            return new ComparisonPredicate(function, ComparisonPredicateType.LessOrEqualsThan, new DateTimeLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <=(Function function, int literalValue)
        {
            return new ComparisonPredicate(function, ComparisonPredicateType.LessOrEqualsThan, new IntegerLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <=(Function function, double literalValue)
        {
            return new ComparisonPredicate(function, ComparisonPredicateType.LessOrEqualsThan, new DecimalLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <=(Function function, string literalValue)
        {
            return new ComparisonPredicate(function, ComparisonPredicateType.LessOrEqualsThan, new StringLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <=(Function function, Column rightColumn)
        {
            return new ComparisonPredicate(function, ComparisonPredicateType.LessOrEqualsThan, rightColumn);
        }
    }
}