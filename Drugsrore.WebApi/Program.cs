using Drugsrore.WebApi.Middleware;
using Drugstore.Application;
using Drugstore.Application.Interfaces;
using Drugstore.Application.Mapping;
using Persistance;
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

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    try
    {
        var context = 
            serviceProvider.GetRequiredService<DrugstoreDbContext>();
        DbInitializer.Initialize(context);
    }
    catch
    {
        throw;
    }
}

app.UseCustomExceptionHandler();
app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseEndpoints(endpoints =>
    endpoints.MapControllers());

app.Run();
