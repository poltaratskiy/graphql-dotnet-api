using GraphQLvsRest.Abstractions.Types;
using GraphQL.Types;

namespace GraphQLvsRest.GraphQL.Types.Author
{
    internal class AddAuthorRequestType : InputObjectGraphType<AddAuthorRequest>
    {
        public AddAuthorRequestType()
        {
            Field(x => x.Name).Description("Author's full name");
            Field(x => x.BirthDate, type: typeof(NonNullGraphType<DateGraphType>)).Description("Author's birth date");
        }
    }
}
