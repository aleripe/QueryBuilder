using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReturnTrue.QueryBuilder.Elements;
using ReturnTrue.QueryBuilder.Renderers;
using System;

namespace ReturnTrue.QueryBuilder.Tests
{
    [TestClass]
    public class LiteralTests
    {
        private SqlClientRenderer sqlClientRenderer;

        [TestInitialize]
        public void Setup()
        {
            sqlClientRenderer = new SqlClientRenderer();
        }

        #region BooleanLiteralValue
        [TestMethod]
        public void CreateBooleanLiteralValue()
        {
            BooleanLiteralValue booleanLiteralValue = new BooleanLiteralValue(true);

            Assert.AreEqual(true, booleanLiteralValue.Literal);
        }

        [TestMethod]
        public void RenderBooleanLiteralValue()
        {
            BooleanLiteralValue booleanLiteralValue = new BooleanLiteralValue(true);

            Assert.AreEqual("1", sqlClientRenderer.Render(booleanLiteralValue));
        }
        #endregion

        #region IntegerLiteralValue
        [TestMethod]
        public void CreateIntegerLiteralValue()
        {
            IntegerLiteralValue integerLiteralValue = new IntegerLiteralValue(1);

            Assert.AreEqual(1, integerLiteralValue.Literal);
        }

        [TestMethod]
        public void RenderIntegerLiteralValue()
        {
            IntegerLiteralValue integerLiteralValue = new IntegerLiteralValue(1);

            Assert.AreEqual("1", sqlClientRenderer.Render(integerLiteralValue));
        }
        #endregion

        #region DecimalLiteralValue
        [TestMethod]
        public void CreateDecimalLiteralValue()
        {
            DecimalLiteralValue decimalLiteralValue = new DecimalLiteralValue(1.5);

            Assert.AreEqual(1.5, decimalLiteralValue.Literal);
        }

        [TestMethod]
        public void RenderDecimalLiteralValue()
        {
            DecimalLiteralValue decimalLiteralValue = new DecimalLiteralValue(1.5);

            Assert.AreEqual("1.5", sqlClientRenderer.Render(decimalLiteralValue));
        }
        #endregion

        #region DateTimeLiteralValue
        [TestMethod]
        public void CreateDateTimeLiteralValue()
        {
            DateTime dateTime = new DateTime(2010, 1, 1);
            DateTimeLiteralValue dateTimeLiteralValue = new DateTimeLiteralValue(dateTime);

            Assert.AreEqual(dateTime, dateTimeLiteralValue.Literal);
        }

        [TestMethod]
        public void RenderDateTimeLiteralValue()
        {
            DateTime dateTime = new DateTime(2010, 1, 1);
            DateTimeLiteralValue dateTimeLiteralValue = new DateTimeLiteralValue(dateTime);

            Assert.AreEqual("CONVERT(datetime, '20100101')", sqlClientRenderer.Render(dateTimeLiteralValue));
        }
        #endregion

        #region StringLiteralValue
        [TestMethod]
        public void CreateStringLiteralValue()
        {
            StringLiteralValue stringLiteralValue = new StringLiteralValue("Value");

            Assert.AreEqual("Value", stringLiteralValue.Literal);
        }

        [TestMethod]
        public void RenderStringLiteralValue()
        {
            StringLiteralValue stringLiteralValue = new StringLiteralValue("Value");

            Assert.AreEqual("'Value'", sqlClientRenderer.Render(stringLiteralValue));
        }
        #endregion
    }
}