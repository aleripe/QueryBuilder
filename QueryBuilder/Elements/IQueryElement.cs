using ReturnTrue.QueryBuilder.Renderers;

namespace ReturnTrue.QueryBuilder.Elements
{
    public interface IQueryElement
    {
        string Render(IRenderer renderer);
    }
}