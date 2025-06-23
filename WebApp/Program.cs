using Microsoft.AspNetCore.Routing.Matching;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    await next(context);
});

app.UseRouting();

app.Use(async (context, next) =>
{
    await next(context);
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/employees", async (HttpContext context) =>
    {
        await context.Response.WriteAsync("Get employees");
    });

    endpoints.MapPost("/employees", async (HttpContext context) =>
    {
        await context.Response.WriteAsync("Create an employee");
    });

    endpoints.MapPut("/employees", async (HttpContext context) =>
    {
        await context.Response.WriteAsync("Update an employee");
    });

    endpoints.MapDelete("/employees/{position}/{id}", async (HttpContext context) =>
    {
        await context.Response.WriteAsync($"Delete the employee: {context.Request.RouteValues["id"]}");
    });

    endpoints.MapGet("/{category=shirts}/{size=medium}/{id?}", async (HttpContext context) =>
    {
        await context.Response.WriteAsync($"Get category: {context.Request.RouteValues["category"]} in size: {context.Request.RouteValues["size"]} with the id: {context.Request.RouteValues["id"]}");
    });
});


app.Run();