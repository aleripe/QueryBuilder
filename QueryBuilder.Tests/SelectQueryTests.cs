using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReturnTrue.QueryBuilder.Elements;
using ReturnTrue.QueryBuilder.Enums;
using ReturnTrue.QueryBuilder.Renderers;
using ReturnTrue.QueryBuilder.Select;
using ReturnTrue.QueryBuilder.Select.From;

namespace ReturnTrue.QueryBuilder.Tests
{
    [TestClass]
    public class SelectQueryTests
    {
        private SqlClientRenderer sqlClientRenderer;

        private static class UserData
        {
            public static Table Table = Sql.Table("Users");
            public static class Columns
            {
                public static Column Id = Sql.Column("Id", Table);
                public static Column Name = Sql.Column("Name", Table);
                public static Column Surname = Sql.Column("Surname", Table);
                public static Column Age = Sql.Column("Age", Table);
            }
        }

        private static class OrderData
        {
            public static Table Table = Sql.Table("Orders");
            public static class Columns
            {
                public static Column Id = Sql.Column("Id", Table);
                public static Column UserId = Sql.Column("UserId", Table);
                public static Column Amount = Sql.Column("Amount", Table);
            }
        }

        private static class ProductData
        {
            public static Table Table = Sql.Table("Products");
            public static class Columns
            {
                public static Column Id = Sql.Column("Id", Table);
                public static Column OrderId = Sql.Column("OrderId", Table);
                public static Column Name = Sql.Column("Name", Table);
            }
        }

        [TestInitialize]
        public void Setup()
        {
            sqlClientRenderer = new SqlClientRenderer();
        }

        [TestMethod]
        public void RenderEmptySelectQuery()
        {
            SelectQuery selectQuery = new SelectQuery();
            
            Assert.AreEqual("", sqlClientRenderer.Render(selectQuery));
        }

        //[TestMethod]
        //public void RenderSelectQuery()
        //{
        //    SelectQuery selectQuery = Sql.Select()
        //        .Select(UserData.Columns.Name, UserData.Columns.Surname, UserData.Columns.Age.Avg())
        //        .From(UserData.Table)
        //        .Where((UserData.Columns.Name == "Mario" | UserData.Columns.Name == "Paolo") & UserData.Columns.Surname.IsLike("%Rossi%"))
        //        .OrderBy(UserData.Columns.Name, UserData.Columns.Surname)
        //        .GroupBy(UserData.Columns.Name, UserData.Columns.Surname)
        //        .Having(UserData.Columns.Age.Avg() < 22);

        //    Assert.AreEqual("SELECT [Name], [Surname], AVG[[Age]) FROM [Users] WHERE (([Name] = 'Mario' OR [Name] = 'Paolo') AND [Surname] LIKE '%Rossi%') ORDER BY [Name] ASC, [Surname] ASC GROUP BY [Name], [Surname] HAVING AVG([Age]) < 22", sqlClientRenderer.Render(selectQuery));
        //}

        [TestMethod]
        public void RenderJoinQuery()
        {
            SelectQuery selectQuery = Sql.Select()
                .Select(UserData.Columns.Name, UserData.Columns.Surname, OrderData.Columns.Amount)
                .From(Sql.Join(Sql.Join(UserData.Table, OrderData.Table, UserData.Columns.Id == OrderData.Columns.UserId), ProductData.Table, OrderData.Columns.Id == ProductData.Columns.OrderId));

            Assert.AreEqual("SELECT [Users].[Name], [Users].[Surname], [Orders].[Amount] FROM [Users] INNER JOIN [Orders] ON [Users].[Id] = [Orders].[UserId] INNER JOIN [Products] ON [Orders].[Id] = [Products].[OrderId]", sqlClientRenderer.Render(selectQuery));
        }
    }
}