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

        public static SelectClauses operator &(Column leftColumn, Column rightColumn)
        {
            return new SelectClauses(new SelectClause(leftColumn), new SelectClause(rightColumn));
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
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.Equals, new BooleanLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator ==(Column leftColumn, DateTime literalValue)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.Equals, new DateTimeLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator ==(Column leftColumn, int literalValue)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.Equals, new IntegerLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator ==(Column leftColumn, double literalValue)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.Equals, new DecimalLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator ==(Column leftColumn, string literalValue)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.Equals, new StringLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator ==(Column leftColumn, Column rightColumn)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.Equals, rightColumn);
        }

        public static ComparisonPredicate operator ==(Column leftColumn, SelectQuery query)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.Equals, query);
        }

        public static ComparisonPredicate operator !=(Column leftColumn, bool literalValue)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.NotEquals, new BooleanLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator !=(Column leftColumn, DateTime literalValue)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.NotEquals, new DateTimeLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator !=(Column leftColumn, int literalValue)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.NotEquals, new IntegerLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator !=(Column leftColumn, double literalValue)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.NotEquals, new DecimalLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator !=(Column leftColumn, string literalValue)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.NotEquals, new StringLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator !=(Column leftColumn, Column rightColumn)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.NotEquals, rightColumn);
        }

        public static ComparisonPredicate operator !=(Column leftColumn, SelectQuery query)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.NotEquals, query);
        }

        public static ComparisonPredicate operator <(Column leftColumn, bool literalValue)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.LessThan, new BooleanLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <(Column leftColumn, DateTime literalValue)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.LessThan, new DateTimeLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <(Column leftColumn, int literalValue)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.LessThan, new IntegerLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <(Column leftColumn, double literalValue)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.LessThan, new DecimalLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <(Column leftColumn, string literalValue)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.LessThan, new StringLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <(Column leftColumn, Column rightColumn)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.LessThan, rightColumn);
        }

        public static ComparisonPredicate operator <(Column leftColumn, SelectQuery query)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.LessThan, query);
        }

        public static ComparisonPredicate operator >(Column leftColumn, bool literalValue)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.GreaterThan, new BooleanLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >(Column leftColumn, DateTime literalValue)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.GreaterThan, new DateTimeLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >(Column leftColumn, int literalValue)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.GreaterThan, new IntegerLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >(Column leftColumn, double literalValue)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.GreaterThan, new DecimalLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >(Column leftColumn, string literalValue)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.GreaterThan, new StringLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >(Column leftColumn, Column rightColumn)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.GreaterThan, rightColumn);
        }

        public static ComparisonPredicate operator >(Column leftColumn, SelectQuery query)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.GreaterThan, query);
        }

        public static ComparisonPredicate operator >=(Column leftColumn, bool literalValue)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.GreaterOrEqualsThan, new BooleanLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >=(Column leftColumn, DateTime literalValue)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.GreaterOrEqualsThan, new DateTimeLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >=(Column leftColumn, int literalValue)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.GreaterOrEqualsThan, new IntegerLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >=(Column leftColumn, double literalValue)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.GreaterOrEqualsThan, new DecimalLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >=(Column leftColumn, string literalValue)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.GreaterOrEqualsThan, new StringLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator >=(Column leftColumn, Column rightColumn)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.GreaterOrEqualsThan, rightColumn);
        }

        public static ComparisonPredicate operator >=(Column leftColumn, SelectQuery query)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.GreaterOrEqualsThan, query);
        }

        public static ComparisonPredicate operator <=(Column leftColumn, bool literalValue)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.LessOrEqualsThan, new BooleanLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <=(Column leftColumn, DateTime literalValue)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.LessOrEqualsThan, new DateTimeLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <=(Column leftColumn, int literalValue)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.LessOrEqualsThan, new IntegerLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <=(Column leftColumn, double literalValue)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.LessOrEqualsThan, new DecimalLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <=(Column leftColumn, string literalValue)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.LessOrEqualsThan, new StringLiteralValue(literalValue));
        }

        public static ComparisonPredicate operator <=(Column leftColumn, Column rightColumn)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.LessOrEqualsThan, rightColumn);
        }

        public static ComparisonPredicate operator <=(Column leftColumn, SelectQuery query)
        {
            return new ComparisonPredicate(leftColumn, PredicateComparisonType.LessOrEqualsThan, query);
        }
    }
}