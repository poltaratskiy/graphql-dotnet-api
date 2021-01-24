using GraphQL.Types;
using GraphQLvsRest.GraphQL.Types.Author;
using GraphQLvsRest.GraphQL.Types.Book;

namespace GraphQLvsRest.GraphQL
{
    public class Mutation : ObjectGraphType
    {
        public Mutation()
        {
            Field<NonNullGraphType<AuthorMutation>, object>("authors")
                .Resolve(_ => new { });

            Field<NonNullGraphType<BookMutation>, object>("books")
                .Resolve(_ => new { });
        }
    }
}
