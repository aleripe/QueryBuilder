using ReturnTrue.QueryBuilder.Elements;
using ReturnTrue.QueryBuilder.Select;
using ReturnTrue.QueryBuilder.Select.Where;
using ReturnTrue.QueryBuilder.Enums;
using ReturnTrue.QueryBuilder.Select.Select;
using System;

namespace ReturnTrue.QueryBuilder
{
    public static class Sql
    {
        public static SelectQuery Select()
        {
            return new SelectQuery();
        }

        public static Column Column(string name)
        {
            return new Column(name);
        }

        public static Table Table(string name)
        {
            return new Table(name);
        }
    }
}