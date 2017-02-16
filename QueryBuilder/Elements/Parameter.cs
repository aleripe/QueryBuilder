using ReturnTrue.QueryBuilder.Renderers;
using System.Data;

namespace ReturnTrue.QueryBuilder.Elements
{
    public class Parameter : IQueryValueExpression
    {
        public string Name { get; private set; }
        public object Value { get; private set; }
        public DbType Type { get; private set; }
        public ParameterDirection Direction { get; private set; }

        public Parameter(string name, object value, DbType type) :
            this(name, value, type, ParameterDirection.Input)
        {
        }

        public Parameter(string name, object value, DbType type, ParameterDirection direction)
        {
            Name = name;
            Value = value;
            Type = type;
            Direction = direction;
        }

        public virtual string Render(IRenderer renderer)
        {
            return renderer.Render(this);
        }
    }
}