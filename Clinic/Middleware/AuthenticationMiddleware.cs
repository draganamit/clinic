public class AuthenticationMiddleware
{
    private readonly RequestDelegate _next;

    public AuthenticationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.User.Identity.IsAuthenticated && context.Request.Path != "/Identity/Account/Login")
        {
            context.Response.Redirect("/Identity/Account/Login");
            return;
        }

        await _next(context);
    }
}
