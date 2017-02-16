using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReturnTrue.QueryBuilder.Elements;
using ReturnTrue.QueryBuilder.Enums;
using ReturnTrue.QueryBuilder.Modifiers;
using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Tests
{
    [TestClass]
    public class FunctionTests
    {
        private SqlClientRenderer sqlClientRenderer;

        [TestInitialize]
        public void Setup()
        {
            sqlClientRenderer = new SqlClientRenderer();
        }

        #region LowerFunction
        [TestMethod]
        public void CreateLowerFunction()
        {
            Column column = new Column("Column1");
            LowerFunction lowerFunction = new LowerFunction(column);

            Assert.AreEqual(column, lowerFunction.Expression);
        }

        [TestMethod]
        public void RenderLowerFunction()
        {
            Column column = new Column("Column1");
            LowerFunction lowerFunction = new LowerFunction(column);

            Assert.AreEqual("LOWER([Column1])", sqlClientRenderer.Render(lowerFunction));
        }
        #endregion

        #region UpperFunction
        [TestMethod]
        public void CreateUpperFunction()
        {
            Column column = new Column("Column1");
            UpperFunction upperFunction = new UpperFunction(column);

            Assert.AreEqual(column, upperFunction.Expression);
        }

        [TestMethod]
        public void RenderUpperFunction()
        {
            Column column = new Column("Column1");
            UpperFunction upperFunction = new UpperFunction(column);

            Assert.AreEqual("UPPER([Column1])", sqlClientRenderer.Render(upperFunction));
        }
        #endregion

        #region AggregateFunction
        [TestMethod]
        public void CreateAggregateFunction()
        {
            Column column = new Column("Column1");
            AggregateFunction aggregateFunction = new AggregateFunction(FunctionType.Count, column);

            Assert.AreEqual(FunctionType.Count, aggregateFunction.FunctionType);
            Assert.IsNull(aggregateFunction.DistinctModifier);
            Assert.AreEqual(column, aggregateFunction.Expression);
        }

        [TestMethod]
        public void CreateAggregateFunctionWithDistinctModifier()
        {
            Column column = new Column("Column1");
            DistinctModifier distinctModifier = new DistinctModifier();
            AggregateFunction aggregateFunction = new AggregateFunction(FunctionType.Count, distinctModifier, column);

            Assert.AreEqual(FunctionType.Count, aggregateFunction.FunctionType);
            Assert.AreEqual(distinctModifier, aggregateFunction.DistinctModifier);
            Assert.AreEqual(column, aggregateFunction.Expression);
        }

        [TestMethod]
        public void RenderAggregateFunction()
        {
            Column column = new Column("Column1");
            AggregateFunction aggregateFunction = new AggregateFunction(FunctionType.Count, column);

            Assert.AreEqual("COUNT([Column1])", sqlClientRenderer.Render(aggregateFunction));
        }

        [TestMethod]
        public void RenderAggregateFunctionWidthDistinctModifier()
        {
            Column column = new Column("Column1");
            DistinctModifier distinctModifier = new DistinctModifier();
            AggregateFunction aggregateFunction = new AggregateFunction(FunctionType.Count, distinctModifier, column);

            Assert.AreEqual("COUNT(DISTINCT [Column1])", sqlClientRenderer.Render(aggregateFunction));
        }
        #endregion

        #region DatePartFunction
        [TestMethod]
        public void CreateDatePartFunction()
        {
            Column column = new Column("Column1");
            DatePartFunction datePartFunction = new DatePartFunction(DatePartType.Year, column);

            Assert.AreEqual(DatePartType.Year, datePartFunction.PartType);
            Assert.AreEqual(column, datePartFunction.Expression);
        }

        [TestMethod]
        public void RenderDatePartFunction()
        {
            Column column = new Column("Column1");
            DatePartFunction datePartFunction = new DatePartFunction(DatePartType.Year, column);
            
            Assert.AreEqual("DATEPART(year,[Column1])", sqlClientRenderer.Render(datePartFunction));
        }
        #endregion
    }
}