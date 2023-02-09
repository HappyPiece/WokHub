namespace WokHub.Middlewares
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext.Request.Headers.ContainsKey("Authorization"))
            {
                httpContext.Request.Headers.TryGetValue("Authorization", out var token);
                Console.WriteLine($"Token is {token}");
            }
            await _next.Invoke(httpContext);
        }  
    }
}
