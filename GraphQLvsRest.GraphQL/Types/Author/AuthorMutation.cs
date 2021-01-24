using GraphQL;
using GraphQL.Types;
using GraphQLvsRest.Abstractions;
using System.Threading.Tasks;

namespace GraphQLvsRest.GraphQL.Types.Author
{
    internal class AuthorMutation : ObjectGraphType
    {
        private readonly IBookStorage _bookStorage;

        public AuthorMutation(IBookStorage bookStorage)
        {
            _bookStorage = bookStorage;

            FieldAsync<AuthorType?, Abstractions.Types.Author?>(
                "addAuthor",
                "Add author to storage",
                new QueryArguments
                {
                    new QueryArgument(typeof(AddAuthorRequestType))
                    {
                        Name = "request",
                        Description = "Add author request",
                    },
                },
                resolve: AddAuthorResolver);
        }

        private Task<Abstractions.Types.Author?> AddAuthorResolver(IResolveFieldContext<object> context)
        {
            var request = context.GetArgument<Abstractions.Types.AddAuthorRequest>("request");
            return _bookStorage.AddAuthor(request);
        }
    }
}
