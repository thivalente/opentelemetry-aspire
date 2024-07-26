using OpenTelemetryAspireApi.Setup;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerConfig();

builder.AddLoggingConfig();

var app = builder.Build();

app.UseSwaggerConfigure();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
