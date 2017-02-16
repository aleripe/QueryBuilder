using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReturnTrue.QueryBuilder.Elements;
using ReturnTrue.QueryBuilder.Enums;
using ReturnTrue.QueryBuilder.Modifiers;
using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Tests
{
    [TestClass]
    public class PredicateTests
    {
        private SqlClientRenderer sqlClientRenderer;

        [TestInitialize]
        public void Setup()
        {
            sqlClientRenderer = new SqlClientRenderer();
        }

        #region ComparisonPredicate
        [TestMethod]
        public void CreateComparisonPredicate()
        {
            Column column = new Column("Column1");
            StringLiteralValue stringLiteralValue = new StringLiteralValue("Value1");
            ComparisonPredicate comparisonPredicate = new ComparisonPredicate(column, ComparisonPredicateType.Equals, stringLiteralValue);

            Assert.AreEqual(column, comparisonPredicate.LeftExpression);
            Assert.AreEqual(ComparisonPredicateType.Equals, comparisonPredicate.ComparisonType);
            Assert.AreEqual(stringLiteralValue, comparisonPredicate.RightExpression);
        }

        [TestMethod]
        public void RenderComparisonPredicate()
        {
            Column column = new Column("Column1");
            StringLiteralValue stringLiteralValue = new StringLiteralValue("Value1");
            ComparisonPredicate comparisonPredicate = new ComparisonPredicate(column, ComparisonPredicateType.Equals, stringLiteralValue);
            
            Assert.AreEqual("[Column1] = 'Value1'", sqlClientRenderer.Render(comparisonPredicate));
        }
        #endregion

        #region MembershipPredicate
        [TestMethod]
        public void CreateMembershipPredicate()
        {
            Column column = new Column("Column1");
            StringLiteralValue stringLiteralValue = new StringLiteralValue("Value1");
            MembershipPredicate membershipPredicate = new MembershipPredicate(column, stringLiteralValue);

            Assert.AreEqual(column, membershipPredicate.Expression);
            Assert.IsNull(membershipPredicate.NotModifier);
            Assert.AreEqual(stringLiteralValue, membershipPredicate.Membership);
        }

        [TestMethod]
        public void CreateMembershipPredicateWithNotModifier()
        {
            Column column = new Column("Column1");
            NotModifier notModifier = new NotModifier();
            StringLiteralValue stringLiteralValue = new StringLiteralValue("Value1");
            MembershipPredicate membershipPredicate = new MembershipPredicate(column, notModifier, stringLiteralValue);

            Assert.AreEqual(column, membershipPredicate.Expression);
            Assert.AreEqual(notModifier, membershipPredicate.NotModifier);
            Assert.AreEqual(stringLiteralValue, membershipPredicate.Membership);
        }

        [TestMethod]
        public void RenderMembershipPredicate()
        {
            Column column = new Column("Column1");
            StringLiteralValue stringLiteralValue = new StringLiteralValue("Value1");
            MembershipPredicate membershipPredicate = new MembershipPredicate(column, stringLiteralValue);

            Assert.AreEqual("[Column1] IN ('Value1')", sqlClientRenderer.Render(membershipPredicate));
        }

        [TestMethod]
        public void RenderMembershipPredicateWithNotModifier()
        {
            Column column = new Column("Column1");
            NotModifier notModifier = new NotModifier();
            StringLiteralValue stringLiteralValue = new StringLiteralValue("Value1");
            MembershipPredicate membershipPredicate = new MembershipPredicate(column, notModifier, stringLiteralValue);

            Assert.AreEqual("[Column1] NOT IN ('Value1')", sqlClientRenderer.Render(membershipPredicate));
        }
        #endregion

        #region PatternPredicate
        [TestMethod]
        public void CreatePatternPredicate()
        {
            Column column = new Column("Column1");
            StringLiteralValue stringLiteralValue = new StringLiteralValue("Value1");
            PatternPredicate patternPredicate = new PatternPredicate(column, stringLiteralValue);

            Assert.AreEqual(column, patternPredicate.Expression);
            Assert.IsNull(patternPredicate.NotModifier);
            Assert.AreEqual(stringLiteralValue, patternPredicate.Pattern);
        }

        [TestMethod]
        public void CreatePatternPredicateWithNotModifier()
        {
            Column column = new Column("Column1");
            NotModifier notModifier = new NotModifier();
            StringLiteralValue stringLiteralValue = new StringLiteralValue("Value1");
            PatternPredicate patternPredicate = new PatternPredicate(column, notModifier, stringLiteralValue);

            Assert.AreEqual(column, patternPredicate.Expression);
            Assert.AreEqual(notModifier, patternPredicate.NotModifier);
            Assert.AreEqual(stringLiteralValue, patternPredicate.Pattern);
        }

        [TestMethod]
        public void RenderPatternPredicate()
        {
            Column column = new Column("Column1");
            StringLiteralValue stringLiteralValue = new StringLiteralValue("%Value1%");
            PatternPredicate patternPredicate = new PatternPredicate(column, stringLiteralValue);

            Assert.AreEqual("[Column1] LIKE '%Value1%'", sqlClientRenderer.Render(patternPredicate));
        }

        [TestMethod]
        public void RenderPatternPredicateWithNotModifier()
        {
            Column column = new Column("Column1");
            NotModifier notModifier = new NotModifier();
            StringLiteralValue stringLiteralValue = new StringLiteralValue("%Value1%");
            PatternPredicate patternPredicate = new PatternPredicate(column, notModifier, stringLiteralValue);

            Assert.AreEqual("[Column1] NOT LIKE '%Value1%'", sqlClientRenderer.Render(patternPredicate));
        }
        #endregion

        #region RangePredicate
        [TestMethod]
        public void CreateRangePredicate()
        {
            Column column = new Column("Column1");
            IntegerLiteralValue stringLiteralValue1 = new IntegerLiteralValue(1);
            IntegerLiteralValue stringLiteralValue2 = new IntegerLiteralValue(3);
            RangePredicate rangePredicate = new RangePredicate(column, stringLiteralValue1, stringLiteralValue2);

            Assert.AreEqual(column, rangePredicate.LeftExpression);
            Assert.IsNull(rangePredicate.NotModifier);
            Assert.AreEqual(stringLiteralValue1, rangePredicate.MiddleExpression);
            Assert.AreEqual(stringLiteralValue2, rangePredicate.RightExpression);
        }

        [TestMethod]
        public void CreateRangePredicateWithNotModifier()
        {
            Column column = new Column("Column1");
            NotModifier notModifier = new NotModifier();
            IntegerLiteralValue stringLiteralValue1 = new IntegerLiteralValue(1);
            IntegerLiteralValue stringLiteralValue2 = new IntegerLiteralValue(3);
            RangePredicate rangePredicate = new RangePredicate(column, notModifier, stringLiteralValue1, stringLiteralValue2);

            Assert.AreEqual(column, rangePredicate.LeftExpression);
            Assert.AreEqual(notModifier, rangePredicate.NotModifier);
            Assert.AreEqual(stringLiteralValue1, rangePredicate.MiddleExpression);
            Assert.AreEqual(stringLiteralValue2, rangePredicate.RightExpression);
        }

        [TestMethod]
        public void RenderRangePredicate()
        {
            Column column = new Column("Column1");
            IntegerLiteralValue stringLiteralValue1 = new IntegerLiteralValue(1);
            IntegerLiteralValue stringLiteralValue2 = new IntegerLiteralValue(3);
            RangePredicate rangePredicate = new RangePredicate(column, stringLiteralValue1, stringLiteralValue2);

            Assert.AreEqual("[Column1] BETWEEN 1 AND 3", sqlClientRenderer.Render(rangePredicate));
        }

        [TestMethod]
        public void RenderRangePredicateWithNotModifier()
        {
            Column column = new Column("Column1");
            NotModifier notModifier = new NotModifier();
            IntegerLiteralValue stringLiteralValue1 = new IntegerLiteralValue(1);
            IntegerLiteralValue stringLiteralValue2 = new IntegerLiteralValue(3);
            RangePredicate rangePredicate = new RangePredicate(column, notModifier, stringLiteralValue1, stringLiteralValue2);


            Assert.AreEqual("[Column1] NOT BETWEEN 1 AND 3", sqlClientRenderer.Render(rangePredicate));
        }
        #endregion

        #region NullPredicate
        [TestMethod]
        public void CreateNullPredicate()
        {
            Column column = new Column("Column1");
            NullPredicate nullPredicate = new NullPredicate(column);

            Assert.AreEqual(column, nullPredicate.Expression);
            Assert.IsNull(nullPredicate.NotModifier);
        }

        [TestMethod]
        public void CreateNullPredicateWithNotModifier()
        {
            Column column = new Column("Column1");
            NotModifier notModifier = new NotModifier();
            NullPredicate nullPredicate = new NullPredicate(column, notModifier);

            Assert.AreEqual(nullPredicate.Expression, column);
            Assert.AreEqual(notModifier, nullPredicate.NotModifier);
        }

        [TestMethod]
        public void RenderNullPredicate()
        {
            Column column = new Column("Column1");
            NullPredicate nullPredicate = new NullPredicate(column);

            Assert.AreEqual("[Column1] IS NULL", sqlClientRenderer.Render(nullPredicate));
        }

        [TestMethod]
        public void RenderNullPredicateWithNotModifier()
        {
            Column column = new Column("Column1");
            NotModifier notModifier = new NotModifier();
            NullPredicate nullPredicate = new NullPredicate(column, notModifier);

            Assert.AreEqual("[Column1] IS NOT NULL", sqlClientRenderer.Render(nullPredicate));
        } 
        #endregion
    }
}