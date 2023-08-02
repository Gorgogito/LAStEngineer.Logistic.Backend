using LAStEngineer.Logistic.Services.WebApi.Middleware;
using LAStEngineer.Logistic.Application.UseCases;
using LAStEngineer.Logistic.Infrastructure;
using LAStEngineer.Logistic.Services.WebApi.Modules.Versioning;
using LAStEngineer.Logistic.Services.WebApi.Modules.Authentication;
using LAStEngineer.Logistic.Services.WebApi.Modules.Swagger;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddVersioning();
builder.Services.AddSwagger();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddCors
  (options =>
  { options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); }
  );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
  app.UseSwagger();
  app.UseSwaggerUI(c =>
  {
    // build a swagger endpoint for each discovered API version

    foreach (var description in provider.ApiVersionDescriptions)
    {
      c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
    }
  });
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("CorsPolicy");
app.MapControllers();

app.Run();
