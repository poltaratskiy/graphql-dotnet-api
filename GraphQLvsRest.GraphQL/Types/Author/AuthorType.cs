using GraphQL.Types;

namespace GraphQLvsRest.GraphQL.Types.Author
{
    internal class AuthorType : ObjectGraphType<Abstractions.Types.Author>
    {
        public AuthorType()
        {
            Field(x => x.Id).Description("Author's identifier");
            Field(x => x.Name).Description("Author's full name");
            Field(x => x.BirthDate, type: typeof(NonNullGraphType<DateGraphType>)).Description("Author's birth date");
        }
    }
}
