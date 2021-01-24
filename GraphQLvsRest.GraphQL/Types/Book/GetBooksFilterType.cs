using GraphQL.Types;
using GraphQLvsRest.Abstractions.Types;

namespace GraphQLvsRest.GraphQL.Types.Book
{
    internal class GetBooksFilterType : InputObjectGraphType<GetBooksFilter>
    {
        public GetBooksFilterType()
        {
            Field(x => x.Author, nullable: true).Description("Filter by template in authors");
            Field(x => x.BookName, nullable: true).Description("Filter by template in books name");
        }
    }
}
