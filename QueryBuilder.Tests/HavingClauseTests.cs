using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReturnTrue.QueryBuilder.Elements;
using ReturnTrue.QueryBuilder.Enums;
using ReturnTrue.QueryBuilder.Renderers;
using ReturnTrue.QueryBuilder.Select;
using ReturnTrue.QueryBuilder.Select.Having;

namespace ReturnTrue.QueryBuilder.Tests
{
    [TestClass]
    public class HavingClauseTests
    {
        private SqlClientRenderer sqlClientRenderer;

        [TestInitialize]
        public void Setup()
        {
            sqlClientRenderer = new SqlClientRenderer();
        }

        #region HavingClause
        [TestMethod]
        public void CreateHavingClause()
        {
            Column column = new Column("Column1");
            StringLiteralValue stringLiteralValue = new StringLiteralValue("Value1");
            ComparisonPredicate comparisonPredicate = new ComparisonPredicate(column, PredicateComparisonType.Equals, stringLiteralValue);
            HavingClause havingClause = new HavingClause(comparisonPredicate);

            Assert.AreEqual(comparisonPredicate, havingClause.Predicate);
        }

        [TestMethod]
        public void AddHavingClauseToSelectQuery()
        {
            SelectQuery selectQuery = new SelectQuery();

            Column column = new Column("Column1");
            StringLiteralValue stringLiteralValue = new StringLiteralValue("Value1");
            ComparisonPredicate comparisonPredicate = new ComparisonPredicate(column, PredicateComparisonType.Equals, stringLiteralValue);
            HavingClause havingClause = new HavingClause(comparisonPredicate);
            selectQuery.Having(havingClause);

            Assert.AreEqual(havingClause, selectQuery.HavingClause);
        }
        #endregion

        #region HavingClauses
        [TestMethod]
        public void AddHavingClauses()
        {
            Column column1 = new Column("Column1");
            Column column2 = new Column("Column2");
            StringLiteralValue stringLiteralValue1 = new StringLiteralValue("Value1");
            StringLiteralValue stringLiteralValue2 = new StringLiteralValue("Value2");
            ComparisonPredicate comparisonPredicate1 = new ComparisonPredicate(column1, PredicateComparisonType.Equals, stringLiteralValue1);
            ComparisonPredicate comparisonPredicate2 = new ComparisonPredicate(column2, PredicateComparisonType.Equals, stringLiteralValue2);
            HavingClause havingClause1 = new HavingClause(comparisonPredicate1);
            HavingClause havingClause2 = new HavingClause(comparisonPredicate2);
            HavingClauses havingClauses = new HavingClauses(havingClause1, BooleanOperatorType.And, havingClause2);

            Assert.AreEqual(havingClause1, havingClauses.LeftClause);
            Assert.AreEqual(BooleanOperatorType.And, havingClauses.OperatorType);
            Assert.AreEqual(havingClause2, havingClauses.RightClause);
        }

        [TestMethod]
        public void RenderHavingClausesAnd()
        {
            Column column1 = new Column("Column1");
            Column column2 = new Column("Column2");
            StringLiteralValue stringLiteralValue1 = new StringLiteralValue("Value1");
            StringLiteralValue stringLiteralValue2 = new StringLiteralValue("Value2");
            ComparisonPredicate comparisonPredicate1 = new ComparisonPredicate(column1, PredicateComparisonType.Equals, stringLiteralValue1);
            ComparisonPredicate comparisonPredicate2 = new ComparisonPredicate(column2, PredicateComparisonType.Equals, stringLiteralValue2);
            HavingClause havingClause1 = new HavingClause(comparisonPredicate1);
            HavingClause havingClause2 = new HavingClause(comparisonPredicate2);
            HavingClauses havingClauses = new HavingClauses(havingClause1, BooleanOperatorType.And, havingClause2);

            Assert.AreEqual("([Column1] = 'Value1' AND [Column2] = 'Value2')", sqlClientRenderer.Render(havingClauses));
        }

        [TestMethod]
        public void RenderHavingClausesOr()
        {
            Column column1 = new Column("Column1");
            Column column2 = new Column("Column2");
            StringLiteralValue stringLiteralValue1 = new StringLiteralValue("Value1");
            StringLiteralValue stringLiteralValue2 = new StringLiteralValue("Value2");
            ComparisonPredicate comparisonPredicate1 = new ComparisonPredicate(column1, PredicateComparisonType.Equals, stringLiteralValue1);
            ComparisonPredicate comparisonPredicate2 = new ComparisonPredicate(column2, PredicateComparisonType.Equals, stringLiteralValue2);
            HavingClause havingClause1 = new HavingClause(comparisonPredicate1);
            HavingClause havingClause2 = new HavingClause(comparisonPredicate2);
            HavingClauses havingClauses = new HavingClauses(havingClause1, BooleanOperatorType.Or, havingClause2);

            Assert.AreEqual("([Column1] = 'Value1' OR [Column2] = 'Value2')", sqlClientRenderer.Render(havingClauses));
        }
        #endregion
    }
}