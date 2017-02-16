using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReturnTrue.QueryBuilder.Elements;
using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Tests
{
    [TestClass]
    public class ColumnTests
    {
        private SqlClientRenderer sqlClientRenderer;

        [TestInitialize]
        public void Setup()
        {
            sqlClientRenderer = new SqlClientRenderer();
        }

        [TestMethod]
        public void CreateColumn()
        {
            Column column = new Column("Column1");

            Assert.AreEqual("Column1", column.Name);
            Assert.IsNull(column.Table);
        }

        [TestMethod]
        public void CreateColumnWithTable()
        {
            Table table = new Table("Table1");
            Column column = new Column("Column1", table);

            Assert.AreEqual("Column1", column.Name);
            Assert.AreEqual(table, column.Table);
        }

        [TestMethod]
        public void RenderColumn()
        {
            Column column = new Column("Column1");

            Assert.AreEqual("[Column1]", sqlClientRenderer.Render(column));
        }

        [TestMethod]
        public void RenderColumnWithTable()
        {
            Table table = new Table("Table1");
            Column column = new Column("Column1", table);

            Assert.AreEqual("[Table1].[Column1]", sqlClientRenderer.Render(column));
        }
    }
}