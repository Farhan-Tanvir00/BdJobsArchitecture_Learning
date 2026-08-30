using Restaurant.Receipt.Handler.Extensions;
using Restaurant.Shared.Swagger;
using Restautant.Shared.Middlewares;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

//swagger
builder.Services.AddSwaggerExtension();
builder.Services.AddOpenApi();


builder.Services.AddTransient<ErrorHandlingMiddleware>();

builder.Services.AddRestaurrantReceiptHandler(builder.Configuration);
var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
