using GraphQL.Types;

namespace GraphQLvsRest.IQueryable.Types.GraphQl
{
    internal class BookType : ObjectGraphType<Data.Dto.Book>
    {
        public BookType()
        {
            Field(x => x.Id).Description("Identifier of the book");
            Field(x => x.Name).Description("Name of the book");
            Field(x => x.Year, type: typeof(IntGraphType)).Description("Year when book was written");
            Field(x => x.Author, type: typeof(AuthorType)).Description("Author");
        }
    }
}
