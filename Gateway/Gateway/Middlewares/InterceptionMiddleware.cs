namespace Gateway.Middlewares
{
    public class InterceptionMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            // ✅ Headers personalizados que Ocelot preservará
            context.Request.Headers["X-API-Gateway"] = "true";
            context.Request.Headers["X-Gateway-Source"] = "api-gateway";
            context.Request.Headers["X-Gateway-RequestId"] = Guid.NewGuid().ToString();
            context.Request.Headers["X-Gateway-Timestamp"] = DateTime.UtcNow.ToString("O");

            Console.WriteLine("🔧 Gateway: Headers de seguridad agregados");

            await next(context);
        }
    }
}
