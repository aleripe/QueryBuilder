using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReturnTrue.QueryBuilder.Elements;
using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Tests
{
    [TestClass]
    public class TableTests
    {
        private SqlClientRenderer sqlClientRenderer;

        [TestInitialize]
        public void Setup()
        {
            sqlClientRenderer = new SqlClientRenderer();
        }

        [TestMethod]
        public void CreateTable()
        {
            Table table = new Table("Table1");

            Assert.AreEqual("Table1", table.Name);
        }

        [TestMethod]
        public void RenderTable()
        {
            Table table = new Table("Table1");

            Assert.AreEqual("[Table1]", sqlClientRenderer.Render(table));
        }
    }
}