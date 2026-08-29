using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi;


namespace Restaurant.Shared.Swagger
{
    public static class SwaggerExtensions
    {
        public static void AddSwaggerExtension(this IServiceCollection service)
        {
            service.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = "Enter your JWT token."
                });

                options.AddSecurityRequirement(document =>
                    new OpenApiSecurityRequirement
                    {
                        [new OpenApiSecuritySchemeReference("bearerAuth", document)] =
                            new List<string>()
                    });
            });

        }
    }
}
