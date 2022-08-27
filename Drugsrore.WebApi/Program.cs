using Drugsrore.WebApi.Middleware;
using Drugsrore.WebApi.Servises;
using Drugstore.Application;
using Drugstore.Application.Interfaces;
using Drugstore.Application.Mapping;
using Persistance;
using Serilog;
using Serilog.Events;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IDrugstoreDbContext).Assembly));
});

services.AddApplication();
services.AddPersistance(builder.Configuration);
services.AddControllers();

services.AddCors(options =>
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    }));

services.AddSwaggerGen(config =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    config.IncludeXmlComments(xmlPath);
});

services.AddSingleton<ICurrentUserService, CurrentUserService>();
services.AddHttpContextAccessor();

builder.Host.UseSerilog();
var app = builder.Build();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .WriteTo.File("DrugsWebAppLog-.txt", rollingInterval: 
        RollingInterval.Day)
    .CreateLogger();

using(var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    try
    {
        var context = 
            serviceProvider.GetRequiredService<DrugstoreDbContext>();
        DbInitializer.Initialize(context);
    }
    catch(Exception exception)
    {
        Log.Fatal(exception, "An error occurred while app initilization");
    }
}

app.UseSwagger();
app.UseSwaggerUI(config =>
{
    config.RoutePrefix = String.Empty;
    config.SwaggerEndpoint("swagger/v1/swagger.json", "DrugstoreWebApi");
});
app.UseCustomExceptionHandler();
app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseEndpoints(endpoints =>
    endpoints.MapControllers());

app.Run();
