using GraphQL.Types;
using GraphQLvsRest.Abstractions.Types;

namespace GraphQLvsRest.GraphQL.Types.Book
{
    internal class AddBookRequestType : InputObjectGraphType<AddBookRequest>
    {
        public AddBookRequestType()
        {
            Field(x => x.AuthorId).Description("Author's identifier");
            Field(x => x.Name).Description("Name of the book");
            Field(x => x.Year, nullable: true).Description("Year when book was written").DefaultValue(null);
        }
    }
}
