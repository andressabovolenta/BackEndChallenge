using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace BackEndChallenge.Configuration
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection ConfigurarSwagger(this IServiceCollection services)
        {

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Andressa Bovolenta - Itaú BackEnd Challenge",
                    Description = "BackEndChallenge",
                    Contact = new OpenApiContact()
                    {
                        Name = "Andressa",
                        Email = "andressa.bbovolenta@gmail.com"
                    }
                });
            });

            return services;
        }


        public static IApplicationBuilder UtilizarConfiguracaoSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/v1/swagger.json", "BackEndChallange");
                c.DocumentTitle = "BackEndChallenge";
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            });
            return app;
        }
    }
}
