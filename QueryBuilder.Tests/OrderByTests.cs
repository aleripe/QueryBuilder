using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReturnTrue.QueryBuilder.Elements;
using ReturnTrue.QueryBuilder.Enums;
using ReturnTrue.QueryBuilder.Renderers;
using ReturnTrue.QueryBuilder.Select.OrderBy;

namespace ReturnTrue.QueryBuilder.Tests
{
    [TestClass]
    public class OrderByTests
    {
        private SqlClientRenderer sqlClientRenderer;

        [TestInitialize]
        public void Setup()
        {
            sqlClientRenderer = new SqlClientRenderer();
        }

        #region OrderByClause
        [TestMethod]
        public void CreateOrderByClause()
        {
            Column column = new Column("Column1");
            OrderByClause orderByClause = new OrderByClause(column);

            Assert.AreEqual(column, orderByClause.Column);
            Assert.AreEqual(OrderType.Ascending, orderByClause.OrderType);
        }

        [TestMethod]
        public void CreateOrderByClauseWithOrderType()
        {
            Column column = new Column("Column1");
            OrderByClause orderByClause = new OrderByClause(column, OrderType.Descending);

            Assert.AreEqual(column, orderByClause.Column);
            Assert.AreEqual(OrderType.Descending, orderByClause.OrderType);
        }

        [TestMethod]
        public void RenderOrderByClause()
        {
            Column column = new Column("Column1");
            OrderByClause orderByClause = new OrderByClause(column);
            
            Assert.AreEqual("[Column1] ASC", sqlClientRenderer.Render(orderByClause));
        }

        [TestMethod]
        public void RenderOrderByClauseWithOrderType()
        {
            Column column = new Column("Column1");
            OrderByClause orderByClause = new OrderByClause(column, OrderType.Descending);
            
            Assert.AreEqual("[Column1] DESC", sqlClientRenderer.Render(orderByClause));
        }
        #endregion

        #region OrderByClauses
        [TestMethod]
        public void CreateOrderByClauses()
        {
            Column column1 = new Column("Column1");
            Column column2 = new Column("Column2");
            OrderByClause orderByClause1 = new OrderByClause(column1);
            OrderByClause orderByClause2 = new OrderByClause(column2);
            OrderByClauses orderByClauses = new OrderByClauses(orderByClause1, orderByClause2);

            Assert.AreEqual(orderByClause1, orderByClauses.LeftClause);
            Assert.AreEqual(orderByClause2, orderByClauses.RightClause);
        }

        [TestMethod]
        public void RenderOrderByClauses()
        {
            Column column1 = new Column("Column1");
            Column column2 = new Column("Column2");
            OrderByClause orderByClause1 = new OrderByClause(column1);
            OrderByClause orderByClause2 = new OrderByClause(column2, OrderType.Descending);
            OrderByClauses orderByClauses = new OrderByClauses(orderByClause1, orderByClause2);
            
            Assert.AreEqual("[Column1] ASC, [Column2] DESC", sqlClientRenderer.Render(orderByClauses));
        }
        #endregion
    }
}