using GraphQL.Types;
using System;

namespace GraphQLvsRest.GraphQL
{
    public class GraphQlSchema : Schema
    {
        public GraphQlSchema(Query query, Mutation mutation, IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            Query = query;
            Mutation = mutation;
        }
    }
}
