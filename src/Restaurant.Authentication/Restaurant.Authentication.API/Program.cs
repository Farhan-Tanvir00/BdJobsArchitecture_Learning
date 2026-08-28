using Microsoft.OpenApi;
using Restaurant.Authentication.Handler.Extensions;
using Restaurant.Authentication.Repository;
using Restaurant.Shared.Security;
using Restaurant.Shared.Swagger;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

//swagger
builder.Services.AddSwaggerExtension();

builder.Services.AddOpenApi();
builder.Services.AddRestaurantAuthenticationHandler(builder.Configuration);
builder.Services.AddSharedJwtAuthentication(builder.Configuration);

var app = builder.Build();

//Seeding Initial
//using var scope = app.Services.CreateScope();
//var seeder = scope.ServiceProvider.GetRequiredService<AdminUserAndInitialRolesSeed>();
//await seeder.SeedAsync();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
