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
            public static Table Table = Sql.Table("Table1");
            public static class Columns
            {
                public static Column Name = Sql.Column("Column1");
                public static Column Surname = Sql.Column("Column2");
                public static Column Age = Sql.Column("Column3");
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
                .Select(UserData.Columns.Name & UserData.Columns.Surname)
                .From(UserData.Table, "Users")
                .Where((UserData.Columns.Name == "Mario" | UserData.Columns.Name == "Paolo") & UserData.Columns.Surname.IsLike("%Rossi%"))
                .OrderBy(UserData.Columns.Name, UserData.Columns.Surname)
                .GroupBy(UserData.Columns.Name)
                .Having(UserData.Columns.Age.Avg() < 22);

            Assert.AreEqual("SELECT [Column1], [Column2] FROM [Table1] Users WHERE (([Column1] = 'Mario' OR [Column1] = 'Paolo') AND [Column2] LIKE '%Rossi%') ORDER BY [Column1] ASC, [Column2] ASC GROUP BY [Column1] HAVING AVG([Column3]) < 22", sqlClientRenderer.Render(selectQuery));
        }
    }
} 