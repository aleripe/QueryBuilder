using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReturnTrue.QueryBuilder.Elements;
using ReturnTrue.QueryBuilder.Enums;
using ReturnTrue.QueryBuilder.Renderers;
using ReturnTrue.QueryBuilder.Select;

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
                public static Column Name = Sql.Column("Name");
                public static Column Surname = Sql.Column("Surname");
                public static Column Age = Sql.Column("Age");
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

        [TestMethod]
        public void RenderSelectQuery()
        {
            SelectQuery selectQuery = Sql.Select()
                .Select(UserData.Columns.Name, UserData.Columns.Surname, UserData.Columns.Age.Avg())
                .From(UserData.Table)
                .Where((UserData.Columns.Name == "Mario" | UserData.Columns.Name == "Paolo") & UserData.Columns.Surname.IsLike("%Rossi%"))
                .OrderBy(UserData.Columns.Name, UserData.Columns.Surname)
                .GroupBy(UserData.Columns.Name, UserData.Columns.Surname)
                .Having(UserData.Columns.Age.Avg() < 22);

            Assert.AreEqual("SELECT [Name], [Surname], AVG[[Age]) FROM [Users] WHERE (([Name] = 'Mario' OR [Name] = 'Paolo') AND [Surname] LIKE '%Rossi%') ORDER BY [Name] ASC, [Surname] ASC GROUP BY [Name], [Surname] HAVING AVG([Age]) < 22", sqlClientRenderer.Render(selectQuery));
        }
    }
} 