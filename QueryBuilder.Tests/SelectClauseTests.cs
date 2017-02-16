using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReturnTrue.QueryBuilder.Elements;
using ReturnTrue.QueryBuilder.Select.Select;
using ReturnTrue.QueryBuilder.Select;
using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Tests
{
    [TestClass]
    public class SelectClauseTests
    {
        private SqlClientRenderer sqlClientRenderer;

        [TestInitialize]
        public void Setup()
        {
            sqlClientRenderer = new SqlClientRenderer();
        }

        #region SelectClause
        [TestMethod]
        public void CreateExpressionSelectClause()
        {
            Column column = new Column("Column1");
            SelectClause selectClause = new SelectClause(column);

            Assert.AreEqual(column, selectClause.Expression);
            Assert.IsNull(selectClause.Alias);
        }

        [TestMethod]
        public void CreateExpressionSelectClauseWithAlias()
        {
            Column column = new Column("Column1");
            SelectClause selectClause = new SelectClause(column, "Column1Alias");

            Assert.AreEqual(column, selectClause.Expression);
            Assert.AreEqual("Column1Alias", selectClause.Alias);
        }

        [TestMethod]
        public void AddExpressionSelectClauseToSelectQuery()
        {
            SelectQuery selectQuery = new SelectQuery();

            Column column = new Column("Column1");
            SelectClause selectClause = new SelectClause(column);
            selectQuery.Select(selectClause);

            Assert.AreEqual(selectClause, selectQuery.SelectClause);
        }

        [TestMethod]
        public void RenderExpressionSelectClause()
        {
            Column column = new Column("Column1");
            SelectClause selectClause = new SelectClause(column);
            
            Assert.AreEqual("[Column1]", sqlClientRenderer.Render(selectClause));
        }

        [TestMethod]
        public void RenderExpressionSelectClauseWithAlias()
        {
            Column column = new Column("Column1");
            SelectClause selectClause = new SelectClause(column, "Column1Alias");
            
            Assert.AreEqual("[Column1] AS Column1Alias", sqlClientRenderer.Render(selectClause));
        }
        #endregion

        #region SelectClauses
        [TestMethod]
        public void CreateExpressionSelectClauses()
        {
            Column column1 = new Column("Column1");
            Column column2 = new Column("Column2");
            SelectClause selectClause1 = new SelectClause(column1);
            SelectClause selectClause2 = new SelectClause(column2);
            SelectClauses selectClauses = new SelectClauses(selectClause1, selectClause2);

            Assert.AreEqual(selectClause1, selectClauses.LeftClause);
            Assert.AreEqual(selectClause2, selectClauses.RightClause);
        }

        [TestMethod]
        public void AddExpressionSelectClausesToSelectQuery()
        {
            SelectQuery selectQuery = new SelectQuery();

            Column column1 = new Column("Column1");
            Column column2 = new Column("Column2");
            SelectClause selectClause1 = new SelectClause(column1);
            SelectClause selectClause2 = new SelectClause(column2);
            selectQuery.Select(selectClause1);
            selectQuery.Select(selectClause2);

            Assert.IsTrue(selectQuery.SelectClause is SelectClauses);
        }

        [TestMethod]
        public void RenderExpressionSelectClauses()
        {
            Column column1 = new Column("Column1");
            Column column2 = new Column("Column2");
            SelectClause selectClause1 = new SelectClause(column1);
            SelectClause selectClause2 = new SelectClause(column2);
            SelectClauses selectClauses = new SelectClauses(selectClause1, selectClause2);
            
            Assert.AreEqual("[Column1], [Column2]", sqlClientRenderer.Render(selectClauses));
        }
        #endregion
    }
}