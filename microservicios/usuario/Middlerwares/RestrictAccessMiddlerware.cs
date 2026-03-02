using Microsoft.AspNetCore.Http;

namespace usuario.Middlerwares
{
    public class RestrictAccessMiddlerware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            var referer = context.Request.Headers["Referrer"].FirstOrDefault();
            if (string.IsNullOrEmpty(referer))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("sin acceso");
                return;
            } else
            {
                await next(context);
            }
                
        }
    }
}
