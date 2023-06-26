namespace SurveyApp.Mvc;

public class RedirectMiddleware
{
    private readonly RequestDelegate _next;

    public RedirectMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if(context.Request.Path == "/login")
        {
            // If user is authenticated, redirect to home
            if (context.User.Identity.IsAuthenticated)
            {
                context.Response.Redirect("/Home/Index");
            }
        }
        await _next.Invoke(context);
    }
}