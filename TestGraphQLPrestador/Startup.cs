using GraphQL.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TestGraphQLPrestador.Models;
using TestGraphQLPrestador.Repositories;

namespace TestGraphQLPrestador
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton<IPrestadorRepository, PrestadorRepository>();
            services.AddSingleton<ITelefoneRepository, TelefoneRepository>();
            services.AddSingleton<PrestadorSchema>()
                   .AddGraphQL((options, provider) =>
                   {
                       options.EnableMetrics = true;
                       var logger = provider.GetRequiredService<ILogger<Startup>>();
                       options.UnhandledExceptionDelegate = ctx => logger.LogError("{Error} occurred", ctx.OriginalException.Message);
                   })
                   .AddSystemTextJson()
                   .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true)
                   .AddDataLoader()
                   .AddGraphTypes(typeof(PrestadorSchema));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseGraphQL<PrestadorSchema>();
            app.UseGraphQLGraphiQL();
            app.UseGraphQLPlayground();
        }
    }
}
