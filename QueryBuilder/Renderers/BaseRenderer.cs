using ReturnTrue.QueryBuilder.Elements;
using ReturnTrue.QueryBuilder.Modifiers;
using ReturnTrue.QueryBuilder.Select;
using ReturnTrue.QueryBuilder.Select.From;
using ReturnTrue.QueryBuilder.Select.GroupBy;
using ReturnTrue.QueryBuilder.Select.Having;
using ReturnTrue.QueryBuilder.Select.OrderBy;
using ReturnTrue.QueryBuilder.Select.Select;
using ReturnTrue.QueryBuilder.Select.Where;
using System;
using System.Collections.Generic;
using System.Data;

namespace ReturnTrue.QueryBuilder.Renderers
{
    public abstract class BaseRenderer : IRenderer
    {
        public bool ReplaceLiteralsWithParameters { get; set; }
        public List<Parameter> Parameters { get; private set; }

        protected Parameter AddParameter(object value, DbType type)
        {
            Parameter parameter = new Parameter(Convert.ToString(Parameters.Count), value, type);
            Parameters.Add(parameter);

            return parameter;
        }

        public abstract string ParameterFormat { get; }
        public abstract string QuotedIdentifierFormat { get; }

        public abstract string Render(DistinctModifier distinctModifier);
        public abstract string Render(NotModifier notModifier);

        public abstract string Render(SelectQuery selectQuery);
        public abstract string Render(SelectClauses selectClauses);
        public abstract string Render(SelectClause selectClause);
        public abstract string Render(FromClauses fromClauses);
        public abstract string Render(JoinFromClause joinFromClause);
        public abstract string Render(TableFromClause tableFromClause);
        public abstract string Render(QueryFromClause queryFromClause);
        public abstract string Render(WhereClauses whereClauses);
        public abstract string Render(WhereClause whereClause);
        public abstract string Render(OrderByClauses orderByClauses);
        public abstract string Render(OrderByClause orderByClause);
        public abstract string Render(GroupByClauses groupByClauses);
        public abstract string Render(GroupByClause groupByClause);
        public abstract string Render(HavingClauses havingClauses);
        public abstract string Render(HavingClause havingClause);
        public abstract string Render(Table table);
        public abstract string Render(Column column);
        public abstract string Render(UpperFunction upperFunction);
        public abstract string Render(LowerFunction lowerFunction);
        public abstract string Render(AggregateFunction aggregateFunction);
        public abstract string Render(DatePartFunction datePartFunction);
        public abstract string Render(ComparisonPredicate comparisonPredicate);
        public abstract string Render(MembershipPredicate membershipPredicate);
        public abstract string Render(PatternPredicate patternPredicate);
        public abstract string Render(RangePredicate rangePredicate);
        public abstract string Render(NullPredicate nullPredicate);
        public abstract string Render(IntegerLiteralArray integerLiteralArray);
        public abstract string Render(StringLiteralArray stringLiteralArray);
        public abstract string Render(BooleanLiteralValue booleanLiteralValue);
        public abstract string Render(DateTimeLiteralValue dateTimeLiteralValue);
        public abstract string Render(IntegerLiteralValue integerLiteralValue);
        public abstract string Render(DecimalLiteralValue decimalLiteralValue);
        public abstract string Render(StringLiteralValue stringLiteralValue);
        public abstract string Render(Parameter parameter);
    }
}