var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Global Exception Middleware
app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    catch (Exception ex)
    {
        context.Response.StatusCode = 500;
        await context.Response.WriteAsJsonAsync(new
        {
            message = "Something went wrong.",
            error = ex.Message
        });
    }
});

// Test API
app.MapGet("/error", () =>
{
    throw new Exception("Database connection failed");
});

app.Run();