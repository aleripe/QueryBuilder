using ReturnTrue.QueryBuilder.Elements;
using ReturnTrue.QueryBuilder.Select;
using ReturnTrue.QueryBuilder.Enums;
using System;
using System.Collections.Generic;
using ReturnTrue.QueryBuilder.Modifiers;

namespace ReturnTrue.QueryBuilder
{
    public static class Sql
    {
        public static SelectQuery Select()
        {
            return new SelectQuery();
        }

        public static Column Column(string name)
        {
            return new Column(name);
        }

        public static Table Table(string name)
        {
            return new Table(name);
        }

        public static Function Lower(IQueryValueExpression expression)
        {
            return new LowerFunction(expression);
        }

        public static Function Upper(IQueryValueExpression expression)
        {
            return new UpperFunction(expression);
        }

        public static Function Avg(IQueryValueExpression expression)
        {
            return new AggregateFunction(FunctionType.Avg, expression);
        }

        public static Function Count(IQueryValueExpression expression)
        {
            return new AggregateFunction(FunctionType.Count, expression);
        }

        public static Function Max(IQueryValueExpression expression)
        {
            return new AggregateFunction(FunctionType.Max, expression);
        }

        public static Function Min(IQueryValueExpression expression)
        {
            return new AggregateFunction(FunctionType.Min, expression);
        }

        public static Function Sum(IQueryValueExpression expression)
        {
            return new AggregateFunction(FunctionType.Sum, expression);
        }

        public static Function Day(IQueryValueExpression expression)
        {
            return new DatePartFunction(DatePartType.Day, expression);
        }

        public static Function Hour(IQueryValueExpression expression)
        {
            return new DatePartFunction(DatePartType.Hour, expression);
        }

        public static Function Minute(IQueryValueExpression expression)
        {
            return new DatePartFunction(DatePartType.Minute, expression);
        }

        public static Function Month(IQueryValueExpression expression)
        {
            return new DatePartFunction(DatePartType.Month, expression);
        }

        public static Function Second(IQueryValueExpression expression)
        {
            return new DatePartFunction(DatePartType.Second, expression);
        }

        public static Function Year(IQueryValueExpression expression)
        {
            return new DatePartFunction(DatePartType.Year, expression);
        }

        public static BooleanLiteralValue Boolean(bool literalValue)
        {
            return new BooleanLiteralValue(literalValue);
        }

        public static IntegerLiteralValue Integer(int literalValue)
        {
            return new IntegerLiteralValue(literalValue);
        }

        public static DecimalLiteralValue Decimal(double literalValue)
        {
            return new DecimalLiteralValue(literalValue);
        }

        public static DateTimeLiteralValue Boolean(DateTime literalValue)
        {
            return new DateTimeLiteralValue(literalValue);
        }

        public static StringLiteralValue String(string literalValue)
        {
            return new StringLiteralValue(literalValue);
        }

        public static IntegerLiteralArray Integer(IEnumerable<int> array)
        {
            return new IntegerLiteralArray(array);
        }

        public static StringLiteralArray String(IEnumerable<string> array)
        {
            return new StringLiteralArray(array);
        }

        public static ComparisonPredicate Equals(IQueryValueExpression leftExpression, IQueryValueExpression rightExpression)
        {
            return new ComparisonPredicate(leftExpression, ComparisonPredicateType.Equals, rightExpression);
        }

        public static ComparisonPredicate NotEquals(IQueryValueExpression leftExpression, IQueryValueExpression rightExpression)
        {
            return new ComparisonPredicate(leftExpression, ComparisonPredicateType.NotEquals, rightExpression);
        }

        public static ComparisonPredicate GreaterThan(IQueryValueExpression leftExpression, IQueryValueExpression rightExpression)
        {
            return new ComparisonPredicate(leftExpression, ComparisonPredicateType.GreaterThan, rightExpression);
        }

        public static ComparisonPredicate LessThan(IQueryValueExpression leftExpression, IQueryValueExpression rightExpression)
        {
            return new ComparisonPredicate(leftExpression, ComparisonPredicateType.LessThan, rightExpression);
        }

        public static ComparisonPredicate GreaterOrEqualsThan(IQueryValueExpression leftExpression, IQueryValueExpression rightExpression)
        {
            return new ComparisonPredicate(leftExpression, ComparisonPredicateType.GreaterOrEqualsThan, rightExpression);
        }

        public static ComparisonPredicate LessOrEqualsThan(IQueryValueExpression leftExpression, IQueryValueExpression rightExpression)
        {
            return new ComparisonPredicate(leftExpression, ComparisonPredicateType.LessOrEqualsThan, rightExpression);
        }

        public static MembershipPredicate In(IQueryValueExpression expression, IQueryMembership membership)
        {
            return new MembershipPredicate(expression, membership);
        }

        public static PatternPredicate Like(IQueryValueExpression expression, StringLiteralValue pattern)
        {
            return new PatternPredicate(expression, pattern);
        }

        public static RangePredicate InRange(IQueryValueExpression leftExpression, IQueryValueExpression middleExpression, IQueryValueExpression rightExpression)
        {
            return new RangePredicate(leftExpression, middleExpression, rightExpression);
        }

        public static NullPredicate Null(IQueryValueExpression expression)
        {
            return new NullPredicate(expression);
        }

        public static NullPredicate NotNull(IQueryValueExpression expression)
        {
            return new NullPredicate(expression, new NotModifier());
        }

        public static DistinctModifier Distinct()
        {
            return new DistinctModifier();
        }

        public static NotModifier Not()
        {
            return new NotModifier();
        }
    }
}