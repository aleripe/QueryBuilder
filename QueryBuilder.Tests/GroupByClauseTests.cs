using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReturnTrue.QueryBuilder.Elements;
using ReturnTrue.QueryBuilder.Renderers;
using ReturnTrue.QueryBuilder.Select.GroupBy;

namespace ReturnTrue.QueryBuilder.Tests
{
    [TestClass]
    public class GroupByClauseTests
    {
        private SqlClientRenderer sqlClientRenderer;

        [TestInitialize]
        public void Setup()
        {
            sqlClientRenderer = new SqlClientRenderer();
        }

        #region GroupByClause
        [TestMethod]
        public void CreateGroupByClause()
        {
            Column column = new Column("Column1");
            GroupByClause groupByClause = new GroupByClause(column);

            Assert.AreEqual(column, groupByClause.Column);
        }

        [TestMethod]
        public void RenderOrderByClause()
        {
            Column column = new Column("Column1");
            GroupByClause groupByClause = new GroupByClause(column);

            Assert.AreEqual("[Column1]", sqlClientRenderer.Render(groupByClause));
        }
        #endregion

        #region GroupByClauses
        [TestMethod]
        public void CreateOrderByClauses()
        {
            Column column1 = new Column("Column1");
            Column column2 = new Column("Column2");
            GroupByClause groupByClause1 = new GroupByClause(column1);
            GroupByClause groupByClause2 = new GroupByClause(column2);
            GroupByClauses groupByClauses = new GroupByClauses(groupByClause1, groupByClause2);

            Assert.AreEqual(groupByClause1, groupByClauses.LeftClause);
            Assert.AreEqual(groupByClause2, groupByClauses.RightClause);
        }

        [TestMethod]
        public void RenderGroupByClauses()
        {
            Column column1 = new Column("Column1");
            Column column2 = new Column("Column2");
            GroupByClause groupByClause1 = new GroupByClause(column1);
            GroupByClause groupByClause2 = new GroupByClause(column2);
            GroupByClauses groupByClauses = new GroupByClauses(groupByClause1, groupByClause2);

            Assert.AreEqual("[Column1], [Column2]", sqlClientRenderer.Render(groupByClauses));
        }
        #endregion
    }
}