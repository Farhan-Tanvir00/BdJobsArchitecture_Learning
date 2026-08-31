using Restaurant.Orchestrator.Handler.Extensions;
using Restaurant.ServiceBus;
using Restaurant.Shared.Security;
using Restaurant.Shared.Swagger;
using Restautant.Shared.Middlewares;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

//swagger
builder.Services.AddSwaggerExtension();
builder.Services.AddOpenApi();

builder.Services.AddSharedJwtAuthentication(builder.Configuration);
builder.Services.AddTransient<ErrorHandlingMiddleware>();


//Service Bus
builder.Services.AddServiceBus();
builder.Services.AddOrchestratorHandler();

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
