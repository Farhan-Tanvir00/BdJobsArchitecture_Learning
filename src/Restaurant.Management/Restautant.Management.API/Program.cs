using Restaurant.Management.Handler.Extensions;
using Restaurant.Shared.Security;
using Restautant.Management.API.Middlewares;
using Restaurant.Shared.Swagger;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

//swagger
builder.Services.AddSwaggerExtension();

builder.Services.AddRestaurantManagementHandler(builder.Configuration);
builder.Services.AddSharedJwtAuthentication(builder.Configuration);
builder.Services.AddTransient<ErrorHandlingMiddleware>();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

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
