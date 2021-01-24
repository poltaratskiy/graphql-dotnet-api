using GraphQL.Types;
using GraphQLvsRest.GraphQL.Types.Author;
using GraphQLvsRest.GraphQL.Types.Book;

namespace GraphQLvsRest.GraphQL
{
    public class Query : ObjectGraphType
    {
        public Query()
        {
            Field<NonNullGraphType<AuthorQuery>, object>("authors")
                .Resolve(_ => new { });

            Field<NonNullGraphType<BookQuery>, object>("books")
                .Resolve(_ => new { });
        }
    }
}
