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
        }

        [TestMethod]
        public void RenderColumn()
        {
            Column column = new Column("Column1");

            Assert.AreEqual("[Column1]", sqlClientRenderer.Render(column));
        }
    }
}