using AutoMapper;
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
using Microsoft.OpenApi.Models;

namespace GraphQLvsRest.REST
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GraphQLvsRest.REST", Version = "v1" });
            });

            services.AddPooledDbContextFactory<BooksDbContext>((serviceProvider, options) =>
            {
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
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
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GraphQLvsRest.REST v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
