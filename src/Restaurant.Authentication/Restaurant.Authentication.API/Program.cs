using Restaurant.Authentication.Handler.Extensions;
using Restaurant.Authentication.Repository;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddOpenApi();
builder.Services.AddRestaurantAuthenticationHandler(builder.Configuration);

var app = builder.Build();

//Seeding Initial
using var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<AdminUserAndInitialRolesSeed>();
await seeder.SeedAsync();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
