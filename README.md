# QueryBuilder .NET

*QueryBuilder .NET* is an Object Oriented QueryBuilder written in C#.

It allows to build complex queries by adding clauses to a fluent interface, using an easy and convenient syntax.

QueryBuilder also outputs this queries as strings, by using renderers. It now ships with a default *SqlClientRenderer* to be used with SqlServer, but other renderers will be added in the future.

## Main features

- Fluent interface
- Convenient syntax
- Supports all clauses
- Functions and predicates
- Renderer for SqlServer

## Sample query

```
// It is not mandatory to create such a structure, but it helps with defining queries
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

// Builds a query using the fluent interface
SelectQuery selectQuery = Sql.Select()
    .Select(UserData.Columns.Name, UserData.Columns.Surname, UserData.Columns.Age.Avg())
    .From(UserData.Table)
    .Where((UserData.Columns.Name == "Mario" | UserData.Columns.Name == "Paolo") & UserData.Columns.Surname.IsLike("%Rossi%"))
    .OrderBy(UserData.Columns.Name, UserData.Columns.Surname)
    .GroupBy(UserData.Columns.Name, UserData.Columns.Surname)
    .Having(UserData.Columns.Age.Avg() < 22);
    
// Renders the following output: "SELECT [Name], [Surname], AVG[[Age]) FROM [Users] WHERE (([Name] = 'Mario' OR [Name] = 'Paolo') AND [Surname] LIKE '%Rossi%') ORDER BY [Name] ASC, [Surname] ASC GROUP BY [Name], [Surname] HAVING AVG([Age]) < 22"
SqlClientRenderer renderer = new SqlClientRenderer();
String output = renderer.Render(selectQuery);
  ```
  
Please note that QueryBuilder .NET renderers **don't** enforce any kind of validation on the input query. You **must** provide a valid query or catch any exception when executed on a database system.

## License

This project is licensed under the terms of the MIT license.
