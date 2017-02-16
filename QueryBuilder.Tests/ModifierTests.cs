using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReturnTrue.QueryBuilder.Modifiers;
using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Tests
{
    [TestClass]
    public class ModifierTests
    {
        private SqlClientRenderer sqlClientRenderer;

        [TestInitialize]
        public void Setup()
        {
            sqlClientRenderer = new SqlClientRenderer();
        }

        [TestMethod]
        public void RenderDistinctModifier()
        {
            DistinctModifier distinctModifier = new DistinctModifier();
            
            Assert.AreEqual("DISTINCT", sqlClientRenderer.Render(distinctModifier));
        }

        [TestMethod]
        public void RenderNotModifier()
        {
            NotModifier notModifier = new NotModifier();
            
            Assert.AreEqual("NOT", sqlClientRenderer.Render(notModifier));
        }
    }
}