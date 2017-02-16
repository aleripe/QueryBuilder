using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReturnTrue.QueryBuilder.Elements;
using ReturnTrue.QueryBuilder.Renderers;
using System.Data;

namespace ReturnTrue.QueryBuilder.Tests
{
    [TestClass]
    public class ParameterTests
    {
        private SqlClientRenderer sqlClientRenderer;

        [TestInitialize]
        public void Setup()
        {
            sqlClientRenderer = new SqlClientRenderer();
        }

        [TestMethod]
        public void CreateParameter()
        {
            Parameter parameter = new Parameter("Parameter1", 1, DbType.Int32);

            Assert.AreEqual("Parameter1", parameter.Name);
            Assert.AreEqual(DbType.Int32, parameter.Type);
            Assert.AreEqual(1, parameter.Value);
            Assert.AreEqual(ParameterDirection.Input, parameter.Direction);
        }

        [TestMethod]
        public void CreateParameterWithDirection()
        {
            Parameter parameter = new Parameter("Parameter1", 1, DbType.Int32, ParameterDirection.Output);

            Assert.AreEqual("Parameter1", parameter.Name);
            Assert.AreEqual(DbType.Int32, parameter.Type);
            Assert.AreEqual(1, parameter.Value);
            Assert.AreEqual(ParameterDirection.Output, parameter.Direction);
        }

        [TestMethod]
        public void RenderParameter()
        {
            Parameter parameter = new Parameter("Parameter1", 1, DbType.Int32, ParameterDirection.Input);
            
            Assert.AreEqual("@Parameter1", sqlClientRenderer.Render(parameter));
        }
    }
}