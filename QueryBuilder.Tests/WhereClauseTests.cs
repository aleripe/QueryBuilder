using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReturnTrue.QueryBuilder.Elements;
using ReturnTrue.QueryBuilder.Enums;
using ReturnTrue.QueryBuilder.Renderers;
using ReturnTrue.QueryBuilder.Select;
using ReturnTrue.QueryBuilder.Select.Where;

namespace ReturnTrue.QueryBuilder.Tests
{
    [TestClass]
    public class WhereClauseTests
    {
        private SqlClientRenderer sqlClientRenderer;

        [TestInitialize]
        public void Setup()
        {
            sqlClientRenderer = new SqlClientRenderer();
        }

        #region WhereClause
        [TestMethod]
        public void CreateWhereClause()
        {
            Column column = new Column("Column1");
            StringLiteralValue stringLiteralValue = new StringLiteralValue("Value1");
            ComparisonPredicate comparisonPredicate = new ComparisonPredicate(column, PredicateComparisonType.Equals, stringLiteralValue);
            WhereClause whereClause = new WhereClause(comparisonPredicate);

            Assert.AreEqual(comparisonPredicate, whereClause.Predicate);
        }

        [TestMethod]
        public void AddWhereClauseToSelectQuery()
        {
            SelectQuery selectQuery = new SelectQuery();

            Column column = new Column("Column1");
            StringLiteralValue stringLiteralValue = new StringLiteralValue("LiteralValue1");
            ComparisonPredicate comparisonPredicate = new ComparisonPredicate(column, PredicateComparisonType.Equals, stringLiteralValue);
            WhereClause whereClause = new WhereClause(comparisonPredicate);
            selectQuery.Where(whereClause);

            Assert.AreEqual(whereClause, selectQuery.WhereClause);
        }
        #endregion

        #region WhereClauses
        [TestMethod]
        public void AddWhereClauses()
        {
            Column column1 = new Column("Column1");
            Column column2 = new Column("Column2");
            StringLiteralValue stringLiteralValue1 = new StringLiteralValue("Value1");
            StringLiteralValue stringLiteralValue2 = new StringLiteralValue("Value2");
            ComparisonPredicate comparisonPredicate1 = new ComparisonPredicate(column1, PredicateComparisonType.Equals, stringLiteralValue1);
            ComparisonPredicate comparisonPredicate2 = new ComparisonPredicate(column2, PredicateComparisonType.Equals, stringLiteralValue2);
            WhereClause whereClause1 = new WhereClause(comparisonPredicate1);
            WhereClause whereClause2 = new WhereClause(comparisonPredicate2);
            WhereClauses whereClauses = new WhereClauses(whereClause1, BooleanOperatorType.And, whereClause2);

            Assert.AreEqual(whereClause1, whereClauses.LeftClause);
            Assert.AreEqual(BooleanOperatorType.And, whereClauses.OperatorType);
            Assert.AreEqual(whereClause2, whereClauses.RightClause);
        }

        [TestMethod]
        public void RenderWhereClausesAnd()
        {
            Column column1 = new Column("Column1");
            Column column2 = new Column("Column2");
            StringLiteralValue stringLiteralValue1 = new StringLiteralValue("Value1");
            StringLiteralValue stringLiteralValue2 = new StringLiteralValue("Value2");
            ComparisonPredicate comparisonPredicate1 = new ComparisonPredicate(column1, PredicateComparisonType.Equals, stringLiteralValue1);
            ComparisonPredicate comparisonPredicate2 = new ComparisonPredicate(column2, PredicateComparisonType.Equals, stringLiteralValue2);
            WhereClause whereClause1 = new WhereClause(comparisonPredicate1);
            WhereClause whereClause2 = new WhereClause(comparisonPredicate2);
            WhereClauses whereClauses = new WhereClauses(whereClause1, BooleanOperatorType.And, whereClause2);

            Assert.AreEqual("([Column1] = 'Value1' AND [Column2] = 'Value2')", sqlClientRenderer.Render(whereClauses));
        }

        [TestMethod]
        public void RenderWhereClausesOr()
        {
            Column column1 = new Column("Column1");
            Column column2 = new Column("Column2");
            StringLiteralValue stringLiteralValue1 = new StringLiteralValue("Value1");
            StringLiteralValue stringLiteralValue2 = new StringLiteralValue("Value2");
            ComparisonPredicate comparisonPredicate1 = new ComparisonPredicate(column1, PredicateComparisonType.Equals, stringLiteralValue1);
            ComparisonPredicate comparisonPredicate2 = new ComparisonPredicate(column2, PredicateComparisonType.Equals, stringLiteralValue2);
            WhereClause whereClause1 = new WhereClause(comparisonPredicate1);
            WhereClause whereClause2 = new WhereClause(comparisonPredicate2);
            WhereClauses whereClauses = new WhereClauses(whereClause1, BooleanOperatorType.Or, whereClause2);

            Assert.AreEqual("([Column1] = 'Value1' OR [Column2] = 'Value2')", sqlClientRenderer.Render(whereClauses));
        }
        #endregion
    }
}