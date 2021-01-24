using GraphQL;
using GraphQL.Types;
using GraphQLvsRest.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLvsRest.GraphQL.Types.Book
{
    internal class BookQuery : ObjectGraphType
    {
        private readonly IBookStorage _bookStorage;

        public BookQuery(IBookStorage bookStorage)
        {
            _bookStorage = bookStorage;

            FieldAsync<BookType, Abstractions.Types.Book?>(
                "findBook",
                "Find book by identifier",
                new QueryArguments {
                    new QueryArgument(typeof(NonNullGraphType<IntGraphType>))
                    {
                        Name = "id",
                        Description = "Identifier of the book"
                    }
                },
                FindBookResolver);

            FieldAsync<NonNullGraphType<ListGraphType<BookType>>, IEnumerable<Abstractions.Types.Book>>(
                "findBooks",
                "Find books by filter",
                new QueryArguments {
                    new QueryArgument(typeof(NonNullGraphType<GetBooksFilterType>))
                    {
                        Name = "filter",
                        Description = "Filter"
                    }
                },
                FindBooksResolver);
        }

        private Task<Abstractions.Types.Book?> FindBookResolver(IResolveFieldContext<object> context)
        {
            var id = context.GetArgument<int>("id");
            return _bookStorage.FindBook(id);
        }

        private Task<IEnumerable<Abstractions.Types.Book>> FindBooksResolver(IResolveFieldContext<object> context)
        {
            var filter = context.GetArgument<Abstractions.Types.GetBooksFilter>("filter");
            return _bookStorage.FindBooks(filter);
        }
    }
}
