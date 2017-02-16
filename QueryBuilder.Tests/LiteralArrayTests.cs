using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReturnTrue.QueryBuilder.Elements;
using ReturnTrue.QueryBuilder.Renderers;
using System.Collections.Generic;

namespace ReturnTrue.QueryBuilder.Tests
{
    [TestClass]
    public class LiteralArrayTests
    {
        private SqlClientRenderer sqlClientRenderer;

        [TestInitialize]
        public void Setup()
        {
            sqlClientRenderer = new SqlClientRenderer();
        }

        #region IntegerLiteralArray
        [TestMethod]
        public void CreateIntegerLiteralArray()
        {
            IEnumerable<int> array = new int[] { 1, 2, 3 };
            IntegerLiteralArray integerLiteralArray = new IntegerLiteralArray(array);

            Assert.AreEqual(array, integerLiteralArray.Array);
        }

        [TestMethod]
        public void RenderIntegerLiteralArray()
        {
            IEnumerable<int> array = new int[] { 1, 2, 3 };
            IntegerLiteralArray integerLiteralArray = new IntegerLiteralArray(array);

            Assert.AreEqual("1,2,3", sqlClientRenderer.Render(integerLiteralArray));
        }
        #endregion

        #region StringLiteralArray
        [TestMethod]
        public void CreateStringLiteralArray()
        {
            IEnumerable<string> array = new string[] { "One", "Two", "Three" };
            StringLiteralArray stringLiteralArray = new StringLiteralArray(array);

            Assert.AreEqual(array, stringLiteralArray.Array);
        }

        [TestMethod]
        public void RenderStringLiteralArray()
        {
            IEnumerable<string> array = new string[] { "One", "Two", "Three" };
            StringLiteralArray stringLiteralArray = new StringLiteralArray(array);

            Assert.AreEqual("'One','Two','Three'", sqlClientRenderer.Render(stringLiteralArray));
        }
        #endregion
    }
}