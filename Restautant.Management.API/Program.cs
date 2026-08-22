using Microsoft.OpenApi;
using Restaurant.Management.Handler.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

//swagger
builder.Services.AddSwaggerGen(options =>
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

builder.Services.AddRestaurantManagementHandler(builder.Configuration);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
