using AutoMapper;
using GraphQL.Server;
using GraphQL.Types;
using GraphQLvsRest.Abstractions;
using GraphQLvsRest.Data;
using GraphQLvsRest.Impl;
using GraphQLvsRest.Impl.Mapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GraphQLvsRest.GraphQL
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

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddDbContextCheck<BooksDbContext>();

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

            services.AddPooledDbContextFactory<BooksDbContext>((serviceProvider, options) =>
            {
                options.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
                //options.UseInMemoryDatabase("BooksDatabase");
                options.UseLoggerFactory(serviceProvider.GetRequiredService<ILoggerFactory>());
                options.UseLazyLoadingProxies();
            });

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(MapperProfile)));
            mapperConfiguration.AssertConfigurationIsValid();
            services.AddSingleton<IMapper>(mapperConfiguration.CreateMapper());

            services.AddSingleton<IBookStorage, BookStorage>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphQL<global::GraphQL.Types.Schema>(); // /graphql
            app.UseGraphQLPlayground();
            app.UseGraphQLVoyager();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health");

                /*endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });*/
            });
        }
    }
}
