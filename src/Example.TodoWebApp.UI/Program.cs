using Example.TodoWebApp.Bussiness.DependencyResolvers.Microsoft;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddBussinessModule();

var app = builder.Build();

app.UseStaticFiles();

app.UseStatusCodePagesWithReExecute("/notfound", "?statusCode={0}");

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
    RequestPath = "/node_modules"
});

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
