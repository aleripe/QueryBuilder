using ReturnTrue.QueryBuilder.Elements;
using ReturnTrue.QueryBuilder.Enums;
using ReturnTrue.QueryBuilder.Renderers;
using ReturnTrue.QueryBuilder.Select.From;
using ReturnTrue.QueryBuilder.Select.GroupBy;
using ReturnTrue.QueryBuilder.Select.Having;
using ReturnTrue.QueryBuilder.Select.OrderBy;
using ReturnTrue.QueryBuilder.Select.Select;
using ReturnTrue.QueryBuilder.Select.Where;
using System;

namespace ReturnTrue.QueryBuilder.Select
{
    public class SelectQuery : IQueryValueExpression, IQueryMembership
    {
        public SelectClause SelectClause { get; private set; }
        public FromClause FromClause { get; private set; }
        public WhereClause WhereClause { get; private set; }
        public OrderByClause OrderByClause { get; private set; }
        public GroupByClause GroupByClause { get; private set; }
        public HavingClause HavingClause { get; private set; }

        public SelectQuery Select(SelectClause selectClause)
        {
            if (SelectClause == null)
            {
                SelectClause = selectClause;
            }
            else
            {
                SelectClause &= selectClause;
            }

            return this;
        }

        public SelectQuery Select(IQueryValueExpression expression)
        {
            return Select(new SelectClause(expression));
        }

        public SelectQuery Select(IQueryValueExpression expression, string alias)
        {
            return Select(new SelectClause(expression, alias));
        }

        public SelectQuery From(FromClause fromClause)
        {
            if (FromClause == null)
            {
                FromClause = fromClause;
            }
            else
            {
                FromClause = new FromClauses(FromClause, fromClause);
            }
            
            return this;
        }

        public SelectQuery From(Table table)
        {
            return From(table, null);
        }

        public SelectQuery From(Table table, string alias)
        {
            return From(new TableFromClause(table, alias));
        }

        public SelectQuery From(SelectQuery query)
        {
            return From(query, null);
        }

        public SelectQuery From(SelectQuery query, string alias)
        {
            return From(new QueryFromClause(query, alias));
        }

        public SelectQuery Where(WhereClause whereClause)
        {
            if (WhereClause == null)
            {
                WhereClause = whereClause;
            }
            else
            {
                WhereClause &= whereClause;
            }

            return this;
        }

        public SelectQuery OrderBy(OrderByClause orderByClause)
        {
            if (OrderByClause == null)
            {
                OrderByClause = orderByClause;
            }
            else
            {
                OrderByClause &= orderByClause;
            }

            return this;
        }

        public SelectQuery OrderBy(Column column)
        {
            return OrderBy(new OrderByClause(column));
        }

        public SelectQuery OrderBy(Column column, OrderType orderType)
        {
            return OrderBy(new OrderByClause(column, orderType));
        }

        public SelectQuery OrderBy(params Column[] columns)
        {
            foreach (Column column in columns)
            {
                OrderBy(column);
            }

            return this;
        }

        public SelectQuery GroupBy(GroupByClause groupByClause)
        {
            if (OrderByClause == null)
            {
                GroupByClause = groupByClause;
            }
            else
            {
                GroupByClause &= groupByClause;
            }

            return this;
        }

        public SelectQuery GroupBy(Column column)
        {
            return GroupBy(new GroupByClause(column));
        }

        public SelectQuery Having(HavingClause havingClause)
        {
            if (WhereClause == null)
            {
                HavingClause = havingClause;
            }
            else
            {
                HavingClause &= havingClause;
            }

            return this;
        }

        public string Render(IRenderer renderer)
        {
            return renderer.Render(this);
        }

        #region Operator overloading
        public static ComparisonPredicate operator ==(SelectQuery query, bool literalValue)
        {
            return new ComparisonPredicate(new BooleanLiteralValue(literalValue), PredicateComparisonType.Equals, query);
        }

        public static ComparisonPredicate operator ==(SelectQuery query, DateTime literalValue)
        {
            return new ComparisonPredicate(new DateTimeLiteralValue(literalValue), PredicateComparisonType.Equals, query);
        }

        public static ComparisonPredicate operator ==(SelectQuery query, int literalValue)
        {
            return new ComparisonPredicate(new IntegerLiteralValue(literalValue), PredicateComparisonType.Equals, query);
        }

        public static ComparisonPredicate operator ==(SelectQuery query, double literalValue)
        {
            return new ComparisonPredicate(new DecimalLiteralValue(literalValue), PredicateComparisonType.Equals, query);
        }

        public static ComparisonPredicate operator ==(SelectQuery query, string literalValue)
        {
            return new ComparisonPredicate(new StringLiteralValue(literalValue), PredicateComparisonType.Equals, query);
        }

        public static ComparisonPredicate operator ==(SelectQuery query, Column column)
        {
            return new ComparisonPredicate(column, PredicateComparisonType.Equals, query);
        }

        public static ComparisonPredicate operator !=(SelectQuery query, bool literalValue)
        {
            return new ComparisonPredicate(new BooleanLiteralValue(literalValue), PredicateComparisonType.NotEquals, query);
        }

        public static ComparisonPredicate operator !=(SelectQuery query, DateTime literalValue)
        {
            return new ComparisonPredicate(new DateTimeLiteralValue(literalValue), PredicateComparisonType.NotEquals, query);
        }

        public static ComparisonPredicate operator !=(SelectQuery query, int literalValue)
        {
            return new ComparisonPredicate(new IntegerLiteralValue(literalValue), PredicateComparisonType.NotEquals, query);
        }

        public static ComparisonPredicate operator !=(SelectQuery query, double literalValue)
        {
            return new ComparisonPredicate(new DecimalLiteralValue(literalValue), PredicateComparisonType.NotEquals, query);
        }

        public static ComparisonPredicate operator !=(SelectQuery query, string literalValue)
        {
            return new ComparisonPredicate(new StringLiteralValue(literalValue), PredicateComparisonType.NotEquals, query);
        }

        public static ComparisonPredicate operator !=(SelectQuery query, Column column)
        {
            return new ComparisonPredicate(column, PredicateComparisonType.NotEquals, query);
        }

        public static ComparisonPredicate operator >(SelectQuery query, bool literalValue)
        {
            return new ComparisonPredicate(new BooleanLiteralValue(literalValue), PredicateComparisonType.GreaterThan, query);
        }

        public static ComparisonPredicate operator >(SelectQuery query, DateTime literalValue)
        {
            return new ComparisonPredicate(new DateTimeLiteralValue(literalValue), PredicateComparisonType.GreaterThan, query);
        }

        public static ComparisonPredicate operator >(SelectQuery query, int literalValue)
        {
            return new ComparisonPredicate(new IntegerLiteralValue(literalValue), PredicateComparisonType.GreaterThan, query);
        }

        public static ComparisonPredicate operator >(SelectQuery query, double literalValue)
        {
            return new ComparisonPredicate(new DecimalLiteralValue(literalValue), PredicateComparisonType.GreaterThan, query);
        }

        public static ComparisonPredicate operator >(SelectQuery query, string literalValue)
        {
            return new ComparisonPredicate(new StringLiteralValue(literalValue), PredicateComparisonType.GreaterThan, query);
        }

        public static ComparisonPredicate operator >(SelectQuery query, Column column)
        {
            return new ComparisonPredicate(column, PredicateComparisonType.GreaterThan, query);
        }

        public static ComparisonPredicate operator <(SelectQuery query, bool literalValue)
        {
            return new ComparisonPredicate(new BooleanLiteralValue(literalValue), PredicateComparisonType.LessThan, query);
        }

        public static ComparisonPredicate operator <(SelectQuery query, DateTime literalValue)
        {
            return new ComparisonPredicate(new DateTimeLiteralValue(literalValue), PredicateComparisonType.LessThan, query);
        }

        public static ComparisonPredicate operator <(SelectQuery query, int literalValue)
        {
            return new ComparisonPredicate(new IntegerLiteralValue(literalValue), PredicateComparisonType.LessThan, query);
        }

        public static ComparisonPredicate operator <(SelectQuery query, double literalValue)
        {
            return new ComparisonPredicate(new DecimalLiteralValue(literalValue), PredicateComparisonType.LessThan, query);
        }

        public static ComparisonPredicate operator <(SelectQuery query, string literalValue)
        {
            return new ComparisonPredicate(new StringLiteralValue(literalValue), PredicateComparisonType.LessThan, query);
        }

        public static ComparisonPredicate operator <(SelectQuery query, Column column)
        {
            return new ComparisonPredicate(column, PredicateComparisonType.LessThan, query);
        }

        public static ComparisonPredicate operator >=(SelectQuery query, bool literalValue)
        {
            return new ComparisonPredicate(new BooleanLiteralValue(literalValue), PredicateComparisonType.GreaterOrEqualsThan, query);
        }

        public static ComparisonPredicate operator >=(SelectQuery query, DateTime literalValue)
        {
            return new ComparisonPredicate(new DateTimeLiteralValue(literalValue), PredicateComparisonType.GreaterOrEqualsThan, query);
        }

        public static ComparisonPredicate operator >=(SelectQuery query, int literalValue)
        {
            return new ComparisonPredicate(new IntegerLiteralValue(literalValue), PredicateComparisonType.GreaterOrEqualsThan, query);
        }

        public static ComparisonPredicate operator >=(SelectQuery query, double literalValue)
        {
            return new ComparisonPredicate(new DecimalLiteralValue(literalValue), PredicateComparisonType.GreaterOrEqualsThan, query);
        }

        public static ComparisonPredicate operator >=(SelectQuery query, string literalValue)
        {
            return new ComparisonPredicate(new StringLiteralValue(literalValue), PredicateComparisonType.GreaterOrEqualsThan, query);
        }

        public static ComparisonPredicate operator >=(SelectQuery query, Column column)
        {
            return new ComparisonPredicate(column, PredicateComparisonType.GreaterOrEqualsThan, query);
        }

        public static ComparisonPredicate operator <=(SelectQuery query, bool literalValue)
        {
            return new ComparisonPredicate(new BooleanLiteralValue(literalValue), PredicateComparisonType.LessOrEqualsThan, query);
        }

        public static ComparisonPredicate operator <=(SelectQuery query, DateTime literalValue)
        {
            return new ComparisonPredicate(new DateTimeLiteralValue(literalValue), PredicateComparisonType.LessOrEqualsThan, query);
        }

        public static ComparisonPredicate operator <=(SelectQuery query, int literalValue)
        {
            return new ComparisonPredicate(new IntegerLiteralValue(literalValue), PredicateComparisonType.LessOrEqualsThan, query);
        }

        public static ComparisonPredicate operator <=(SelectQuery query, double literalValue)
        {
            return new ComparisonPredicate(new DecimalLiteralValue(literalValue), PredicateComparisonType.LessOrEqualsThan, query);
        }

        public static ComparisonPredicate operator <=(SelectQuery query, string literalValue)
        {
            return new ComparisonPredicate(new StringLiteralValue(literalValue), PredicateComparisonType.LessOrEqualsThan, query);
        }

        public static ComparisonPredicate operator <=(SelectQuery query, Column column)
        {
            return new ComparisonPredicate(column, PredicateComparisonType.LessOrEqualsThan, query);
        } 
        #endregion
    }
}