using GraphQL.Types;

namespace GraphQLvsRest.IQueryable.Types.GraphQl
{
    internal class AuthorType : ObjectGraphType<Data.Dto.Author>
    {
        public AuthorType()
        {
            Field(x => x.Id).Description("Author's identifier");
            Field(x => x.Name).Description("Author's full name");
            Field(x => x.BirthDate, type: typeof(NonNullGraphType<DateGraphType>)).Description("Author's birth date");
            Field(x => x.Books, type: typeof(ListGraphType<BooleanGraphType>)).Description("Author's books");
        }
    }
}
