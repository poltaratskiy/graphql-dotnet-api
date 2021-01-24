using GraphQL.Server;
using GraphQL.Types;
using GraphQLvsRest.Data;
using GraphQLvsRest.IQueryable.GraphQl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GraphQLvsRest.IQueryable
{
    public class Startup
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IConfiguration _configuration;

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            _environment = environment;
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            #region logging
            services.AddLogging(cfg =>
                cfg.AddConsole()
                .AddFilter((category, level) =>
                {
                    if (category.Contains("Microsoft.AspNetCore") || category.Contains("Microsoft.Hosting"))
                    {
                        if (level >= LogLevel.Warning)
                            return true;
                        else
                            return false;
                    }

                    if (category.Contains("Microsoft.EntityFrameworkCore") && level < LogLevel.Information)
                        return false;

                    return true;
                }));
            #endregion logging

            #region database
            services.AddPooledDbContextFactory<BooksDbContext>((serviceProvider, options) =>
            {
                options.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
                //options.UseInMemoryDatabase("BooksDatabase");
                options.UseLoggerFactory(serviceProvider.GetRequiredService<ILoggerFactory>());
                options.UseLazyLoadingProxies();
            });
            #endregion database

            services
                .AddSingleton<Schema, GraphQlSchema>()
                .AddGraphQL((options, provider) =>
                {
                    options.EnableMetrics = _environment.IsDevelopment();
                    var logger = provider.GetRequiredService<ILogger<Startup>>();
                    options.UnhandledExceptionDelegate = ctx => logger.LogError("{Error} occurred", ctx.OriginalException.Message);
                })
                .AddSystemTextJson()
                .AddDataLoader()
                .AddGraphTypes(typeof(GraphQlSchema).Assembly, ServiceLifetime.Singleton);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseGraphQL<global::GraphQL.Types.Schema>(); // /graphql
            app.UseGraphQLPlayground();
            app.UseGraphQLVoyager();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        }
    }
}
