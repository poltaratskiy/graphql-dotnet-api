using GraphQL.Types;
using System;

namespace GraphQLvsRest.IQueryable.GraphQl
{
    public class GraphQlSchema : Schema
    {
        public GraphQlSchema(Query query, IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            Query = query;
        }
    }
}
