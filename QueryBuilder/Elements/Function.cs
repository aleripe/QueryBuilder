using ReturnTrue.QueryBuilder.Enums;
using ReturnTrue.QueryBuilder.Renderers;
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
            return new ComparisonPredicate(function, PredicateComparisonType.Equals, new BooleanLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator ==(Function function, DateTime literalValue)
        {
            return new ComparisonPredicate(function, PredicateComparisonType.Equals, new DateTimeLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator ==(Function function, int literalValue)
        {
            return new ComparisonPredicate(function, PredicateComparisonType.Equals, new IntegerLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator ==(Function function, double literalValue)
        {
            return new ComparisonPredicate(function, PredicateComparisonType.Equals, new DecimalLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator ==(Function function, string literalValue)
        {
            return new ComparisonPredicate(function, PredicateComparisonType.Equals, new StringLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator ==(Function function, Column rightColumn)
        {
            return new ComparisonPredicate(function, PredicateComparisonType.Equals, rightColumn);
        }

        public static ComparisonPredicate operator !=(Function function, bool literalValue)
        {
            return new ComparisonPredicate(function, PredicateComparisonType.NotEquals, new BooleanLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator !=(Function function, DateTime literalValue)
        {
            return new ComparisonPredicate(function, PredicateComparisonType.NotEquals, new DateTimeLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator !=(Function function, int literalValue)
        {
            return new ComparisonPredicate(function, PredicateComparisonType.NotEquals, new IntegerLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator !=(Function function, double literalValue)
        {
            return new ComparisonPredicate(function, PredicateComparisonType.NotEquals, new DecimalLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator !=(Function function, string literalValue)
        {
            return new ComparisonPredicate(function, PredicateComparisonType.NotEquals, new StringLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator !=(Function function, Column rightColumn)
        {
            return new ComparisonPredicate(function, PredicateComparisonType.NotEquals, rightColumn);
        }

        public static ComparisonPredicate operator <(Function function, bool literalValue)
        {
            return new ComparisonPredicate(function, PredicateComparisonType.LessThan, new BooleanLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <(Function function, DateTime literalValue)
        {
            return new ComparisonPredicate(function, PredicateComparisonType.LessThan, new DateTimeLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <(Function function, int literalValue)
        {
            return new ComparisonPredicate(function, PredicateComparisonType.LessThan, new IntegerLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <(Function function, double literalValue)
        {
            return new ComparisonPredicate(function, PredicateComparisonType.LessThan, new DecimalLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <(Function function, string literalValue)
        {
            return new ComparisonPredicate(function, PredicateComparisonType.LessThan, new StringLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <(Function function, Column rightColumn)
        {
            return new ComparisonPredicate(function, PredicateComparisonType.LessThan, rightColumn);
        }

        public static ComparisonPredicate operator >(Function function, bool literalValue)
        {
            return new ComparisonPredicate(function, PredicateComparisonType.GreaterThan, new BooleanLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >(Function function, DateTime literalValue)
        {
            return new ComparisonPredicate(function, PredicateComparisonType.GreaterThan, new DateTimeLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >(Function function, int literalValue)
        {
            return new ComparisonPredicate(function, PredicateComparisonType.GreaterThan, new IntegerLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >(Function function, double literalValue)
        {
            return new ComparisonPredicate(function, PredicateComparisonType.GreaterThan, new DecimalLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >(Function function, string literalValue)
        {
            return new ComparisonPredicate(function, PredicateComparisonType.GreaterThan, new StringLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >(Function function, Column rightColumn)
        {
            return new ComparisonPredicate(function, PredicateComparisonType.GreaterThan, rightColumn);
        }

        public static ComparisonPredicate operator >=(Function function, bool literalValue)
        {
            return new ComparisonPredicate(function, PredicateComparisonType.GreaterOrEqualsThan, new BooleanLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >=(Function function, DateTime literalValue)
        {
            return new ComparisonPredicate(function, PredicateComparisonType.GreaterOrEqualsThan, new DateTimeLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >=(Function function, int literalValue)
        {
            return new ComparisonPredicate(function, PredicateComparisonType.GreaterOrEqualsThan, new IntegerLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >=(Function function, double literalValue)
        {
            return new ComparisonPredicate(function, PredicateComparisonType.GreaterOrEqualsThan, new DecimalLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >=(Function function, string literalValue)
        {
            return new ComparisonPredicate(function, PredicateComparisonType.GreaterOrEqualsThan, new StringLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >=(Function function, Column rightColumn)
        {
            return new ComparisonPredicate(function, PredicateComparisonType.GreaterOrEqualsThan, rightColumn);
        }

        public static ComparisonPredicate operator <=(Function function, bool literalValue)
        {
            return new ComparisonPredicate(function, PredicateComparisonType.LessOrEqualsThan, new BooleanLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <=(Function function, DateTime literalValue)
        {
            return new ComparisonPredicate(function, PredicateComparisonType.LessOrEqualsThan, new DateTimeLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <=(Function function, int literalValue)
        {
            return new ComparisonPredicate(function, PredicateComparisonType.LessOrEqualsThan, new IntegerLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <=(Function function, double literalValue)
        {
            return new ComparisonPredicate(function, PredicateComparisonType.LessOrEqualsThan, new DecimalLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <=(Function function, string literalValue)
        {
            return new ComparisonPredicate(function, PredicateComparisonType.LessOrEqualsThan, new StringLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <=(Function function, Column rightColumn)
        {
            return new ComparisonPredicate(function, PredicateComparisonType.LessOrEqualsThan, rightColumn);
        }
    }
}