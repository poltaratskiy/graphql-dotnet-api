using GraphQL;
using GraphQL.Types;
using GraphQLvsRest.Abstractions;
using System.Threading.Tasks;

namespace GraphQLvsRest.GraphQL.Types.Book
{
    internal class BookMutation : ObjectGraphType
    {
        private readonly IBookStorage _bookStorage;

        public BookMutation(IBookStorage bookStorage)
        {
            _bookStorage = bookStorage;

            FieldAsync<BookType?, Abstractions.Types.Book?>(
                "addBook",
                "Add book to the storage",
                new QueryArguments
                {
                    new QueryArgument(typeof(NonNullGraphType<AddBookRequestType>))
                    {
                        Name = "request",
                        Description = "Request for adding book to storage"
                    }
                },
                resolve: AddBookResolver);
        }

        private Task<Abstractions.Types.Book?> AddBookResolver(IResolveFieldContext<object> context)
        {
            var request = context.GetArgument<Abstractions.Types.AddBookRequest>("request");
            return _bookStorage.AddBook(request);
        }
    }
}
