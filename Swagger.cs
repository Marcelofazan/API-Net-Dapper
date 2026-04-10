using NSwag.Generation.Processors.Security;
using NSwag;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace ApiMySql
{
    public static class Swagger
    {
        internal static void ConfigureSwaggerDoc(this IServiceCollection services)
        {
            services.AddOpenApiDocument(config =>
            {
                config.AddSecurity("apikey", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "x-api-key",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Forneça o token para acessar as funções operacionais da API."
                });

                config.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("bearer"));

                config.Version = "v1";

                //Habilita a geração de exemplos prara propriedades aninhadas 
                config.AllowReferencesWithProperties = true;
                config.Title = "Título da API";
                config.Description = "" +
                "**Descrição da API 1.**</br></br>" +
                "" +
                "**Descrição da API 2:**</br></br>" +
                "" +
                "`Descrição da API 3` - *Descrição da API.*</br></br>" +
                "`Descrição da API 4` - *Descrição da API.*</br></br>" +
                "" +
                "Token operacional: `TOKEN `";
            });
        }

        internal static void ConfigureSwaggerUI(this IApplicationBuilder app)
        {
            // Ativa o middleware para veicular o Swagger gerado como um terminal JSON. 
            app.UseOpenApi();

            // Esta opção possibilita a inclusão de css e js personalizados na UI do Swagger 
            app.UseStaticFiles();

            // Register the Swagger generator and the Swagger UI middlewares 
            app.UseSwaggerUi3(config => config.TransformToExternalPath = (internalUiRoute, request) =>
            {
                config.Path = "/swagger";
                config.CustomStylesheetPath = "/css/swagger/custom.css";
                config.CustomJavaScriptPath = "/scripts/swagger/custom.js";

                //Configuração para funcionar bem no IIS 
                if (internalUiRoute.StartsWith("/") == true && internalUiRoute.StartsWith(request.PathBase) == false)
                {
                    return request.PathBase + internalUiRoute;
                }
                else
                {
                    return internalUiRoute;
                }
            });

            // Habilita a interface gráfica do ReDoc 
            app.UseReDoc(options =>
            {
                options.CustomStylesheetPath = "/css/swagger/custom.css";
                options.Path = "/redoc";
                options.DocumentPath = "/swagger/v1/swagger.json";
            });
        }

    }
}
