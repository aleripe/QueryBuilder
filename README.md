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

## Components

### Columns

```
Column column = new Column("Column1");
Column column = Sql.Column("Column1"); // Shortcut
```

### Functions

```
LowerFunction lowerFunction = new LowerFunction(column);
LowerFunction lowerFunction = Sql.Lower(column); // Shortcut

UpperFunction upperFunction = new UpperFunction(column);
UpperFunction upperFunction = Sql.Upper(column); // Shortcut

AggregateFunction aggregateFunction = new AggregateFunction(FunctionType.Count, column);
AggregateFunction aggregateFunction = Sql.Count(column); // Shortcut

DatePartFunction datePartFunction = new DatePartFunction(DatePartType.Year, column);
DatePartFunction datePartFunction = Sql.Year(column); // Shortcut
```

### Literal values

```
BooleanLiteralValue booleanLiteralValue = new BooleanLiteralValue(true);
BooleanLiteralValue booleanLiteralValue = Sql.Boolean(true); // Shortcut
BooleanLiteralValue booleanLiteralValue = true; // Shortcut

IntegerLiteralValue integerLiteralValue = new IntegerLiteralValue(1);
IntegerLiteralValue integerLiteralValue = Sql.Integer(1); // Shortcut
IntegerLiteralValue integerLiteralValue = 1; // Shortcut

DecimalLiteralValue decimalLiteralValue = new DecimalLiteralValue(1.5);
DecimalLiteralValue decimalLiteralValue = Sql.Decimal(1.5); // Shortcut
DecimalLiteralValue decimalLiteralValue = 1.5; // Shortcut

DateTimeLiteralValue dateTimeLiteralValue = new DateTimeLiteralValue(new DateTime(2010, 1, 1));
DateTimeLiteralValue dateTimeLiteralValue = Sql.DateTime(new DateTime(2010, 1, 1)); // Shortcut
DateTimeLiteralValue dateTimeLiteralValue = new DateTime(2010, 1, 1); // Shortcut

StringLiteralValue stringLiteralValue = new StringLiteralValue("Value");
StringLiteralValue stringLiteralValue = Sql.String("Value"); // Shortcut
StringLiteralValue stringLiteralValue = "Value"; // Shortcut

IntegerLiteralArray integerLiteralArray = new IntegerLiteralArray(new int[] { 1, 2, 3 });
IntegerLiteralArray integerLiteralArray = Sql.Integer(new int[] { 1, 2, 3 }); // Shortcut

StringLiteralArray stringLiteralArray = new StringLiteralArray(new string[] { "One", "Two", "Three" });
StringLiteralArray stringLiteralArray = Sql.String(new string[] { "One", "Two", "Three" }); // Shortcut
```

### Predicates

```
ComparisonPredicate comparisonPredicate = new ComparisonPredicate(column, PredicateComparisonType.Equals, stringLiteralValue);
ComparisonPredicate comparisonPredicate = Sql.Equals(column, stringLiteralValue); // Shortcut
ComparisonPredicate comparisonPredicate = (column == stringLiteralValue); // Shortcut

MembershipPredicate membershipPredicate = new MembershipPredicate(column, stringLiteralValue);
MembershipPredicate membershipPredicate = Sql.In(column, stringLiteralArray); // Shortcut
MembershipPredicate membershipPredicate = column.IsIn(stringLiteralArray); // Shortcut

PatternPredicate patternPredicate = new PatternPredicate(column, stringLiteralValue);
PatternPredicate patternPredicate = Sql.Like(column, stringLiteralValue); // Shortcut
PatternPredicate patternPredicate = column.IsLike(stringLiteralValue); // Shortcut

RangePredicate rangePredicate = new RangePredicate(column, integerLiteralValue1, integerLiteralValue2);
RangePredicate rangePredicate = Sql.InRange(column, integerLiteralValue1, integerLiteralValue2); // Shortcut);
RangePredicate rangePredicate = column.IsInRange(integerLiteralValue1, integerLiteralValue2); // Shortcut

NullPredicate nullPredicate = new NullPredicate(column);
NullPredicate nullPredicate = Sql.Null(column); // Shortcut
PatternPredicate patternPredicate = column.IsNull(); // Shortcut
```

### Modifiers

``` 
DistinctModifier distinctModifier = new DistinctModifier();
DistinctModifier distinctModifier = Sql.Distinct();

NotModifier notModifier = new NotModifier();
NotModifier notModifier = Sql.Not();
```

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

// Renders the following output: "SELECT [Name], [Surname], AVG[[Age]) FROM [Users] WHERE (([Name] = @1 OR [Name] = @2) AND [Surname] LIKE @3) ORDER BY [Name] ASC, [Surname] ASC GROUP BY [Name], [Surname] HAVING AVG([Age]) < @4"
SqlClientRenderer renderer = new SqlClientRenderer();
renderer.ReplaceLiteralsWithParameters = true; // Replaces literals with SqlParameters to avoid SqlInjection
String output = renderer.Render(selectQuery);
```
  
Please note that QueryBuilder .NET renderers **don't** enforce any kind of validation on the input query. You **must** provide a valid query or catch any exception when executed on a database system.

## License

This project is licensed under the terms of the MIT license.
