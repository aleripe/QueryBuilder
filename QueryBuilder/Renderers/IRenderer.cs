using ReturnTrue.QueryBuilder.Elements;
using ReturnTrue.QueryBuilder.Modifiers;
using ReturnTrue.QueryBuilder.Select;
using ReturnTrue.QueryBuilder.Select.From;
using ReturnTrue.QueryBuilder.Select.GroupBy;
using ReturnTrue.QueryBuilder.Select.Having;
using ReturnTrue.QueryBuilder.Select.OrderBy;
using ReturnTrue.QueryBuilder.Select.Select;
using ReturnTrue.QueryBuilder.Select.Where;

namespace ReturnTrue.QueryBuilder.Renderers
{
    public interface IRenderer
    {
        string Render(DistinctModifier distinctModifier);
        string Render(NotModifier notModifier);

        string Render(SelectQuery selectQuery);
        string Render(SelectClauses selectClauses);
        string Render(SelectClause selectClause);
        string Render(FromClauses fromClauses);
        string Render(TableFromClause tableFromClause);
        string Render(QueryFromClause queryFromClause);
        string Render(WhereClauses whereClauses);
        string Render(WhereClause whereClause);
        string Render(OrderByClauses orderByClauses);
        string Render(OrderByClause orderByClause);
        string Render(GroupByClauses groupByClauses);
        string Render(GroupByClause groupByClause);
        string Render(HavingClauses havingClauses);
        string Render(HavingClause havingClause);
        string Render(Table table);
        string Render(Column column);
        string Render(UpperFunction upperFunction);
        string Render(LowerFunction lowerFunction);
        string Render(AggregateFunction aggregateFunction);
        string Render(DatePartFunction datePartFunction);
        string Render(ComparisonPredicate comparisonPredicate);
        string Render(MembershipPredicate membershipPredicate);
        string Render(PatternPredicate patternPredicate);
        string Render(RangePredicate rangePredicate);
        string Render(NullPredicate nullPredicate);
        string Render(IntegerLiteralArray integerLiteralArray);
        string Render(StringLiteralArray stringLiteralArray);
        string Render(BooleanLiteralValue booleanLiteralValue);
        string Render(DateTimeLiteralValue dateTimeLiteralValue);
        string Render(IntegerLiteralValue integerLiteralValue);
        string Render(DecimalLiteralValue decimalLiteralValue);
        string Render(StringLiteralValue stringLiteralValue);
        string Render(Parameter parameter);
    }
}