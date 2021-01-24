using System.Linq;
using GraphQL.Types;

namespace GraphQLvsRest.IQueryable.Extentions
{
    public static class QueryableExtentions
    {
        public static GraphQL.Builders.FieldBuilder<object, IQueryable<TSource>> CustomField<TGraphType, TSource>(
            this ComplexGraphType<object> graphType,
            string name,
            System.Func<GraphQL.IResolveFieldContext<object>, IQueryable<TSource>> resolve)
            where TSource : class
        {
            var builder = graphType.Field<ObjectGraphType<IQueryable<TSource>>, IQueryable<TSource>>(name);
            builder.Resolve(resolve);
            return builder;
        }
    }
}
