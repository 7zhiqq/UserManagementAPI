using System.Diagnostics;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    public LoggingMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine($"Incoming Request: {context.Request.Method} {context.Request.Path}");
        var stopwatch = Stopwatch.StartNew();
        await _next(context);
        stopwatch.Stop();
        Console.WriteLine($"Response Status: {context.Response.StatusCode} (Processed in {stopwatch.ElapsedMilliseconds} ms)");
    }
}
