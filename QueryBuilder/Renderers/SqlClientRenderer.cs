using ReturnTrue.QueryBuilder.Elements;
using ReturnTrue.QueryBuilder.Enums;
using ReturnTrue.QueryBuilder.Modifiers;
using ReturnTrue.QueryBuilder.Select;
using ReturnTrue.QueryBuilder.Select.From;
using ReturnTrue.QueryBuilder.Select.GroupBy;
using ReturnTrue.QueryBuilder.Select.Having;
using ReturnTrue.QueryBuilder.Select.OrderBy;
using ReturnTrue.QueryBuilder.Select.Select;
using ReturnTrue.QueryBuilder.Select.Where;
using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ReturnTrue.QueryBuilder.Renderers
{
    public class SqlClientRenderer : BaseRenderer
    {
        public override string ParameterFormat
        {
            get { return "@{0}"; }
        }

        public override string QuotedIdentifierFormat
        {
            get { return "[{0}]"; }
        }

        public override string Render(DistinctModifier distinctModifier)
        {
            return "DISTINCT";
        }

        public override string Render(NotModifier notModifier)
        {
            return "NOT";
        }

        public override string Render(SelectQuery selectQuery)
        {
            StringBuilder text = new StringBuilder();
            
            if (selectQuery.SelectClause != null)
            {
                text.AppendFormat("SELECT {0} ", selectQuery.SelectClause.Render(this));
            }

            if (selectQuery.FromClause != null)
            {
                text.AppendFormat("FROM {0} ", selectQuery.FromClause.Render(this));
            }

            if (selectQuery.WhereClause != null)
            {
                text.AppendFormat("WHERE {0} ", selectQuery.WhereClause.Render(this));
            }

            if (selectQuery.OrderByClause != null)
            {
                text.AppendFormat("ORDER BY {0} ", selectQuery.OrderByClause.Render(this));
            }

            if (selectQuery.GroupByClause != null)
            {
                text.AppendFormat("GROUP BY {0} ", selectQuery.GroupByClause.Render(this));
            }

            if (selectQuery.HavingClause != null)
            {
                text.AppendFormat("HAVING {0} ", selectQuery.HavingClause.Render(this));
            }

            return text.ToString().Trim();
        }

        public override string Render(SelectClauses selectClauses)
        {
            if (selectClauses.LeftClause == null)
            {
                return selectClauses.RightClause.Render(this);
            }
            else if (selectClauses.RightClause == null)
            {
                return selectClauses.LeftClause.Render(this);
            }
            else
            {
                return string.Format("{0}, {1}", selectClauses.LeftClause.Render(this), selectClauses.RightClause.Render(this));
            }
        }

        public override string Render(SelectClause selectClause)
        {
            StringBuilder text = new StringBuilder();

            text.AppendFormat("{0} ", selectClause.Expression.Render(this));

            if (selectClause.Alias != null)
            {
                text.AppendFormat("AS {0}", selectClause.Alias);
            }

            return text.ToString().Trim();
        }

        public override string Render(FromClauses fromClauses)
        {
            if (fromClauses.LeftClause == null)
            {
                return fromClauses.RightClause.Render(this);
            }
            else if (fromClauses.RightClause == null)
            {
                return fromClauses.LeftClause.Render(this);
            }
            else
            {
                return string.Format("{0}, {1}", fromClauses.LeftClause.Render(this), fromClauses.RightClause.Render(this));
            }
        }

        public override string Render(TableFromClause tableFromClause)
        {
            StringBuilder text = new StringBuilder();

            text.AppendFormat("{0} ", tableFromClause.Table.Render(this));

            if (tableFromClause.Alias != null)
            {
                text.AppendFormat("{0} ", tableFromClause.Alias);
            }

            return text.ToString().Trim();
        }

        public override string Render(QueryFromClause queryFromClause)
        {
            StringBuilder text = new StringBuilder();

            text.AppendFormat("({0}) ", queryFromClause.Query.Render(this));

            if (queryFromClause.Alias != null)
            {
                text.AppendFormat("{0} ", queryFromClause.Alias);
            }

            return text.ToString().Trim();
        }

        public override string Render(WhereClauses whereClauses)
        {
            if (whereClauses.LeftClause == null)
            {
                return whereClauses.RightClause.Render(this);
            }
            else if (whereClauses.RightClause == null)
            {
                return whereClauses.LeftClause.Render(this);
            }
            else
            {
                StringBuilder text = new StringBuilder();

                text.AppendFormat("({0} ", whereClauses.LeftClause.Render(this));

                text.AppendFormat("{0} ", whereClauses.OperatorType.ToString().ToUpper());

                text.AppendFormat("{0}) ", whereClauses.RightClause.Render(this));

                return text.ToString().Trim();
            }
        }

        public override string Render(WhereClause whereClause)
        {
            return string.Format("{0}", whereClause.Predicate.Render(this));
        }

        public override string Render(OrderByClauses orderByClauses)
        {
            if (orderByClauses.LeftClause == null)
            {
                return orderByClauses.RightClause.Render(this);
            }
            else if (orderByClauses.RightClause == null)
            {
                return orderByClauses.LeftClause.Render(this);
            }
            else
            {
                return string.Format("{0}, {1}", orderByClauses.LeftClause.Render(this), orderByClauses.RightClause.Render(this));
            }
        }

        public override string Render(OrderByClause orderByClause)
        {
            StringBuilder text = new StringBuilder();

            text.AppendFormat("{0} ", orderByClause.Column.Render(this));

            text.AppendFormat("{0}", (orderByClause.OrderType == OrderType.Ascending ? "ASC" : "DESC"));

            return text.ToString().Trim();
        }

        public override string Render(HavingClauses havingClauses)
        {
            if (havingClauses.LeftClause == null)
            {
                return havingClauses.RightClause.Render(this);
            }
            else if (havingClauses.RightClause == null)
            {
                return havingClauses.LeftClause.Render(this);
            }
            else
            {
                StringBuilder text = new StringBuilder();

                text.AppendFormat("({0} ", havingClauses.LeftClause.Render(this));

                text.AppendFormat("{0} ", havingClauses.OperatorType.ToString().ToUpper());

                text.AppendFormat("{0}) ", havingClauses.RightClause.Render(this));

                return text.ToString().Trim();
            }
        }

        public override string Render(HavingClause havingClause)
        {
            return string.Format("{0}", havingClause.Predicate.Render(this));
        }

        public override string Render(GroupByClauses groupByClauses)
        {
            if (groupByClauses.LeftClause == null)
            {
                return groupByClauses.RightClause.Render(this);
            }
            else if (groupByClauses.RightClause == null)
            {
                return groupByClauses.LeftClause.Render(this);
            }
            else
            {
                return string.Format("{0}, {1}", groupByClauses.LeftClause.Render(this), groupByClauses.RightClause.Render(this));
            }
        }

        public override string Render(GroupByClause groupByClause)
        {
            StringBuilder text = new StringBuilder();

            text.AppendFormat("{0} ", groupByClause.Column.Render(this));

            return text.ToString().Trim();
        }

        public override string Render(Table table)
        {
            return string.Format(QuotedIdentifierFormat, table.Name).Trim();
        }

        public override string Render(Column column)
        {
            StringBuilder text = new StringBuilder();

            text.AppendFormat(string.Concat(QuotedIdentifierFormat, " "), column.Name);

            return text.ToString().Trim();
        }

        public override string Render(UpperFunction upperFunction)
        {
            return string.Format("UPPER({0}) ", upperFunction.Expression.Render(this)).Trim();
        }

        public override string Render(LowerFunction lowerFunction)
        {
            return string.Format("LOWER({0}) ", lowerFunction.Expression.Render(this)).Trim();
        }

        public override string Render(AggregateFunction aggregateFunction)
        {
            StringBuilder text = new StringBuilder();

            text.AppendFormat("{0}(", aggregateFunction.FunctionType.ToString().ToUpper());

            if (aggregateFunction.DistinctModifier != null)
            {
                text.AppendFormat("{0} ", aggregateFunction.DistinctModifier.Render(this));
            }

            text.AppendFormat("{0}) ", aggregateFunction.Expression.Render(this));

            return text.ToString().Trim();
        }

        public override string Render(DatePartFunction datePartFunction)
        {
            return string.Format("DATEPART({0},{1}) ", datePartFunction.PartType.ToString().ToLower(), datePartFunction.Expression.Render(this)).Trim();
        }

        public override string Render(ComparisonPredicate comparisonPredicate)
        {
            StringBuilder text = new StringBuilder();

            text.AppendFormat("{0} ", comparisonPredicate.LeftExpression.Render(this));

            switch (comparisonPredicate.ComparisonType)
            {
                case PredicateComparisonType.Equals:
                    text.Append("= ");
                    break;
                case PredicateComparisonType.NotEquals:
                    text.Append("<> ");
                    break;
                case PredicateComparisonType.LessThan:
                    text.Append("< ");
                    break;
                case PredicateComparisonType.GreaterThan:
                    text.Append("> ");
                    break;
                case PredicateComparisonType.LessOrEqualsThan:
                    text.Append("<= ");
                    break;
                case PredicateComparisonType.GreaterOrEqualsThan:
                    text.Append(">= ");
                    break;
            }

            if (comparisonPredicate.RightExpression is SelectQuery)
            {
                text.AppendFormat("({0}) ", comparisonPredicate.RightExpression.Render(this));
            }
            else
            {
                text.AppendFormat("{0} ", comparisonPredicate.RightExpression.Render(this));
            }

            return text.ToString().Trim();
        }

        public override string Render(MembershipPredicate membershipPredicate)
        {
            StringBuilder text = new StringBuilder();

            text.AppendFormat("{0} ", membershipPredicate.Expression.Render(this));

            if (membershipPredicate.NotModifier != null)
            {
                text.AppendFormat("{0} ", membershipPredicate.NotModifier.Render(this));
            }

            text.AppendFormat("IN ({0}) ", membershipPredicate.Membership.Render(this));

            return text.ToString().Trim();
        }

        public override string Render(PatternPredicate patternPredicate)
        {
            StringBuilder text = new StringBuilder();

            text.AppendFormat("{0} ", patternPredicate.Expression.Render(this));

            if (patternPredicate.NotModifier != null)
            {
                text.AppendFormat("{0} ", patternPredicate.NotModifier.Render(this));
            }

            text.AppendFormat("LIKE {0} ", patternPredicate.Pattern.Render(this));

            return text.ToString().Trim();
        }

        public override string Render(RangePredicate rangePredicate)
        {
            StringBuilder text = new StringBuilder();

            text.AppendFormat("{0} ", rangePredicate.LeftExpression.Render(this));

            if (rangePredicate.NotModifier != null)
            {
                text.AppendFormat("{0} ", rangePredicate.NotModifier.Render(this));
            }

            text.AppendFormat("BETWEEN {0} ", rangePredicate.MiddleExpression.Render(this));

            text.AppendFormat("AND {0} ", rangePredicate.RightExpression.Render(this));

            return text.ToString().Trim();
        }

        public override string Render(NullPredicate nullPredicate)
        {
            StringBuilder text = new StringBuilder();

            text.AppendFormat("{0} IS ", nullPredicate.Expression.Render(this));

            if (nullPredicate.NotModifier != null)
            {
                text.AppendFormat("{0} ", nullPredicate.NotModifier.Render(this));
            }

            text.Append("NULL ");

            return text.ToString().Trim();
        }

        public override string Render(IntegerLiteralArray integerLiteralArray)
        {
            if (ReplaceLiteralsWithParameters)
            {
                return string.Join(",", integerLiteralArray.Array.Select(value => AddParameter(value, DbType.Int32).Render(this)));
            }
            else
            {
                return string.Join(",", integerLiteralArray.Array);
            }
        }

        public override string Render(StringLiteralArray stringLiteralArray)
        {
            if (ReplaceLiteralsWithParameters)
            {
                return string.Join(",", stringLiteralArray.Array.Select(value => AddParameter(value, DbType.String).Render(this)));
            }
            else
            {
                return string.Join(",", stringLiteralArray.Array.Select(s => string.Format("'{0}'", s.Replace("'", "''"))));
            }
        }

        public override string Render(DateTimeLiteralValue dateTimeLiteralValue)
        {
            if (ReplaceLiteralsWithParameters)
            {
                return AddParameter(dateTimeLiteralValue.Literal, DbType.Boolean).Render(this);
            }
            else
            {
                return string.Format("CONVERT(datetime, '{0}')", Convert.ToDateTime(dateTimeLiteralValue.Literal).ToString("yyyyMMdd"));
            }
        }

        public override string Render(DecimalLiteralValue decimalLiteralValue)
        {
            if (ReplaceLiteralsWithParameters)
            {
                return AddParameter(decimalLiteralValue.Literal, DbType.Double).Render(this);
            }
            else
            {
                return string.Format(CultureInfo.InvariantCulture, "{0}", decimalLiteralValue.Literal);
            }
        }

        public override string Render(StringLiteralValue stringLiteralValue)
        {
            if (ReplaceLiteralsWithParameters)
            {
                return AddParameter(stringLiteralValue.Literal, DbType.String).Render(this);
            }
            else
            {
                return string.Format("'{0}'", stringLiteralValue.Literal.Replace("'", "''"));
            }
        }

        public override string Render(IntegerLiteralValue integerLiteralValue)
        {
            if (ReplaceLiteralsWithParameters)
            {
                return AddParameter(integerLiteralValue.Literal, DbType.Int32).Render(this);
            }
            else
            {
                return string.Format("{0}", integerLiteralValue.Literal);
            }
        }

        public override string Render(BooleanLiteralValue booleanLiteralValue)
        {
            if (ReplaceLiteralsWithParameters)
            {
                return AddParameter(booleanLiteralValue.Literal, DbType.Boolean).Render(this);
            }
            else
            {
                return string.Format("{0}", Convert.ToInt32(booleanLiteralValue.Literal));
            }
        }

        public override string Render(Parameter parameter)
        {
            return string.Format(ParameterFormat, parameter.Name);
        }
    }
}