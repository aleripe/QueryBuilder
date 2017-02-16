using ReturnTrue.QueryBuilder.Enums;
using ReturnTrue.QueryBuilder.Modifiers;
using ReturnTrue.QueryBuilder.Renderers;
using ReturnTrue.QueryBuilder.Select;
using ReturnTrue.QueryBuilder.Select.OrderBy;
using ReturnTrue.QueryBuilder.Select.Select;
using System;
using System.Collections.Generic;

namespace ReturnTrue.QueryBuilder.Elements
{
    public class Column : IQueryValueExpression
    {
        public string Name { get; private set; }

        public Column(string name)
        {
            Name = name;
        }

        public virtual string Render(IRenderer renderer)
        {
            return renderer.Render(this);
        }

        public PatternPredicate IsLike(string pattern)
        {
            return new PatternPredicate(this, new StringLiteralValue(pattern));
        }

        public PatternPredicate IsNotLike(string pattern)
        {
            return new PatternPredicate(this, new NotModifier(), new StringLiteralValue(pattern));
        }

        public MembershipPredicate IsIn(IQueryMembership membership)
        {
            return new MembershipPredicate(this, membership);
        }

        public MembershipPredicate IsIn(IEnumerable<int> membership)
        {
            return new MembershipPredicate(this, new IntegerLiteralArray(membership));
        }

        public MembershipPredicate IsNotIn(IQueryMembership membership)
        {
            return new MembershipPredicate(this, new NotModifier(), membership);
        }

        public MembershipPredicate IsNotIn(string membership)
        {
            return new MembershipPredicate(this, new NotModifier(), new StringLiteralValue(membership));
        }

        public RangePredicate IsInRange(IQueryValueExpression middleExpression, IQueryValueExpression rightExpression)
        {
            return new RangePredicate(this, middleExpression, rightExpression);
        }

        public RangePredicate IsNotInRange(IQueryValueExpression middleExpression, IQueryValueExpression rightExpression)
        {
            return new RangePredicate(this, new NotModifier(), middleExpression, rightExpression);
        }

        public NullPredicate IsNull()
        {
            return new NullPredicate(this);
        }

        public NullPredicate IsNotNull()
        {
            return new NullPredicate(this, new NotModifier());
        }

        public AggregateFunction Count()
        {
            return new AggregateFunction(FunctionType.Count, this);
        }

        public AggregateFunction Sum()
        {
            return new AggregateFunction(FunctionType.Sum, this);
        }

        public AggregateFunction Avg()
        {
            return new AggregateFunction(FunctionType.Avg, this);
        }

        public AggregateFunction Max()
        {
            return new AggregateFunction(FunctionType.Max, this);
        }

        public AggregateFunction Min()
        {
            return new AggregateFunction(FunctionType.Min, this);
        }

        public DatePartFunction DatePart(DatePartType partType)
        {
            return new DatePartFunction(partType, this);
        }

        public UpperFunction ToUpper()
        {
            return new UpperFunction(this);
        }

        public LowerFunction ToLower()
        {
            return new LowerFunction(this);
        }

        public OrderByClause Asc()
        {
            return new OrderByClause(this, OrderType.Ascending);
        }

        public OrderByClause Desc()
        {
            return new OrderByClause(this, OrderType.Descending);
        }

        public static OrderByClause operator +(Column column)
        {
            return new OrderByClause(column, OrderType.Ascending);
        }

        public static OrderByClause operator -(Column column)
        {
            return new OrderByClause(column, OrderType.Descending);
        }

        public static ComparisonPredicate operator ==(Column leftColumn, bool literalValue)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.Equals, new BooleanLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator ==(Column leftColumn, DateTime literalValue)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.Equals, new DateTimeLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator ==(Column leftColumn, int literalValue)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.Equals, new IntegerLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator ==(Column leftColumn, double literalValue)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.Equals, new DecimalLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator ==(Column leftColumn, string literalValue)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.Equals, new StringLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator ==(Column leftColumn, Column rightColumn)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.Equals, rightColumn);
        }

        public static ComparisonPredicate operator ==(Column leftColumn, SelectQuery query)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.Equals, query);
        }

        public static ComparisonPredicate operator !=(Column leftColumn, bool literalValue)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.NotEquals, new BooleanLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator !=(Column leftColumn, DateTime literalValue)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.NotEquals, new DateTimeLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator !=(Column leftColumn, int literalValue)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.NotEquals, new IntegerLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator !=(Column leftColumn, double literalValue)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.NotEquals, new DecimalLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator !=(Column leftColumn, string literalValue)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.NotEquals, new StringLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator !=(Column leftColumn, Column rightColumn)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.NotEquals, rightColumn);
        }

        public static ComparisonPredicate operator !=(Column leftColumn, SelectQuery query)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.NotEquals, query);
        }

        public static ComparisonPredicate operator <(Column leftColumn, bool literalValue)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.LessThan, new BooleanLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <(Column leftColumn, DateTime literalValue)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.LessThan, new DateTimeLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <(Column leftColumn, int literalValue)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.LessThan, new IntegerLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <(Column leftColumn, double literalValue)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.LessThan, new DecimalLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <(Column leftColumn, string literalValue)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.LessThan, new StringLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <(Column leftColumn, Column rightColumn)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.LessThan, rightColumn);
        }

        public static ComparisonPredicate operator <(Column leftColumn, SelectQuery query)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.LessThan, query);
        }

        public static ComparisonPredicate operator >(Column leftColumn, bool literalValue)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.GreaterThan, new BooleanLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >(Column leftColumn, DateTime literalValue)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.GreaterThan, new DateTimeLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >(Column leftColumn, int literalValue)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.GreaterThan, new IntegerLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >(Column leftColumn, double literalValue)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.GreaterThan, new DecimalLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >(Column leftColumn, string literalValue)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.GreaterThan, new StringLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >(Column leftColumn, Column rightColumn)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.GreaterThan, rightColumn);
        }

        public static ComparisonPredicate operator >(Column leftColumn, SelectQuery query)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.GreaterThan, query);
        }

        public static ComparisonPredicate operator >=(Column leftColumn, bool literalValue)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.GreaterOrEqualsThan, new BooleanLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >=(Column leftColumn, DateTime literalValue)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.GreaterOrEqualsThan, new DateTimeLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >=(Column leftColumn, int literalValue)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.GreaterOrEqualsThan, new IntegerLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >=(Column leftColumn, double literalValue)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.GreaterOrEqualsThan, new DecimalLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >=(Column leftColumn, string literalValue)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.GreaterOrEqualsThan, new StringLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >=(Column leftColumn, Column rightColumn)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.GreaterOrEqualsThan, rightColumn);
        }

        public static ComparisonPredicate operator >=(Column leftColumn, SelectQuery query)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.GreaterOrEqualsThan, query);
        }

        public static ComparisonPredicate operator <=(Column leftColumn, bool literalValue)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.LessOrEqualsThan, new BooleanLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <=(Column leftColumn, DateTime literalValue)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.LessOrEqualsThan, new DateTimeLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <=(Column leftColumn, int literalValue)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.LessOrEqualsThan, new IntegerLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <=(Column leftColumn, double literalValue)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.LessOrEqualsThan, new DecimalLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <=(Column leftColumn, string literalValue)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.LessOrEqualsThan, new StringLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <=(Column leftColumn, Column rightColumn)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.LessOrEqualsThan, rightColumn);
        }

        public static ComparisonPredicate operator <=(Column leftColumn, SelectQuery query)
        {
            return new ComparisonPredicate(leftColumn, ComparisonPredicateType.LessOrEqualsThan, query);
        }
    }
}