using GraphQL.Types;
using GraphQLvsRest.Data;
using GraphQLvsRest.Data.Dto;
using GraphQLvsRest.IQueryable.Extentions;
using GraphQLvsRest.IQueryable.Types.GraphQl;
using Microsoft.EntityFrameworkCore;

namespace GraphQLvsRest.IQueryable.GraphQl
{
    public class Query : ObjectGraphType
    {
        private readonly IDbContextFactory<BooksDbContext> _contextFactory;

        public Query(IDbContextFactory<BooksDbContext> contextFactory)
        {
            _contextFactory = contextFactory;

            this.CustomField<ListGraphType<AuthorType>, Author>("authorsQuery", context => _contextFactory.CreateDbContext().Authors.AsQueryable());
        }
    }
}
