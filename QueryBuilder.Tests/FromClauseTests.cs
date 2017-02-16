using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReturnTrue.QueryBuilder.Elements;
using ReturnTrue.QueryBuilder.Renderers;
using ReturnTrue.QueryBuilder.Select;
using ReturnTrue.QueryBuilder.Select.From;
using ReturnTrue.QueryBuilder.Select.Select;

namespace ReturnTrue.QueryBuilder.Tests
{
    [TestClass]
    public class FromClauseTests
    {
        private SqlClientRenderer sqlClientRenderer;

        [TestInitialize]
        public void Setup()
        {
            sqlClientRenderer = new SqlClientRenderer();
        }

        #region TableFromClause
        [TestMethod]
        public void CreateTableFromClause()
        {
            Table table = new Table("Table1");
            TableFromClause tableFromClause = new TableFromClause(table);

            Assert.AreEqual(table, tableFromClause.Table);
            Assert.IsNull(tableFromClause.Alias);
        }

        [TestMethod]
        public void CreateTableFromClauseWithAlias()
        {
            Table table = new Table("Table1");
            TableFromClause tableFromClause = new TableFromClause(table, "Table1Alias");

            Assert.AreEqual(table, tableFromClause.Table);
            Assert.AreEqual("Table1Alias", tableFromClause.Alias);
        }

        [TestMethod]
        public void AddTableFromClauseToSelectQuery()
        {
            SelectQuery selectQuery = new SelectQuery();

            Table table = new Table("Table1");
            TableFromClause tableFromClause = new TableFromClause(table);
            selectQuery.From(tableFromClause);

            Assert.AreEqual(tableFromClause, selectQuery.FromClause);
        }

        [TestMethod]
        public void RenderTableFromClause()
        {
            Table table = new Table("Table1");
            TableFromClause tableFromClause = new TableFromClause(table);
            
            Assert.AreEqual("[Table1]", sqlClientRenderer.Render(tableFromClause));
        }

        [TestMethod]
        public void RenderTableFromClauseWithAlias()
        {
            Table table = new Table("Table1");
            TableFromClause tableFromClause = new TableFromClause(table, "Table1Alias");
            
            Assert.AreEqual("[Table1] Table1Alias", sqlClientRenderer.Render(tableFromClause));
        }
        #endregion

        #region QueryFromClause
        [TestMethod]
        public void AddQueryFromClause()
        {
            SelectQuery query = new SelectQuery();
            query.Select(new SelectClause(new Column("Column1")));
            query.From(new TableFromClause(new Table("Table1")));
            QueryFromClause queryFromClause = new QueryFromClause(query);

            Assert.AreEqual(query, queryFromClause.Query);
            Assert.IsNull(queryFromClause.Alias);
        }

        [TestMethod]
        public void AddQueryFromClauseWithAlias()
        {
            SelectQuery query = new SelectQuery();
            query.Select(new SelectClause(new Column("Column1")));
            query.From(new TableFromClause(new Table("Table1")));
            QueryFromClause queryFromClause = new QueryFromClause(query, "Query1Alias");

            Assert.AreEqual(query, queryFromClause.Query);
            Assert.AreEqual("Query1Alias", queryFromClause.Alias);
        }

        [TestMethod]
        public void RenderQueryFromClause()
        {
            SelectQuery query = new SelectQuery();
            query.Select(new SelectClause(new Column("Column1")));
            query.From(new TableFromClause(new Table("Table1")));
            QueryFromClause queryFromClause = new QueryFromClause(query);
            
            Assert.AreEqual("(SELECT [Column1] FROM [Table1])", sqlClientRenderer.Render(queryFromClause));
        }

        [TestMethod]
        public void RenderQueryFromClauseWithAlias()
        {
            SelectQuery query = new SelectQuery();
            query.Select(new SelectClause(new Column("Column1")));
            query.From(new TableFromClause(new Table("Table1")));
            QueryFromClause queryFromClause = new QueryFromClause(query, "Query1Alias");
            
            Assert.AreEqual("(SELECT [Column1] FROM [Table1]) Query1Alias", sqlClientRenderer.Render(queryFromClause));
        }
        #endregion

        #region SelectClauses
        [TestMethod]
        public void CreateFromClauses()
        {
            Table table1 = new Table("Table1");
            Table table2 = new Table("Table2");
            TableFromClause fromClause1 = new TableFromClause(table1);
            TableFromClause fromClause2 = new TableFromClause(table2);
            FromClauses fromClauses = new FromClauses(fromClause1, fromClause2);

            Assert.AreEqual(fromClause1, fromClauses.LeftClause);
            Assert.AreEqual(fromClause2, fromClauses.RightClause);
        }

        [TestMethod]
        public void AddFromClausesToSelectQuery()
        {
            SelectQuery selectQuery = new SelectQuery();

            Table table1 = new Table("Table1");
            Table table2 = new Table("Table2");
            TableFromClause fromClause1 = new TableFromClause(table1);
            TableFromClause fromClause2 = new TableFromClause(table2);
            selectQuery.From(fromClause1);
            selectQuery.From(fromClause2);

            Assert.IsTrue(selectQuery.FromClause is FromClauses);
        }

        [TestMethod]
        public void RenderFromClauses()
        {
            Table table1 = new Table("Table1");
            Table table2 = new Table("Table2");
            TableFromClause fromClause1 = new TableFromClause(table1);
            TableFromClause fromClause2 = new TableFromClause(table2);
            FromClauses fromClauses = new FromClauses(fromClause1, fromClause2);
            
            Assert.AreEqual("[Table1], [Table2]", sqlClientRenderer.Render(fromClauses));
        }
        #endregion
    }
}