using GraphQL.Types;
using GraphQL;
using GraphQLvsRest.Abstractions;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GraphQLvsRest.GraphQL.Types.Author
{
    internal class AuthorQuery : ObjectGraphType
    {
        private readonly IBookStorage _bookStorage;

        public AuthorQuery(IBookStorage bookStorage)
        {
            _bookStorage = bookStorage;

            FieldAsync<AuthorType, Abstractions.Types.Author?>(
                "findAuthor",
                "Find author by identifier",
                new QueryArguments {
                    new QueryArgument(typeof(NonNullGraphType<IntGraphType>))
                    {
                        Name = "id",
                        Description = "Author's identifier"
                    }
                },
                resolve: FindAuthorResolver);

            FieldAsync<NonNullGraphType<ListGraphType<AuthorType>>, IEnumerable<Abstractions.Types.Author>>(
                "findAuthors",
                "Find all authors by template of author's name",
                new QueryArguments
                {
                    new QueryArgument(typeof(NonNullGraphType<StringGraphType>))
                    {
                        Name = "Name",
                        Description = "Name template"
                    }
                },
                resolve: FindAuthorsResolver);
        }

        private Task<Abstractions.Types.Author?> FindAuthorResolver(IResolveFieldContext<object> context)
        {
            var id = context.GetArgument<int>("id");
            return _bookStorage.FindAuthor(id);
        }

        private Task<IEnumerable<Abstractions.Types.Author>> FindAuthorsResolver(IResolveFieldContext<object> context)
        {
            var nameTemplate = context.GetArgument<string>("name");
            return _bookStorage.FindAuthors(nameTemplate);
        }
    }
}
